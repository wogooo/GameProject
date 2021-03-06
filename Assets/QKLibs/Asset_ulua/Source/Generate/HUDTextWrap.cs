﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class HUDTextWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(HUDText), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("AddLocalized", AddLocalized);
		L.RegFunction("Add", Add);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("bitmapFont", get_bitmapFont, set_bitmapFont);
		L.RegVar("trueTypeFont", get_trueTypeFont, set_trueTypeFont);
		L.RegVar("fontSize", get_fontSize, set_fontSize);
		L.RegVar("fontStyle", get_fontStyle, set_fontStyle);
		L.RegVar("applyGradient", get_applyGradient, set_applyGradient);
		L.RegVar("gradientTop", get_gradientTop, set_gradientTop);
		L.RegVar("gradienBottom", get_gradienBottom, set_gradienBottom);
		L.RegVar("effect", get_effect, set_effect);
		L.RegVar("effectColor", get_effectColor, set_effectColor);
		L.RegVar("offsetCurve", get_offsetCurve, set_offsetCurve);
		L.RegVar("alphaCurve", get_alphaCurve, set_alphaCurve);
		L.RegVar("scaleCurve", get_scaleCurve, set_scaleCurve);
		L.RegVar("isVisible", get_isVisible, null);
		L.RegVar("ambigiousFont", get_ambigiousFont, set_ambigiousFont);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddLocalized(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			HUDText obj = (HUDText)ToLua.CheckObject(L, 1, typeof(HUDText));
			string arg0 = ToLua.CheckString(L, 2);
			UnityEngine.Color arg1 = ToLua.ToColor(L, 3);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);
			obj.AddLocalized(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Add(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			HUDText obj = (HUDText)ToLua.CheckObject(L, 1, typeof(HUDText));
			object arg0 = ToLua.ToVarObject(L, 2);
			UnityEngine.Color arg1 = ToLua.ToColor(L, 3);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);
			obj.Add(arg0, arg1, arg2);
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
	static int get_bitmapFont(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UIFont ret = obj.bitmapFont;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index bitmapFont on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_trueTypeFont(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.Font ret = obj.trueTypeFont;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index trueTypeFont on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fontSize(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			int ret = obj.fontSize;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fontSize on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fontStyle(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.FontStyle ret = obj.fontStyle;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fontStyle on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_applyGradient(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			bool ret = obj.applyGradient;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index applyGradient on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gradientTop(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.Color ret = obj.gradientTop;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index gradientTop on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gradienBottom(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.Color ret = obj.gradienBottom;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index gradienBottom on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_effect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UILabel.Effect ret = obj.effect;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index effect on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_effectColor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.Color ret = obj.effectColor;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index effectColor on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_offsetCurve(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.AnimationCurve ret = obj.offsetCurve;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index offsetCurve on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_alphaCurve(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.AnimationCurve ret = obj.alphaCurve;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index alphaCurve on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scaleCurve(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.AnimationCurve ret = obj.scaleCurve;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index scaleCurve on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isVisible(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			bool ret = obj.isVisible;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index isVisible on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ambigiousFont(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.Object ret = obj.ambigiousFont;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index ambigiousFont on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bitmapFont(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UIFont arg0 = (UIFont)ToLua.CheckUnityObject(L, 2, typeof(UIFont));
			obj.bitmapFont = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index bitmapFont on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_trueTypeFont(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.Font arg0 = (UnityEngine.Font)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Font));
			obj.trueTypeFont = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index trueTypeFont on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fontSize(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.fontSize = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fontSize on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fontStyle(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.FontStyle arg0 = (UnityEngine.FontStyle)ToLua.CheckObject(L, 2, typeof(UnityEngine.FontStyle));
			obj.fontStyle = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index fontStyle on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_applyGradient(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.applyGradient = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index applyGradient on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gradientTop(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			obj.gradientTop = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index gradientTop on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gradienBottom(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			obj.gradienBottom = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index gradienBottom on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_effect(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UILabel.Effect arg0 = (UILabel.Effect)ToLua.CheckObject(L, 2, typeof(UILabel.Effect));
			obj.effect = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index effect on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_effectColor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			obj.effectColor = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index effectColor on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_offsetCurve(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.AnimationCurve arg0 = (UnityEngine.AnimationCurve)ToLua.CheckObject(L, 2, typeof(UnityEngine.AnimationCurve));
			obj.offsetCurve = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index offsetCurve on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_alphaCurve(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.AnimationCurve arg0 = (UnityEngine.AnimationCurve)ToLua.CheckObject(L, 2, typeof(UnityEngine.AnimationCurve));
			obj.alphaCurve = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index alphaCurve on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scaleCurve(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.AnimationCurve arg0 = (UnityEngine.AnimationCurve)ToLua.CheckObject(L, 2, typeof(UnityEngine.AnimationCurve));
			obj.scaleCurve = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index scaleCurve on a nil value" : e.Message);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ambigiousFont(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			HUDText obj = (HUDText)o;
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Object));
			obj.ambigiousFont = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o == null ? "attempt to index ambigiousFont on a nil value" : e.Message);
		}
	}
}

