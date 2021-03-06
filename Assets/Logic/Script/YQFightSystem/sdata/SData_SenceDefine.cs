﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SenceDefineInfo
{
    internal static void FillFieldIndex(ITabReader reader)
    {
        IdependPacks = reader.ColumnName2Index("dependPacks");
        IID = reader.ColumnName2Index("ID");
    }

    public SenceDefineInfo(ITabReader reader, int row)
    {
        ID = reader.GetI16(IID, row);
        string pack_str = reader.GetS(IdependPacks, row);
        pack_str = pack_str.Trim();
        if (string.IsNullOrEmpty(pack_str))
            DependPacks = new string[0];
        else
            DependPacks = pack_str.Split(';');
    }

    public readonly short ID;
    public readonly string[] DependPacks;

    internal static short IdependPacks;
    internal static short IID;
}

public class SData_SenceDefine : MonoEX.Singleton<SData_SenceDefine>
{
    public SData_SenceDefine()
    {
        using (ITabReader reader = TabReaderManage.Single.CreateInstance())
        {
            MonoEX.Debug.Logout(MonoEX.LOG_TYPE.LT_INFO, "开始装载 SenceDefine");

            reader.Load("bsv", "SenceDefine");
            SenceDefineInfo.FillFieldIndex(reader);

            int rowCount = reader.GetRowCount();
            //TODODO
            rowCount = 1;
            for (int row = 0; row < rowCount; row++)
            {
                SenceDefineInfo currInfo = new SenceDefineInfo(reader, row);

                string[] depend = new string[currInfo.DependPacks.Length + 1];
                int idx = 0;
                Array.ForEach(currInfo.DependPacks, (i) => depend[idx++] = i);
                depend[idx] = SceneID2LevelName(currInfo.ID);

                SceneManage.Single.RegScene(SceneID2LevelName(currInfo.ID), depend);//注册场景
            }

        }
    }

    public static string SceneID2LevelName(int id)
    {
        return string.Format("tzbd_{0:D2}", id);
    }
}