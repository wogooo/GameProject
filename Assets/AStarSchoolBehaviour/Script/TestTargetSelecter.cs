﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LuaInterface;


/// <summary>
/// 测试目标选择器
/// </summary>
public class TestTargetSelecter : MonoBehaviour
{

    /// <summary>
    /// 成员列表
    /// </summary>
    public TargetList<ClusterData> MemberList = null;

    /// <summary>
    /// 地图底板
    /// </summary>
    public GameObject MapPlane;

    /// <summary>
    /// 地图宽度
    /// </summary>
    public int MapWidth;

    /// <summary>
    /// 地图高度
    /// </summary>
    public int MapHeight;

    /// <summary>
    /// 单元数量
    /// </summary>
    public int ItemCount = 100;

    /// <summary>
    /// 搜索对象
    /// </summary>
    private ClusterData _leader;

    /// <summary>
    /// 颜对应表
    /// </summary>
    private Dictionary<int, Color> typeColor = new Dictionary<int, Color>();


    private LuaState L = null;

    private LuaFunction LFunc = null;

    private LuaTable TestData = null;

    /// <summary>
    /// 单位数据列表
    /// </summary>
    //private List<Dictionary<string, object>>  itemDataList = new List<Dictionary<string, object>>();


    void Start()
    {
        // 创建地图目标列表
        MemberList = new TargetList<ClusterData>(MapPlane.transform.localPosition.x, MapPlane.transform.localPosition.z, MapWidth, MapHeight, 1);

        CreateAllMember(ItemCount);

        // 初始化类型颜色
        typeColor.Add(1, Color.white);
        typeColor.Add(2, Color.black);
        typeColor.Add(3, Color.yellow);
        typeColor.Add(4, Color.blue);
        typeColor.Add(5, Color.cyan);

        // 初始化Lua
        //InitLua();
    }

    void Update()
    {

        // 绘制四叉树内单元
        DrawQuadTreeLine(MemberList.QuadTree);

        // 单元移动
        MemberMove();

        // 搜寻目标
        ScanTarget();
        //SacanTargetFromLua();

        // 操作控制
        Control();

    }

    /// <summary>
    /// 初始化Lua
    /// </summary>
    //private void InitLua()
    //{
    //    // TODO LUA需要销毁
    //    L = new LuaState();
    //    L.Start();
    //    // 读取lua文件
    //    L.DoFile( @"D:\project\Project1\GameProject\Assets\Lua\targetSelect.lua");
    //    // 获得lua方法
    //    LFunc = L.GetFunction("SearchTargetWithJson");

    //    // LFunc = L.GetFunction("String");
    //    TestData = L.GetTable("testData");
    //}


    /// <summary>
    /// 单元移动
    /// </summary>
    private void MemberMove()
    {
        bool isTouchTopBorder = false;
        bool isTouchBottomBorder = false;
        bool isTouchRightBorder = false;
        bool isTouchLeftBorder = false;
        foreach (var member in MemberList.List)
        {
            var memberData = member.AllData.MemberData;
            // 判断是否碰到边框
            isTouchTopBorder = member.X + memberData.SpaceSet >= MapPlane.transform.localPosition.x + MapWidth * 0.5f;
            isTouchBottomBorder = member.X <= MapPlane.transform.localPosition.x - MapWidth * 0.5f;
            isTouchRightBorder = member.Y + memberData.SpaceSet >= MapPlane.transform.localPosition.z + MapHeight * 0.5f;
            isTouchLeftBorder = member.Y <= MapPlane.transform.localPosition.z - MapHeight * 0.5f;

            if (isTouchTopBorder || isTouchBottomBorder)
            {
                // X折射
                member.Direction = new Vector3((isTouchTopBorder ? -1 : 1) * Math.Abs(member.Direction.x), 0, member.Direction.z);
            }
            if (isTouchRightBorder || isTouchLeftBorder)
            {
                // Y折射
                member.Direction = new Vector3(member.Direction.x, 0, (isTouchRightBorder ? -1 : 1) * Math.Abs(member.Direction.z));
            }
            // 按照方向移动
            var step = member.Direction.normalized * memberData.MoveSpeed * Time.deltaTime;
            member.X += step.x;
            member.Y += step.z;
        }
        MemberList.RebuildQuadTree();
    }

    /// <summary>
    /// 操作控制
    /// </summary>
    private void Control()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CleanAllMember();
            CreateAllMember(ItemCount);
        }
    }

    /// <summary>
    /// 单元搜寻目标
    /// </summary>
    private void ScanTarget()
    {
        // 遍历对象,
        //foreach (var item in MemberList.List)
        //{

        var item = _leader;
        var memberData = item.AllData.MemberData;
        // 根据对象的搜寻外径获取对向列表
        var itemRect = new RectGraphics(new Vector2(item.X, item.Y), memberData.AttackRange,
                memberData.AttackRange, 0);
        Utils.DrawGraphics(itemRect, Color.red);

        // 根据策略筛选目标
        var targetList = TargetSelecter.TargetFilter(item, MemberList.QuadTree);

        // 连线
        foreach (var targetItem in targetList)
        {
            Debug.DrawLine(new Vector3(item.X, 0, item.Y), new Vector3(targetItem.X, 0, targetItem.Y));
        }

        foreach (var memberItem in MemberList.List)
        {
            if (TargetSelecter.IsCollisionItem(memberItem, item.X, item.Y, memberData.AttackRange * 0.5f))
            {
                Utils.DrawRect(new Vector3(memberItem.X, 0, memberItem.Y), memberData.SpaceSet + 1, memberData.SpaceSet + 1, 0, Color.red);
            }
        }
        Utils.DrawCircle(new Vector3(item.X, 0, item.Y), memberData.AttackRange * 0.5f, Color.red);

        //}
    }

    /// <summary>
    /// 搜索目标从lua中获得
    /// </summary>
    private void SacanTargetFromLua()
    {
        var item = _leader;
        //foreach (var item in MemberList.List)
        //{


        //LuaTable tableData = new LuaTable(TestData.GetReference(), L);
        //StringBuilder sbForTableData = new StringBuilder();

        //// 搜索单位的搜索范围矩形
        //var itemRect = new Rectangle(item.X - item.AttackRange * 0.5f, item.Y - item.AttackRange * 0.5f, item.AttackRange,
        //    item.AttackRange);
        //// 搜索范围内的其他单位
        //var targetList = MemberList.QuadTree.GetScope(itemRect);
        //// 绘制搜索范围 
        //Utils.DrawRect(itemRect, Color.red);

        //sbForTableData.Append("{'data' : [");
        ////  代码解析为string
        //for (var i = 0; i < targetList.Count; i++)
        //{
        //    // 排除自己
        //    var member = targetList[i];
        //    if (item.Equals(member))
        //    {
        //        continue;
        //    }

        //    //sbForTableData.Append("{");
        //    //sbForTableData.Append("'Name' : " + member.Name + ",");
        //    //sbForTableData.Append("'Surface' : " + (member.IsSurface ? 1 : 0) + ",");
        //    //sbForTableData.Append("'Air' : " + (member.IsAir ? 1 : 0) + ",");
        //    //sbForTableData.Append("'Build' : " + (member.IsBuild ? 1 : 0) + ",");

        //    //sbForTableData.Append("'Tank' : " + (member.ItemType == MemberItemType.Tank ? 1 : 0) + ",");
        //    //sbForTableData.Append("'LV' : " + (member.ItemType == MemberItemType.LV ? 1 : 0) + ",");
        //    //sbForTableData.Append("'Cannon' : " + (member.ItemType == MemberItemType.Cannon ? 1 : 0) + ",");
        //    //sbForTableData.Append("'Aircraft' : " + (member.ItemType == MemberItemType.Aircraft ? 1 : 0) + ",");
        //    //sbForTableData.Append("'Soldier' : " + (member.ItemType == MemberItemType.Soldier ? 1 : 0) + ",");

        //    //sbForTableData.Append("'HealthMax' : " + member.MaxHealth + ",");
        //    //sbForTableData.Append("'Health' : " + member.Health + ",");
        //    //sbForTableData.Append("'Angle' : " + Vector3.Angle(item.Direction, member.Direction) + ",");
        //    //sbForTableData.Append("'Position' : { 'x' : " + member.X + ",'y' : " +  member.Y + "}");
        //    //sbForTableData.Append("}");
        //    if (i != targetList.Count - 1)
        //    {
        //        sbForTableData.Append(",");
        //    }
        //}

        //sbForTableData.Append("]}");


        ////Debug.Log(sbForTableData);
        //TestData["jsonData"] = sbForTableData.ToString();
        //// TODO func需要销毁
        //LFunc.BeginPCall();
        //LFunc.PushArgs(new object[]{TestData, 10000});
        //LFunc.PCall();
        //LFunc.EndPCall();
        // Debug.Log(result[0]);
        // 将数据传入

        //var table = (LuaTable)result[0];
        //for (var i = 1; i <= table.Length; i++)
        //{
        //    var oneTargetData = ((LuaTable)table[i]);
        //    // var wight = oneTargetData["wight"];
        //    var x = (double)((LuaTable)((LuaTable)oneTargetData["target"])["Position"])["x"];
        //    var y = (double)((LuaTable)((LuaTable)oneTargetData["target"])["Position"])["y"];
        //    // Debug.Log(((LuaTable)oneTargetData["target"])["Name"]);
        //    // 连线各个目标
        //    Debug.DrawLine(new Vector3(_leader.X, 0, _leader.Y), new Vector3((float)x, 0, (float)y));
        //    //Debug.Log(i + ":" + wight);
        //}

    }


    /// <summary>
    /// 创建测试单元
    /// </summary>
    /// <param name="count">创建单元个数</param>
    private void CreateAllMember(int count)
    {
        var random = new System.Random();
        // 测试 四叉树遇上超大目标
        for (var i = 0; i < count; i++)
        {
            // TODO 创建数据
            var memberData = new VOBase
            {
                SpaceSet = 10,
                MoveSpeed = 10,
                AttackRange = 20
            };
            var gameObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var member = gameObj.AddComponent<ClusterData>();
            var x = random.Next(0, MapWidth);
            var y = random.Next(0, MapHeight);


            memberData.SpaceSet = i % 5 + 1;
            memberData.CurrentHP = i % 5 + 1;
            memberData.AttackRange = 100;
            memberData.TotalHp = 10;
            memberData.GeneralType = (short)random.Next(1, 4);
            //member.IsSurface = random.Next(1) > 0;
            //member.IsAir = !member.IsSurface;
            //member.IsBuild = random.Next(1) > 0;
            memberData.ArmyType = (short)random.Next(1, 4);
            memberData.IsHide = random.Next(1) > 0;

            member.AllData.MemberData = memberData;
            //    new VOBase()
            //{
            //    AttackRange = 20,
            //    SpaceSet = 3,
            //    ObjID = new ObjectID(ObjectID.ObjectType.MySoldier),
            //    MoveSpeed = 60
            //};
            // TODO 物理信息中一部分来自于数据
            member.MaxSpeed = 10;
            member.RotateSpeed = 10;
            member.transform.localPosition = new Vector3((i % 3) * 2 + x, 0, i / 3 * 2 + y);
            member.name = "item" + i;
            member.Diameter = (i) % 5 + 1;
            //member.Name = "member" + i;
            member.X = x;
            member.Y = y;
            //member.IsTaunt = random.Next(1) > 0;

            // 随机给方向
            member.Direction = new Vector3(random.Next(1, 100), 0, random.Next(1, 100));

            var fightData = member.AllData.SelectWeightData;
            fightData = new SelectWeightData();
            // 选择目标数据
            fightData.AirWeight = -1;
            fightData.BuildWeight = 100;
            fightData.SurfaceWeight = 100;

            fightData.HumanWeight = 10;
            fightData.OrcWeight = 10;
            fightData.OmnicWeight = 10;
            //member.TankWeight = 10;
            //member.LVWeight = 10;
            //member.CannonWeight = 10;
            //member.AirCraftWeight = 10;
            //member.SoldierWeight = 10;

            fightData.HideWeight = -1;
            fightData.TauntWeight = 1000;

            fightData.HealthMaxWeight = 0;
            fightData.HealthMinWeight = 10;
            //member.AngleWeight = 10;
            fightData.DistanceMaxWeight = 0;
            fightData.DistanceMinWeight = 10;

            member.AllData.MemberData.Accuracy = 0.9f;
            member.AllData.MemberData.SpreadRange = 10;

            //memberData.MultiAimMax = 10;
            MemberList.Add(member);
            if (i == 0)
            {
                _leader = member;
            }

        }
    }

    /// <summary>
    /// 清理掉所有对象
    /// </summary>
    private void CleanAllMember()
    {
        MemberList.Clear();
    }

    /// <summary>
    /// 绘制单元位置与四叉树分区情况
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="quadTree"></param>
    private void DrawQuadTreeLine<T>(QuadTree<T> quadTree) where T : IBaseMember, IGraphicsHolder
    {
        // 绘制四叉树边框
        Utils.DrawGraphics(quadTree.GetRectangle(), Color.white);
        // 遍历四叉树内容
        foreach (var item in quadTree.GetItemList())
        {
            // 绘制当前对象
            Utils.DrawGraphics(item.MyCollisionGraphics, typeColor[1]);
            // 绘制前进方向
            var position = new Vector3(item.X, 0, item.Y);
            Debug.DrawLine(position, position + item.Direction.normalized * 2, Color.red);
        }

        if (quadTree.GetSubNodes()[0] != null)
        {
            foreach (var node in quadTree.GetSubNodes())
            {
                DrawQuadTreeLine(node);
            }
        }
    }
}