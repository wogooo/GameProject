﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//协程管理器
public class CoroutineManage : MonoBehaviour
{
    public delegate void IUpdate();
    public static void AutoInstance()
    {
        if (Single == null)
            UROMSystem.Single.AddComponent<CoroutineManage>();
    }

    public static CoroutineManage Single = null;
    //void OnEnable()
    public CoroutineManage()
    {
        Single = this;
    }

    public new void StartCoroutine(IEnumerator it)
    {
        base.StartCoroutine(it);
    }

    public void RegComponentUpdate(IUpdate iupdate)
    {
        m_NeedRemove.Remove(iupdate);
        m_NeedAdd.Add(iupdate);
    }

    public void UnRegComponentUpdate(IUpdate iupdate)
    {
        m_NeedAdd.Remove(iupdate);
        m_NeedRemove.Add(iupdate);
    }

    public void Update()
    {
        //调用update委托 
        foreach (IUpdate curr in m_UpdateDelegates)
            curr();

        //加入update委托
        {
            foreach (IUpdate curr in m_NeedAdd) m_UpdateDelegates.Add(curr);

            m_NeedAdd.Clear();
        }

        //删除已经无效的update委托
        {
            foreach (IUpdate curr in m_NeedRemove) m_UpdateDelegates.Remove(curr);

            m_NeedRemove.Clear();
        }

        //执行MonoEX的协程
        MonoEX.CoroutineManage.Single.ProcessCoroutines();
        // if (U3DEXRoot.ScripteSystem != null)  U3DEXRoot.ScripteSystem.Update();

    }

    HashSet<IUpdate> m_NeedRemove = new HashSet<IUpdate>();
    HashSet<IUpdate> m_UpdateDelegates = new HashSet<IUpdate>();
    HashSet<IUpdate> m_NeedAdd = new HashSet<IUpdate>();
}
