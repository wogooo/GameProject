﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class RanderControlWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(RanderControl), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("SyncData", SyncData);
		L.RegFunction("Begin", Begin);
		L.RegFunction("DestoryFSM", DestoryFSM);
		L.RegFunction("SetBloodBarValue", SetBloodBarValue);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("bloodBarCom", get_bloodBarCom, set_bloodBarCom);
		L.RegVar("bloodBar", get_bloodBar, set_bloodBar);
		L.RegVar("NowWorldCamera", get_NowWorldCamera, set_NowWorldCamera);
		L.RegVar("Head", get_Head, set_Head);
		L.RegVar("isEnemy", get_isEnemy, set_isEnemy);
		L.RegVar("isSetShader", get_isSetShader, set_isSetShader);
		L.RegVar("groupIndex", get_groupIndex, set_groupIndex);
		L.RegVar("ModelRander", get_ModelRander, set_ModelRander);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SyncData(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RanderControl obj = (RanderControl)ToLua.CheckObject(L, 1, typeof(RanderControl));
			obj.SyncData();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Begin(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RanderControl obj = (RanderControl)ToLua.CheckObject(L, 1, typeof(RanderControl));
			obj.Begin();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DestoryFSM(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RanderControl obj = (RanderControl)ToLua.CheckObject(L, 1, typeof(RanderControl));
			obj.DestoryFSM();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetBloodBarValue(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RanderControl obj = (RanderControl)ToLua.CheckObject(L, 1, typeof(RanderControl));
			obj.SetBloodBarValue();
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
	static int get_bloodBarCom(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			BloodBar ret = obj.bloodBarCom;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index bloodBarCom on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bloodBar(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			UnityEngine.Transform ret = obj.bloodBar;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index bloodBar on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NowWorldCamera(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			UnityEngine.Camera ret = obj.NowWorldCamera;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index NowWorldCamera on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Head(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			UnityEngine.Transform ret = obj.Head;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Head on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isEnemy(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			bool ret = obj.isEnemy;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isEnemy on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isSetShader(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			bool ret = obj.isSetShader;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isSetShader on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_groupIndex(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			int ret = obj.groupIndex;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index groupIndex on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ModelRander(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			MFAModelRender ret = obj.ModelRander;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index ModelRander on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bloodBarCom(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			BloodBar arg0 = (BloodBar)ToLua.CheckUnityObject(L, 2, typeof(BloodBar));
			obj.bloodBarCom = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index bloodBarCom on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bloodBar(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));
			obj.bloodBar = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index bloodBar on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_NowWorldCamera(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			UnityEngine.Camera arg0 = (UnityEngine.Camera)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Camera));
			obj.NowWorldCamera = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index NowWorldCamera on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Head(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));
			obj.Head = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Head on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isEnemy(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.isEnemy = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isEnemy on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isSetShader(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.isSetShader = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isSetShader on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_groupIndex(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.groupIndex = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index groupIndex on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ModelRander(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			RanderControl obj = (RanderControl)o;
			MFAModelRender arg0 = (MFAModelRender)ToLua.CheckUnityObject(L, 2, typeof(MFAModelRender));
			obj.ModelRander = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index ModelRander on a nil value" : e.Message);
		}
	}
}

