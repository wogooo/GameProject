using System;
using System.Collections.Generic;
using LuaInterface;

public class SData_equiprecast_c : MonoEX.Singleton<SData_equiprecast_c>
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
            equiprecast_cInfo dif = new equiprecast_cInfo();
            SDataUtils.dealTable((LuaTable)o2, (Object o11, Object o22) =>
            {
                switch (head[(int)(double)o11 - 1])
				{
					case "RecastQuality": dif.RecastQuality = (short)(double)o22; break;
					case "Item1": dif.Item1 = (int)(double)o22; break;
					case "Num1": dif.Num1 = (short)(double)o22; break;
					case "Item2": dif.Item2 = (int)(double)o22; break;
					case "Num2": dif.Num2 = (short)(double)o22; break;
                }
            });
            if (Data.ContainsKey(dif.RecastQuality))
                MonoEX.Debug.Logout(MonoEX.LOG_TYPE.LT_ERROR, "重复的ID：" + dif.RecastQuality.ToString());
            Data.Add(dif.RecastQuality, dif);
        });
    }

    public equiprecast_cInfo GetDataOfID(int Id)
    {
        if (!Data.ContainsKey(Id)) throw new Exception(String.Format("equiprecast_cInfo::GetDataOfID() not found data  Id:{0}", Id));
        return Data[Id];
    }

    internal Dictionary<int, equiprecast_cInfo> Data = new Dictionary<int, equiprecast_cInfo>();
}


public struct equiprecast_cInfo
{
	 /// <summary>
	 ///重铸品质
	 /// </summary>
	public short RecastQuality;
	 /// <summary>
	 ///道具ID
	 /// </summary>
	public int Item1;
	 /// <summary>
	 ///需求数量
	 /// </summary>
	public short Num1;
	 /// <summary>
	 ///道具ID
	 /// </summary>
	public int Item2;
	 /// <summary>
	 ///需求数量
	 /// </summary>
	public short Num2;
}
