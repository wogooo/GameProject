﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class DP_FightPrefabManageWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(DP_FightPrefabManage), typeof(System.Object));
		L.RegFunction("Init", Init);
		L.RegFunction("InstantiateObject3D", InstantiateObject3D);
		L.RegFunction("ReLoad3DObjects", ReLoad3DObjects);
		L.RegFunction("CreateMat", CreateMat);
		L.RegFunction("New", _CreateDP_FightPrefabManage);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("ColorTab", get_ColorTab, set_ColorTab);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDP_FightPrefabManage(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				DP_FightPrefabManage obj = new DP_FightPrefabManage();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: DP_FightPrefabManage.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			DP_FightPrefabManage.Init();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InstantiateObject3D(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			UnityEngine.GameObject o = DP_FightPrefabManage.InstantiateObject3D(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReLoad3DObjects(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			DP_FightPrefabManage.ReLoad3DObjects();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateMat(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			bool arg0 = LuaDLL.luaL_checkboolean(L, 1);
			UnityEngine.Material o = DP_FightPrefabManage.CreateMat(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ColorTab(IntPtr L)
	{
		try
		{
			ToLua.Push(L, DP_FightPrefabManage.ColorTab);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ColorTab(IntPtr L)
	{
		try
		{
			UnityEngine.Color32[] arg0 = ToLua.CheckObjectArray<UnityEngine.Color32>(L, 2);
			DP_FightPrefabManage.ColorTab = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

