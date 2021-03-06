﻿using UnityEngine;
using System.Collections;
/// <summary>
/// 战斗单元的工厂类 主要提供给ulua逻辑 创建战斗对象
/// </summary>
public class FightUnitFactory {


    public static DisplayOwner CreateUnit(int unitType, CreateActorParam otherParam)
    {
        VOBase vo = new VOBase();
        switch (unitType)
        {
            case (int)ObjectID.ObjectType.MyJiDi:
                vo = new JiDiVO();
                vo.ObjID = new ObjectID(ObjectID.ObjectType.MyJiDi);
                break;
            case (int)ObjectID.ObjectType.EnemyJiDi:
                vo = new JiDiVO();
                vo.ObjID = new ObjectID(ObjectID.ObjectType.EnemyJiDi);
                break;
            case (int)ObjectID.ObjectType.MySoldier:
                vo = new FightVO();
                vo.ObjID = new ObjectID(ObjectID.ObjectType.MySoldier);
                break;
            case (int)ObjectID.ObjectType.EnemySoldier:
                vo = new FightVO();
                vo.ObjID = new ObjectID(ObjectID.ObjectType.EnemySoldier);
                break;
            case (int)ObjectID.ObjectType.MyTower:
                vo = new TurretVO();
                vo.ObjID = new ObjectID(ObjectID.ObjectType.MyTower);
                break;
            case (int)ObjectID.ObjectType.EnemyTower:
                vo = new TurretVO();
                vo.ObjID = new ObjectID(ObjectID.ObjectType.EnemyTower);
                break;
            case (int)ObjectID.ObjectType.MyTank:
                vo = null;
                break;
            case (int)ObjectID.ObjectType.EnemyTank:
                vo = null;
                break;
            case (int)ObjectID.ObjectType.MyObstacle:
                vo = null;
                break;
            case (int)ObjectID.ObjectType.EnemyObstacle:
                vo = null;
                break;
            case (int)ObjectID.ObjectType.NPCObstacle:
                vo = new VOBase();
                vo.ObjID = new ObjectID(ObjectID.ObjectType.NPCObstacle);
                break;
        }
        return DataManager.Single.Create(vo, otherParam);
    }


    /// <summary>
    /// 删除单位
    /// </summary>
    /// <param name="obj">被删除单位数据</param>
    public static void DeleteUnit(VOBase obj)
    {
        DataManager.Single.Delete(obj.ObjID);
        DisplayerManager.Single.DelDisplay(obj.ObjID);
    }
}
