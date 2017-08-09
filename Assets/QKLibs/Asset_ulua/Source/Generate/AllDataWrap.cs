﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class AllDataWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AllData), typeof(System.Object));
		L.RegFunction("New", _CreateAllData);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("BuffInfoList", get_BuffInfoList, set_BuffInfoList);
		L.RegVar("RemainInfoList", get_RemainInfoList, set_RemainInfoList);
		L.RegVar("MemberData", get_MemberData, set_MemberData);
		L.RegVar("SelectWeightData", get_SelectWeightData, set_SelectWeightData);
		L.RegVar("AOEData", get_AOEData, set_AOEData);
		L.RegVar("SkillInfoList", get_SkillInfoList, set_SkillInfoList);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAllData(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				AllData obj = new AllData();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: AllData.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BuffInfoList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AllData obj = (AllData)o;
			System.Collections.Generic.IList<BuffInfo> ret = obj.BuffInfoList;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index BuffInfoList on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_RemainInfoList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AllData obj = (AllData)o;
			System.Collections.Generic.IList<RemainInfo> ret = obj.RemainInfoList;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index RemainInfoList on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MemberData(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AllData obj = (AllData)o;
			VOBase ret = obj.MemberData;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index MemberData on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SelectWeightData(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AllData obj = (AllData)o;
			SelectWeightData ret = obj.SelectWeightData;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index SelectWeightData on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AOEData(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AllData obj = (AllData)o;
			ArmyAOEData ret = obj.AOEData;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index AOEData on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SkillInfoList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AllData obj = (AllData)o;
			System.Collections.Generic.IList<SkillInfo> ret = obj.SkillInfoList;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index SkillInfoList on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_BuffInfoList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AllData obj = (AllData)o;
			System.Collections.Generic.IList<BuffInfo> arg0 = (System.Collections.Generic.IList<BuffInfo>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.IList<BuffInfo>));
			obj.BuffInfoList = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index BuffInfoList on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_RemainInfoList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AllData obj = (AllData)o;
			System.Collections.Generic.IList<RemainInfo> arg0 = (System.Collections.Generic.IList<RemainInfo>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.IList<RemainInfo>));
			obj.RemainInfoList = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index RemainInfoList on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MemberData(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AllData obj = (AllData)o;
			VOBase arg0 = (VOBase)ToLua.CheckObject(L, 2, typeof(VOBase));
			obj.MemberData = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index MemberData on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SelectWeightData(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AllData obj = (AllData)o;
			SelectWeightData arg0 = (SelectWeightData)ToLua.CheckObject(L, 2, typeof(SelectWeightData));
			obj.SelectWeightData = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index SelectWeightData on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AOEData(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AllData obj = (AllData)o;
			ArmyAOEData arg0 = (ArmyAOEData)ToLua.CheckObject(L, 2, typeof(ArmyAOEData));
			obj.AOEData = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index AOEData on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SkillInfoList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			AllData obj = (AllData)o;
			System.Collections.Generic.IList<SkillInfo> arg0 = (System.Collections.Generic.IList<SkillInfo>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.IList<SkillInfo>));
			obj.SkillInfoList = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index SkillInfoList on a nil value" : e.Message);
		}
	}
}

