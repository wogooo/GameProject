﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 位置对象
/// </summary>
public abstract class PositionObject : MonoBehaviour, IBaseMember, IGraphicsHolder//, IGraphical<Rectangle>
{

    ///// <summary>
    ///// 目标筛选数据
    ///// </summary>
    //public VOBase MemberData {
    //    get { return memberData; }
    //    set
    //    {
    //        memberData = value;
    //        if (memberData != null)
    //        {
    //            // 初始化数据时初始化图形对象
    //            MyCollisionGraphics = new CircleGraphics(new Vector2(x, y), memberData.SpaceSet * 0.5f);
    //        }
    //    }
    //}

    /// <summary>
    /// 所有数据持有
    /// </summary>
    public AllData AllData {
        get
        {
            return allData;
        }
        set
        {
            allData = value;
        }
    }

    /// <summary>
    /// 单位图形
    /// </summary>
    public ICollisionGraphics MyCollisionGraphics
    {
        get
        {
            if (collisionGraphics == null)
            {
                collisionGraphics = new CircleGraphics(new Vector2(transform.position.x, transform.position.z), allData.MemberData.SpaceSet * 0.5f * ClusterManager.Single.UnitWidth);
            }
            collisionGraphics.Postion = new Vector2(transform.position.x, transform.position.z);
            return collisionGraphics;
        }
        set { collisionGraphics = value; }
    }


    /// <summary>
    /// 单位ID
    /// </summary>
    public long Id {
        get
        {
            if (id < 0)
            {
                id = ++staticId;
            }
            return id;
        }
    }

    /// <summary>
    /// 碰撞组, 不同组不会碰到
    /// </summary>
    public int CollisionGroup { get; set; }

    ///// <summary>
    ///// 物理信息
    ///// </summary>
    //public virtual PhysicsInfo PhysicsInfo
    //{
    //    get
    //    {
    //        if (physicsInfo == null)
    //        {
    //            physicsInfo = new PhysicsInfo();
    //            physicsInfo.MaxSpeed = AllData.MemberData.MoveSpeed;
    //        }
    //        if (physicsInfo.Quality < Utils.ApproachZero)
    //        {
    //            physicsInfo.Quality = Diameter * Diameter;
    //        }
    //        return physicsInfo;
    //    }
    //}


    /// <summary>
    /// 单元直径
    /// </summary>
    public float Diameter
    {
        get { return AllData.MemberData.SpaceSet; }
        set
        {
            AllData.MemberData.SpaceSet = value < 0 ? 1 : value;
            // 更新图形空间值
            CollisionGraphics.SetGraphicsSpaceSet(MyCollisionGraphics, value * 0.5f, ClusterManager.Single.UnitWidth);
        }
    }


    /// <summary>
    /// 当前位置引用
    /// 读取与设置的为GameObject的localPosition
    /// </summary>
    public Vector3 Position
    {
        get { return transform.position; }
        set
        { transform.position = value; }
    }

    /// <summary>
    /// 当前位置X
    /// </summary>
    public float X
    {
        get { return transform.position.x; }
        set
        { transform.position = new Vector3(value, transform.position.y, transform.position.z); }
    }

    /// <summary>
    /// 当前位置Y
    /// </summary>
    public float Y
    {
        get { return transform.position.z; }
        set
        { transform.position = new Vector3(transform.position.x, transform.position.y, value); }
    }

    /// <summary>
    /// 当前高度
    /// </summary>
    public float Height
    {
        get { return height; }
        set { height = value; }
    }


    /// <summary>
    /// 设置旋转值
    /// </summary>
    public Vector3 Rotate
    {
        set { this.transform.Rotate(value); }
    }

    /// <summary>
    /// 返回当前单位的正前向量
    /// </summary>
    public Vector3 Direction
    {
        get { return this.transform.forward; }
        set { this.transform.forward = value; }
    }

    public Vector3 DirectionRight
    {
        get { return this.transform.right; }
    }

    /// <summary>
    /// 当前对象的gameobject的引用
    /// </summary>
    public GameObject ItemObj
    {
        get { return this.gameObject; }
    }

    /// <summary>
    /// 当前对象是否可以移动
    /// 子类如果不可移动则重构该属性
    /// </summary>
    public virtual bool CouldMove
    {
        get { return true; }
    }

    /// <summary>
    /// 是否在移动
    /// </summary>
    public bool IsMoving
    {
        get { return isMoving; }
    }


    ///// <summary>
    ///// 物理信息
    ///// </summary>
    //protected PhysicsInfo physicsInfo = new PhysicsInfo();

    /// <summary>
    /// 物体质量
    /// </summary>
    public float Quality {
        get
        {
            if (quality < Utils.ApproachZero)
            {
                quality = Diameter*Diameter;
            }
            return quality + plusQuality; 
        }
        set { quality = value; }
    }

    /// <summary>
    /// 速度方向
    /// </summary>
    public Vector3 SpeedDirection { get; set; }

    /// <summary>
    /// 最大移动速度
    /// </summary>
    public float MaxSpeed
    {
        get { return AllData.MemberData.MoveSpeed; }
        set { AllData.MemberData.MoveSpeed = value; }
    }

    /// <summary>
    /// 是否可被选择
    /// </summary>
    public bool CouldSelect { get; set; }

    /// <summary>
    /// 所有数据持有
    /// </summary>
    private AllData allData = new AllData();

    /// <summary>
    /// 图形对象
    /// </summary>
    private ICollisionGraphics collisionGraphics = null;

    /// <summary>
    /// 用于标记对象
    /// </summary>
    private static long staticId;

    /// <summary>
    /// 当前单位ID
    /// </summary>
    private long id = -1;

    /// <summary>
    /// 当前位置x
    /// </summary>
    //private float x = 0f;

    /// <summary>
    /// 当前位置y
    /// </summary>
    //private float y = 0f;

    /// <summary>
    /// 当前高度
    /// </summary>
    private float height = 0;

    /// <summary>
    /// 物体质量
    /// </summary>
    protected float quality = 0;

    /// <summary>
    /// 附加质量
    /// 用于挤开其他未到达目标单位
    /// </summary>
    protected float plusQuality = 0f;

    ///// <summary>
    ///// 单元直径
    ///// </summary>
    //private float diameter = 1;

    ///// <summary>
    ///// 历史x
    ///// </summary>
    //private float hisX;

    ///// <summary>
    ///// 历史y
    ///// </summary>
    //private float hisY;

    ///// <summary>
    ///// 历史直径
    ///// </summary>
    //private float hisDiameter;

    ///// <summary>
    ///// 历史rect
    ///// </summary>
    //private Rectangle hisRectangle;

    /// <summary>
    /// 是否正在移动
    /// </summary>
    private bool isMoving = true;



    /// <summary>
    /// 开始运行
    /// </summary>
    public void Begin()
    {
        ClusterManager.Single.Add(this);
    }

    /// <summary>
    /// 停止移动
    /// </summary>
    public void StopMove()
    {
        isMoving = false;
    }

    /// <summary>
    /// 继续移动
    /// </summary>
    public void ContinueMove()
    {
        isMoving = true;
    }

    /// <summary>
    /// 转向目标(延Y轴旋转)
    /// </summary>
    /// <param name="target">目标点</param>
    public void RotateToWithoutYAxis(Vector3 target)
    {
        transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
    }

    /// <summary>
    /// 清除数据
    /// </summary>
    public void Clear()
    {
        if (AllData.SkillInfoList != null)
        {
            // 清除运行中的技能
            foreach (var skillInfo in AllData.SkillInfoList)
            {
                TriggerTicker.Single.Remove(skillInfo.AddtionId);
            }
        }
        if (AllData.BuffInfoList != null)
        {
            // 清除运行中的Buff
            foreach (var buffInfo in AllData.BuffInfoList)
            {
                TriggerTicker.Single.Remove(buffInfo.AddtionId);
            }
        }
        
    }

    ///// <summary>
    ///// 返回位置图形
    ///// </summary>
    ///// <returns>方形图形</returns>
    //public Rectangle GetGraphical()
    //{
    //    //值有变更时重新创建Rect
    //    var halfDiameter = Diameter * 0.5f;
    //    var x = transform.position.x - halfDiameter;
    //    var y = transform.position.z - halfDiameter;
    //    if (hisDiameter - diameter > Utils.ApproachZero ||
    //        diameter - hisDiameter > Utils.ApproachZero ||
    //        hisX - x > Utils.ApproachZero ||
    //        x - hisX > Utils.ApproachZero ||
    //        hisY - y > Utils.ApproachZero ||
    //        y - hisY > Utils.ApproachZero)
    //    {
    //        hisX = x;
    //        hisY = y;
    //        hisDiameter = diameter;
    //        if (hisRectangle == null)
    //        {
    //            //Debug.Log("1");
    //            hisRectangle = new Rectangle(x, y, diameter, diameter);
    //        }
    //        else
    //        {
    //            hisRectangle.X = x;
    //            hisRectangle.Y = y;
    //            hisRectangle.Width = diameter;
    //            hisRectangle.Height = diameter;
    //        }
    //    }
    //    return hisRectangle;
    //}
}




///// <summary>
///// 集群物理信息
///// </summary>
//public class PhysicsInfo
//{

//    /// <summary>
//    /// 物理动量
//    /// 动量 = 质量 * 速度
//    /// 最大动量 = 质量 * 最大速度
//    /// </summary>
//    public float Momentum
//    {
//        get { return SpeedDirection.magnitude * Quality; }
//        //set
//        //{
//        //    momentum = value;
//        //}
//    }

//    /// <summary>
//    /// 速度方向
//    /// </summary>
//    public Vector3 SpeedDirection
//    {
//        get { return speedDirection; }
//        set { speedDirection = value; }
//    }

//    ///// <summary>
//    ///// 动向方向
//    ///// </summary>
//    //public Vector3 Direction
//    //{
//    //    get { return direction; }
//    //    set { direction = value.normalized; }
//    //}

//    /// <summary>
//    /// 物体质量
//    /// </summary>
//    public float Quality
//    {
//        get { return quality; }
//        set { quality = value; }
//    }

//    /// <summary>
//    /// 移动速度
//    /// </summary>
//    //public float Speed
//    //{
//    //    get { return Momentum.magnitude / Quality; }
//    //    //set {
//    //    //    //speed = value > maxSpeed ? maxSpeed : value;
//    //    //    speed = value;
//    //    //}
//    //}

//    /// <summary>
//    /// 最大速度
//    /// </summary>
//    public float MaxSpeed
//    {
//        get { return maxSpeed; }
//        set { maxSpeed = value; }
//    }

//    ///// <summary>
//    ///// 动量
//    ///// </summary>
//    //private Vector3 momentum;

//    /// <summary>
//    /// 速度方向
//    /// </summary>
//    private Vector3 speedDirection;

//    ///// <summary>
//    ///// 动量方向
//    ///// </summary>
//    //private Vector3 direction;

//    /// <summary>
//    /// 质量
//    /// </summary>
//    private float quality = 1;

//    /// <summary>
//    /// 速度
//    /// </summary>
//    //private float speed = 0;

//    /// <summary>
//    /// 最大速度
//    /// </summary>
//    private float maxSpeed = 10;
//}


/// <summary>
/// 图形持有者
/// </summary>
public interface IGraphicsHolder
{

    /// <summary>
    /// 单位图形
    /// </summary>
    ICollisionGraphics MyCollisionGraphics { get; set; }
}

/// <summary>
/// 数据持有接口
/// </summary>
public interface IAllDataHolder
{
    AllData AllData { get; set; }
}