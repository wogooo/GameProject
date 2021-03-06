﻿using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Xml;
using DG.Tweening;

class wnd_fight : wnd_base
{
    public const string ResName = "ui_fight";
    public wnd_fight()
        : base(ResName)
    {
        WndManage.Single.RegWnd(ResName, "ui_fight",15, WndFadeMode.Alpha, WndAnimationMode.situ);
        Single = this; 
    }
    protected override void OnLostInstance()
    {
        EagleEyeMap = null;
        m_IsInitd = false;
        HeroSelectframe = null;
        //解除事件绑定
        {
            var ptzCamera = GameObject.Find("PTZCamera");

            var posTransform = ptzCamera.GetComponent<PositionTransform>();
            posTransform.OnValueChanged -= OnCameraPosChanged;

            var rotationTransform = ptzCamera.GetComponent<RotationTransform>();
            rotationTransform.OnValueChanged -= OnCameraRotation;
        }

        RemoveCountDownTweener();
    }

    public void SetSelectHero(GameObject uihero)
    { 
        HeroSelectframe.SetActive(uihero != null);

        if (uihero != null)
        {
            HeroSelectframe.transform.parent = uihero.transform;
            HeroSelectframe.transform.localPosition = Vector3.zero;
        } 
    }

    protected override void OnNewInstance()
    {
        var ptzCamera = GameObject.Find("PTZCamera");

        GameObject view = m_instance.FindWidget("radar_mid/radar_view");
        EagleEyeMap = view.GetComponent<UIEagleEyeMap>();
        EagleEyeMap.WorldCamera = ptzCamera.transform.Find("SceneryCamera").GetComponent<Camera>();

        Vector2 WorldOrigin = new Vector2();
        Vector2 WorldSize = new Vector2();

        int mapHeight = SData_mapdata.Single.GetDataOfID(1).MapMaxRow + 5;//+ DiamondGridMap.SideSize * 2
        DiamondGridMap.Grid2World(mapHeight, DiamondGridMap.SideSize, -DiamondGridMap.SideSize*2 , out WorldOrigin.x, out WorldOrigin.y);

        DiamondGridMap.Grid2World(
            mapHeight,
            SData_mapdata.Single.GetDataOfID(1).MapMaxColumn + DiamondGridMap.SideSize, SData_mapdata.Single.GetDataOfID(1).MapMaxRow,
            out WorldSize.x, out WorldSize.y
            );

        PauseWidget = m_instance.FindWidget("pause_widget");

        RadarHeroHead = m_instance.FindWidget("radar_widget/head_widget").GetComponent<UIWidget>();


        var kills_widget = m_instance.FindWidget("kills_widget");
        for (int i = 1; i <= 5; i++)
            UIKills[i-1] = kills_widget.transform.FindChild(i.ToString() + "kill").gameObject;

        WorldSize.x -= WorldOrigin.x;
        WorldSize.y -= WorldOrigin.y;

        EagleEyeMap.WorldOrigin = WorldOrigin;
        EagleEyeMap.WorldSize = WorldSize;
        EagleEyeMap.SetWorldRectChanged();

        //绑定云台相机变换事件
        var posTransform = ptzCamera.GetComponent<PositionTransform>();
        posTransform.OnValueChanged += OnCameraPosChanged;

        var rotationTransform = ptzCamera.GetComponent<RotationTransform>();
        rotationTransform.OnValueChanged += OnCameraRotation;

        // 绑定雷达点击事件
        GameObject radarView = m_instance.FindWidget("radar_widget/content/radar_mid/radar_view");
        UIEventListener.Get(radarView).onClick += OnRadarClick;
        UIEventListener.Get(radarView).onDrag += OnRadarDrag;

        //连斩相关
        var num_widget_txt = m_instance.FindWidget("num_widget/txt");
        var tween_widget_txt = m_instance.FindWidget("tween_widget/txt");
        var tween_widget = m_instance.FindWidget("tween_widget");
        var combo_widget = m_instance.FindWidget("combo_widget");

        HeroSelectframe = m_instance.FindWidget("content/selectframe");

        var AvatarTextureObj = m_instance.FindWidget("grain");
        CMAvatarTexture = AvatarTextureObj.GetComponent<UITexture>();


        var cutin_widgetObj = m_instance.FindWidget("cutin_widget");
        var grainfx = GameObjectExtension.FindChild(cutin_widgetObj.transform, "fx");

         
        AvatarTextureTweens = cutin_widgetObj.GetComponents<UITweener>();
        AvatarFXTweens = grainfx.GetComponents<UITweener>();



        LianZhan_num_widgetLabel = num_widget_txt.GetComponent<UILabel>();
        LianZhan_tween_widgetLabel = tween_widget_txt.GetComponent<UILabel>();
        LianZhan_Tweens = tween_widget.GetComponents<UITweener>();
        LianZhan_Tween = combo_widget.GetComponent<UITweener>();

        mb_zhuiguang_fx = m_instance.FindWidget("zhuiguang_fx");
        mb_zhuiguang_fx.SetActive(false);

        
    }

    public void AddKillHero()
    {
        if(!m_IsFightAIEnd)
        {
            int count = 0;//活动的tween数量
            foreach(var curr in KillHeroTweens)
            {
                if (curr.startTime + curr.duration > Time.time)
                    count++;
            }
            var yoffset = count * 50;

            var gameObj = UIKills[m_KillCount];
            gameObj.SetActive(true);
            var twneener = gameObj.GetComponents<UITweener>();
            foreach (var curr in twneener)
            {
               
                if(curr.tweenGroup==1)
                {
                    var posTween = curr as TweenPosition;
                    if(posTween!=null)
                    {
                        var oldPos = posTween.from ;
                        oldPos.y -= yoffset;
                        posTween.from = oldPos;

                        oldPos = posTween.to;
                        oldPos.y -= yoffset;
                        posTween.to = oldPos;
                    }
                }

                curr.ResetToBeginning();
                curr.PlayForward();


                KillHeroTweens.Add(new KillHeroTween() {  duration= curr.duration, startTime = Time.time}); 
            }
        }
        m_KillCount++;
    }



    UITweener[] AvatarFXTweens;
    UITweener[] AvatarTextureTweens;
    //GameObject AvatarTextureObj;
    UILabel LianZhan_num_widgetLabel;
    UILabel LianZhan_tween_widgetLabel;
    UITweener[] LianZhan_Tweens;
    UITweener LianZhan_Tween;
    GameObject HeroSelectframe;
    GameObject[] UIKills = new GameObject[5];
    public GameObject mb_zhuiguang_fx;//追光效果模板
    public UITexture CMAvatarTexture;
    public void ShowAvatarTexture()
    {
        //AvatarTextureObj.SetActive(true);
        foreach(var tween in AvatarFXTweens)
        {
            tween.ResetToBeginning();
            tween.PlayForward();
        }

        foreach (var tween in AvatarTextureTweens)
        {
            tween.ResetToBeginning();
            tween.PlayForward();
        } 
    }

    public void HideAvatarTexture(Vector3 targetPos)
    {
        foreach (var tween in AvatarTextureTweens)
        {
            tween.ResetToBeginning();
            tween.PlayReverse();
        } 
        

        if (targetPos != Vector3.zero)
        {
            //创建一个追光效果，并渐移到目标位置
            var zhuiguangObj = GameObject.Instantiate(mb_zhuiguang_fx);
            zhuiguangObj.name = "zhuiguangFX";
            zhuiguangObj.transform.position = mb_zhuiguang_fx.transform.position;
            zhuiguangObj.transform.rotation = mb_zhuiguang_fx.transform.rotation;
            zhuiguangObj.transform.localScale = mb_zhuiguang_fx.transform.localScale;
            zhuiguangObj.SetActive(true);
            zhuiguangObj.transform.DOMove(targetPos, 0.5f);
            GameObject.Destroy(zhuiguangObj, 0.52f);
        }
    }

    public void OnLianzhanChanged(int newV)
    {
       LianZhan_tween_widgetLabel.text = LianZhan_num_widgetLabel.text = newV.ToString();
        foreach(var tween in LianZhan_Tweens)
        {
            tween.ResetToBeginning();
            tween.PlayForward(); 
        }

        LianZhan_Tween.ResetToBeginning();
        LianZhan_Tween.PlayForward(); 
    }

	void OnRadarDrag (GameObject ob, Vector2 delta)
	{
		/*
		 * 	
			|y
			|    
			|	
			|	屏幕区域
			|   
			|------------x
			(0.0)
		*/
		// 点击的屏幕位置
		Vector3 touchPos = Input.mousePosition;

		/*
			P1				P2


			P0				P3
		*/
		// 雷达在屏的区域 
		UIWidget view = ob.GetComponent<UIWidget> ();
		Vector3[] p = view.worldCorners;
		for (int i = 0; i < p.Length; ++i)
		{
			p[i] = UICamera.currentCamera.WorldToScreenPoint(p[i]);
		}

		// 雷达在屏幕的大小
		Vector2 viewSize = new Vector2(p[3].x - p[0].x,p[1].y - p[0].y);

		// UV
		Vector2 uv = new Vector2((touchPos.x - p[1].x)/viewSize.x,(touchPos.y - p[1].y)/viewSize.y);

		// 通过雷达UV获取世界位置
		Vector3 wordPos = EagleEyeMap.GetWordPositionByUV (uv.x, uv.y);


		// 测试点击位置
		//EagleEyeMap.AddActor(wordPos.x ,wordPos.z,20,30,"army",Color.green,false,1);

		// 移动相机
        YQ2CameraCtrl.Single.JumpToWorldPos(wordPos.x,wordPos.z );
	}

	void OnRadarClick(GameObject ob)
	{

		/*
		 * 	
			|y
			|    
			|	
			|	屏幕区域
			|   
			|------------x
			(0.0)
		*/
		// 点击的屏幕位置
		Vector3 touchPos = Input.mousePosition;

		/*
			P1				P2


			P0				P3
		*/
		// 雷达在屏的区域 
		UIWidget view = ob.GetComponent<UIWidget> ();
		Vector3[] p = view.worldCorners;
		for (int i = 0; i < p.Length; ++i)
		{
			p[i] = UICamera.currentCamera.WorldToScreenPoint(p[i]);
		}

		// 雷达在屏幕的大小
		Vector2 viewSize = new Vector2(p[3].x - p[0].x,p[1].y - p[0].y);

		// UV
		Vector2 uv = new Vector2((touchPos.x - p[1].x)/viewSize.x,(touchPos.y - p[1].y)/viewSize.y);

		// 通过雷达UV获取世界位置
		Vector3 wordPos = EagleEyeMap.GetWordPositionByUV (uv.x, uv.y);


		// 测试点击位置
		//EagleEyeMap.AddActor(wordPos.x ,wordPos.z,20,30,"army",Color.green,false,1);

		// 移动相机
        YQ2CameraCtrl.Single.JumpToWorldPos(wordPos.x, wordPos.z);
	}

    void RemoveCountDownTweener()
    {
        if (CountDownTweener != null && CountDownTweener.IsActive()) CountDownTweener.Kill();
    }

    

    //相机位置变化
    void OnCameraPosChanged(PositionTransform self)
    {
        EagleEyeMap.SetVisualFieldChanged();
    }

    protected override void OnShowfinish() {
        //隐藏掉界面
        GameObject radar_widget = m_instance.FindWidget("radar_widget");
        radar_widget.transform.parent.gameObject.SetActive(false);

        PauseWidget.SetActive(false); //隐藏倒计时面板

        HeroSelectframe.SetActive(false);//隐藏头像选择框
        m_IsInitd = true;
    }

    public void Reset()
    {
        m_IsInitd = false; 
        if ( EagleEyeMap != null) EagleEyeMap.Clear();
        RemoveCountDownTweener();
        m_IsFightAIEnd = false;
        m_KillCount = 0;
        KillHeroTweens.Clear();
    }

    //相机旋转值变化
    void OnCameraRotation(RotationTransform self)
    {
        EagleEyeMap.SetVisualFieldChanged();
    }

    public bool IsInitd { get { return m_IsInitd; } }

    public UIWidget RadarHeroHeadMB { get { return RadarHeroHead; } }

    UIWidget RadarHeroHead;
    GameObject PauseWidget;//倒计时显示隐藏控制
    public UIEagleEyeMap EagleEyeMap;
    public static wnd_fight Single = null;
    Tweener CountDownTweener;//倒计时tweener
    bool m_IsInitd = false;
    bool m_IsFightAIEnd = false;
    short m_KillCount;
    List<KillHeroTween> KillHeroTweens = new List<KillHeroTween>();
    class KillHeroTween
    {
        public float duration;
        public float startTime;
    }
} 
 