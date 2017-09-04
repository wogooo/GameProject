﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class AstarFightWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AstarFight), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("InitMap", InitMap);
		L.RegFunction("AnalysisMap", AnalysisMap);
		L.RegFunction("Clear", Clear);
		L.RegFunction("isZhangAi", isZhangAi);
		L.RegFunction("setAllZhenxingList", setAllZhenxingList);
		L.RegFunction("setZhenxingInfo", setZhenxingInfo);
		L.RegFunction("getNum", getNum);
		L.RegFunction("setMaxX", setMaxX);
		L.RegFunction("OnDestroy", OnDestroy);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("DiameterX", get_DiameterX, set_DiameterX);
		L.RegVar("DiameterY", get_DiameterY, set_DiameterY);
		L.RegVar("MapWidth", get_MapWidth, set_MapWidth);
		L.RegVar("MapHeight", get_MapHeight, set_MapHeight);
		L.RegVar("UnitWidth", get_UnitWidth, set_UnitWidth);
		L.RegVar("IsJumpPoint", get_IsJumpPoint, set_IsJumpPoint);
		L.RegVar("LoadMap", get_LoadMap, set_LoadMap);
		L.RegVar("PathPoint", get_PathPoint, set_PathPoint);
		L.RegVar("PathPointFather", get_PathPointFather, set_PathPointFather);
		L.RegVar("ItemCount", get_ItemCount, set_ItemCount);
		L.RegVar("Instance", get_Instance, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitMap(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AstarFight obj = (AstarFight)ToLua.CheckObject(L, 1, typeof(AstarFight));
			int[][] arg0 = ToLua.CheckObjectArray<int[]>(L, 2);
			int[][] arg1 = ToLua.CheckObjectArray<int[]>(L, 3);
			obj.InitMap(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AnalysisMap(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AstarFight obj = (AstarFight)ToLua.CheckObject(L, 1, typeof(AstarFight));
			obj.AnalysisMap();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AstarFight obj = (AstarFight)ToLua.CheckObject(L, 1, typeof(AstarFight));
			obj.Clear();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int isZhangAi(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			AstarFight obj = (AstarFight)ToLua.CheckObject(L, 1, typeof(AstarFight));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
			obj.isZhangAi(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setAllZhenxingList(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int[] arg0 = ToLua.CheckNumberArray<int>(L, 1);
			System.Collections.Generic.Dictionary<int,int[]> o = AstarFight.setAllZhenxingList(arg0);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setZhenxingInfo(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			AstarFight obj = (AstarFight)ToLua.CheckObject(L, 1, typeof(AstarFight));
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
			int arg2 = (int)LuaDLL.luaL_checknumber(L, 4);
			obj.setZhenxingInfo(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getNum(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AstarFight obj = (AstarFight)ToLua.CheckObject(L, 1, typeof(AstarFight));
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 o = obj.getNum(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setMaxX(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AstarFight obj = (AstarFight)ToLua.CheckObject(L, 1, typeof(AstarFight));
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.setMaxX(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDestroy(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AstarFight obj = (AstarFight)ToLua.CheckObject(L, 1, typeof(AstarFight));
			obj.OnDestroy();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DiameterX(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			int ret = obj.DiameterX;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index DiameterX on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DiameterY(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			int ret = obj.DiameterY;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index DiameterY on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MapWidth(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			int ret = obj.MapWidth;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index MapWidth on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MapHeight(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			int ret = obj.MapHeight;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index MapHeight on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UnitWidth(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, AstarFight.UnitWidth);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsJumpPoint(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			bool ret = obj.IsJumpPoint;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index IsJumpPoint on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LoadMap(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			LoadMap ret = obj.LoadMap;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index LoadMap on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PathPoint(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			UnityEngine.GameObject ret = obj.PathPoint;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index PathPoint on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PathPointFather(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			UnityEngine.GameObject ret = obj.PathPointFather;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index PathPointFather on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ItemCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			int ret = obj.ItemCount;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index ItemCount on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		try
		{
			ToLua.Push(L, AstarFight.Instance);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DiameterX(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.DiameterX = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index DiameterX on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DiameterY(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.DiameterY = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index DiameterY on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MapWidth(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.MapWidth = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index MapWidth on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MapHeight(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.MapHeight = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index MapHeight on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UnitWidth(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			AstarFight.UnitWidth = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsJumpPoint(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.IsJumpPoint = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index IsJumpPoint on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LoadMap(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			LoadMap arg0 = (LoadMap)ToLua.CheckUnityObject(L, 2, typeof(LoadMap));
			obj.LoadMap = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index LoadMap on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_PathPoint(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.GameObject));
			obj.PathPoint = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index PathPoint on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_PathPointFather(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.GameObject));
			obj.PathPointFather = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index PathPointFather on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ItemCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AstarFight obj = (AstarFight)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.ItemCount = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index ItemCount on a nil value" : e.Message);
		}
	}
}

