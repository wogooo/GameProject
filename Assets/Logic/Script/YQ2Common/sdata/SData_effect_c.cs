using System;
using System.Collections.Generic;
using LuaInterface;

public class SData_effect_c : MonoEX.Singleton<SData_effect_c>
{
    public void setData(LuaTable table1, LuaTable table2)
    {
        var head = new string[table1.Length];
        SDataUtils.dealTable(table1, (Object o1, Object o2) =>
        {
            head[(int)(double)o1 - 1] = (string)o2;
        });
        SDataUtils.dealTable(table2, (Object o1, Object o2) =>
        {
            effect_cInfo dif = new effect_cInfo();
            SDataUtils.dealTable((LuaTable)o2, (Object o11, Object o22) =>
            {
                switch (head[(int)(double)o11 - 1])
				{
					case "ArmyID": dif.ArmyID = (int)(double)o22; break;
					case "MuzzleFlash": dif.MuzzleFlash = (string)o22; break;
					case "FlashPlayTime": dif.FlashPlayTime = (float)(double)o22; break;
					case "Bullet": dif.Bullet = (string)o22; break;
					case "BulletType": dif.BulletType = (short)(double)o22; break;
					case "Chain": dif.Chain = (string)o22; break;
					case "ChainPlayTime": dif.ChainPlayTime = (float)(double)o22; break;
					case "Range": dif.Range = (string)o22; break;
					case "RangePlayTime": dif.RangePlayTime = (float)(double)o22; break;
					case "Trajectory": dif.Trajectory = (string)o22; break;
					case "Gethit_Bullet": dif.Gethit_Bullet = (string)o22; break;
					case "Gethit_BulletPlayTime": dif.Gethit_BulletPlayTime = (float)(double)o22; break;
					case "Gethit_Missile": dif.Gethit_Missile = (string)o22; break;
					case "Gethit_MissilePlayTime": dif.Gethit_MissilePlayTime = (float)(double)o22; break;
                }
            });
            if (Data.ContainsKey(dif.ArmyID))
                MonoEX.Debug.Logout(MonoEX.LOG_TYPE.LT_ERROR, "重复的ID：" + dif.ArmyID.ToString());
            Data.Add(dif.ArmyID, dif);
        });
    }

    public effect_cInfo GetDataOfID(int Id)
    {
        if (!Data.ContainsKey(Id)) throw new Exception(String.Format("effect_cInfo::GetDataOfID() not found data  Id:{0}", Id));
        return Data[Id];
    }

    internal Dictionary<int, effect_cInfo> Data = new Dictionary<int, effect_cInfo>();
}


public struct effect_cInfo
{
	 /// <summary>
	 ///单位ID
	 /// </summary>
	public int ArmyID;
	 /// <summary>
	 ///枪口火焰
	 /// </summary>
	public string MuzzleFlash;
	 /// <summary>
	 ///火焰播放时间
	 /// </summary>
	public float FlashPlayTime;
	 /// <summary>
	 ///子弹
	 /// </summary>
	public string Bullet;
	 /// <summary>
	 ///子弹类型
	 /// </summary>
	public short BulletType;
	 /// <summary>
	 ///链状特效
	 /// </summary>
	public string Chain;
	 /// <summary>
	 ///链状特效播放时间
	 /// </summary>
	public float ChainPlayTime;
	 /// <summary>
	 ///范围效果
	 /// </summary>
	public string Range;
	 /// <summary>
	 ///范围效果播放时间
	 /// </summary>
	public float RangePlayTime;
	 /// <summary>
	 ///特效轨迹
	 /// </summary>
	public string Trajectory;
	 /// <summary>
	 ///受击子弹
	 /// </summary>
	public string Gethit_Bullet;
	 /// <summary>
	 ///受击子弹播放时间
	 /// </summary>
	public float Gethit_BulletPlayTime;
	 /// <summary>
	 ///受击导弹
	 /// </summary>
	public string Gethit_Missile;
	 /// <summary>
	 ///受击导弹播放时间
	 /// </summary>
	public float Gethit_MissilePlayTime;
}
