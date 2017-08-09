﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UtilsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Utils), typeof(System.Object));
		L.RegFunction("PositionToNum", PositionToNum);
		L.RegFunction("NumToPosition", NumToPosition);
		L.RegFunction("NumToPostionByList", NumToPostionByList);
		L.RegFunction("IsCoverage", IsCoverage);
		L.RegFunction("DrawGraphics", DrawGraphics);
		L.RegFunction("DrawRect", DrawRect);
		L.RegFunction("DrawSector", DrawSector);
		L.RegFunction("DrawTriangle", DrawTriangle);
		L.RegFunction("DrawCircle", DrawCircle);
		L.RegFunction("GetKey", GetKey);
		L.RegFunction("GetHorizonalTestLine", GetHorizonalTestLine);
		L.RegFunction("GetVerticalTestLine", GetVerticalTestLine);
		L.RegFunction("GetDistancePointToLine", GetDistancePointToLine);
		L.RegFunction("GetDistancePointToPoint", GetDistancePointToPoint);
		L.RegFunction("CreateOrOpenFile", CreateOrOpenFile);
		L.RegFunction("LoadFileInfo", LoadFileInfo);
		L.RegFunction("LoadFileRotate", LoadFileRotate);
		L.RegFunction("CombineFile", CombineFile);
		L.RegFunction("DepartFileData", DepartFileData);
		L.RegFunction("GetMapDataByFileName", GetMapDataByFileName);
		L.RegFunction("GetTheta", GetTheta);
		L.RegFunction("WithOutY", WithOutY);
		L.RegFunction("V3ToV2WithouY", V3ToV2WithouY);
		L.RegFunction("GetRange", GetRange);
		L.RegFunction("GetTwoPointDistance2D", GetTwoPointDistance2D);
		L.RegFunction("CopyArray", CopyArray);
		L.RegFunction("GetMapFileNameById", GetMapFileNameById);
		L.RegFunction("MoveAndRotateObj", MoveAndRotateObj);
		L.RegFunction("StopMove", StopMove);
		L.RegFunction("New", _CreateUtils);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegConstant("Member", 2);
		L.RegConstant("Obstacle", 1);
		L.RegConstant("Accessibility", 0);
		L.RegConstant("MyBaseId", 10);
		L.RegConstant("MyTurretId", 11);
		L.RegConstant("EnemyBaseId", 110);
		L.RegConstant("EnemyTurretId", 111);
		L.RegConstant("Closed", -1);
		L.RegConstant("Opened", -1);
		L.RegConstant("MemberItemTypeHuman", 1);
		L.RegConstant("MemberItemTypeOrc", 2);
		L.RegConstant("MemberItemTypeOmnic", 3);
		L.RegConstant("EnemyCamp", 2);
		L.RegConstant("MyCamp", 1);
		L.RegConstant("NeutralCamp", 0);
		L.RegConstant("BulletTypeNormal", 1);
		L.RegConstant("BulletTypeScope", 2);
		L.RegConstant("AOEObjScope", 1);
		L.RegConstant("AOEPointScope", 2);
		L.RegConstant("AOEScope", 3);
		L.RegConstant("AOEForwardScope", 4);
		L.RegConstant("GeneralTypeSurface", 1);
		L.RegConstant("GeneralTypeAir", 2);
		L.RegConstant("GeneralTypeBuilding", 3);
		L.RegConstant("SurfaceCollisionGroup", 0);
		L.RegConstant("AirCollisionGroup", 2);
		L.RegConstant("SurfaceTypeConstantId", 5);
		L.RegConstant("AirTypeConstantId", 6);
		L.RegConstant("HumanArmyType", 1);
		L.RegConstant("OrcArmyType", 2);
		L.RegConstant("MechanicArmyType", 3);
		L.RegConstant("BaseArmyType", 4);
		L.RegConstant("TurretArmyType", 5);
		L.RegConstant("BaseBaseId", 220001000);
		L.RegConstant("TurretBaseId", 220002000);
		L.RegConstant("AngleToPi", 0.0174532923847437);
		L.RegConstant("PiToAngle", 57.2957801818848);
		L.RegConstant("TicksTimeToSecond", 10000000);
		L.RegConstant("EffectLayer", 12);
		L.RegVar("TargetPointSelectorXKey", get_TargetPointSelectorXKey, null);
		L.RegVar("TargetPointSelectorYKey", get_TargetPointSelectorYKey, null);
		L.RegVar("RadianToAngle", get_RadianToAngle, null);
		L.RegVar("AngleToRadian", get_AngleToRadian, null);
		L.RegVar("HalfPI", get_HalfPI, null);
		L.RegVar("NotCompleted", get_NotCompleted, null);
		L.RegVar("NoValue", get_NoValue, null);
		L.RegVar("FloatSign", get_FloatSign, null);
		L.RegVar("DoubleSign", get_DoubleSign, null);
		L.RegVar("ApproachZero", get_ApproachZero, null);
		L.RegVar("ApproachKZero", get_ApproachKZero, null);
		L.RegVar("Single", get_Single, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUtils(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				Utils obj = new Utils();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Utils.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PositionToNum(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 1);
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg3 = (float)LuaDLL.luaL_checknumber(L, 4);
			float arg4 = (float)LuaDLL.luaL_checknumber(L, 5);
			int[] o = Utils.PositionToNum(arg0, arg1, arg2, arg3, arg4);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NumToPosition(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 1);
			UnityEngine.Vector2 arg1 = ToLua.ToVector2(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg3 = (float)LuaDLL.luaL_checknumber(L, 4);
			float arg4 = (float)LuaDLL.luaL_checknumber(L, 5);
			UnityEngine.Vector3 o = Utils.NumToPosition(arg0, arg1, arg2, arg3, arg4);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NumToPostionByList(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 1);
			System.Collections.Generic.IList<Node> arg1 = (System.Collections.Generic.IList<Node>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.IList<Node>));
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg3 = (float)LuaDLL.luaL_checknumber(L, 4);
			float arg4 = (float)LuaDLL.luaL_checknumber(L, 5);
			System.Collections.Generic.List<UnityEngine.Vector3> o = Utils.NumToPostionByList(arg0, arg1, arg2, arg3, arg4);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsCoverage(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 6);
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 1);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg3 = (float)LuaDLL.luaL_checknumber(L, 4);
			float arg4 = (float)LuaDLL.luaL_checknumber(L, 5);
			float arg5 = (float)LuaDLL.luaL_checknumber(L, 6);
			bool o = Utils.IsCoverage(arg0, arg1, arg2, arg3, arg4, arg5);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DrawGraphics(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ICollisionGraphics arg0 = (ICollisionGraphics)ToLua.CheckObject(L, 1, typeof(ICollisionGraphics));
			UnityEngine.Color arg1 = ToLua.ToColor(L, 2);
			Utils.DrawGraphics(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DrawRect(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 1);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg3 = (float)LuaDLL.luaL_checknumber(L, 4);
			UnityEngine.Color arg4 = ToLua.ToColor(L, 5);
			Utils.DrawRect(arg0, arg1, arg2, arg3, arg4);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DrawSector(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 1);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg3 = (float)LuaDLL.luaL_checknumber(L, 4);
			UnityEngine.Color arg4 = ToLua.ToColor(L, 5);
			Utils.DrawSector(arg0, arg1, arg2, arg3, arg4);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DrawTriangle(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 1);
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 2);
			UnityEngine.Vector3 arg2 = ToLua.ToVector3(L, 3);
			UnityEngine.Color arg3 = ToLua.ToColor(L, 4);
			Utils.DrawTriangle(arg0, arg1, arg2, arg3);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DrawCircle(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 1);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Color arg2 = ToLua.ToColor(L, 3);
			Utils.DrawCircle(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKey(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			long arg0 = LuaDLL.tolua_checkint64(L, 1);
			long arg1 = LuaDLL.tolua_checkint64(L, 2);
			long o = Utils.GetKey(arg0, arg1);
			LuaDLL.tolua_pushint64(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHorizonalTestLine(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 1);
			UnityEngine.Vector2 o = Utils.GetHorizonalTestLine(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetVerticalTestLine(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 1);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Vector2 o = Utils.GetVerticalTestLine(arg0, arg1);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDistancePointToLine(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 1);
			UnityEngine.Vector2 arg1 = ToLua.ToVector2(L, 2);
			UnityEngine.Vector2 arg2 = ToLua.ToVector2(L, 3);
			float o = Utils.GetDistancePointToLine(arg0, arg1, arg2);
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDistancePointToPoint(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 1);
			UnityEngine.Vector2 arg1 = ToLua.ToVector2(L, 2);
			float o = Utils.GetDistancePointToPoint(arg0, arg1);
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateOrOpenFile(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string arg0 = ToLua.CheckString(L, 1);
			string arg1 = ToLua.CheckString(L, 2);
			string arg2 = ToLua.CheckString(L, 3);
			Utils.CreateOrOpenFile(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFileInfo(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1 && TypeChecker.CheckTypes(L, 1, typeof(System.IO.FileInfo)))
			{
				System.IO.FileInfo arg0 = (System.IO.FileInfo)ToLua.ToObject(L, 1);
				string o = Utils.LoadFileInfo(arg0);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else if (count == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string arg0 = ToLua.ToString(L, 1);
				string o = Utils.LoadFileInfo(arg0);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: Utils.LoadFileInfo");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFileRotate(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			string o = Utils.LoadFileRotate(arg0);
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CombineFile(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			System.Collections.Generic.List<string> arg0 = (System.Collections.Generic.List<string>)ToLua.CheckObject(L, 1, typeof(System.Collections.Generic.List<string>));
			string o = Utils.CombineFile(arg0);
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DepartFileData(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			System.Collections.Generic.Dictionary<string,string> o = Utils.DepartFileData(arg0);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMapDataByFileName(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			string o = Utils.GetMapDataByFileName(arg0);
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTheta(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 1);
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg3 = (float)LuaDLL.luaL_checknumber(L, 4);
			float o = Utils.GetTheta(arg0, arg1, arg2, arg3);
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WithOutY(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 1);
			UnityEngine.Vector3 o = Utils.WithOutY(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int V3ToV2WithouY(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 1);
			UnityEngine.Vector2 o = Utils.V3ToV2WithouY(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRange(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 1);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			float o = Utils.GetRange(arg0, arg1, arg2);
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTwoPointDistance2D(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 1);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg3 = (float)LuaDLL.luaL_checknumber(L, 4);
			float o = Utils.GetTwoPointDistance2D(arg0, arg1, arg2, arg3);
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyArray(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			int[][] arg0 = ToLua.CheckObjectArray<int[]>(L, 1);
			int[][] arg1 = null;
			int arg2 = (int)LuaDLL.luaL_checknumber(L, 3);
			int arg3 = (int)LuaDLL.luaL_checknumber(L, 4);
			Utils.CopyArray(arg0, out arg1, arg2, arg3);
			ToLua.Push(L, arg1);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMapFileNameById(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int)))
			{
				string arg0 = ToLua.ToString(L, 1);
				int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
				string o = Utils.GetMapFileNameById(arg0, arg1);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int)))
			{
				int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
				int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
				string o = Utils.GetMapFileNameById(arg0, arg1);
				LuaDLL.lua_pushstring(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: Utils.GetMapFileNameById");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveAndRotateObj(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 5);
			Utils obj = (Utils)ToLua.CheckObject(L, 1, typeof(Utils));
			System.Collections.Generic.IList<MoveTarget> arg0 = (System.Collections.Generic.IList<MoveTarget>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.IList<MoveTarget>));
			UnityEngine.GameObject arg1 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 3, typeof(UnityEngine.GameObject));
			int arg2 = (int)LuaDLL.luaL_checknumber(L, 4);
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

			obj.MoveAndRotateObj(arg0, arg1, arg2, arg3);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopMove(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Utils obj = (Utils)ToLua.CheckObject(L, 1, typeof(Utils));
			obj.StopMove();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TargetPointSelectorXKey(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, Utils.TargetPointSelectorXKey);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TargetPointSelectorYKey(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushstring(L, Utils.TargetPointSelectorYKey);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_RadianToAngle(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, Utils.RadianToAngle);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AngleToRadian(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, Utils.AngleToRadian);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HalfPI(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, Utils.HalfPI);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NotCompleted(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, Utils.NotCompleted);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NoValue(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, Utils.NoValue);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FloatSign(IntPtr L)
	{
		try
		{
			LuaDLL.tolua_pushint64(L, Utils.FloatSign);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DoubleSign(IntPtr L)
	{
		try
		{
			LuaDLL.tolua_pushuint64(L, Utils.DoubleSign);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ApproachZero(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, Utils.ApproachZero);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ApproachKZero(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, Utils.ApproachKZero);
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
			ToLua.PushObject(L, Utils.Single);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

