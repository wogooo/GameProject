﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Util_TimerManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Util.TimerManager), typeof(System.Object));
		L.RegFunction("AddTimer", AddTimer);
		L.RegFunction("RemoveTimer", RemoveTimer);
		L.RegFunction("Do", Do);
		L.RegFunction("DoOnce", DoOnce);
		L.RegFunction("IsEnd", IsEnd);
		L.RegFunction("OnDestroy", OnDestroy);
		L.RegFunction("New", _CreateUtil_TimerManager);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("Single", get_Single, null);
		L.RegVar("StartTimerTick", get_StartTimerTick, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUtil_TimerManager(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				Util.TimerManager obj = new Util.TimerManager();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Util.TimerManager.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddTimer(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Util.TimerManager obj = (Util.TimerManager)ToLua.CheckObject(L, 1, typeof(Util.TimerManager));
			Util.Timer arg0 = (Util.Timer)ToLua.CheckObject(L, 2, typeof(Util.Timer));
			obj.AddTimer(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveTimer(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Util.TimerManager obj = (Util.TimerManager)ToLua.CheckObject(L, 1, typeof(Util.TimerManager));
			Util.Timer arg0 = (Util.Timer)ToLua.CheckObject(L, 2, typeof(Util.Timer));
			obj.RemoveTimer(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Do(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Util.TimerManager obj = (Util.TimerManager)ToLua.CheckObject(L, 1, typeof(Util.TimerManager));
			obj.Do();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoOnce(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Util.TimerManager obj = (Util.TimerManager)ToLua.CheckObject(L, 1, typeof(Util.TimerManager));
			double arg0 = (double)LuaDLL.luaL_checknumber(L, 2);
			bool o = obj.DoOnce(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsEnd(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Util.TimerManager obj = (Util.TimerManager)ToLua.CheckObject(L, 1, typeof(Util.TimerManager));
			bool o = obj.IsEnd();
			LuaDLL.lua_pushboolean(L, o);
			return 1;
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
			Util.TimerManager obj = (Util.TimerManager)ToLua.CheckObject(L, 1, typeof(Util.TimerManager));
			obj.OnDestroy();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Single(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, Util.TimerManager.Single);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_StartTimerTick(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Util.TimerManager obj = (Util.TimerManager)o;
			double ret = obj.StartTimerTick;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index StartTimerTick on a nil value" : e.Message);
		}
	}
}

