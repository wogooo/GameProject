﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class PositionObjectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PositionObject), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("Begin", Begin);
		L.RegFunction("StopMove", StopMove);
		L.RegFunction("ContinueMove", ContinueMove);
		L.RegFunction("Clear", Clear);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("AllData", get_AllData, set_AllData);
		L.RegVar("MyCollisionGraphics", get_MyCollisionGraphics, set_MyCollisionGraphics);
		L.RegVar("Id", get_Id, null);
		L.RegVar("CollisionGroup", get_CollisionGroup, set_CollisionGroup);
		L.RegVar("Diameter", get_Diameter, set_Diameter);
		L.RegVar("Position", get_Position, set_Position);
		L.RegVar("X", get_X, set_X);
		L.RegVar("Y", get_Y, set_Y);
		L.RegVar("Height", get_Height, set_Height);
		L.RegVar("Rotate", null, set_Rotate);
		L.RegVar("Direction", get_Direction, set_Direction);
		L.RegVar("DirectionRight", get_DirectionRight, null);
		L.RegVar("ItemObj", get_ItemObj, null);
		L.RegVar("CouldMove", get_CouldMove, null);
		L.RegVar("IsMoving", get_IsMoving, null);
		L.RegVar("Quality", get_Quality, set_Quality);
		L.RegVar("SpeedDirection", get_SpeedDirection, set_SpeedDirection);
		L.RegVar("MaxSpeed", get_MaxSpeed, set_MaxSpeed);
		L.RegVar("CouldSelect", get_CouldSelect, set_CouldSelect);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Begin(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PositionObject obj = (PositionObject)ToLua.CheckObject(L, 1, typeof(PositionObject));
			obj.Begin();
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
			PositionObject obj = (PositionObject)ToLua.CheckObject(L, 1, typeof(PositionObject));
			obj.StopMove();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ContinueMove(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PositionObject obj = (PositionObject)ToLua.CheckObject(L, 1, typeof(PositionObject));
			obj.ContinueMove();
			return 0;
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
			PositionObject obj = (PositionObject)ToLua.CheckObject(L, 1, typeof(PositionObject));
			obj.Clear();
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
	static int get_AllData(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			AllData ret = obj.AllData;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index AllData on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MyCollisionGraphics(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			ICollisionGraphics ret = obj.MyCollisionGraphics;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index MyCollisionGraphics on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Id(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			long ret = obj.Id;
			LuaDLL.tolua_pushint64(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Id on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CollisionGroup(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			int ret = obj.CollisionGroup;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index CollisionGroup on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Diameter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			float ret = obj.Diameter;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Diameter on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Position(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			UnityEngine.Vector3 ret = obj.Position;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Position on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_X(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			float ret = obj.X;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index X on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Y(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			float ret = obj.Y;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Y on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Height(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			float ret = obj.Height;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Height on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Direction(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			UnityEngine.Vector3 ret = obj.Direction;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Direction on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DirectionRight(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			UnityEngine.Vector3 ret = obj.DirectionRight;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index DirectionRight on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ItemObj(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			UnityEngine.GameObject ret = obj.ItemObj;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index ItemObj on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CouldMove(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			bool ret = obj.CouldMove;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index CouldMove on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsMoving(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			bool ret = obj.IsMoving;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index IsMoving on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Quality(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			float ret = obj.Quality;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Quality on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SpeedDirection(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			UnityEngine.Vector3 ret = obj.SpeedDirection;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index SpeedDirection on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MaxSpeed(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			float ret = obj.MaxSpeed;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index MaxSpeed on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_CouldSelect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			bool ret = obj.CouldSelect;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index CouldSelect on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AllData(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			AllData arg0 = (AllData)ToLua.CheckObject(L, 2, typeof(AllData));
			obj.AllData = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index AllData on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MyCollisionGraphics(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			ICollisionGraphics arg0 = (ICollisionGraphics)ToLua.CheckObject(L, 2, typeof(ICollisionGraphics));
			obj.MyCollisionGraphics = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index MyCollisionGraphics on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CollisionGroup(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.CollisionGroup = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index CollisionGroup on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Diameter(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.Diameter = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Diameter on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Position(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.Position = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Position on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_X(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.X = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index X on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Y(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.Y = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Y on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Height(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.Height = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Height on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Rotate(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.Rotate = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Rotate on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Direction(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.Direction = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Direction on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Quality(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.Quality = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index Quality on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SpeedDirection(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.SpeedDirection = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index SpeedDirection on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MaxSpeed(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.MaxSpeed = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index MaxSpeed on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_CouldSelect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			PositionObject obj = (PositionObject)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.CouldSelect = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index CouldSelect on a nil value" : e.Message);
		}
	}
}

