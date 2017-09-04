﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class PTZCameraWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PTZCamera), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("HideShadowCamera", HideShadowCamera);
		L.RegFunction("ShowShadowCamera", ShowShadowCamera);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("Instence", get_Instence, null);
		L.RegVar("Field", get_Field, set_Field);
		L.RegVar("NearClipPlane", get_NearClipPlane, set_NearClipPlane);
		L.RegVar("FarClipPlane", get_FarClipPlane, set_FarClipPlane);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HideShadowCamera(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			PTZCamera.HideShadowCamera();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ShowShadowCamera(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			PTZCamera.ShowShadowCamera();
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
	static int get_Instence(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PTZCamera obj = (PTZCamera)o;
			PTZCamera ret = obj.Instence;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Instence on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Field(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PTZCamera obj = (PTZCamera)o;
			float ret = obj.Field;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Field on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NearClipPlane(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PTZCamera obj = (PTZCamera)o;
			float ret = obj.NearClipPlane;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index NearClipPlane on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FarClipPlane(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PTZCamera obj = (PTZCamera)o;
			float ret = obj.FarClipPlane;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index FarClipPlane on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Field(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PTZCamera obj = (PTZCamera)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.Field = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Field on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_NearClipPlane(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PTZCamera obj = (PTZCamera)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.NearClipPlane = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index NearClipPlane on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_FarClipPlane(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PTZCamera obj = (PTZCamera)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.FarClipPlane = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index FarClipPlane on a nil value" : e.Message);
		}
	}
}

