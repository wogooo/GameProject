﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UIToast_ShowTypeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UIToast.ShowType));
		L.RegVar("Queue", get_Queue, null);
		L.RegVar("Upwards", get_Upwards, null);
		L.RegFunction("IntToEnum", IntToEnum);
		L.EndEnum();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Queue(IntPtr L)
	{
		ToLua.Push(L, UIToast.ShowType.Queue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Upwards(IntPtr L)
	{
		ToLua.Push(L, UIToast.ShowType.Upwards);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		UIToast.ShowType o = (UIToast.ShowType)arg0;
		ToLua.Push(L, o);
		return 1;
	}
}

