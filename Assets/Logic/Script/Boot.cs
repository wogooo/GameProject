﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using QKSDK;
public class Boot : MonoBehaviour
{

    void Awake()
    {
        ////sdk登录入口  将来特种部队可以改成自己的sdk
        //SDKInstance.SetSDKListener(GameQKSDKListener.Single);
    }


    // Use this for initialization
    void Start()
    {
        //配置模块列表
        List<IModule> modules = new List<IModule>();
        modules.Add(new Module_U3DEX());
        modules.Add(new Module_NGui());
        //modules.Add(new Module_UniLua());
        //modules.Add(new Module_NGuiLua());
        modules.Add(new Module_OOSyncClient());
        //modules.Add(new Module_OOSyncClientLua());
        //modules.Add(new Module_DOTweenLua());
        modules.Add(new Module_ulua());

        //初始化模块
        U3DEX u3dex = gameObject.AutoInstance<U3DEX>();
        u3dex.Go(modules, InitDone);

    }

    /// <summary>
    /// 模块初始化完成
    /// </summary>
    void InitDone()
    {
        StartCoroutine(coInitDone());
    }

    IEnumerator coInitDone()
    {
        //初始化内核级窗体
        {
            //new wnd_MsgBox();
            //new wnd_poptip();
            //new wnd_update();
        }

        //注册逻辑层脚本接口 
        {
            //LuaLogicOpenLibs.OpenLibs(LuaRoot._Lua);
        }


        if (GameConfig.Single.IsDev)//调试模式，显示等待远程调试器连接界面
        {
            //ULDebug.Log("调试模式");
            //new wnd_waitdebugger();
            //wnd_waitdebugger.Single.OnGoClick = CallLogicScript;
            //wnd_waitdebugger.Single.Show(Wnd.DefaultDuration);
            CallLogicScript();
        }
        else
        {
            //编辑器模式下禁用自动更新
            //#if !UNITY_EDITOR
            //等待更新结束
            //ULDebug.Log("热更新开始");
            IEnumerator co = wnd_update.Single.Go();
            while (co.MoveNext()) yield return null;
            //#endif
            //执行逻辑脚本
            CallLogicScript();
        }

        yield break;
    }


    void CallLogicScript()
    {
        //lua逻辑入口
        //LuaRoot.DoFile("_libmain");
        //LuaRoot.DoFile("main");

        AppFacade.Instance.StartUp();   //启动游戏
        Application.targetFrameRate = 30;
    }
}
