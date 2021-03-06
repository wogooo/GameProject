﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using DG.Tweening;

#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// 滚动对象
/// </summary>
[RequireComponent(typeof(TransformMixer))]
[ExecuteInEditMode]
public abstract class ScrollObject : MonoBehaviour
{
    public Color GizmosCubeColor = Color.green;
    public ScrollAreaLimiter Owner = null;
    //public string PositionTransformTag;//位置变换器tag

    /// <summary>
    /// 包围盒
    /// </summary>
    public abstract Bounds bounds { get; }

    public Vector3 ScrollViewPosition { get { return m_transformMixer.MainPositionTransform.Value; } }

    public Vector3 ScrollLogicPosition { get { return m_MoveRecord.CurrentPos; } }


    /// <summary>
    /// 绝对量瞬间跳转，无惯性
    /// </summary>
    public void JumpTo(Vector3 pos)
    {

        KillTween();


        Vector3 newPos;
        if (!Owner.GetInAreaPosition(pos, this, out newPos))
            m_transformMixer.MainPositionTransform.Value = newPos;
        else
            m_transformMixer.MainPositionTransform.Value = pos;

        m_MoveRecord.Clear(m_transformMixer.MainPositionTransform.Value);
    }

    /// <summary>
    /// 相对量瞬间跳转，无惯性
    /// </summary>
    public void JumpOffset(Vector3 offset)
    {
        JumpTo(m_MoveRecord.CurrentPos + offset);
    }

    /// <summary>
    /// 绝对量移动，有惯性
    /// </summary>
    public void MoveTo(Vector3 pos)
    {
        if (m_tw != null) m_tw.Kill();
        m_MoveRecord.JumpTo(pos);
        //计算显示位置
        Vector3 newPos;
        if (!Owner.GetInAreaPosition(pos, this, out newPos))//已经超出范围
        {
            float damped = (1f - Owner.Damped);

            Vector3 finalPos = pos;
            if (finalPos.x > newPos.x)
            {
                float outx = (finalPos.x - newPos.x);
                float outsoftx = Owner.SoftArea.max.x - Owner.Area.max.x;
                finalPos.x = newPos.x + Mathf.Clamp(Mathf.Sqrt(outx) * damped, 0, outsoftx);
            }

            //if (finalPos.y > newPos.y)
            //{
            //    float outy = (finalPos.y - newPos.y);
            //    float outsofty = Owner.SoftArea.max.y - Owner.Area.max.y;
            //    finalPos.y = newPos.y + Mathf.Clamp(Mathf.Sqrt(outy) * damped, 0, outsofty);
            //}

            //if (finalPos.z > newPos.z)
            //{
            //    float outz = (finalPos.z - newPos.z);
            //    float outsoftz = Owner.SoftArea.max.z - Owner.Area.max.z;
            //    finalPos.z = newPos.z + Mathf.Clamp(Mathf.Sqrt(outz) * damped, 0, outsoftz);
            //}

            if (finalPos.x < newPos.x)
            {
                float outx = (newPos.x - finalPos.x);
                float outsoftx = Owner.Area.min.x - Owner.SoftArea.min.x;
                finalPos.x = newPos.x - Mathf.Clamp(Mathf.Sqrt(outx) * damped, 0, outsoftx);
            }

            //if (finalPos.y < newPos.y)
            //{
            //    float outy = (newPos.y - finalPos.y);
            //    float outsofty = Owner.Area.min.y - Owner.SoftArea.min.y;
            //    finalPos.y = newPos.y - Mathf.Clamp(Mathf.Sqrt(outy) * damped, 0, outsofty);
            //}

            //if (finalPos.z < newPos.z)
            //{
            //    float outz = (newPos.z - finalPos.z);
            //    float outsoftz = Owner.Area.min.z - Owner.SoftArea.min.z;
            //    finalPos.z = newPos.z - Mathf.Clamp(Mathf.Sqrt(outz) * damped, 0, outsoftz);
            //}
            m_transformMixer.MainPositionTransform.Value = finalPos;
        }
        else
            m_transformMixer.MainPositionTransform.Value = pos;

    }

    /// <summary>
    /// 相对量移动，有惯性
    /// </summary>
    public void MoveOffset(Vector3 offset)
    {
        MoveTo(m_MoveRecord.CurrentPos + offset);
    }

    /// <summary>
    /// 运动结束,此时产生惯性
    /// </summary>
    public void MoveEnd(bool lockX = true, bool lockY = true, bool lockZ = true)
    {
        KillTween();

        Vector3 newPos;
        if (Owner.GetInAreaPosition(m_transformMixer.MainPositionTransform.Value, this, out newPos))//没有超出范围
        {
            Vector3 inertiaSpeed = m_MoveRecord.GetInertiaSpeed(0.5f) * Owner.Inertia;//惯性移动速度,非物理公式的模拟算法

            // 锁X轴滑动
            if (!lockX)
            {
                inertiaSpeed.x = 0;
            }
            // 锁Y轴滑动
            if (!lockY)
            {
                inertiaSpeed.y = 0;
            }
            // 锁Z轴滑动
            if (!lockZ)
            {
                inertiaSpeed.z = 0;
            }

            Vector3 ToPos = m_MoveRecord.CurrentPos + inertiaSpeed;

            if (!Owner.GetInAreaPosition(ToPos, this, out newPos)) //运动后超界 
                ToPos = newPos; //修正终止位置

            float spd = Vector3.Distance(inertiaSpeed, Vector3.zero);

            if (spd == 0)//惯性速度为0立即设置
            {
                TweenSetPos(ToPos);
                OnTweenKill();
            }
            else
            {
                float inertiaTime = Mathf.Min(spd / 2.0f, Owner.InertiaTimeLimit);

                m_tw = DOTween.To(() => m_transformMixer.MainPositionTransform.Value, TweenSetPos, ToPos, inertiaTime)
                   .SetAutoKill(true)
                   .SetRecyclable(false)
                   .SetEase(Ease.OutExpo)
                   .OnKill(() => OnTweenKill())
                   .OnComplete(() => OnTweenKill());
            }

        }
        else //已经超出范围
        {
            m_tw = DOTween.To(() => m_transformMixer.MainPositionTransform.Value, TweenSetPos, newPos, Vector3.Distance(m_MoveRecord.CurrentPos, newPos) / Owner.ReboundVelocity)
                   .SetAutoKill(true)
                   .SetRecyclable(false)
                   .SetEase(Ease.OutExpo)
                   .OnKill(() => OnTweenKill())
                   .OnComplete(() => OnTweenKill());
        }

    }

    void TweenSetPos(Vector3 pos)
    {
        m_transformMixer.MainPositionTransform.Value = pos;
        m_MoveRecord.Clear(pos);

    }

    void OnTweenKill()
    {
        m_MoveRecord.Clear(m_transformMixer.MainPositionTransform.Value);
        m_tw = null;
    }


#if UNITY_EDITOR
    public bool showHandles { get { return UnityEditor.Tools.current == UnityEditor.Tool.Rect; } }

    protected virtual void OnDrawGizmos()
    {
        Bounds bs = bounds;
        Gizmos.color = GizmosCubeColor;
        Gizmos.DrawWireCube(ScrollViewPosition + bs.center, bs.size);
    }
#endif
    protected virtual void Start()
    {
        m_transformMixer = GetComponent<TransformMixer>();
        m_MoveRecord.Clear(ScrollViewPosition);
    }


    void OnDestroy()
    {
        KillTween();
    }

    void KillTween()
    {
        if (m_tw != null) { m_tw.Kill(); m_tw = null; }
    }


    TransformMixer m_transformMixer = null;

    Tweener m_tw = null;

    public MoveRecord m_MoveRecord = new MoveRecord();
}
