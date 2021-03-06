﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class SkillInfoWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SkillInfo), typeof(SkillBase));
		L.RegFunction("AddSubFormulaItem", AddSubFormulaItem);
		L.RegFunction("GetSubFormulaList", GetSubFormulaList);
		L.RegFunction("New", _CreateSkillInfo);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("IsActive", get_IsActive, set_IsActive);
		L.RegVar("IsDone", get_IsDone, set_IsDone);
		L.RegVar("WeightData", get_WeightData, set_WeightData);
		L.RegVar("CDTime", get_CDTime, set_CDTime);
		L.RegVar("CDGroup", get_CDGroup, set_CDGroup);
		L.RegVar("IntervalTime", get_IntervalTime, set_IntervalTime);
		L.RegVar("ReleaseTime", get_ReleaseTime, set_ReleaseTime);
		L.RegVar("Icon", get_Icon, set_Icon);
		L.RegVar("SkillName", get_SkillName, set_SkillName);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSkillInfo(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
				SkillInfo obj = new SkillInfo(arg0);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: SkillInfo.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddSubFormulaItem(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkillInfo obj = (SkillInfo)ToLua.CheckObject(L, 1, typeof(SkillInfo));
			IFormulaItem arg0 = (IFormulaItem)ToLua.CheckObject(L, 2, typeof(IFormulaItem));
			obj.AddSubFormulaItem(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSubFormulaList(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkillInfo obj = (SkillInfo)ToLua.CheckObject(L, 1, typeof(SkillInfo));
			FormulaParamsPacker arg0 = (FormulaParamsPacker)ToLua.CheckObject(L, 2, typeof(FormulaParamsPacker));
			System.Collections.Generic.List<IFormula> o = obj.GetSubFormulaList(arg0);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsActive(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			bool ret = obj.IsActive;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index IsActive on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsDone(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			bool ret = obj.IsDone;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index IsDone on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WeightData(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			SelectWeightData ret = obj.WeightData;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index WeightData on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CDTime(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			float ret = obj.CDTime;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index CDTime on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CDGroup(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			int ret = obj.CDGroup;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index CDGroup on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IntervalTime(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			float ret = obj.IntervalTime;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index IntervalTime on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ReleaseTime(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			int ret = obj.ReleaseTime;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index ReleaseTime on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Icon(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			string ret = obj.Icon;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Icon on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SkillName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			string ret = obj.SkillName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index SkillName on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsActive(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.IsActive = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index IsActive on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsDone(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.IsDone = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index IsDone on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_WeightData(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			SelectWeightData arg0 = (SelectWeightData)ToLua.CheckObject(L, 2, typeof(SelectWeightData));
			obj.WeightData = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index WeightData on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CDTime(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.CDTime = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index CDTime on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CDGroup(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.CDGroup = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index CDGroup on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IntervalTime(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.IntervalTime = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index IntervalTime on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ReleaseTime(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.ReleaseTime = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index ReleaseTime on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Icon(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.Icon = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Icon on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SkillName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillInfo obj = (SkillInfo)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.SkillName = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index SkillName on a nil value" : e.Message);
		}
	}
}

