﻿using UnityEngine;
using System.Collections.Generic;
using System;


/// <summary>
/// UI自适应组件
/// </summary>
[RequireComponent(typeof(Camera))]
[AddComponentMenu("QK/UI/UIAdaptation")]
class UIAdaptation : MonoBehaviour
{
    public static Camera UICameraIns;
    public static UnityEngine.Camera UICamera
    {
        get
        {
            if (UICameraIns == null)
            {
                UICameraIns = GameObject.Find("UIRoot/Camera_UI").GetComponent<Camera>();
            }
            return UICameraIns;
        }
    }
    void Update()
    {
        if (Screen.width != m_LastScreenWidth || Screen.height != m_LastScreenHeight)
        {
            m_LastScreenWidth = Screen.width;
            m_LastScreenHeight = Screen.height;
            gameObject.GetComponent<Camera>().rect = new Rect(0,0,1,1);//修正一不同的分辨率启动的时候，改变UICamera的Rect值
            float aspectRatio = (float)m_LastScreenWidth / (float)m_LastScreenHeight;

            float z = Ratio2Distance(aspectRatio);

            gameObject.transform.localPosition = new Vector3(0, 0, z);
            
        }
    }

    float Ratio2Distance(float aspectRatio)
    {
        if (aspectRatio <= m_RatioInfos[0].ratio)
            return m_RatioInfos[0].distance;
        else
        {
            for (int i = 0; i < m_RatioInfos.Length; i++)
            {
                if (aspectRatio >= m_RatioInfos[i].ratio && i + 1 < m_RatioInfos.Length && aspectRatio <= m_RatioInfos[i + 1].ratio)
                {
                    RatioInfo cInfo = m_RatioInfos[i];

                    if (i + 1 < m_RatioInfos.Length)
                    {
                        RatioInfo nInfo = m_RatioInfos[i + 1];
                        float xs = (aspectRatio - cInfo.ratio) / (nInfo.ratio - cInfo.ratio);
                        return Mathf.Lerp(cInfo.distance, nInfo.distance, xs);
                    }
                    else
                        return cInfo.distance;
                }
            }
        }
        
        return m_RatioInfos[m_RatioInfos.Length - 1].distance;

    }

    class RatioInfo
    {
        public RatioInfo(float ratio, float distance)
        {
            this.ratio = ratio;
            this.distance = distance;
        }

        public float ratio;//横纵比
        public float distance;//相机距离
    }

    RatioInfo[] m_RatioInfos = new RatioInfo[]{
         //new RatioInfo(1,-1156f),//1:1   
         //new RatioInfo(1.25f,-925f),//5:4  
         //new RatioInfo(1.333333333f,-867f), //4:3    
         //new RatioInfo(1.5f,-770f),//960:640 
         //new RatioInfo(1.6f,-723f),//16:10   
         //new RatioInfo(1.775f,-650f), //1136:640 
         //new RatioInfo(1.777777778f,-650f),//16:9 1280:720 1920:1080 2560:1440 

         new RatioInfo(1,-985f),//1:1   
         new RatioInfo(1.25f,-788f),//5:4  
         new RatioInfo(1.333333333f,-738), //4:3    
         new RatioInfo(1.5f,-656f),//960:640 
         new RatioInfo(1.6f,-615f),//16:10   
         new RatioInfo(1.775f,-554f), //1136:640 
         new RatioInfo(1.777777778f,-553f),//16:9 1280:720 1920:1080 2560:1440 
    };

    int m_LastScreenWidth = -1;
    int m_LastScreenHeight = -1;
}
