﻿using UnityEngine;
using System.Collections.Generic;
using LuaInterface;
using System;
public class GameResFactory
{
    private static GameResFactory sInstance = null;
    public static GameResFactory Instance()
    {
        if (sInstance == null)
        {
            sInstance = new GameResFactory();
            sInstance.mResManager = AppFacade.Instance.GetManager<ResourceManager>();
        }
        return sInstance;
    }

    internal ResourceManager mResManager;
    private List<GameObject> mUIEffectsList = new List<GameObject>();
    public AssetPacker mAssetPacker = null;

    //private List<GameObject> mUIList = new List<GameObject>();
    //private Dictionary<string, GameObjectCache> mResCaches = new Dictionary<string, GameObjectCache>();

    public Texture2D GetGoFromPrefab(string spName)
    {
        return Resources.Load<Texture2D>("Item Icon/" + spName);
    }

    /////////////////结束/////////////////
    public void GetUIPrefab(string assetName, GameObject parent, LuaTable luaTable, LuaFunction luaCallBack)
    {
        if (mResManager == null) return;

        GameObject go = GameObjectExtension.InstantiateFromPacket(assetName, assetName + ".prefab", parent);
        go.name = assetName;
        go.layer = LayerMask.NameToLayer("UI");
        go.transform.SetParent(parent.transform, false);

        LuaBehaviour tmpBehaviour = go.AddComponent<LuaBehaviour>();
        tmpBehaviour.Init(luaTable);

        if (luaCallBack != null)
        {
            luaCallBack.BeginPCall();
            luaCallBack.Push(go);
            luaCallBack.PCall();
            luaCallBack.EndPCall();
        }
        //Debug.Log("CreatePanel::>> " + assetName + " " + prefab);
        //mUIList.Add(go);


        //mResManager.LoadPrefab("pack_res/ui_login", "ui_login", delegate(UnityEngine.Object[] objs)
        //    {
        //        if (objs.Length == 0) return;
        //        GameObject prefab = objs[0] as GameObject;
        //        if (prefab == null)
        //        {
        //            return;
        //        }
        //        GameObject go = UnityEngine.GameObject.Instantiate(prefab) as GameObject;
        //        go.name = assetName;
        //        go.layer = LayerMask.NameToLayer("UI");
        //go.transform.SetParent(parent, false);

        //        LuaBehaviour tmpBehaviour = go.AddComponent<LuaBehaviour>();
        //        tmpBehaviour.Init(luaTable);

        //        if (luaCallBack != null)
        //        {
        //            luaCallBack.BeginPCall();
        //            luaCallBack.Push(go);
        //            luaCallBack.PCall();
        //            luaCallBack.EndPCall();
        //        }
        //        Debug.Log("CreatePanel::>> " + assetName + " " + prefab);
        //        //mUIList.Add(go);
        //    });
    }

    public void DestroyUIPrefab(GameObject go)
    {
        GameObject.Destroy(go);
        //mUIList.Remove(go);
    }

    public void PrintArray(Vector3[] va)
    {
        LGYLOG.Log(va[0].x + "=====1");
        LGYLOG.Log(va[1].y + "=====2");
        LGYLOG.Log(va[2].z + "=====3");
    }

    protected void GetEffectObj(string effname, System.Action<GameObject> callBack)
    {
        //if (mResManager == null) return;
        //mResManager.LoadPrefab(effname, effname, delegate(UnityEngine.Object[] objs)
        //{
        //    if (objs.Length == 0) return;
        //    GameObject prefab = objs[0] as GameObject;
        //    if (prefab == null)
        //    {
        //        return;
        //    }
        //    GameObject go = GameObject.Instantiate(prefab) as GameObject;
        //    if (callBack != null)
        //    {
        //        callBack(go);
        //    }
        //});
    }

    //获取UI特效
    public void GetUIEffect(string effname, LuaFunction luaCallBack)
    {
        GetEffectObj(effname, (Obj) =>
        {
            if (Obj != null)
            {
                mUIEffectsList.Add(Obj);
            }
            if (luaCallBack != null)
            {
                luaCallBack.BeginPCall();
                luaCallBack.Push(Obj);
                luaCallBack.PCall();
                luaCallBack.EndPCall();
            }
        });
    }

    public void DestroyUIEffect(GameObject obj)
    {
        GameObject.Destroy(obj);
        //mUIEffectsList.Remove(obj);
    }

    public void DestroyAllUIEffect()
    {
        for (int i = mUIEffectsList.Count - 1; i >= 0; --i)
        {
            GameObject.Destroy(mUIEffectsList[i]);
        }
        mUIEffectsList.Clear();
    }
}
