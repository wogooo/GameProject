﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Util;
using Random = System.Random;

/// <summary>
/// 战斗数据同步器
/// </summary>
public class FightDataSyncer : ILoopItem
{
    /// <summary>
    /// 单例
    /// </summary>
    public static FightDataSyncer Single
    {
        get
        {
            if (single == null)
            {
                single = new FightDataSyncer();
                // 启动循环
                if (single.looperId < 0)
                {
                    single.Start();
                }
            }
            return single;
        }
    }

    /// <summary>
    /// 单例对象
    /// </summary>
    private static FightDataSyncer single = null;

    /// <summary>
    /// 是否已启动
    /// </summary>
    public bool IsStart {
        get { return isStart; } 
    }

    /// <summary>
    /// 服务器IP
    /// </summary>
    public const string ServerIpAddress = "127.0.0.1";

    /// <summary>
    /// 服务器端口
    /// </summary>
    public const int ServerPort = 6000;

    /// <summary>
    /// 操作超时
    /// </summary>
    public const int OperationTimeOut = 3000;

    ///// <summary>
    ///// 数据列表
    ///// </summary>
    //private List<FightSyncData> dataStack = new List<FightSyncData>();

    /// <summary>
    /// 待发送列表
    /// </summary>
    private List<byte[]> beSendList = new List<byte[]>();

    /// <summary>
    /// 操作数据缓存-发送
    /// </summary>
    private Dictionary<int, MsgOptional> opMsgBufferSend = new Dictionary<int, MsgOptional>();

    /// <summary>
    /// 操作完成回调
    /// </summary>
    private Dictionary<int, Action> opSendCallbackDic = new Dictionary<int, Action>(); 

    /// <summary>
    /// 操作数据缓存-接收
    /// 区分两个列表防止ID冲突
    /// </summary>
    private Dictionary<int, MsgOptional> opMsgBufferReceive = new Dictionary<int, MsgOptional>();

    /// <summary>
    /// 循环器ID
    /// </summary>
    private long looperId = -1;

    /// <summary>
    /// 是否已启动
    /// </summary>
    private bool isStart = false;

    /// <summary>
    /// 用户Id
    /// </summary>
    private int userId = -1;

    /// <summary>
    /// 敌方类型
    /// </summary>
    private Dictionary<int, int> enemyTypeList = new Dictionary<int, int>()
    {
        {(int) ObjectID.ObjectType.MyJiDi, (int) ObjectID.ObjectType.EnemyJiDi},
        {(int) ObjectID.ObjectType.MyObstacle, (int) ObjectID.ObjectType.EnemyObstacle},
        {(int) ObjectID.ObjectType.MySoldier, (int) ObjectID.ObjectType.EnemySoldier},
        {(int) ObjectID.ObjectType.MyTank, (int) ObjectID.ObjectType.EnemyTank},
        {(int) ObjectID.ObjectType.MyTower, (int) ObjectID.ObjectType.EnemyTower},
    };



    /// <summary>
    /// 启动
    /// </summary>
    public void Start()
    {
        if (looperId > 0)
        {
            LooperManager.Single.Remove(looperId);
        }
        looperId = LooperManager.Single.Add(this);
        // 初始化userId
        userId = new Random(DateTime.Now.Millisecond).Next(int.MaxValue);
        // 初始化
        single.Init();
        isStart = true;
    }

    /// <summary>
    /// 停止监听与发送战斗同步数据
    /// </summary>
    public void Stop()
    {
        LooperManager.Single.Remove(looperId);
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        // 未启动不初始化
        if (isStart)
        {
            return;
        }

        try
        {
            // 链接服务器
            SocketManager.Single.Connect(ServerIpAddress, ServerPort);
            // 添加处理服务器消息事件
            SocketManager.Single.AddDataAction((data) =>
            {
                Debug.Log("数据" + data.Length);
                // 解析数据头
                var msgHead = SocketManager.DeSerialize<MsgHead>(data);
                var headData = (byte[]) msgHead.body.Clone();
                // 解析数据内容
                switch (msgHead.msgId)
                {
                    case (int) MsgId.MsgOptional:
                        // 操作消息
                        while (ByteUtils.CouldRead(headData))
                        {
                            var opData = ByteUtils.ReadMsg(ref headData);
                            // 操作数据
                            var msgOp = SocketManager.DeSerialize<MsgOptional>(opData);
                            Debug.Log("收到操作数据" + " opType:" + msgOp.OpType + "opPosX:" + msgOp.OpPosX + "opPosY:" +
                                      msgOp.OpPosY + ", opPosZ:" + msgOp.OpPosZ + ", opParams:" + msgOp.OpParams);
                            // TODO 操作转化到本地行为
                            switch (msgOp.OpType)
                            {
                                case 1:
                                    // 唯一Id
                                    var opUniqueId = msgOp.OpUniqueNum;
                                    // 保存数据, 等待确认数据
                                    PushBeComfirmData(msgOp);

                                    // 设置超时
                                    var killTimer = new Timer(OperationTimeOut).OnCompleteCallback(() =>
                                    {
                                        // 超时失败删除操作
                                        opMsgBufferSend.Remove(opUniqueId);
                                        // 发送取消请求
                                        Debug.LogError("操作超时,操作内容:" + opUniqueId + ", ");
                                    }).Start();

                                    // 操作结束停止计时
                                    opSendCallbackDic.Add(opUniqueId, () =>
                                    {
                                        killTimer.Kill();
                                    });


                                    // TODO 如果是基地则不创建
                                    var kvDic = GetParams(msgOp.OpParams);
                                    var sourceUserId = Convert.ToInt32(kvDic["UserId"]);
                                    // 创建确认发送消息
                                    var cOpMsg = MsgFactory.GetMsgComfirmOperation(opUniqueId, sourceUserId, "");
                                    var unitType = Convert.ToInt32(kvDic["UnitType"]);
                                    if (unitType != 1 && unitType != 2)
                                    {
                                        // 缓存发送确认操作
                                        PushtBeSendData(cOpMsg, (int) MsgId.MsgComfirmOperation);
                                    }
                                    break;
                            }
                        }
                        break;
                    case (int) MsgId.MsgComfirmOperation:
                        // 操作确认消息
                        while (ByteUtils.CouldRead(headData))
                        {
                            var cOpData = ByteUtils.ReadMsg(ref headData);
                            // 操作确认数据
                            var msgCmOp = SocketManager.DeSerialize<MsgComfirmOperation>(cOpData);
                            // 激活本地下兵
                            // 获得本地缓存操作
                            ComfirmOp(msgCmOp);
                        }
                        break;

                    case (int) MsgId.MsgRandomSeedResponse:
                    {
                        // 随机种子消息
                        while (ByteUtils.CouldRead(headData))
                        {
                            var msgRandomSeedData = ByteUtils.ReadMsg(ref headData);
                            // 数据反序列化
                            var msgRandomSeed = SocketManager.DeSerialize<MsgRandomSeedRequest>(msgRandomSeedData);
                            // 设置随机种子
                            RandomPacker.Single.SetSeed(msgRandomSeed.RandomSeed);
                            // 输出log
                            Debug.Log("收到随机种子消息:" + msgRandomSeed.RandomSeed);
                        }
                        break;
                    }
                    // 战斗请求回复消息
                    case (int) MsgId.MsgAskBattleResponse:
                    {
                        // 读取消息
                        var msgAskBattleResponseData = (ByteUtils.CouldRead(headData))
                            ? ByteUtils.ReadMsg(ref headData)
                            : null;
                        if (msgAskBattleResponseData == null)
                        {
                            break;
                        }
                        // 反序列化战斗请求回复消息
                        var msgAskBattleResponse = SocketManager.DeSerialize<MsgAskBattleResponse>(msgAskBattleResponseData);
                        // 读取数据准备战斗
                        // 匹配成功
                        // TODO 匹配成功事件
                        // 创建两方基地
                        // 按照等级与种族
                        // TODO
                        Debug.Log("匹配成功.");
                        break;
                    }
                    case (int) MsgId.MsgString:
                        // 字符串消息
                        while (ByteUtils.CouldRead(headData))
                        {
                            var subData = ByteUtils.ReadMsg(ref headData);
                            // 字符串
                            Debug.Log("收到字符数据:" + Encoding.UTF8.GetString(subData));
                        }
                        break;
                }
            });
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }


    /// <summary>
    /// 添加数据
    /// 状态, FSM数据, 单位属性, 单位位置, 单位方向, 目标点列表(路径), 目标(技能/攻击目标)
    /// 障碍物
    /// 每个单位的当前数据(列表)(每个单位的,当前位置, 当前目标, 当前方向, 动作?)
    /// 攻击行为(带目标, 起点终点, 如果有)
    /// 技能行为(带目标, 起点终点, 如果有)
    /// 状态切换
    /// 状态机FSM数据
    /// </summary>
    public void AddData(DisplayOwner displayOwner)
    {
        if (userId < 0)
        {
            Start();
        }
        // DisplayOwner转化为ObjectID
        // 封装, 放入列表
        var objPos = displayOwner.GameObj;
        // 添加同步数据
        var msgOp = MsgFactory.GetMsgOptional(1, objPos.transform.position.x, objPos.transform.position.y,
            objPos.transform.position.z,
                "UserId:" + userId +
                ",ObjectId:" + displayOwner.ClusterData.AllData.MemberData.ObjID.ID +
                ",UniqueId:" + displayOwner.ClusterData.AllData.MemberData.UniqueID +
                ",UnitType:" + (int)displayOwner.ClusterData.AllData.MemberData.ObjID.ObjType +
                //",CmName:" + objPos.name.Substring(0, objPos.name.IndexOf("(", StringComparison.Ordinal)) +
                ",Level:" + displayOwner.ClusterData.AllData.MemberData.ArmyLevel +
                (displayOwner.MFAModelRender == null ? "" :
                ",MeshPackName:" + displayOwner.MFAModelRender.MeshPackName +
                ",TexturePackName:" + displayOwner.MFAModelRender.TexturePackName));

        // 本地缓存
        PushBeComfirmData(msgOp, true);

        // 超时回收被创建单位
        var killTimer = new Timer(OperationTimeOut / 1000).OnCompleteCallback(() =>
        {
            // 超时回收单位
            DisplayerManager.Single.DelDisplay(displayOwner);
        }).Start();

        // 操作结束停止计时
        opSendCallbackDic.Add(msgOp.OpUniqueNum, () =>
        {
            killTimer.Kill();
        });

        // 数据放入缓冲
        PushtBeSendData(msgOp, (int)MsgId.MsgOptional);
    }

    /// <summary>
    /// 循环执行
    /// </summary>
    public void Do()
    {
        if (beSendList.Count == 0)
        {
            return;
        }
        // 整合数据
        var combineBytes = new byte[0];
        foreach (var sendItem in beSendList)
        {
            combineBytes = ByteUtils.ConnectByte(combineBytes, sendItem, 0, sendItem.Length);
        }
        // 发送数据
        SocketManager.Single.Send(combineBytes);
        // 清空列表
        beSendList.Clear();

        // ------------------其他功能--------------------
        // 如果收到服务器的数据
        // 则用该帧作为编号发到服务器
        // 卡顿时所有单位停止移动
        // 收到数据同步
    }

    /// <summary>
    /// 是否结束运行
    /// </summary>
    /// <returns></returns>
    public bool IsEnd()
    {
        // TODO 判断是否战斗结束
        return false;
    }

    /// <summary>
    /// 销毁时操作
    /// </summary>
    public void OnDestroy()
    {
        // TODO 销毁数据
        beSendList.Clear();
        looperId = -1;
        SocketManager.Single.ClearAllAction();
        isStart = false;
        userId = -1;
    }

    /// <summary>
    /// 待发送数据放入缓冲
    /// </summary>
    /// <param name="t">被序列化对象</param>
    /// <param name="msgId">msg类型Id</param>
    private void PushtBeSendData<T>(T t, int msgId)
    {
        // 数据放入缓冲
        beSendList.Add(PackageData(SocketManager.Serialize(t), userId, msgId));
    }

    /// <summary>
    /// 缓存待确认数据
    /// </summary>
    /// <param name="opMsg"></param>
    /// <param name="isLocal">是否为发送等待, 否则为接收等待</param>
    private void PushBeComfirmData(MsgOptional opMsg, bool isLocal = false)
    {
        // 保存数据, 等待确认数据
        var opUniqueId = opMsg.OpUniqueNum;
        if (isLocal)
        {
            opMsgBufferSend.Add(opUniqueId, opMsg);
        }
        else
        {
            opMsgBufferReceive.Add(opUniqueId, opMsg);
        }
    }


    /// <summary>
    /// 打包数据
    /// </summary>
    /// <param name="packageData">被包装数据</param>
    /// <param name="uId">用户Id</param>
    /// <param name="msgId">数据Id</param>
    /// <returns></returns>
    private byte[] PackageData(byte[] packageData, int uId, int msgId)
    {
        byte[] result = null;

        packageData = ByteUtils.AddDataHead(packageData);
        // 将数据打包放入MsgHead的body中
        var dataHead = MsgFactory.GetMsgHead(uId, msgId, packageData);
        result = SocketManager.Serialize(dataHead);

        return result;
    }

    /// <summary>
    /// 解析字符
    /// </summary>
    /// <param name="paramsStr"></param>
    /// <returns></returns>
    private Dictionary<string, string> GetParams(string paramsStr)
    {
        Dictionary<string, string> result = null;

        if (!String.IsNullOrEmpty(paramsStr))
        {
            result = new Dictionary<string, string>();
            var partArray = paramsStr.Split(',');
            foreach (var part in partArray)
            {
                var tmpPart = part.Trim();
                // 解析Key/Val
                var kv = tmpPart.Split(':');
                var key = kv[0].Trim();
                var value = kv[1].Trim();
                result.Add(key, value);
            }
        }

        return result;
    }

    /// <summary>
    /// 将缓存的操作进行确认
    /// </summary>
    /// <param name="msgCmOp">确认消息</param>
    private void ComfirmOp(MsgComfirmOperation msgCmOp)
    {
        if (msgCmOp.OpSourceUserId == userId)
        {
            if (opMsgBufferSend.ContainsKey(msgCmOp.OpUniqueNum))
            {
                var bufferMsgOp = opMsgBufferSend[msgCmOp.OpUniqueNum];
                ComfirmOptional(bufferMsgOp, true);
                // 删除
                opMsgBufferSend.Remove(msgCmOp.OpUniqueNum);

            }
            else
            {
                Debug.LogError("接收操作列表-不存在操作:" + msgCmOp.OpUniqueNum);
            }
        }
        else
        {
            if (opMsgBufferReceive.ContainsKey(msgCmOp.OpUniqueNum))
            {
                var bufferMsgOp = opMsgBufferReceive[msgCmOp.OpUniqueNum];
                ComfirmOptional(bufferMsgOp);
                // 删除
                opMsgBufferReceive.Remove(msgCmOp.OpUniqueNum);
            }
            else
            {
                Debug.LogError("发送操作列表-不存在操作:" + msgCmOp.OpUniqueNum);
            }
        }
    }

    /// <summary>
    /// 确认操作
    /// </summary>
    /// <param name="msgOp">被确认操作消息</param>
    /// <param name="isLocal">是否本地创建</param>
    private void ComfirmOptional(MsgOptional msgOp, bool isLocal = false)
    {
        // 下兵操作
        // 解析Params
        // TODO 模型动画相关参数不全
        var kvDic = GetParams(msgOp.OpParams);
        var objectId = Convert.ToInt32(kvDic["ObjectId"]);
        var unitType = Convert.ToInt32(kvDic["UnitType"]);
        var uniqueId = Convert.ToInt32(kvDic["UniqueId"]);
        //var cmName = kvDic["CmName"];
        var level = Convert.ToInt32(kvDic["Level"]);
        string meshPackname = null;
        string texturePackname = null;
        if (kvDic.ContainsKey("MeshPackName"))
        {
            meshPackname = kvDic["MeshPackName"];
        }
        if (kvDic.ContainsKey("TexturePackName"))
        {
            texturePackname = kvDic["TexturePackName"];
        }
        // 如果本地缓存了DisplayOwner不创建
        DisplayOwner memberDisplay = null;
        if (isLocal)
        {
            // 获取本地DisplayOwner
            memberDisplay = DisplayerManager.Single.GetElementById((ObjectID.ObjectType)unitType, objectId);
            // 设置起始位置
            memberDisplay.GameObj.transform.position = new Vector3(msgOp.OpPosX, msgOp.OpPosY, msgOp.OpPosZ);
        }
        else
        {
            // 映射类型
            if (enemyTypeList.ContainsKey(unitType))
            {
                unitType = enemyTypeList[unitType];
            }
            // 映射位置
            // 地图绝对宽度
            //var mapAbsoluteWidth = LoadMap.Single.MapWidth*LoadMap.Single.UnitWidth;
            //var setPosX = mapAbsoluteWidth - msgOp.OpPosX;
            var mapingPos = LoadMap.Single.MapItemToEnemy(new Vector3(msgOp.OpPosX, msgOp.OpPosY, msgOp.OpPosZ));
            // 创建单位
            memberDisplay = FightUnitFactory.CreateUnit(unitType, new CreateActorParam(mapingPos.x, mapingPos.z, level)
            {
                ColorMat = true,
                CardID = 0,
                MeshPackName = meshPackname,
                TexturePackName = texturePackname,
                SoldierID = uniqueId,
            });
        }
        // 本地操作结束callback
        opSendCallbackDic[msgOp.OpUniqueNum]();
        // 激活单位
        memberDisplay.GameObj.SetActive(true);
        // 开始移动
        memberDisplay.RanderControl.Begin();
    }
}

///// <summary>
///// 战斗同步数据
///// </summary>
//public class FightSyncData
//{
//    /// 状态, FSM数据, 单位属性, 单位位置, 单位方向, 目标点列表(路径), 目标(技能/攻击目标)
//    public SoldierFSMSystem FsmData { get; set; }


//    public AllData AllData { get; set; }


//    public ClusterData ClusterData { get; set; }

//    // DisplayOwner转化为Id

//    // 两边ID一致问题


//}