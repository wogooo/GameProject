﻿using UnityEngine;
using System.Collections;

public class Soldier_JinengGongji_State : SoldierFSMState
{

    public override void Init()
    {
        StateID = SoldierStateID.JinengGongji;
    }

    public override void DoBeforeEntering(SoldierFSMSystem fsm)
    {
        Debug.Log("技能攻击:" + fsm.Display.GameObj.name);
        // 单位转向目标
        var clusterData = fsm.Display.ClusterData as ClusterData;
        if (clusterData != null)
        {
            clusterData.RotateToWithoutYAxis(fsm.EnemyTarget.ClusterData.transform.position);
        }
    }

    public override void Action(SoldierFSMSystem fsm)
    {
        // TODO 持续技能
        // fsm 中带技能
        if (fsm.IsCanInJinenggongji && fsm.EnemyTarget.ClusterData != null && fsm.EnemyTarget.GameObj != null)
        {
            SkillManager.Single.DoSkillInfo(fsm.Skill, FormulaParamsPackerFactroy.Single.GetFormulaParamsPacker(fsm.Skill,
                fsm.Display,
                fsm.EnemyTarget));

            fsm.IsCanInJinenggongji = false;
            fsm.Skill = null;
            // 切换状态到行进状态
            fsm.TargetIsLoseEfficacy = true;
            fsm.EnemyTarget = null;
        }
    }

    public override void DoBeforeLeaving(SoldierFSMSystem fsm)
    {
        //Debug.Log("技能攻击结束");
    }
}