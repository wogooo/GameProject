﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class MailLoopGridWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(MailLoopGrid), typeof(LoopGrid));
		L.RegFunction("InsertDataBack", InsertDataBack);
		L.RegFunction("UpOneData", UpOneData);
		L.RegFunction("DelYDorYLQ_Mail", DelYDorYLQ_Mail);
		L.RegFunction("InitWindow", InitWindow);
		L.RegFunction("OneBtnGet", OneBtnGet);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InsertDataBack(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			MailLoopGrid obj = (MailLoopGrid)ToLua.CheckObject(L, 1, typeof(MailLoopGrid));
			LuaTable arg0 = ToLua.CheckLuaTable(L, 2);
			obj.InsertDataBack(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UpOneData(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			MailLoopGrid obj = (MailLoopGrid)ToLua.CheckObject(L, 1, typeof(MailLoopGrid));
			string arg0 = ToLua.CheckString(L, 2);
			LuaTable arg1 = ToLua.CheckLuaTable(L, 3);
			obj.UpOneData(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DelYDorYLQ_Mail(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			MailLoopGrid obj = (MailLoopGrid)ToLua.CheckObject(L, 1, typeof(MailLoopGrid));
			obj.DelYDorYLQ_Mail();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitWindow(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			MailLoopGrid obj = (MailLoopGrid)ToLua.CheckObject(L, 1, typeof(MailLoopGrid));
			obj.InitWindow();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OneBtnGet(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			MailLoopGrid obj = (MailLoopGrid)ToLua.CheckObject(L, 1, typeof(MailLoopGrid));
			obj.OneBtnGet();
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
}

