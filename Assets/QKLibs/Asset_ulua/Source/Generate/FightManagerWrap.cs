﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class FightManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(FightManager), typeof(System.Object));
		L.RegFunction("StartFight", StartFight);
		L.RegFunction("AnalysisMap", AnalysisMap);
		L.RegFunction("EndFight", EndFight);
		L.RegFunction("InitMap", InitMap);
		L.RegFunction("Clear", Clear);
		L.RegFunction("SetMemberPos", SetMemberPos);
		L.RegFunction("GetPos", GetPos);
		L.RegFunction("DoHealthChangeAction", DoHealthChangeAction);
		L.RegFunction("DoEndGameAction", DoEndGameAction);
		L.RegFunction("DoMemberDeadAction", DoMemberDeadAction);
		L.RegFunction("SetHealthChangeAction", SetHealthChangeAction);
		L.RegFunction("SetEndGameAction", SetEndGameAction);
		L.RegFunction("SetMemberDeadAction", SetMemberDeadAction);
		L.RegFunction("GetDemageHurtType", GetDemageHurtType);
		L.RegFunction("New", _CreateFightManager);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("MapWidth", get_MapWidth, set_MapWidth);
		L.RegVar("MapHeight", get_MapHeight, set_MapHeight);
		L.RegVar("UnitWidth", get_UnitWidth, set_UnitWidth);
		L.RegVar("Single", get_Single, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateFightManager(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				FightManager obj = new FightManager();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: FightManager.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartFight(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			FightManager obj = (FightManager)ToLua.CheckObject(L, 1, typeof(FightManager));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			MapManager.MapDataParamsPacker arg1 = (MapManager.MapDataParamsPacker)ToLua.CheckObject(L, 3, typeof(MapManager.MapDataParamsPacker));
			bool arg2 = LuaDLL.luaL_checkboolean(L, 4);
			obj.StartFight(arg0, arg1, arg2);
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
			FightManager obj = (FightManager)ToLua.CheckObject(L, 1, typeof(FightManager));
			obj.AnalysisMap();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndFight(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FightManager obj = (FightManager)ToLua.CheckObject(L, 1, typeof(FightManager));
			obj.EndFight();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitMap(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1 && TypeChecker.CheckTypes(L, 1, typeof(FightManager)))
			{
				FightManager obj = (FightManager)ToLua.ToObject(L, 1);
				obj.InitMap();
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(FightManager), typeof(int[][]), typeof(int[][])))
			{
				FightManager obj = (FightManager)ToLua.ToObject(L, 1);
				int[][] arg0 = ToLua.CheckObjectArray<int[]>(L, 2);
				int[][] arg1 = ToLua.CheckObjectArray<int[]>(L, 3);
				obj.InitMap(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: FightManager.InitMap");
			}
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
			FightManager obj = (FightManager)ToLua.CheckObject(L, 1, typeof(FightManager));
			obj.Clear();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetMemberPos(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			FightManager obj = (FightManager)ToLua.CheckObject(L, 1, typeof(FightManager));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			FightManager.MemberType arg1 = (FightManager.MemberType)ToLua.CheckObject(L, 3, typeof(FightManager.MemberType));
			UnityEngine.Vector3 arg2 = ToLua.ToVector3(L, 4);
			obj.SetMemberPos(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPos(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			FightManager obj = (FightManager)ToLua.CheckObject(L, 1, typeof(FightManager));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			FightManager.MemberType arg1 = (FightManager.MemberType)ToLua.CheckObject(L, 3, typeof(FightManager.MemberType));
			UnityEngine.Vector3 o = obj.GetPos(arg0, arg1);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoHealthChangeAction(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 7);
			FightManager obj = (FightManager)ToLua.CheckObject(L, 1, typeof(FightManager));
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.GameObject));
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);
			float arg3 = (float)LuaDLL.luaL_checknumber(L, 5);
			FightManager.HurtType arg4 = (FightManager.HurtType)ToLua.CheckObject(L, 6, typeof(FightManager.HurtType));
			ObjectID.ObjectType arg5 = (ObjectID.ObjectType)ToLua.CheckObject(L, 7, typeof(ObjectID.ObjectType));
			obj.DoHealthChangeAction(arg0, arg1, arg2, arg3, arg4, arg5);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoEndGameAction(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FightManager obj = (FightManager)ToLua.CheckObject(L, 1, typeof(FightManager));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.DoEndGameAction(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoMemberDeadAction(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			FightManager obj = (FightManager)ToLua.CheckObject(L, 1, typeof(FightManager));
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.GameObject));
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
			FightManager.MemberType arg2 = (FightManager.MemberType)ToLua.CheckObject(L, 4, typeof(FightManager.MemberType));
			obj.DoMemberDeadAction(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetHealthChangeAction(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FightManager obj = (FightManager)ToLua.CheckObject(L, 1, typeof(FightManager));
			System.Action<FightManager.HealthChangePacker> arg0 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg0 = (System.Action<FightManager.HealthChangePacker>)ToLua.CheckObject(L, 2, typeof(System.Action<FightManager.HealthChangePacker>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				arg0 = DelegateFactory.CreateDelegate(typeof(System.Action<FightManager.HealthChangePacker>), func) as System.Action<FightManager.HealthChangePacker>;
			}

			obj.SetHealthChangeAction(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetEndGameAction(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FightManager obj = (FightManager)ToLua.CheckObject(L, 1, typeof(FightManager));
			System.Action<int> arg0 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg0 = (System.Action<int>)ToLua.CheckObject(L, 2, typeof(System.Action<int>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				arg0 = DelegateFactory.CreateDelegate(typeof(System.Action<int>), func) as System.Action<int>;
			}

			obj.SetEndGameAction(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetMemberDeadAction(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FightManager obj = (FightManager)ToLua.CheckObject(L, 1, typeof(FightManager));
			System.Action<UnityEngine.GameObject,int,FightManager.MemberType> arg0 = null;
			LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

			if (funcType2 != LuaTypes.LUA_TFUNCTION)
			{
				 arg0 = (System.Action<UnityEngine.GameObject,int,FightManager.MemberType>)ToLua.CheckObject(L, 2, typeof(System.Action<UnityEngine.GameObject,int,FightManager.MemberType>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				arg0 = DelegateFactory.CreateDelegate(typeof(System.Action<UnityEngine.GameObject,int,FightManager.MemberType>), func) as System.Action<UnityEngine.GameObject,int,FightManager.MemberType>;
			}

			obj.SetMemberDeadAction(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDemageHurtType(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TriggerData arg0 = (TriggerData)ToLua.CheckObject(L, 1, typeof(TriggerData));
			FightManager.HurtType o = FightManager.GetDemageHurtType(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MapWidth(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FightManager obj = (FightManager)o;
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
			FightManager obj = (FightManager)o;
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
			LuaDLL.lua_pushinteger(L, FightManager.UnitWidth);
			return 1;
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
			ToLua.PushObject(L, FightManager.Single);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MapWidth(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			FightManager obj = (FightManager)o;
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
			FightManager obj = (FightManager)o;
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
			FightManager.UnitWidth = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

