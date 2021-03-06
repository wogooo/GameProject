﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class SkillManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SkillManager), typeof(System.Object));
		L.RegFunction("CreateSkillInfo", CreateSkillInfo);
		L.RegFunction("GetSkillScript", GetSkillScript);
		L.RegFunction("CreateSkillInfoList", CreateSkillInfoList);
		L.RegFunction("AttachSkillAttribute", AttachSkillAttribute);
		L.RegFunction("CopySkillInfo", CopySkillInfo);
		L.RegFunction("DoFormula", DoFormula);
		L.RegFunction("SkillCouldRelease", SkillCouldRelease);
		L.RegFunction("SetSkillInCD", SetSkillInCD);
		L.RegFunction("SubSkillCD", SubSkillCD);
		L.RegFunction("DoSkillInfo", DoSkillInfo);
		L.RegFunction("DoSkillNum", DoSkillNum);
		L.RegFunction("AddSkillInfo", AddSkillInfo);
		L.RegFunction("ContainsInstanceSkillId", ContainsInstanceSkillId);
		L.RegFunction("GetSkillInstance", GetSkillInstance);
		L.RegFunction("DelBuffInstance", DelBuffInstance);
		L.RegFunction("CheckAndDoSkillInfo", CheckAndDoSkillInfo);
		L.RegFunction("Pause", Pause);
		L.RegFunction("Start", Start);
		L.RegFunction("SetTriggerData", SetTriggerData);
		L.RegFunction("GetSkillTriggerDataList", GetSkillTriggerDataList);
		L.RegFunction("ClearSkillTriggerData", ClearSkillTriggerData);
		L.RegFunction("ClearAllSkillTriggerData", ClearAllSkillTriggerData);
		L.RegFunction("SetEachAction", SetEachAction);
		L.RegFunction("New", _CreateSkillManager);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("SkillPacketName", get_SkillPacketName, null);
		L.RegVar("RunType", get_RunType, set_RunType);
		L.RegVar("SkillInfoDic", get_SkillInfoDic, set_SkillInfoDic);
		L.RegVar("Single", get_Single, null);
		L.RegVar("isPause", get_isPause, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSkillManager(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				SkillManager obj = new SkillManager();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: SkillManager.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateSkillInfo(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(SkillManager), typeof(int), typeof(int)))
			{
				SkillManager obj = (SkillManager)ToLua.ToObject(L, 1);
				int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
				int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
				SkillInfo o = obj.CreateSkillInfo(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 4 && TypeChecker.CheckTypes(L, 1, typeof(SkillManager), typeof(int), typeof(DisplayOwner), typeof(int)))
			{
				SkillManager obj = (SkillManager)ToLua.ToObject(L, 1);
				int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
				DisplayOwner arg1 = (DisplayOwner)ToLua.ToObject(L, 3);
				int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
				SkillInfo o = obj.CreateSkillInfo(arg0, arg1, arg2);
				ToLua.PushObject(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: SkillManager.CreateSkillInfo");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSkillScript(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
			string o = obj.GetSkillScript(arg0, arg1);
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateSkillInfoList(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			System.Collections.Generic.IList<int> arg0 = (System.Collections.Generic.IList<int>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.IList<int>));
			DisplayOwner arg1 = (DisplayOwner)ToLua.CheckObject(L, 3, typeof(DisplayOwner));
			System.Collections.Generic.IList<SkillInfo> o = obj.CreateSkillInfoList(arg0, arg1);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AttachSkillAttribute(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			SkillInfo arg0 = (SkillInfo)ToLua.CheckObject(L, 2, typeof(SkillInfo));
			VOBase arg1 = (VOBase)ToLua.CheckObject(L, 3, typeof(VOBase));
			obj.AttachSkillAttribute(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopySkillInfo(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			SkillInfo arg0 = (SkillInfo)ToLua.CheckObject(L, 2, typeof(SkillInfo));
			SkillInfo o = obj.CopySkillInfo(arg0);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoFormula(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			IFormula arg0 = (IFormula)ToLua.CheckObject(L, 2, typeof(IFormula));
			System.Action arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (System.Action)ToLua.CheckObject(L, 3, typeof(System.Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				arg1 = DelegateFactory.CreateDelegate(typeof(System.Action), func) as System.Action;
			}

			obj.DoFormula(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SkillCouldRelease(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			SkillBase arg0 = (SkillBase)ToLua.CheckObject(L, 2, typeof(SkillBase));
			bool o = obj.SkillCouldRelease(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSkillInCD(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			SkillInfo arg0 = (SkillInfo)ToLua.CheckObject(L, 2, typeof(SkillInfo));
			obj.SetSkillInCD(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SubSkillCD(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			SkillInfo arg0 = (SkillInfo)ToLua.CheckObject(L, 2, typeof(SkillInfo));
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
			obj.SubSkillCD(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoSkillInfo(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 5);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			SkillBase arg0 = (SkillBase)ToLua.CheckObject(L, 2, typeof(SkillBase));
			FormulaParamsPacker arg1 = (FormulaParamsPacker)ToLua.CheckObject(L, 3, typeof(FormulaParamsPacker));
			bool arg2 = LuaDLL.luaL_checkboolean(L, 4);
			System.Action arg3 = null;
			LuaTypes funcType5 = LuaDLL.lua_type(L, 5);

			if (funcType5 != LuaTypes.LUA_TFUNCTION)
			{
				 arg3 = (System.Action)ToLua.CheckObject(L, 5, typeof(System.Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 5);
				arg3 = DelegateFactory.CreateDelegate(typeof(System.Action), func) as System.Action;
			}

			obj.DoSkillInfo(arg0, arg1, arg2, arg3);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoSkillNum(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 5);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			FormulaParamsPacker arg1 = (FormulaParamsPacker)ToLua.CheckObject(L, 3, typeof(FormulaParamsPacker));
			bool arg2 = LuaDLL.luaL_checkboolean(L, 4);
			System.Action arg3 = null;
			LuaTypes funcType5 = LuaDLL.lua_type(L, 5);

			if (funcType5 != LuaTypes.LUA_TFUNCTION)
			{
				 arg3 = (System.Action)ToLua.CheckObject(L, 5, typeof(System.Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 5);
				arg3 = DelegateFactory.CreateDelegate(typeof(System.Action), func) as System.Action;
			}

			obj.DoSkillNum(arg0, arg1, arg2, arg3);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddSkillInfo(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			SkillInfo arg0 = (SkillInfo)ToLua.CheckObject(L, 2, typeof(SkillInfo));
			obj.AddSkillInfo(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ContainsInstanceSkillId(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			long arg0 = LuaDLL.tolua_checkint64(L, 2);
			bool o = obj.ContainsInstanceSkillId(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSkillInstance(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			long arg0 = LuaDLL.tolua_checkint64(L, 2);
			SkillInfo o = obj.GetSkillInstance(arg0);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DelBuffInstance(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			long arg0 = LuaDLL.tolua_checkint64(L, 2);
			obj.DelBuffInstance(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CheckAndDoSkillInfo(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			System.Collections.Generic.IList<SkillInfo> arg0 = (System.Collections.Generic.IList<SkillInfo>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.IList<SkillInfo>));
			TriggerData arg1 = (TriggerData)ToLua.CheckObject(L, 3, typeof(TriggerData));
			obj.CheckAndDoSkillInfo(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Pause(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			obj.Pause();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			obj.Start();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTriggerData(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			TriggerData arg0 = (TriggerData)ToLua.CheckObject(L, 2, typeof(TriggerData));
			obj.SetTriggerData(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSkillTriggerDataList(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			ObjectID arg0 = (ObjectID)ToLua.CheckObject(L, 2, typeof(ObjectID));
			TriggerLevel1 arg1 = (TriggerLevel1)ToLua.CheckObject(L, 3, typeof(TriggerLevel1));
			TriggerLevel2 arg2 = (TriggerLevel2)ToLua.CheckObject(L, 4, typeof(TriggerLevel2));
			System.Collections.Generic.List<TriggerData> o = obj.GetSkillTriggerDataList(arg0, arg1, arg2);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearSkillTriggerData(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			ObjectID arg0 = (ObjectID)ToLua.CheckObject(L, 2, typeof(ObjectID));
			TriggerLevel1 arg1 = (TriggerLevel1)ToLua.CheckObject(L, 3, typeof(TriggerLevel1));
			TriggerLevel2 arg2 = (TriggerLevel2)ToLua.CheckObject(L, 4, typeof(TriggerLevel2));
			obj.ClearSkillTriggerData(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearAllSkillTriggerData(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			obj.ClearAllSkillTriggerData();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetEachAction(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			SkillManager obj = (SkillManager)ToLua.CheckObject(L, 1, typeof(SkillManager));
			ObjectID arg0 = (ObjectID)ToLua.CheckObject(L, 2, typeof(ObjectID));
			System.Action<TriggerLevel1,TriggerLevel2,TriggerData> arg1 = null;
			LuaTypes funcType3 = LuaDLL.lua_type(L, 3);

			if (funcType3 != LuaTypes.LUA_TFUNCTION)
			{
				 arg1 = (System.Action<TriggerLevel1,TriggerLevel2,TriggerData>)ToLua.CheckObject(L, 3, typeof(System.Action<TriggerLevel1,TriggerLevel2,TriggerData>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				arg1 = DelegateFactory.CreateDelegate(typeof(System.Action<TriggerLevel1,TriggerLevel2,TriggerData>), func) as System.Action<TriggerLevel1,TriggerLevel2,TriggerData>;
			}

			bool arg2 = LuaDLL.luaL_checkboolean(L, 4);
			obj.SetEachAction(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SkillPacketName(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, SkillManager.SkillPacketName);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_RunType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillManager obj = (SkillManager)o;
			int ret = obj.RunType;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index RunType on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SkillInfoDic(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillManager obj = (SkillManager)o;
			System.Collections.Generic.IDictionary<long,SkillInfo> ret = obj.SkillInfoDic;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index SkillInfoDic on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Single(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, SkillManager.Single);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPause(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, SkillManager.isPause);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_RunType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillManager obj = (SkillManager)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.RunType = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index RunType on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SkillInfoDic(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			SkillManager obj = (SkillManager)o;
			System.Collections.Generic.IDictionary<long,SkillInfo> arg0 = (System.Collections.Generic.IDictionary<long,SkillInfo>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.IDictionary<long,SkillInfo>));
			obj.SkillInfoDic = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index SkillInfoDic on a nil value" : e.Message);
		}
	}
}

