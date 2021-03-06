﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;  
class wnd_waitdebugger:wnd_base
{
    public const string DependPacks = "rom_upd;rom_share";//依赖包
    public const string ResName = "ui_waitdebugger"; //包中资源名
    public delegate void onGoClick();

    public onGoClick OnGoClick = null;

    public wnd_waitdebugger()
        : base(ResName)
    {
        WndManage.Single.RegWnd(ResName, DependPacks,  15, WndFadeMode.Alpha, WndAnimationMode.situ);
        Single = this;
    }

    void OnBtnClick(GameObject go)
    {
        CallLogicScript();
        Hide(Wnd.DefaultDuration);
    }

      
      void CallLogicScript()
    {
        if (OnGoClick != null) OnGoClick(); 
    }
     


    protected override void OnLostInstance()
    {

    }

    protected override void OnNewInstance()
    {
        GameObject btn = m_instance.FindWidget("btn");
        UIEventListener listener = UIEventListener.Get(btn);
        listener.onClick = OnBtnClick;
    }

 
    public static wnd_waitdebugger Single = null; 
}
 
/*
 


    public const string ui_lock = "ui_lock";
    public const string ui_poptip = "ui_poptip";
    public const string ui_msgbox = "ui_msgbox";
    public const string ui_update = "ui_update";
   
 //初始化各种基础窗体
        new wnd_update(); 
        new wnd_MsgBox();
        new wnd_poptip(); 
        wnd_poptip.Single.Show(0);//立即显示poptip窗体

  //注册内核级界面
        RegWnd(Wnd.ui_update, "rom_upd;rom_share", 0,15,WndFadeMode.Alpha, WndAnimationMode.situ);
      
        RegWnd(Wnd.ui_msgbox, "rom_share", 9990, 15, WndFadeMode.ScaleAlpha, WndAnimationMode.situ);

        //UIFlyManage 9995
        //UIDragDropRoot 9998
        RegWnd(Wnd.ui_lock, "rom_share", 9999, 60, WndFadeMode.Alpha, WndAnimationMode.situ);
        RegWnd(Wnd.ui_poptip, "rom_share", 10000, -1, WndFadeMode.None, WndAnimationMode.situ);
        
 */