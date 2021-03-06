using System;
using System.Collections.Generic;
using LuaInterface;

public class SData_soldierRender_data : MonoEX.Singleton<SData_soldierRender_data>
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
            soldierRender_dataInfo dif = new soldierRender_dataInfo();
            SDataUtils.dealTable((LuaTable)o2, (Object o11, Object o22) =>
            {
                switch (head[(int)(double)o11 - 1])
				{
					case "ArmyID": dif.ArmyID = (int)(double)o22; break;
					case "CmType": dif.CmType = (short)(double)o22; break;
					case "ColorMat": dif.ColorMat = (short)(double)o22; break;
					case "FlagColorIdx": dif.FlagColorIdx = (short)(double)o22; break;
					case "MeshPackName": dif.MeshPackName = (string)o22; break;
					case "TexturePackName": dif.TexturePackName = (string)o22; break;
					case "IsHero": dif.IsHero = (short)(double)o22; break;
                }
            });
            if (Data.ContainsKey(dif.ArmyID))
                MonoEX.Debug.Logout(MonoEX.LOG_TYPE.LT_ERROR, "重复的ID：" + dif.ArmyID.ToString());
            Data.Add(dif.ArmyID, dif);
        });
    }

    public soldierRender_dataInfo GetDataOfID(int Id)
    {
        if (!Data.ContainsKey(Id)) throw new Exception(String.Format("soldierRender_dataInfo::GetDataOfID() not found data  Id:{0}", Id));
        return Data[Id];
    }

    internal Dictionary<int, soldierRender_dataInfo> Data = new Dictionary<int, soldierRender_dataInfo>();
}


public struct soldierRender_dataInfo
{
	 /// <summary>
	 ///
	 /// </summary>
	public int ArmyID;
	 /// <summary>
	 ///
	 /// </summary>
	public short CmType;
	 /// <summary>
	 ///
	 /// </summary>
	public short ColorMat;
	 /// <summary>
	 ///
	 /// </summary>
	public short FlagColorIdx;
	 /// <summary>
	 ///
	 /// </summary>
	public string MeshPackName;
	 /// <summary>
	 ///
	 /// </summary>
	public string TexturePackName;
	 /// <summary>
	 ///
	 /// </summary>
	public short IsHero;
}
