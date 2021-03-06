﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 地图管理器
/// </summary>
public class MapManager : Singleton<MapManager>
{

    public const string MapDataPacket = "mapdatapack";


    public const string MapDataFileName = "mapdata";
    /// <summary>
    /// 地图文件数据字典
    /// (地图文件名, 地图数据)
    /// </summary>
    private Dictionary<string, string> mapDataDic = null;

    /// <summary>
    /// 地图文件是否已加载
    /// </summary>
    private bool isLoaded = false;
    // -----------------文件加载管理--------------------

    /// <summary>
    /// 按照ID加载文件, 并且将加载文件缓存
    /// </summary>
    /// <param name="mapId">被加载地图DI</param>
    /// <param name="level">被加载层级</param>
    /// <returns>被加载地图内容, 如果不存在返回null</returns>
    public int[][] GetMapInfoById(int mapId, int level)
    {
        int[][] result = null;

        if (!isLoaded)
        {
            // 加载文件
            mapDataDic = Utils.DepartFileData(PacketManage.Single.GetPacket(MapDataPacket).LoadString(MapDataFileName));
            
            //mapDataDic = Utils.DepartFileData(Utils.LoadFileRotate(@"MapData\mapdata"));
            //var mapData = GameObjectExtension.InstantiateModelFromPacket(MapDataPacket, MapDataFileName, null);
            
            if (mapDataDic == null)
            {
                Debug.LogError("加载失败");
            }
            else
            {
                isLoaded = true;
            }
        }
        if (mapId > 0)
        {
            // 从缓存中查找, 如果缓存中不存在, 则从文件中加载
            var key = Utils.GetMapFileNameById(mapId, level);
            if (mapDataDic != null && mapDataDic.ContainsKey(key))
            {
                result = DeCodeInfo(mapDataDic[key]);
            }
            else
            {
                Debug.LogError("地图不存在 ID:" + mapId);
            }
        }

        return result;
    }


    /// <summary>
    /// 解析建筑地图
    /// </summary>
    /// <param name="mapData">地图数据</param>
    /// <param name="packer">数据包装</param>
    public void AnalysisMap(int[][] mapData, MapDataParamsPacker packer = null)
    {

        // 获取基地位置
        for (var row = 0; row < mapData.Length; row++)
        {
            var line = mapData[row];
            for (var col = 0; col < line.Length; col++)
            {
                var cell = line[col];
                switch (cell)
                {
                    case Utils.Accessibility:
                        // 无障碍
                        break;
                    case Utils.Obstacle:
                    {
                        // 障碍物
                        var paramObj = new CreateActorParam(col, row);
                        FightUnitFactory.CreateUnit((int) ObjectID.ObjectType.NPCObstacle, paramObj).ClusterData.Begin();
                    }
                        break;
                    case Utils.MyBaseId:
                    {
                        // 我方基地
                        var pos = Utils.NumToPosition(LoadMap.Single.transform.position, new Vector2(col, row),
                            ClusterManager.Single.UnitWidth, ClusterManager.Single.MapWidth,
                            ClusterManager.Single.MapHeight);
                        var paramObj = new CreateActorParam(pos.x, pos.z, packer.BaseLevel);
                        FightUnitFactory.CreateUnit((int)ObjectID.ObjectType.MyJiDi, paramObj).ClusterData.Begin();
                    }
                        break;
                    case Utils.MyTurretId:
                    {
                        // 我方防御塔
                        var pos = Utils.NumToPosition(LoadMap.Single.transform.position, new Vector2(col, row),
                            ClusterManager.Single.UnitWidth, ClusterManager.Single.MapWidth,
                            ClusterManager.Single.MapHeight);
                        var paramObj = new CreateActorParam(pos.x, pos.z, packer.TurretLevel);
                        FightUnitFactory.CreateUnit((int)ObjectID.ObjectType.MyTower, paramObj).ClusterData.Begin();
                    }
                        break;
                    case Utils.EnemyBaseId:
                    {
                        // 敌方基地
                        var pos = Utils.NumToPosition(LoadMap.Single.transform.position, new Vector2(col, row),
                            ClusterManager.Single.UnitWidth, ClusterManager.Single.MapWidth,
                            ClusterManager.Single.MapHeight);
                        var paramObj = new CreateActorParam(pos.x, pos.z, packer.EnemyBaseLevel);
                        FightUnitFactory.CreateUnit((int)ObjectID.ObjectType.EnemyJiDi, paramObj).ClusterData.Begin();
                    }
                        break;
                    case Utils.EnemyTurretId:
                    {
                        // 敌方防御塔
                        var pos = Utils.NumToPosition(LoadMap.Single.transform.position, new Vector2(col, row),
                            ClusterManager.Single.UnitWidth, ClusterManager.Single.MapWidth,
                            ClusterManager.Single.MapHeight);
                        var paramObj = new CreateActorParam(pos.x, pos.z, packer.TurretLevel);
                        var turret = FightUnitFactory.CreateUnit((int)ObjectID.ObjectType.EnemyTower, paramObj);
                        turret.ClusterData.Begin();
                    }
                        break;
                }
            }
        }
    }


    /// <summary>
    /// 解码地图数据
    /// </summary>
    /// <param name="mapInfoJson">地图数据json</param>
    /// <returns>地图数据数组</returns>
    private int[][] DeCodeInfo(string mapInfoJson)
    {
        if (string.IsNullOrEmpty(mapInfoJson))
        {
            return null;
        }
        //var mapData = new List<List<int>>();
        // 读出数据
        var mapLines = mapInfoJson.Split('\n');

        int[][] mapInfo = new int[mapLines.Length][];
        for (var row = 0; row < mapLines.Length; row++)
        {
            var line = mapLines[row];
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            var cells = line.Split(',');
            mapInfo[row] = new int[cells.Length];
            for (int col = 0; col < cells.Length; col++)
            {
                if (string.IsNullOrEmpty(cells[col].Trim()))
                {
                    continue;
                }
                //Debug.Log(cells[col]);
                mapInfo[row][col] = int.Parse(cells[col]);
            }
        }

        return mapInfo;
    }

    /// <summary>
    /// 地图数据包装类
    /// </summary>
    public class MapDataParamsPacker
    {
        /// <summary>
        /// 地图Id
        /// </summary>
        public int MapId = -1;

        /// <summary>
        /// 我方基地等级
        /// </summary>
        public int BaseLevel = 1;

        /// <summary>
        /// 我方防御塔等级
        /// </summary>
        public int TurretLevel = 1;

        /// <summary>
        /// 我方种族
        /// </summary>
        public int Race = 0;

        /// <summary>
        /// 敌方基地等级
        /// </summary>
        public int EnemyBaseLevel = 1;

        /// <summary>
        /// 敌方防御塔等级
        /// </summary>
        public int EnemyTurretLevel = 1;
        /// <summary>
        /// 敌方种族
        /// </summary>
        public int EnemyRace = 0;
    }
}