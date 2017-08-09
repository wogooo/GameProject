﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// 生命值变动行为
/// </summary>
public class HealthChangeFormulaItem : AbstractFormulaItem
{

    /// <summary>
    /// 伤害/治疗类型
    /// </summary>
    public DemageOrCure DemageOrCure { get; set; }

    /// <summary>
    /// 生命值变动类型
    /// </summary>
    public HealthChangeType HealthChangeType { get; set; }

    /// <summary>
    /// 生命值变更目标
    /// 0: 自己
    /// 1: 目标
    /// </summary>
    public int HealthChangeTarget { get; set; }

    /// <summary>
    /// 生命值变动量
    /// </summary>
    public float Value { get; set; }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="array">数据数组</param>
    /// 
    /// 0>行为节点类型
    /// 1>特效Key(或path)
    /// 2>飞行速度
    /// 3>飞行方式(0抛物线, 1直线, 2 sin线
    /// 456>缩放
    public HealthChangeFormulaItem(string[] array)
    {
        if (array == null)
        {
            throw new Exception("数据列表为空");
        }
        var argsCount = 5;
        // 解析参数
        if (array.Length < argsCount)
        {
            throw new Exception("参数数量错误.需求参数数量:" + argsCount + " 实际数量:" + array.Length);
        }
        // 是否等待完成,特效Key,速度,飞行轨迹
        var formulaType = GetDataOrReplace<int>("FormulaType", array, 0, ReplaceDic);
        var healthChangeType = GetDataOrReplace<HealthChangeType>("HealthChangeType", array, 1, ReplaceDic);
        var demageOrCure = GetDataOrReplace<DemageOrCure>("DemageOrCure", array, 2, ReplaceDic);
        var healthChangeTarget = GetDataOrReplace<int>("HealthChangeTarget", array, 3, ReplaceDic);
        var value = GetDataOrReplace<float>("Value", array, 4, ReplaceDic);


        FormulaType = formulaType;
        HealthChangeType = healthChangeType;
        DemageOrCure = demageOrCure;
        HealthChangeTarget = healthChangeTarget;
        Value = value;
    }



    /// <summary>
    /// 获生命值变动行为节点
    /// </summary>
    /// <param name="paramsPacker"></param>
    /// <returns>生命值变动节点</returns>
    public override IFormula GetFormula(FormulaParamsPacker paramsPacker)
    {
        IFormula result = null;
        string errorMsg = null;
        if (paramsPacker == null)
        {
            errorMsg = "调用参数 paramsPacker 为空.";
        }
        else if (HealthChangeTarget != 0 && HealthChangeTarget != 1)
        {
            errorMsg = "目标标志错误, 应为0或1, 实际值:" + HealthChangeTarget;
        }
        else if ((paramsPacker.ReceiverMenber == null && HealthChangeTarget == 1) ||
            (paramsPacker.ReleaseMember == null))
        {
            errorMsg = "伤害/治疗目标对象为空.";
        }

        if (!string.IsNullOrEmpty(errorMsg))
        {
            throw new Exception(errorMsg);
        }

        // 替换数据
        ReplaceData(paramsPacker);
        // 数据本地化
        var myFormulaType = FormulaType;
        var myHealthChageType = HealthChangeType;
        var myDemageOrCure = DemageOrCure;
        var myValue = Value;
        var myHealthChangeTarget = HealthChangeTarget;
        var targetDisPlayOwner = myHealthChangeTarget == 0 ? paramsPacker.ReleaseMember : paramsPacker.ReceiverMenber;
        var myIsNotLethal = paramsPacker.IsNotLethal;

        // 创建行为节点
        result = new Formula((callback, scope) =>
        {
            // 验证数据
            if (targetDisPlayOwner.ClusterData == null)
            {
                return;
            }
            // 计算伤害/治疗量
            var changeValue = HurtResult.GetHurtForSkill(targetDisPlayOwner, myDemageOrCure, myHealthChageType, myValue);
            // targetDisPlayOwner.ClusterData.AllData.MemberData.CurrentHP += changeValue;
            // 创建伤害/治疗事件
            SkillManager.Single.SetTriggerData(new TriggerData()
            {
                HealthChangeValue = changeValue,
                ReceiveMember = paramsPacker.ReleaseMember,
                ReleaseMember = targetDisPlayOwner,
                TypeLevel1 = TriggerLevel1.Fight,
                TypeLevel2 = myDemageOrCure == DemageOrCure.Cure ? TriggerLevel2.BeCure : TriggerLevel2.BeAttack,
                IsNotLethal = myIsNotLethal,
                DemageType = DemageType.SkillAttackDemage
            });
            callback();
        }, myFormulaType);

        return result;
    }
}

/// <summary>
/// 伤害/治疗类型
/// </summary>
public enum DemageOrCure
{
    Demage = 0,         // 伤害
    Cure = 1            // 治疗
}

/// <summary>
/// 伤害类型
/// </summary>
public enum DemageType
{
    None = 0,
    NormalAttackDemage = 1,
    SkillAttackDemage = 2,
}

/// <summary>
/// 生命值变动类型
/// </summary>
public enum HealthChangeType
{
    Fixed = 0,          // 固定值
    Percentage = 1,     // 百分比
}