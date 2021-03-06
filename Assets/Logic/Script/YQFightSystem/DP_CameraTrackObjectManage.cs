﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

/// <summary>
/// 相机追随物管理
/// </summary>
public class DP_CameraTrackObjectManage : MonoEX.Singleton<DP_CameraTrackObjectManage>
{

    public DP_CameraTrackObjectManage()
    {
        DP_FightEvent.OnActorMove += OnActorMove;
        YQ2CameraCtrl.Single.OnUserYRot += OnInterruptLookAround;
        YQ2CameraCtrl.Single.OnInterruptObjMode += OnInterruptLookAround;
    }

    public void CancelTrackActor(int actorID)
    {
        if (m_CurrTrackActorID == actorID) { 
            m_CurrTrackActorID = -1;
            YQ2CameraCtrl.Single.InterruptObjMode();
        }
        if (m_CurrTrackHeroActorID == actorID) m_CurrTrackHeroActorID = -1; 
    }
     
    /// <summary>
    /// 播放镜头环视
    /// </summary>
    /// <param name="complateRecall">执行结束回调函数</param>
    public void LookAround( Action complateRecall )
    {
        MonoEX.CoroutineManage.Single.StartCoroutine(coLookAround(complateRecall));
    }

    //打断环视
    public void OnInterruptLookAround()
    {
        m_InterruptLookAround = true;
    }

    /// <summary>
    /// 旋转相机携程
    /// 从配置中读取旋转参数
    /// </summary>
    /// <param name="complateRecall"></param>
    /// <returns></returns>
    IEnumerator coLookAround( Action complateRecall )
    {
        //计算演示动画数值区间
        var yrot_str = UserDatas.GetUserData("CameraYRot");
        var scale_str = UserDatas.GetUserData("CameraScale");
        float user_yrot;
        float user_scale;

        if(!float.TryParse(yrot_str,out user_yrot))
            user_yrot = SData_mapdata.Single.GetDataOfID(1).CameraY_Xuanzhuan_End;

        if (!float.TryParse(scale_str, out user_scale))
            user_scale = SData_mapdata.Single.GetDataOfID(1).FreeCamera_Scale_End;

        float scale_start;
        float scale_end = user_scale;
        if (user_scale < SData_mapdata.Single.GetDataOfID(1).FreeCamera_Scale_StopRange_Min)
            scale_start = SData_mapdata.Single.GetDataOfID(1).FreeCamera_Scale_End;
        else if (user_scale > SData_mapdata.Single.GetDataOfID(1).FreeCamera_Scale_StopRange_Max)
            scale_start = SData_mapdata.Single.GetDataOfID(1).FreeCamera_Scale; 
        else 
            scale_start = user_scale;

        float yrot_start;
        float yrot_end = user_yrot;
        if (user_yrot < SData_mapdata.Single.GetDataOfID(1).CameraY_Xuanzhuan_StopRange_Min)
            yrot_start = SData_mapdata.Single.GetDataOfID(1).CameraY_Xuanzhuan_End;
        else if (user_yrot > SData_mapdata.Single.GetDataOfID(1).CameraY_Xuanzhuan_StopRange_Max)
            yrot_start = SData_mapdata.Single.GetDataOfID(1).CameraY_Xuanzhuan_Start;
        else
            yrot_start = user_yrot;


        YQ2CameraCtrl.Single.EnabledAll = false;//禁用相机控制

        float count = 0;
        do
        {
            if (m_InterruptLookAround) break;//已经被打断了

            count += Time.deltaTime;

            //计算插值系数
            var t = Mathf.Clamp(count / SData_FightKeyValue.Single.ZhanqianCameraStop, 0, 1);

            //插值
            var currScale = DP_TweenFuncs.Tween_Deceleration_Float(scale_start, scale_end, t);
            var currYRot = DP_TweenFuncs.Tween_Deceleration_Float(yrot_start, yrot_end, t);

            //应用效果
            YQ2CameraCtrl.Single.SetScale(currScale);
            YQ2CameraCtrl.Single.SetYRot(currYRot);

            yield return null;
        } while (count < SData_FightKeyValue.Single.ZhanqianCameraStop);


        YQ2CameraCtrl.Single.EnabledAll = true;//启用相机控制
    }

    /// <summary>
    /// 镜头跟随环视
    /// </summary>
    /// <param name="targetTrans">目标对象Transform</param>
    /// <param name="complateRecall">执行结束回调函数</param>
    public void LookFollowAround(Transform targetTrans, Action complateRecall)
    {
        MonoEX.CoroutineManage.Single.StartCoroutine(CoFollowAndAround(targetTrans, complateRecall));
    }

    /// <summary>
    /// 根据目标点跟随旋转
    /// </summary>
    /// <param name="targerTrans">目标transform</param>
    /// <param name="complateRecall">结束时回调Action</param>
    /// <returns></returns>
    IEnumerator CoFollowAndAround(Transform targerTrans, Action complateRecall)
    {
        // 验证transform有效性
        if (targerTrans != null)
        {
            // 读取系统配置旋转参数: 旋转半径, 旋转时y轴高度, 旋转速度
            var rotationRedius = SData_mapdata.Single.GetDataOfID(1).Camera_Rotate_Radius;
            var rotationYOffset = SData_mapdata.Single.GetDataOfID(1).Camera_Rotate_Yoffset;
            var rotationSpeed = SData_mapdata.Single.GetDataOfID(1).Camera_Rotate_Speed;

            // 旋转计数
            var rotationTimes = 0;
            do
            {
                // 中断滚随旋转
                if (m_InterruptLookAround)
                {
                    break;
                }
                rotationTimes = YQ2CameraCtrl.Single.LookAndAround(rotationRedius, rotationYOffset, rotationSpeed,
                    targerTrans.localPosition, rotationTimes);
                yield return null;
            } while (rotationTimes != 0);

            // 执行结束 执行回调
            if (complateRecall != null)
            {
                complateRecall();
            }
        }
    }

    public void UnLockOP()
    {
        YQ2CameraCtrl.Single.EnabledAll = true;

        Transform tr;
        float dirX;
        // TODO 这行代码与其他层紧耦合 如可以, 需要进行改造
        DP_BattlefieldDraw.Single.GetActorTransfrom(m_CurrTrackHeroActorID, out tr, out dirX);

        if (
            tr == null ||//没有找到对应的演员
            !YQ2CameraCtrl.Single.IsObjMode//当前不在目标模式
            ) return;

        YQ2CameraCtrl.Single.SwapTrackObject(tr.position, dirX, false);//追踪这个角色
        m_CurrTrackActorID = m_CurrTrackHeroActorID;//设置当前追踪的ID
        m_CurrTrackActorIsDirRight = dirX>0;
    }


    /// <summary>
    /// 演员移动
    /// </summary>
    void OnActorMove(int actorID)
    {
        if (m_CurrTrackActorID != actorID || //如果不是当前跟踪的演员
            !YQ2CameraCtrl.Single.IsObjMode //不是目标模式
            ) return;

        Transform tr; float dirX; DP_BattlefieldDraw.Single.GetActorTransfrom(m_CurrTrackActorID, out tr, out dirX);
        if (tr == null) return;//没有找到对应的演员
         
        //当演员朝向发生变化的时候，需要重新切换追踪对象来使镜头X偏移正确
        if((dirX>0)!=m_CurrTrackActorIsDirRight)//方向发生改变
        {
            m_CurrTrackActorIsDirRight = !m_CurrTrackActorIsDirRight;
            YQ2CameraCtrl.Single.SwapTrackObject(tr.position, dirX,true);//重新追踪这个角色
        }else//朝向没有改变
            YQ2CameraCtrl.Single.OnTrackPosChanged(tr.position); //通知摄像机控制器刷新坐标
    }

    public void Reset()
    {
        UnLockOP();
        m_CurrTrackActorID = -1;
        m_CurrTrackHeroActorID = -1;
        //m_LookAroundStep = LookAroundStep.SelectObj;
        m_InterruptLookAround = false; 
    }

    /*
    enum LookAroundStep
    {
        SelectObj,//选择环视对象
        LookArounding,//环视中
        Nothing,
    }*/

    int m_CurrTrackActorID = -1; //最近一次追踪的演员
    bool m_CurrTrackActorIsDirRight;//最近一次追踪的演员方向

    bool m_InterruptLookAround = false;//是否已经打断了环视
    //LookAroundStep m_LookAroundStep = LookAroundStep.SelectObj;
    int m_CurrTrackHeroActorID = -1;//最近一次追踪的英雄
}
