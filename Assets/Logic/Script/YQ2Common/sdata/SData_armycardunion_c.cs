using System;
using System.Collections.Generic;
using LuaInterface;

public class SData_armycardunion_c : MonoEX.Singleton<SData_armycardunion_c>
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
            armycardunion_cInfo dif = new armycardunion_cInfo();
            SDataUtils.dealTable((LuaTable)o2, (Object o11, Object o22) =>
            {
                switch (head[(int)(double)o11 - 1])
				{
					case "UniqueID": dif.UniqueID = (int)(double)o22; break;
					case "ArmyCardID": dif.ArmyCardID = (int)(double)o22; break;
					case "ArmyUnionLevel": dif.ArmyUnionLevel = (short)(double)o22; break;
					case "UnionAttributeAdd1": dif.UnionAttributeAdd1 = (int)(double)o22; break;
					case "AddPoint1": dif.AddPoint1 = (float)(double)o22; break;
					case "UnionAttributeAdd2": dif.UnionAttributeAdd2 = (int)(double)o22; break;
					case "AddPoint2": dif.AddPoint2 = (float)(double)o22; break;
					case "UnionAttributeAdd3": dif.UnionAttributeAdd3 = (int)(double)o22; break;
					case "AddPoint3": dif.AddPoint3 = (float)(double)o22; break;
					case "UnionAttribute1": dif.UnionAttribute1 = (int)(double)o22; break;
					case "Point1": dif.Point1 = (float)(double)o22; break;
					case "RequireCardID1": dif.RequireCardID1 = (int)(double)o22; break;
					case "RequireCardStar1": dif.RequireCardStar1 = (short)(double)o22; break;
					case "RequireCardLevel1": dif.RequireCardLevel1 = (short)(double)o22; break;
					case "RequireCardQuality1": dif.RequireCardQuality1 = (short)(double)o22; break;
					case "UnionAttribute2": dif.UnionAttribute2 = (int)(double)o22; break;
					case "Point2": dif.Point2 = (float)(double)o22; break;
					case "RequireCardID2": dif.RequireCardID2 = (int)(double)o22; break;
					case "RequireCardStar2": dif.RequireCardStar2 = (short)(double)o22; break;
					case "RequireCardLevel2": dif.RequireCardLevel2 = (short)(double)o22; break;
					case "RequireCardQuality2": dif.RequireCardQuality2 = (short)(double)o22; break;
					case "UnionAttribute3": dif.UnionAttribute3 = (int)(double)o22; break;
					case "Point3": dif.Point3 = (float)(double)o22; break;
					case "RequireCardID3": dif.RequireCardID3 = (int)(double)o22; break;
					case "RequireCardStar3": dif.RequireCardStar3 = (short)(double)o22; break;
					case "RequireCardLevel3": dif.RequireCardLevel3 = (short)(double)o22; break;
					case "RequireCardQuality3": dif.RequireCardQuality3 = (short)(double)o22; break;
					case "UnionAttribute4": dif.UnionAttribute4 = (int)(double)o22; break;
					case "Point4": dif.Point4 = (float)(double)o22; break;
					case "RequireCardID4": dif.RequireCardID4 = (int)(double)o22; break;
					case "RequireCardStar4": dif.RequireCardStar4 = (short)(double)o22; break;
					case "RequireCardLevel4": dif.RequireCardLevel4 = (short)(double)o22; break;
					case "RequireCardQuality4": dif.RequireCardQuality4 = (short)(double)o22; break;
                }
            });
            if (Data.ContainsKey(dif.UniqueID))
                MonoEX.Debug.Logout(MonoEX.LOG_TYPE.LT_ERROR, "重复的ID：" + dif.UniqueID.ToString());
            Data.Add(dif.UniqueID, dif);
        });
    }

    public armycardunion_cInfo GetDataOfID(int Id)
    {
        if (!Data.ContainsKey(Id)) throw new Exception(String.Format("armycardunion_cInfo::GetDataOfID() not found data  Id:{0}", Id));
        return Data[Id];
    }

    internal Dictionary<int, armycardunion_cInfo> Data = new Dictionary<int, armycardunion_cInfo>();
}


public struct armycardunion_cInfo
{
	 /// <summary>
	 ///唯一ID
	 /// </summary>
	public int UniqueID;
	 /// <summary>
	 ///卡牌ID
	 /// </summary>
	public int ArmyCardID;
	 /// <summary>
	 ///协同等级
	 /// </summary>
	public short ArmyUnionLevel;
	 /// <summary>
	 ///协同额外属性1
	 /// </summary>
	public int UnionAttributeAdd1;
	 /// <summary>
	 ///协同额外属性值1
	 /// </summary>
	public float AddPoint1;
	 /// <summary>
	 ///协同额外属性2
	 /// </summary>
	public int UnionAttributeAdd2;
	 /// <summary>
	 ///协同额外属性值2
	 /// </summary>
	public float AddPoint2;
	 /// <summary>
	 ///协同额外属性3
	 /// </summary>
	public int UnionAttributeAdd3;
	 /// <summary>
	 ///协同额外属性值3
	 /// </summary>
	public float AddPoint3;
	 /// <summary>
	 ///协同属性1
	 /// </summary>
	public int UnionAttribute1;
	 /// <summary>
	 ///协同属性值1
	 /// </summary>
	public float Point1;
	 /// <summary>
	 ///需求卡牌ID1
	 /// </summary>
	public int RequireCardID1;
	 /// <summary>
	 ///需求卡牌星级1
	 /// </summary>
	public short RequireCardStar1;
	 /// <summary>
	 ///需求卡牌等级1
	 /// </summary>
	public short RequireCardLevel1;
	 /// <summary>
	 ///需求卡牌品质1
	 /// </summary>
	public short RequireCardQuality1;
	 /// <summary>
	 ///协同属性2
	 /// </summary>
	public int UnionAttribute2;
	 /// <summary>
	 ///协同属性值2
	 /// </summary>
	public float Point2;
	 /// <summary>
	 ///需求卡牌ID2
	 /// </summary>
	public int RequireCardID2;
	 /// <summary>
	 ///需求卡牌星级2
	 /// </summary>
	public short RequireCardStar2;
	 /// <summary>
	 ///需求卡牌等级2
	 /// </summary>
	public short RequireCardLevel2;
	 /// <summary>
	 ///需求卡牌品质2
	 /// </summary>
	public short RequireCardQuality2;
	 /// <summary>
	 ///协同属性3
	 /// </summary>
	public int UnionAttribute3;
	 /// <summary>
	 ///协同属性值3
	 /// </summary>
	public float Point3;
	 /// <summary>
	 ///需求卡牌ID3
	 /// </summary>
	public int RequireCardID3;
	 /// <summary>
	 ///需求卡牌星级3
	 /// </summary>
	public short RequireCardStar3;
	 /// <summary>
	 ///需求卡牌等级3
	 /// </summary>
	public short RequireCardLevel3;
	 /// <summary>
	 ///需求卡牌品质3
	 /// </summary>
	public short RequireCardQuality3;
	 /// <summary>
	 ///协同属性4
	 /// </summary>
	public int UnionAttribute4;
	 /// <summary>
	 ///协同属性值4
	 /// </summary>
	public float Point4;
	 /// <summary>
	 ///需求卡牌ID4
	 /// </summary>
	public int RequireCardID4;
	 /// <summary>
	 ///需求卡牌星级4
	 /// </summary>
	public short RequireCardStar4;
	 /// <summary>
	 ///需求卡牌等级4
	 /// </summary>
	public short RequireCardLevel4;
	 /// <summary>
	 ///需求卡牌品质4
	 /// </summary>
	public short RequireCardQuality4;
}
