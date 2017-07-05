﻿using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// 待机状态 待机状态可以由入场状态切换而来
/// </summary>
public class Soldier_Daiji_State : SoldierFSMState {
    public override void Init()
    {
        StateID = SoldierStateID.DaiJi;
    }

    public override void Action(SoldierFSMSystem fsm)
    {
        
    }

}
