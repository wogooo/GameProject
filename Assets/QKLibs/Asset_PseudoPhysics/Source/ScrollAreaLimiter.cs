﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[AddComponentMenu("QK/PseudoPhysics/ScrollAreaLimiter")]
public class ScrollAreaLimiter : MonoBehaviour
{

    public Bounds Area = new Bounds(Vector3.zero, new Vector3(10, 10, 10));
    public Bounds SoftArea = new Bounds(Vector3.zero, new Vector3(12, 12, 12));
    public Color GizmosCubeColor = Color.red;
    public Color GizmosSoftCubeColor = new Color(0.5f, 0, 0.5f);
    public float Damped = 0.3f;//阻尼
    public float Inertia = 0.5f;//惯性
    public float InertiaTimeLimit = 0.5f;//惯性时间限制/秒
    public float ReboundVelocity = 2f;//回弹速度
    void OnDrawGizmos()
    {
        //弹性范围，不能小于限制区域
        {
            Vector3 softmin, softmax;
            softmin = SoftArea.min;
            softmax = SoftArea.max;

            Vector3 areamin, areamax;
            areamin = Area.min;
            areamax = Area.max;

            bool needChangeMin = false;
            bool needChangeMax = false;

            if (areamin.x < softmin.x) { softmin.x = areamin.x; needChangeMin = true; }
            if (areamin.y < softmin.y) { softmin.y = areamin.y; needChangeMin = true; }
            if (areamin.z < softmin.z) { softmin.z = areamin.z; needChangeMin = true; }

            if (areamax.x > softmax.x) { softmax.x = areamax.x; needChangeMax = true; }
            if (areamax.y > softmax.y) { softmax.y = areamax.y; needChangeMax = true; }
            if (areamax.z > softmax.z) { softmax.z = areamax.z; needChangeMax = true; }

            if (needChangeMin) SoftArea.min = softmin;
            if (needChangeMax) SoftArea.max = softmax;
        }


        Gizmos.color = GizmosCubeColor;
        Gizmos.DrawWireCube(transform.position + Area.center, Area.size);

    }

    /// <summary>
    /// 判定某滚动物体是否在区域内
    /// </summary>
    //public bool AreaContains(ScrollObject obj) { return AreaContains(obj.ScrollViewPosition, obj.bounds); }

    /// <summary>
    /// 某包围盒是否完全在本区域内
    /// </summary>
    public bool AreaContains(Vector3 position, Bounds bounds)
    {
        Vector3 min, max; Bounds2Local(position, bounds, out   min, out   max);
        return LocalContains(Area, CalculateBoundsVertexs(min, max));
    }




    /// <summary>
    /// 获取一个滚动物体在区域内的位置。
    /// 如果物体不在区域内，则获取将物体以最短距离挪动到区域内后的位置
    /// </summary>
    public bool GetInAreaPosition(Vector3 objPos, ScrollObject obj, out Vector3 pos)
    {
        Vector3 min, max; Bounds2Local(objPos, obj.bounds, out   min, out   max);
        Vector3[] boundsVertexs = CalculateBoundsVertexs(min, max);
        if (LocalContains(Area, boundsVertexs))//滚动物体没有超出范围
        {
            pos = objPos;
            return true;
        }

        //处理滚动物体超出范围的情况
        Vector3 moveDistance = Vector3.zero;
        foreach (Vector3 v in boundsVertexs)
        {
            if (!Area.Contains(v))//该点超出范围
            {
                Vector3 n = Area.ClosestPoint(v);//将该点限制在范围内
                Vector3 offset = n - v;//移动进包围盒偏移量
                if (Math.Abs(offset.x) > Math.Abs(moveDistance.x)) moveDistance.x = offset.x;
                //if (Math.Abs(offset.y) > Math.Abs(moveDistance.y)) moveDistance.y = offset.y;
                //if (Math.Abs(offset.z) > Math.Abs(moveDistance.z)) moveDistance.z = offset.z;
            }
        }
        pos = objPos + moveDistance;
        return false;
    }

    bool LocalContains(Bounds localBounds, Vector3[] otherBoundsVertexs)
    {
        int len = otherBoundsVertexs.Length;

        for (int i = 0; i < len; i++) if (!localBounds.Contains(otherBoundsVertexs[i])) return false;

        return true;
    }

    /// <summary>
    /// 生成包围盒顶点列表
    /// </summary> 
    /// <returns></returns>
    Vector3[] CalculateBoundsVertexs(Vector3 min, Vector3 max)
    {
        return new Vector3[]{
            //min,
            //max,
            //new Vector3(max.x, min.y, min.z),
            //new Vector3(max.x, max.y, min.z),
            //new Vector3(min.x, max.y, min.z),
            //new Vector3(min.x, min.y, max.z),
            //new Vector3(max.x, min.y, max.z),
            new Vector3(min.x, max.y, max.z)
        };
    }

    void Bounds2Local(Vector3 position, Bounds bounds, out Vector3 min, out Vector3 max)
    {
        Vector3 offset = position - transform.position;//计算和区域之间的相对偏移量
        min = offset + bounds.min;
        max = offset + bounds.max;
    }
}