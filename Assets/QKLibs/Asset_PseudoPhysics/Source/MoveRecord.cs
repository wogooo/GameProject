﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 运动位置记录
/// </summary>
public class MoveRecord
{
    public void Clear(Vector3 origin)
    {
        m_origin = m_currentPos = origin;
        m_MoveNodes.Clear();
        m_MoveNodes.Add(new MoveInfo() { pos = m_origin, time = Time.time });
    }

    public void JumpTo(Vector3 pos)
    {
        m_currentPos = pos;
        m_MoveNodes.Add(new MoveInfo() { pos = pos, time = Time.time });
    }


    public Vector3 CurrentPos { get { return m_currentPos; } set { m_currentPos = value; } }

    public Vector3 TotalOffset { get { return m_currentPos - m_origin; } }

    /// <summary>
    /// 获取惯性速度
    /// </summary>
    public Vector3 GetInertiaSpeed(float validTime)
    {
        int count = m_MoveNodes.Count;
        if (count < 2) return Vector3.zero;//没有移动过

        float now = Time.time;

        List<KeyValuePair<float, Vector3>> l = new List<KeyValuePair<float, Vector3>>();//权重，速度
        float sumq = 0;//总权重

        for (int i = count - 1; i > 0; i--)
        {
            int i2 = i - 1;
            MoveInfo b = m_MoveNodes[i2];
            MoveInfo e = m_MoveNodes[i];

            float tspan = now - e.time;
            if (tspan >= validTime) break;

            float nspan = e.time - b.time;
            if (nspan == 0) nspan = 0.001f;

            Vector3 speed = (e.pos - b.pos) / nspan;
            float q = 1f - Mathf.Clamp(tspan, 0, validTime) / validTime;
            l.Add(new KeyValuePair<float, Vector3>(q, speed));
            sumq += q;
        }

        Vector3 re = Vector3.zero;
        foreach (KeyValuePair<float, Vector3> curr in l)
        {
            float q = curr.Key;//权重
            Vector3 sp = curr.Value;//速度
            re += sp * (q / sumq);
        }

        return re;
    }

    struct MoveInfo
    {
        public Vector3 pos;
        public float time;
    }

    Vector3 m_origin;
    Vector3 m_currentPos;
    List<MoveInfo> m_MoveNodes = new List<MoveInfo>();

}