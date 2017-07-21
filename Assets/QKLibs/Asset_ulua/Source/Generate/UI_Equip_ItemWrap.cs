﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UI_Equip_ItemWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UI_Equip_Item), typeof(UIScrollViewItemBase));
		L.RegFunction("setIcon", setIcon);
		L.RegFunction("setIconFrame", setIconFrame);
		L.RegFunction("setIconSelectFrame", setIconSelectFrame);
		L.RegFunction("setEquipmentLevel", setEquipmentLevel);
		L.RegFunction("setEquipped", setEquipped);
		L.RegFunction("setEquipmentLock", setEquipmentLock);
		L.RegFunction("setEmpty", setEmpty);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("_EquipID", get__EquipID, set__EquipID);
		L.RegVar("sIcon", get_sIcon, set_sIcon);
		L.RegVar("sIconFrame", get_sIconFrame, set_sIconFrame);
		L.RegVar("sIconSelectFrame", get_sIconSelectFrame, set_sIconSelectFrame);
		L.RegVar("tEquipmentLevel", get_tEquipmentLevel, set_tEquipmentLevel);
		L.RegVar("sEquipped", get_sEquipped, set_sEquipped);
		L.RegVar("sLocked", get_sLocked, set_sLocked);
		L.RegVar("cEquipment", get_cEquipment, set_cEquipment);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setIcon(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes(L, 1, typeof(UI_Equip_Item), typeof(string)))
			{
				UI_Equip_Item obj = (UI_Equip_Item)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				obj.setIcon(arg0);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UI_Equip_Item), typeof(UIAtlas), typeof(string)))
			{
				UI_Equip_Item obj = (UI_Equip_Item)ToLua.ToObject(L, 1);
				UIAtlas arg0 = (UIAtlas)ToLua.ToObject(L, 2);
				string arg1 = ToLua.ToString(L, 3);
				obj.setIcon(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UI_Equip_Item.setIcon");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setIconFrame(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes(L, 1, typeof(UI_Equip_Item), typeof(string)))
			{
				UI_Equip_Item obj = (UI_Equip_Item)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				obj.setIconFrame(arg0);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(UI_Equip_Item), typeof(UIAtlas), typeof(string)))
			{
				UI_Equip_Item obj = (UI_Equip_Item)ToLua.ToObject(L, 1);
				UIAtlas arg0 = (UIAtlas)ToLua.ToObject(L, 2);
				string arg1 = ToLua.ToString(L, 3);
				obj.setIconFrame(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UI_Equip_Item.setIconFrame");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setIconSelectFrame(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UI_Equip_Item obj = (UI_Equip_Item)ToLua.CheckObject(L, 1, typeof(UI_Equip_Item));
			string arg0 = ToLua.CheckString(L, 2);
			obj.setIconSelectFrame(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setEquipmentLevel(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UI_Equip_Item obj = (UI_Equip_Item)ToLua.CheckObject(L, 1, typeof(UI_Equip_Item));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.setEquipmentLevel(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setEquipped(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UI_Equip_Item obj = (UI_Equip_Item)ToLua.CheckObject(L, 1, typeof(UI_Equip_Item));
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.setEquipped(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setEquipmentLock(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UI_Equip_Item obj = (UI_Equip_Item)ToLua.CheckObject(L, 1, typeof(UI_Equip_Item));
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.setEquipmentLock(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setEmpty(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)ToLua.CheckObject(L, 1, typeof(UI_Equip_Item));
			obj.setEmpty();
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
	static int get__EquipID(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			int ret = obj._EquipID;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index _EquipID on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sIcon(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UISprite ret = obj.sIcon;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sIcon on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sIconFrame(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UISprite ret = obj.sIconFrame;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sIconFrame on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sIconSelectFrame(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UISprite ret = obj.sIconSelectFrame;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sIconSelectFrame on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tEquipmentLevel(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UILabel ret = obj.tEquipmentLevel;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index tEquipmentLevel on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sEquipped(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UISprite ret = obj.sEquipped;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sEquipped on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sLocked(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UISprite ret = obj.sLocked;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sLocked on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cEquipment(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UnityEngine.GameObject ret = obj.cEquipment;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index cEquipment on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set__EquipID(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj._EquipID = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index _EquipID on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sIcon(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UISprite arg0 = (UISprite)ToLua.CheckUnityObject(L, 2, typeof(UISprite));
			obj.sIcon = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sIcon on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sIconFrame(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UISprite arg0 = (UISprite)ToLua.CheckUnityObject(L, 2, typeof(UISprite));
			obj.sIconFrame = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sIconFrame on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sIconSelectFrame(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UISprite arg0 = (UISprite)ToLua.CheckUnityObject(L, 2, typeof(UISprite));
			obj.sIconSelectFrame = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sIconSelectFrame on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tEquipmentLevel(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UILabel arg0 = (UILabel)ToLua.CheckUnityObject(L, 2, typeof(UILabel));
			obj.tEquipmentLevel = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index tEquipmentLevel on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sEquipped(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UISprite arg0 = (UISprite)ToLua.CheckUnityObject(L, 2, typeof(UISprite));
			obj.sEquipped = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sEquipped on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sLocked(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UISprite arg0 = (UISprite)ToLua.CheckUnityObject(L, 2, typeof(UISprite));
			obj.sLocked = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index sLocked on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cEquipment(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UI_Equip_Item obj = (UI_Equip_Item)o;
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.GameObject));
			obj.cEquipment = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index cEquipment on a nil value" : e.Message);
		}
	}
}

