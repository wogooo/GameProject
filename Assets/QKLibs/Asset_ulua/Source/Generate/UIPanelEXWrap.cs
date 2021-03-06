﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UIPanelEXWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIPanelEX), typeof(UIPanel));
		L.RegFunction("reset", reset);
		L.RegFunction("CalculateConstrainOffset", CalculateConstrainOffset);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("tsartSpanX", get_tsartSpanX, set_tsartSpanX);
		L.RegVar("tsartSpanY", get_tsartSpanY, set_tsartSpanY);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int reset(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPanelEX obj = (UIPanelEX)ToLua.CheckObject(L, 1, typeof(UIPanelEX));
			obj.reset();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculateConstrainOffset(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UIPanelEX obj = (UIPanelEX)ToLua.CheckObject(L, 1, typeof(UIPanelEX));
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
			UnityEngine.Vector2 arg1 = ToLua.ToVector2(L, 3);
			UnityEngine.Vector3 o = obj.CalculateConstrainOffset(arg0, arg1);
			ToLua.Push(L, o);
			return 1;
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
	static int get_tsartSpanX(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIPanelEX obj = (UIPanelEX)o;
			float ret = obj.tsartSpanX;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index tsartSpanX on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tsartSpanY(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIPanelEX obj = (UIPanelEX)o;
			float ret = obj.tsartSpanY;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index tsartSpanY on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tsartSpanX(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIPanelEX obj = (UIPanelEX)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.tsartSpanX = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index tsartSpanX on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tsartSpanY(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UIPanelEX obj = (UIPanelEX)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.tsartSpanY = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index tsartSpanY on a nil value" : e.Message);
		}
	}
}

