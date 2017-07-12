﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


/// <summary>
/// 追击状态检测
/// </summary>
public class ZhuiJiTrigger : SoldierFSMTrigger
{

    /// <summary>
    /// 初始化
    /// </summary>
    public override void Init()
    {
        triggerId = SoldierTriggerID.ZhuiJi;
    }


    /// <summary>
    /// 检测条件
    /// </summary>
    /// <param name="fsm"></param>
    /// <returns></returns>
    public override bool CheckTrigger(SoldierFSMSystem fsm)
    {
        switch (fsm.CurrentStateID)
        {
            // 行进切追击
            case SoldierStateID.Xingjin:
            {
                // 如果正在技能攻击或普通攻击则不进入追击状态
                if (fsm.IsCanInJinenggongji || fsm.IsCanInPutonggongji)
                {
                    return false;
                }
                var clusterData = fsm.Display.ClusterData;
                //var objId = clusterData.MemberData.ObjID;
                // 视野范围内是否有敌人
                var pos = new Vector2(clusterData.X, clusterData.Y);
                // 范围内符合阵营条件的单位列表
                var scopeMemberList = ClusterManager.Single.CheckRange(pos, clusterData.AllData.MemberData.SightRange,
                    clusterData.AllData.MemberData.Camp, true);
                // 按照权重与是否可攻击单位选择
                var filtedlist = TargetSelecter.Single.TargetFilter(clusterData, scopeMemberList);
                Utils.DrawGraphics(new CircleGraphics(pos, clusterData.AllData.MemberData.SightRange), Color.yellow);
                //fsm.Display.ClusterData.MemberData.SightRange
                if (filtedlist.Count > 0)
                {
                    // 追击目标
                    // 设置状态 切追击状态
                    fsm.IsZhuiJi = true;
                    return SetTarget(fsm, filtedlist);
                }

                return fsm.IsZhuiJi;
            }
        }

        return false;
    }


    /// <summary>
    /// 设置目标单位
    /// </summary>
    /// <param name="fsm"></param>
    /// <param name="res"></param>
    /// <returns></returns>
    private bool SetTarget(SoldierFSMSystem fsm, IList<PositionObject> res)
    {
        var ran = new System.Random();
        // TODO 取最近的
        var target = res[ran.Next(0, res.Count)];
        fsm.EnemyTarget = DisplayerManager.Single.GetElementByPositionObject(target);
        return res.Count > 0;
    }
}