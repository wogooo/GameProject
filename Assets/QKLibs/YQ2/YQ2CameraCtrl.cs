﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;

[AddComponentMenu("QK/YQ2/CameraCtrl")]
[RequireComponent(typeof(TransformMixer))]
public class YQ2CameraCtrl : MonoBehaviour
{
    /// <summary>
    /// 单例对象
    /// </summary>
    public static YQ2CameraCtrl Single = null;

    public UIFollow uf;
    void Awake()
    {
        // 获取单例对象
        m_TransformMixer = GetComponent<TransformMixer>();
        //位置合成器，用于描述相机偏移量
        m_OffsetTransform = GetComponent<PositionTransform>() ?? gameObject.AddComponent<PositionTransform>();
        Single = this;

        // 设置位移变化触发器
        m_TransformMixer.MainPositionTransform.OnValueChanged += OnCameraPositionTransform;
        m_OffsetTransform.OnValueChanged += OnCameraPositionTransform;
    }

    /// <summary>
    /// 位移变化触发器
    /// </summary>
    /// <param name="self"></param>
    void OnCameraPositionTransform(PositionTransform self)
    {
        if (OnPoschanged != null)
        {
            m_TransformMixer.ManualUpdate();
            OnPoschanged(transform.position);
        }
    }

    /// <summary>
    /// 立即合成变换
    /// </summary>
    public void MixerTransform()
    {
        m_TransformMixer.ManualUpdate();
    }


    void Start()
    {
        // 初始化触控事件
        EasyTouch.On_TouchDown += OnTouchDownHandler;
        EasyTouch.On_TouchUp += OnTouchUpHandler;


        //EasyTouch.On_PinchIn += OnPinchIn;
        //EasyTouch.On_PinchOut += OnPinchOut;
        EasyTouch.On_TouchUp2Fingers += OnTouchUp2Fingers;

        //TODODO 关闭屏幕长按旋转摄像机
        //EasyTouch.On_LongTap += OnLongTap;

        //        EasyTouch.On_DoubleTap += (gesture) => { };
        // 边界控制器
        m_ScrollObject = GetComponent<BoxScrollObject>();

        // 本地化数据层数据
        var cameraData = SData_mapdata.Single.GetDataOfID(1);
        m_CameraTurnaroundTime = cameraData.Camera_ZhuanshenTime;
        m_TerrainCellBianchang = cameraData.terrain_cell_bianchang;
        m_CameraYAroundMin = cameraData.CameraY_XuanzhuanMin;
        m_CameraYAroundMax = cameraData.CameraY_XuanzhuanMax;
        m_Camera_YOffsetMax = cameraData.Camera_YOffsetMax;
        m_Camera_YOffsetMin = cameraData.Camera_YOffsetMin;
        m_Camera_RotationMax = cameraData.Camera_RotationMax;
        m_Camera_RotationMin = cameraData.Camera_RotationMin;
        m_Camera_ZOffsetMax = cameraData.Camera_ZOffsetMax;
        m_Camera_ZOffsetMin = cameraData.Camera_ZOffsetMin;
        m_Camera_XOffsetMax = cameraData.Camera_XOffsetMax;
        m_Camera_XOffsetMin = cameraData.Camera_XOffsetMin;
        m_CameraTrnaroundSpeed = cameraData.CameraY_XuanzhuanSpeed;
        m_FreeCamera_Scale_Speed = cameraData.FreeCamera_Scale_Speed;
        m_Camera_Overall_Zoffset = cameraData.Camera_Overall_Zoffset;
        m_Camera_Overall_Yoffset = cameraData.Camera_Overall_Yoffset;
        m_Camera_Overall_Yrotate = cameraData.Camera_Overall_Yrotate;
        m_Camera_Overall_Xrotate = cameraData.Camera_Overall_Xrotate;

        uf = GetComponent<UIFollow>();

        // 设置相机初始位置
        transform.position = new Vector3(transform.position.x, transform.position.y + m_Camera_Overall_Yoffset, transform.position.z + m_Camera_Overall_Zoffset);
        transform.Rotate(Vector3.up, m_Camera_Overall_Yrotate);
        transform.Rotate(Vector3.right, m_Camera_Overall_Xrotate);
    }

    /// <summary>
    /// 相机追踪的物体位置改变
    /// </summary>
    /// <param name="pos3d">跟踪目标位置</param>
    public void OnTrackPosChanged(Vector3 pos3d)
    {
        if (m_WorkMode != WorkMode.Obj)
            return;
        //m_HasTrackPos3d = true;//标记已经获得了追踪位置

        if (m_TrackPos3d != pos3d)//产生了移动
        {
            CDLockd = false;
            XOffsetTo(GetXOffset(), Ease.Linear, true, m_CameraTurnaroundTime);
        }

        m_TrackPos3d = pos3d; //更新追踪目标位置


        //计算相机的目标位置和目标旋转角度，并根据情况决定是用何种方式插值移动 

        var x = m_TrackPos3d.x; //+ (m_ActorDirX > 0 ? m_XOffset : -m_XOffset)
        var z = m_TrackPos3d.z;
        Vector3 oldPos = m_ScrollObject.ScrollViewPosition;
        var newPos = new Vector3(x, m_Height, z);

        // 求两点之间距离
        var distance = Vector3.Distance(oldPos, newPos);
        // 验证距离不为0
        if (distance > QKMath.PRECISION)
        {

            var gd = DiamondGridMap.wxs * m_TerrainCellBianchang;
            distance /= gd;

            float time = m_FocusObjChanged ? distance * distance / 30000f : 0f;//距离越大时间加成越大
            if (newPos.x < -99999)
                time = 0;//非法距离，瞬间移动
            else if (m_FocusObjChanged && time < 0.1f) time = 0.1f;


            MoveTo(
                newPos,
                m_FocusObjChanged ? Ease.OutQuart : Ease.Linear,
                !m_FocusObjChanged,
                time
                );
        }

        m_FocusObjChanged = false;
    }

    /// <summary>
    /// 旋转镜头函数
    /// </summary>
    /// <param name="rotationRedius">旋转半径</param>
    /// <param name="rotationYOffset">旋转Y偏移</param>
    /// <param name="rotationSpeed">旋转速度</param>
    /// <param name="targetPos">旋转目标点</param>
    /// <param name="cameraPos">相机位置</param>
    /// <param name="rotatingTime">当前旋转次数</param>
    /// <returns>下次旋转计数(计数*速度(单位旋转角度)为当前旋转角度) 具体值: rotatingTime+1</returns>
    public int LookAndAround(float rotationRedius, float rotationYOffset, float rotationSpeed, Vector3 targetPos, int rotatingTime)
    {
        // --------------------------计算相机位置----------------------------
        // 每帧旋转角度
        // 以中心点为基准使用
        // x = x_center + Math.Sin(2 * Math.PI / 360) * r, 
        // y = y_center + Math.Cos(2 * Math.PI / 360) * r
        // 的公式加上速度计算当前位置
        var radian = (2 * Utils.AngleToPi) * rotationSpeed * rotatingTime;
        var pointX = targetPos.x + Math.Sin(radian) * rotationRedius;
        var pointY = targetPos.z + Math.Cos(radian) * rotationRedius;

        // 设置相机位置
        m_OffsetTransform.Value = new Vector3((float)pointX, targetPos.y + rotationYOffset, (float)pointY);
        // --------------------------计算相机位置----------------------------

        // --------------------------计算相机旋转----------------------------

        // 获取相机与目标位置差值
        var posDiff = targetPos - m_OffsetTransform.Value;

        // 计算三个平面上的角度旋转
        posDiff.Normalize();
        // Y轴旋转
        var yRotate = Quaternion.AngleAxis(rotationSpeed * rotatingTime + 180, Vector3.up);
        // 求与当前运行轨迹圆的切线向量
        var tangent = Vector3.Cross(
            new Vector3(
                (float)Math.Sin((rotationSpeed * rotatingTime + 180) * Utils.AngleToPi),
                0,
                (float)Math.Cos((rotationSpeed * rotatingTime + 180) * Utils.AngleToPi)),
            Vector3.down);
        // 相对X轴旋转
        var xRotate = Quaternion.AngleAxis(angle: (float)(90 - Math.Atan(d: rotationRedius / rotationYOffset) / Math.PI * 180), axis: tangent);
        m_TransformMixer.MainRotationTransform.Value = xRotate * yRotate;
        // --------------------------计算相机旋转---------------------------- 
        // 旋转大于360度或小于-360度,归零
        rotatingTime++;
        var radianNow = (rotatingTime - 1) * rotationSpeed;
        if (radianNow > 360 || radianNow < -360)
        {
            rotatingTime = 0;
        }
        // 返回当前已旋转次数
        return rotatingTime;
    }

    /// <summary>
    /// 设定相机缩放
    /// </summary>
    /// <param name="scale">缩放比例</param>
    public void SetScale(float scale)
    {
        //if (m_WorkMode == WorkMode.Obj && !m_HasTrackPos3d) return;//锁视角尚未获得追踪位置

        m_Scale = scale;

        // 从表中读取属差值性值用于缩放
        ScaleLerp();


        float x, z;

        if (m_WorkMode == WorkMode.Free)
        {
            Vector3 currPos = m_ScrollObject.ScrollViewPosition;
            //m_CurrXPos = currPos.x - oldXOffset + (m_XOffset - oldXOffset);

            //x = currPos.x;// + (m_XOffset - oldXOffset);
            //x = m_CurrXPos;
            x = currPos.x;
            z = currPos.z;
            //m_CurrXOffset = m_XOffset;
        }
        else //锁定目标模式
        {
            x = m_TrackPos3d.x;
            z = m_TrackPos3d.z;
        }

        // 移动相机位置, 并转镜头
        XOffsetTo(GetXOffset(), Ease.Linear, true, 0f);
        ZOffsetTo(m_ZOffset, Ease.Linear, true, 0f);
        MoveTo(new Vector3(x, m_Height, z), Ease.Linear, true, 0f);
        RotXTo(m_Rotation, Ease.Linear, 0f);
    }

    /// <summary>
    /// 设定相机y轴旋转系数 0-1
    /// </summary>
    /// <param name="xs">按照Y轴旋转角度</param>
    public void SetYRot(float xs)
    {
        m_YRotScale = xs;
        //Debug.Log("xs:"+xs.ToString());
        float yRot = Mathf.Lerp(
            m_CameraYAroundMin,
            m_CameraYAroundMax,
            m_YRotScale
            );


        Vector3 tmpEuler = m_TransformMixer.MainRotationTransform.Value.eulerAngles;
        tmpEuler.y = yRot;
        //Debug.Log("xs:" + xs.ToString() + "   " + yRot);
        m_TransformMixer.MainRotationTransform.Value = Quaternion.Euler(tmpEuler);
        ApplyOffset();//y旋转会影响偏移量
    }


    /// <summary>
    /// 获取缩放差值属性
    /// </summary>
    void ScaleLerp()
    {
        // 规定四属性的起始点, 使用m_Scale求四属性区间画出一条摄像机路径
        m_Height = Mathf.Lerp(m_Camera_YOffsetMax, m_Camera_YOffsetMin, m_Scale);
        m_Rotation = Mathf.Lerp(m_Camera_RotationMax, m_Camera_RotationMin, m_Scale);
        m_ZOffset = Mathf.Lerp(m_Camera_ZOffsetMax, m_Camera_ZOffsetMin, m_Scale);
        m_XOffset = Mathf.Lerp(m_Camera_XOffsetMax, m_Camera_XOffsetMin, m_Scale);
    }

    /// <summary>
    /// 相机注视某点(不改变旋转角度和高度)
    /// </summary>
    //    public void LookAt(float worldx, float worldz)
    //    {
    //        var oldPos =m_ScrollObject.ScrollViewPosition;
    //        float height = oldPos.y;
    //        Vector3 dir = -(m_TransformMixer.MainRotationTransform.Value * Vector3.forward);
    //        dir.Normalize();//归一化
    //        Plane pl = new Plane(Vector3.down, new Vector3(worldx, height, 0));
    //        Ray ray = new Ray(new Vector3(worldx, 0, worldz), dir);
    //        float enter; pl.Raycast(ray, out enter);
    //        var newPos = ray.GetPoint(enter);
    //
    //        //距离比较远的时候用减速运动提升效果，较近的时候用匀速运动防止抖动
    //        MoveTo(newPos, Vector3.Distance(oldPos, newPos) > (1*DiamondGridMap.wxs * SData_MapData.Single.TerrainCellBianchang) ? Ease.OutQuart : Ease.Linear,false, 0.2f);
    //    }


    /// <summary>
    /// 切换跟随目标，同时进入目标跟随模式
    /// </summary>
    /// <param name="trackPos3d">跟随目标</param>
    /// <param name="actorDirX">演员的X朝向</param>
    /// <param name="isZhuanshen">是否转身</param>
    public void SwapTrackObject(
        Vector3 trackPos3d,
        float actorDirX,
        bool isZhuanshen
        )
    {
        //m_TrackPos3d = trackPos3d;
        m_ActorDirX = actorDirX;
        //m_HasTrackPos3d = false;//当前尚未取得追踪物的3D位置
        //m_FocusHeroDataID = dataID;
        //m_FocusIsAttack = isAttack;
        m_WorkMode = WorkMode.Obj;

        //ScaleLerp();

        //停止位置补间
        StopPosXTweener();
        StopPosYTweener();
        StopPosZTweener();

        //目标物改变标志
        m_FocusObjChanged = true;


        if (isZhuanshen)//中途转身的处理
        {
            CDLockd = true;
            //CD = SData_MapData.Single.Camera_ZhuanshenCD;

            //平滑的移动x偏移
            XOffsetTo(GetXOffset(),
                Ease.Linear,
                false,
                m_CameraTurnaroundTime);
        }
        else
        {
            CDLockd = false;

            //当前x偏移量直接变化到最终值
            XOffsetTo(
                (m_ActorDirX > 0 ? m_XOffset : -m_XOffset),
                Ease.Linear,
                false,
                0);
        }

        //立即补间位置
        OnTrackPosChanged(trackPos3d);
    }

    /// <summary>
    /// 获取X轴偏移值
    /// </summary>
    /// <returns>
    /// 锁屏或自由视角时返回0
    /// 否则根据X轴朝向返回X偏移的正值或负值
    /// </returns>
    float GetXOffset()
    {
        if (CDLockd) return 0;
        return m_ActorDirX > 0 ? m_XOffset : -m_XOffset;
    }
    bool CDLockd = false;
    //float CD;

    /// <summary>
    /// 二指拉近
    /// </summary>
    /// <param name="gesture"></param>
    void OnPinchIn(Gesture gesture)
    {

        if (!m_EnabledScale) return;

        float scale = m_Scale - gesture.deltaPinch * InOutScale;
        if (scale < 0) scale = 0;
        SetScale(scale);
    }


    /// <summary>
    /// 二指拉远
    /// </summary>
    /// <param name="gesture"></param>
    void OnPinchOut(Gesture gesture)
    {
        if (!m_EnabledScale) return;

        float scale = m_Scale + gesture.deltaPinch * InOutScale;
        if (scale > 1) scale = 1;
        SetScale(scale);
    }

    /// <summary>
    /// 二指缩放结束保存
    /// </summary>
    /// <param name="gesture"></param>
    void OnTouchUp2Fingers(Gesture gesture)
    {
        if (istuiguan)
            CPlayerPrefs.Single.SetUserDate("CameraScale", m_Scale.ToString("f5"));
    }

    /// <summary>
    /// 拖拽
    /// </summary>
    /// <param name="gesture"></param>
    void OnTouchDownHandler(Gesture gesture)
    {
        if (!m_EnabledTouch || gesture.touchCount > 1) return;
        // 中断角色跟随 进入自由模式
        InterruptObjMode();
        // 停止x,z轴移动动画
        StopPosXTweener();
        StopPosZTweener();

        // 计算移动目标点 锁Y轴拖拽与Z轴拖拽
        var localPos = GetMoveTargetPos(m_Camera_Overall_Xrotate,
            m_Camera_Overall_Yrotate,
            gesture.deltaPosition,
            m_Camera_Overall_Yoffset,
            m_Camera_Overall_Zoffset,
            lockY: true, lockZ: true);
        uf.Target = null;
        m_ScrollObject.MoveTo(localPos);


        //抛出用户自行移动相机事件
        if (OnUserTouch != null) OnUserTouch();
    }

    /// <summary>
    /// 计算移动目标点
    /// </summary>
    /// <param name="eulerAngleX">x轴旋转角度</param>
    /// <param name="eulerAngleY">y轴旋转角度</param>
    /// <param name="offsetY">y轴偏移量</param>
    /// <param name="offsetZ">z轴偏移量</param>
    /// <param name="dragPosition">拖拽向量</param>
    /// <param name="lockX">是否锁定X轴滑动</param>
    /// <param name="lockY">是否锁定Y轴滑动</param>
    /// <param name="lockZ">是否锁定Z轴滑动</param>
    /// <returns></returns>
    private Vector3 GetMoveTargetPos(float eulerAngleX,
        float eulerAngleY,
        Vector3 dragPosition,
        float offsetY = float.MinValue,
        float offsetZ = float.MinValue,
        bool lockX = false,
        bool lockY = false,
        bool lockZ = false)
    {
        const float movescale = TouchScale;
        var rotY = eulerAngleY;
        var rotX = eulerAngleX;

        // 获取相对相机的左侧向量与后方向量
        var rDir = Quaternion.Euler(rotX, rotY, 0) * Vector3.left;
        var fDir = Quaternion.Euler(rotX, rotY, 0) * Vector3.back;
        var uDir = Quaternion.Euler(rotX, rotY, 0) * Vector3.up;

        //向量标准化(变成长度为1的向量)
        rDir.Normalize();
        fDir.Normalize();

        // 获取相对于相机方向的控制拖拽向量

        var add = (!lockX ? rDir * dragPosition.x * movescale : Vector3.zero)
    + (!lockY ? fDir * dragPosition.y * movescale : Vector3.zero)
    + (!lockZ ? uDir * dragPosition.z * movescale : Vector3.zero);

        //var add = new Vector3(-dragPosition.x * movescale, 0, 0);

        //localPos.x -= gesture.deltaPosition.x * movescale;
        //localPos.z -= gesture.deltaPosition.y * movescale;
        // 移动位置
        Vector3 localPos = m_ScrollObject.ScrollLogicPosition;
        localPos += add;

        if (offsetY > float.MinValue) { localPos.y = offsetY; }
        if (offsetZ > float.MinValue) { localPos.z = offsetZ; }
        return localPos;
    }


    public event Action OnUserTouch;
    public event Action<Vector3> OnPoschanged;

    /// <summary>
    /// 跳转到世界位置，无惯性
    /// </summary>
    public void JumpToWorldPos(float x, float z)
    {
        if (!m_EnabledTouch) return;//已禁用

        InterruptObjMode();
        StopAllTween();
        Vector3 localPos = m_ScrollObject.ScrollLogicPosition;
        localPos.x = x;
        localPos.z = z;
        m_ScrollObject.JumpTo(localPos);
    }


    /// <summary>
    /// 屏幕长点击事件
    /// </summary>
    /// <param name="gesture"></param>
    void OnLongTap(Gesture gesture)
    {
        if (!m_EnabledRot || gesture.touchCount > 1) return;

        var v = gesture.deltaTime * YRotScale;

        var ps = gesture.position;

        if (ps.x < Screen.width / 2)//长按屏幕左侧
            m_YRotScale += v; // 角度向左转
        else//长按屏幕右侧
            m_YRotScale -= v; // 角度向右转

        m_YRotScale = Mathf.Clamp(m_YRotScale, 0, 1);

        this.SetYRot(m_YRotScale);

        if (OnUserYRot != null) OnUserYRot();
    }

    /// <summary>
    /// 目标相机模式被打断
    /// </summary>
    public event Action OnInterruptObjMode;

    /// <summary>
    /// 目标相机模式被打断
    /// </summary>
    public event Action OnUserYRot;

    public bool EnabledAll
    {
        set { EnabledTouch = EnabledScale = EnabledRot = value; }
    }

    public bool EnabledTouch
    {
        get { return m_EnabledTouch; }
        set { m_EnabledTouch = value; }
    }

    public bool EnabledScale
    {
        get { return m_EnabledScale; }
        set { m_EnabledScale = value; }
    }

    public bool EnabledRot
    {
        get { return m_EnabledRot; }
        set { m_EnabledRot = value; }
    }

    public bool IsObjMode
    {
        get { return m_WorkMode == WorkMode.Obj; }
    }

    /// <summary>
    /// 打断目标相机模式
    /// </summary>
    public void InterruptObjMode()
    {
        if (m_WorkMode != WorkMode.Obj) return;
        m_WorkMode = WorkMode.Free;//切为自由相机模式

        StopXOffsetTweener();
        StopZOffsetTweener();

        if (OnInterruptObjMode != null) OnInterruptObjMode();
    }

    /// <summary>
    /// 旋转角度
    /// 摄像机角度视线按照x轴旋转
    /// </summary>
    /// <param name="xRot">转动角度</param>
    /// <param name="ease">转动方式</param>
    /// <param name="time">转动时间</param>
    private void RotXTo(float xRot, Ease ease, float time = 0.3f)
    {
        var x = m_TransformMixer.MainRotationTransform.Value.eulerAngles.x;
        if (QKMath.Equals(xRot, x)) return; //没有旋转的必要

        StopRotXTweener();

        if (QKMath.Equals(time, 0))
        {
            Vector3 tmpEuler = m_TransformMixer.MainRotationTransform.Value.eulerAngles;
            tmpEuler.x = xRot;
            m_TransformMixer.MainRotationTransform.Value = Quaternion.Euler(tmpEuler);
        }
        else
            m_rotXTweener = DOTween.To(
                () => m_TransformMixer.MainRotationTransform.Value.eulerAngles.x,
                (rot_x) =>
                {
                    Vector3 tmpEuler = m_TransformMixer.MainRotationTransform.Value.eulerAngles;
                    tmpEuler.x = rot_x;
                    m_TransformMixer.MainRotationTransform.Value = Quaternion.Euler(tmpEuler);
                },
                xRot,
                time
                ).SetAutoKill().SetEase(ease);
    }

    /// <summary>
    /// Y轴移动
    /// </summary>
    /// <param name="newy">目标Y值</param>
    /// <param name="ease">移动方式</param>
    /// <param name="time">移动时间</param>
    void MoveYTo(float newy, Ease ease, float time = 0.3f)
    {
        var pos = m_ScrollObject.ScrollViewPosition;

        if (!QKMath.Equals(pos.y, newy))
        {
            StopPosYTweener();

            if (QKMath.Equals(time, 0))
            {
                Vector3 tmpPos = m_ScrollObject.ScrollViewPosition;
                tmpPos.y = newy;
                m_ScrollObject.JumpTo(tmpPos);
            }
            else
                m_posYTweener = DOTween.To(
                    () => m_ScrollObject.ScrollViewPosition.y,
                    (v) =>
                    {
                        Vector3 tmpPos = m_ScrollObject.ScrollViewPosition;
                        tmpPos.y = v;
                        m_ScrollObject.JumpTo(tmpPos);
                    },
                    newy,
                    0.3f
                    ).SetAutoKill().SetEase(ease);

        }

    }

    /// <summary>
    /// 停止Z轴横移
    /// </summary>
    void StopZOffsetTweener() { if (m_ZOffsetTweener != null && m_ZOffsetTweener.IsActive()) m_ZOffsetTweener.Kill(); }

    /// <summary>
    /// 停止X轴横移
    /// </summary>
    void StopXOffsetTweener() { if (m_XOffsetTweener != null && m_XOffsetTweener.IsActive()) m_XOffsetTweener.Kill(); }

    /// <summary>
    /// 停止X轴移动
    /// </summary>
    void StopPosXTweener() { if (m_posXTweener != null && m_posXTweener.IsActive()) m_posXTweener.Kill(); }

    /// <summary>
    /// 停止X轴移动
    /// </summary>
    void StopPosZTweener() { if (m_posZTweener != null && m_posZTweener.IsActive()) m_posZTweener.Kill(); }

    /// <summary>
    /// 停止Y轴移动
    /// </summary>
    void StopPosYTweener() { if (m_posYTweener != null && m_posYTweener.IsActive()) m_posYTweener.Kill(); }

    /// <summary>
    /// 停止X轴旋转
    /// </summary>
    void StopRotXTweener() { if (m_rotXTweener != null && m_rotXTweener.IsActive()) m_rotXTweener.Kill(); }

    /// <summary>
    /// 停止所有移动与旋转
    /// </summary>
    void StopAllTween()
    {
        StopPosXTweener();
        StopPosYTweener();
        StopPosZTweener();
        StopXOffsetTweener();
        StopRotXTweener();
        StopZOffsetTweener();
    }

    /// <summary>
    /// 顺滑操作X轴位置
    /// </summary>
    /// <param name="newV">目标X值</param>
    /// <param name="ease"></param>
    /// <param name="constant">是否在执行状态下修改newV并继续操作</param>
    /// <param name="time">执行时间</param>
    void XOffsetTo(float newV, Ease ease, bool constant = false, float time = 0.3f)
    {
        StopXOffsetTweener();
        if (QKMath.Equals(time, 0))
        {
            m_CurrXOffset = newV;
            ApplyOffset();
        }
        else
            m_XOffsetTweener = DOTween.To(
                () => m_CurrXOffset,//m_ScrollObject.ScrollViewPosition.x
                (v) =>
                {
                    m_CurrXOffset = v;
                    ApplyOffset();
                },
                newV,
                time
                ).SetAutoKill().SetEase(ease);
    }

    /// <summary>
    /// 顺滑操作Z轴位置
    /// </summary>
    /// <param name="newV">目标X值</param>
    /// <param name="ease"></param>
    /// <param name="constant">是否在执行状态下修改newV并继续操作</param>
    /// <param name="time">执行时间</param>
    void ZOffsetTo(float newV, Ease ease, bool constant = false, float time = 0.3f)
    {
        StopZOffsetTweener();
        if (QKMath.Equals(time, 0))
        {
            m_CurrZOffset = newV;
            ApplyOffset();
        }
        else
            m_ZOffsetTweener = DOTween.To(
                () => m_CurrZOffset,//m_ScrollObject.ScrollViewPosition.x
                (v) =>
                {
                    m_CurrZOffset = v;
                    ApplyOffset();
                },
                newV,
                time
                ).SetAutoKill().SetEase(ease);
    }

    void ApplyOffset()
    {
        var rotY = m_TransformMixer.MainRotationTransform.Value.eulerAngles.y;

        var rDir = Quaternion.Euler(0, rotY, 0) * Vector3.right;
        var fDir = Quaternion.Euler(0, rotY, 0) * Vector3.back;
        rDir.Normalize();
        fDir.Normalize();

        var v = m_OffsetTransform.Value;
        v = rDir * m_CurrXOffset + fDir * m_CurrZOffset;
        m_OffsetTransform.Value = v;
    }

    /// <summary>
    /// 向目标移动
    /// </summary>
    /// <param name="newpos">目标点</param>
    /// <param name="ease">移动方式</param>
    /// <param name="constant">持续移动(上次移动未结束时继续操作)</param>
    /// <param name="time">移动时间</param>
    void MoveTo(Vector3 newpos, Ease ease, bool constant = false, float time = 0.3f)
    {
        var pos = m_ScrollObject.ScrollViewPosition;

        if (!QKMath.Equals(pos.x, newpos.x))
        {
            /*
             if (constant && m_posXTweener != null && m_posXTweener.IsActive())//持续模式，且当前tweener仍然有效 
                 //m_posXTweener.ChangeValues(m_ScrollObject.ScrollViewPosition.x, newpos.x);
                 m_posXTweener.ChangeEndValue(newpos.x);
             else*/
            {
                StopPosXTweener();
                if (QKMath.Equals(time, 0))
                {

                    //m_CurrXPos = newpos.x;
                    //ApplyXPos(); 
                    Vector3 tmpPos = m_ScrollObject.ScrollViewPosition;
                    tmpPos.x = newpos.x;
                    m_ScrollObject.JumpTo(tmpPos);
                }
                else
                    m_posXTweener = DOTween.To(
                        () => m_ScrollObject.ScrollViewPosition.x,//m_ScrollObject.ScrollViewPosition.x
                        (v) =>
                        {
                            var tmp = m_ScrollObject.ScrollViewPosition;
                            tmp.x = v;
                            m_ScrollObject.JumpTo(tmp);
                            //m_CurrXPos = v;
                            //ApplyXPos();
                        },
                        newpos.x,
                        time
                        ).SetAutoKill().SetEase(ease);
            }
        }

        if (!QKMath.Equals(pos.y, newpos.y))
        {
            if (constant && m_posYTweener != null && m_posYTweener.IsActive())//持续模式，且当前tweener仍然有效 
                //m_posYTweener.ChangeValues(m_ScrollObject.ScrollViewPosition.y, newpos.y);
                m_posYTweener.ChangeEndValue(newpos.y, true);
            else
            {
                StopPosYTweener();
                if (QKMath.Equals(time, 0))
                {
                    Vector3 tmpPos = m_ScrollObject.ScrollViewPosition;
                    tmpPos.y = newpos.y;
                    m_ScrollObject.JumpTo(tmpPos);
                }
                else
                    m_posYTweener = DOTween.To(
                        () => m_ScrollObject.ScrollViewPosition.y,
                        (v) =>
                        {
                            Vector3 tmpPos = m_ScrollObject.ScrollViewPosition;
                            tmpPos.y = v;
                            m_ScrollObject.JumpTo(tmpPos);
                        },
                        newpos.y,
                        0.3f
                        ).SetAutoKill().SetEase(ease);
            }

        }

        if (!QKMath.Equals(pos.z, newpos.z))
        {
            if (constant && m_posZTweener != null && m_posZTweener.IsActive())//持续模式，且当前tweener仍然有效 
                //m_posYTweener.ChangeValues(m_ScrollObject.ScrollViewPosition.y, newpos.y);
                m_posZTweener.ChangeEndValue(newpos.z, true);
            else
            {
                StopPosZTweener();

                if (QKMath.Equals(time, 0))
                {
                    Vector3 tmpPos = m_ScrollObject.ScrollViewPosition;
                    tmpPos.z = newpos.z;
                    m_ScrollObject.JumpTo(tmpPos);
                }
                else
                    m_posZTweener = DOTween.To(
                        () => m_ScrollObject.ScrollViewPosition.z,
                        (v) =>
                        {
                            Vector3 tmpPos = m_ScrollObject.ScrollViewPosition;
                            tmpPos.z = v;
                            m_ScrollObject.JumpTo(tmpPos);
                        },
                        newpos.z,
                        0.3f
                        ).SetAutoKill().SetEase(ease);
            }

        }
    }

    /// <summary>
    /// 应用x位置，合成偏移效果和位移效果
    /// </summary>
    /*void ApplyXPos()
    {
        Vector3 tmpPos = m_ScrollObject.ScrollViewPosition;
        tmpPos.x = m_CurrXPos + m_CurrXOffset;
        m_ScrollObject.JumpTo(tmpPos);
    }*/


    /// <summary>
    /// 拖拽完毕
    /// </summary>
    /// <param name="gesture"></param>
    void OnTouchUpHandler(Gesture gesture)
    {
        m_ScrollObject.MoveEnd(true, false, false);
    }

    /// <summary>
    /// 拉近拉远速度
    /// </summary>
    float InOutScale
    {
        get
        {
            return 0.005f * m_FreeCamera_Scale_Speed;
        }
    }

    /// <summary>
    /// Y轴旋转速度
    /// </summary>
    float YRotScale
    {
        get
        {
            return YRotScaleXS * m_CameraTrnaroundSpeed;
        }
    }

#if UNITY_STANDALONE_WIN //windows平台
    /// <summary>
    /// 拖拽位移速度
    /// </summary>
    const float TouchScale = 0.5f;

    /// <summary>
    /// Y轴旋转速度
    /// </summary>
    const float YRotScaleXS = 0.5f;
#else//其它平台
    /// <summary>
    /// 拖拽位移速度
    /// </summary>
    const float TouchScale = 0.3f;

    /// <summary>
    /// Y轴旋转速度
    /// </summary>
    const float YRotScaleXS = 3.6f;
#endif



    /// <summary>
    /// 地图边界碰撞检测
    /// </summary>
    BoxScrollObject m_ScrollObject;

    /// <summary>
    /// 变换混合器
    /// </summary>
    TransformMixer m_TransformMixer;


    /// <summary>
    /// 相机工作模式
    /// </summary>
    enum WorkMode
    {
        Free,//自由相机
        Obj,//跟随目标相机
    }

    // -----------------------位移动画-------------------
    Tweener m_ZOffsetTweener = null;
    Tweener m_XOffsetTweener = null;
    Tweener m_posXTweener = null;
    Tweener m_posYTweener = null;
    Tweener m_posZTweener = null;

    Tweener m_rotXTweener = null;
    // -----------------------位移动画-------------------

    WorkMode m_WorkMode = WorkMode.Free;//当前工作模式，默认自由 

    //------------------------位移属性--------------------
    float m_CurrXOffset = 0;//当前x偏移值
    float m_CurrZOffset = 0;
    //float m_CurrXPos = 0;//当前x位移值

    PositionTransform m_OffsetTransform;
    public float m_Scale = 1;//当前缩放值
    public float m_YRotScale = 0.5f;//y轴旋转插值
    float m_ZOffset;
    float m_XOffset;

    float m_Height;
    float m_Rotation;

    private float m_CameraTurnaroundTime = 0;
    private float m_CameraTrnaroundSpeed = 0;
    private float m_TerrainCellBianchang = 0;
    private float m_CameraYAroundMin = 0;
    private float m_CameraYAroundMax = 0;
    private float m_FreeCamera_Scale_Speed = 0;

    private float m_Camera_YOffsetMax = 0;
    private float m_Camera_YOffsetMin = 0;
    private float m_Camera_RotationMax = 0;
    private float m_Camera_RotationMin = 0;
    private float m_Camera_ZOffsetMax = 0;
    private float m_Camera_ZOffsetMin = 0;
    private float m_Camera_XOffsetMax = 0;
    private float m_Camera_XOffsetMin = 0;

    private float m_Camera_Overall_Zoffset = 0;
    private float m_Camera_Overall_Yoffset = 0;
    private float m_Camera_Overall_Yrotate = 0;
    private float m_Camera_Overall_Xrotate = 0;
    //------------------------位移属性--------------------

    public bool istuiguan = false;

    //int m_FocusHeroDataID = 0;
    //bool m_FocusIsAttack = false;
    //bool m_HasTrackPos3d = false;
    bool m_FocusObjChanged = false;
    Vector3 m_TrackPos3d;//演员3d位置
    float m_ActorDirX;//演员当前的X朝向
    bool m_EnabledTouch = true;
    bool m_EnabledScale = true;
    bool m_EnabledRot = true;


}