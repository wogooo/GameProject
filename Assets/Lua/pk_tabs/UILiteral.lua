local data = {
    info = {key = "$ID", keytype = keytype.int},
    head = {"$ID", "Literal"},
    body = {
        [10001] = {10001, "强化+#N激活"},
        [10002] = {10002, "#N件套属性:"},
        [10003] = {10003, "强化"},
        [10004] = {10004, "重铸"},
        [10005] = {10005, "修理"},
        [10006] = {10006, "1.装备的重铸指对已激活的副属性进行变更\n2.强化等级达到该品质上限时（除白色），按钮为【重铸】\n3.仅紫色，橙色，红色品质的装备可以进行重铸，其他颜色"},
        [10007] = {10007, "经济"},
        [10008] = {10008, "攻击"},
        [10009] = {10009, "防御"},
        [10010] = {10010, "生命"},
        [10011] = {10011, "未激活"},
        [10012] = {10012, "级"},
        [10013] = {10013, "一键"},
        [10014] = {10014, "装备"},
        [10015] = {10015, "维修"},
        [10016] = {10016, "卸下"},
        [10017] = {10017, "更换"},
        [10018] = {10018, "详细属性"},
        [10019] = {10019, "退出游戏"},
        [10020] = {10020, "快速游戏"},
        [10021] = {10021, "继续游戏"},
        [10022] = {10022, "关卡"},
        [10023] = {10023, "难度等级"},
        [10024] = {10024, "通关时基地血量不低于50%"},
        [10025] = {10025, "不使用重型坦克获得胜利"},
        [10026] = {10026, "在120S内获得胜利"},
        [10027] = {10027, "暂停"},
        [10028] = {10028, "确认退出"},
        [10029] = {10029, "确认退出战斗吗？"},
        [10030] = {10030, "退出将不会获得任何奖励，同时本次战斗记录为失败"},
        [10031] = {10031, "剩余兵力"},
        [10032] = {10032, "下一张"},
        [10033] = {10033, "详细属性"},
        [10034] = {10034, "详细属性"},
        [10035] = {10035, "详细属性"},
        [10036] = {10036, "详细属性"},
        [10037] = {10037, "详细属性"},
        [10038] = {10038, "详细属性"},
        [10039] = {10039, "详细属性"},
        --------------------------------------------------
        -- [10000] = {10000, "详细属性"},
        -- [10001] = {10001, "详细属性"},
        -- [10002] = {10002, "详细属性"},
        -- [10003] = {10003, "详细属性"},
        -- [10004] = {10004, "详细属性"},
        -- [10005] = {10005, "详细属性"},
        -- [10006] = {10006, "详细属性"},
        -- [10007] = {10007, "详细属性"},
        -- [10008] = {10008, "详细属性"},
        -- [10009] = {10009, "详细属性"},
        --20001
        [20001] = {20001, "升星"},
        [20002] = {20002, "升级"},
        [20003] = {20003, "生命"},
        [20004] = {20004, "秒伤"},
        [20005] = {20005, "火力"},
        [20006] = {20006, "队伍"},
        [20007] = {20007, "防御"},
        [20008] = {20008, "目标"},
        [20009] = {20009, "射程"},
        [20010] = {20010, "范围"},
        [20011] = {20011, "一键装备"},
        [20012] = {20012, "晋阶"},
        [20013] = {20013, "装备"},
        [20014] = {20014, "获得"},
        [20015] = {20015, "晋阶成功"},
        [20016] = {20016, "军功章"},
        [20017] = {20017, "现有"},
        [20018] = {20018, "需要"},
        [20019] = {20019, "已激活"},
        [20020] = {20020, "信息"},
        [20021] = {20021, "技能"},
        [20022] = {20022, "兵员"},
        [20023] = {20023, "协同"},
        [20024] = {20024, "可分配经验"},
        [20025] = {20025, "升级1次"},
        [20026] = {20026, "升级10次"},
        [20027] = {20027, "兵牌"},
        [20028] = {20028, "拥有"},
        [20029] = {20029, "技能重置"},
        [20030] = {20030, "重置[00FFFF]%s[-]的技能加点\n普通重置返回80%%的技能点\n完美重置返回100%%的技能点"},
        [20031] = {20031, "该卡牌最多可以编队%d(%d)张"},
        [20032] = {20032, "提示:提升协同兵种星级,可获得更多属性"},
        [20033] = {20033, "金币"},
        [20034] = {20034, "协同作战"},
        [20035] = {20035, "协同升级"},
        [20036] = {20036, "可分配经验"},
        [20037] = {20037, "生命成长:"},
        [20038] = {20038, "火力成长:"},
        [20039] = {20039, "防御成长:"},
        [20040] = {20040, "点击任意屏幕继续"},
        [20041] = {20041, "等级:"},
        [20042] = {20042, "说明:"},
        [20043] = {20043, "现有:"},
        [20044] = {20044, "需要:"},
        [20045] = {20045, "二星解锁"},
        [20046] = {20046, "三星解锁"},
        [20047] = {20047, "四星解锁"},
        [20048] = {20048, "五星解锁"},
        [20049] = {20049, "卡牌%d星解锁"},
        [20050] = {20050, "令 [00FF00]%s[-] 和 [00FF00]%s[-] 协同作战"},
        [20051] = {20051, "激活"},

        --卡牌进阶
        [20101] = {20101, "卡牌已达最大阶品！"},
        [20102] = {20102, "晋阶所需材料不足！"},
        [20103] = {20103, "有未激活插槽！"},
        [20104] = {20104, "晋阶需要卡牌等级达到%d级！"},
        [20105] = {20105, "金币不足！"},
        [20106] = {20106, "没有可激活的插槽！"},

        [20111] = {20111, "生命成长:"},
        [20112] = {20112, "火力成长:"},
        [20113] = {20113, "防御成长:"},

        --卡牌升级
        [20201] = {20201, "卡牌已达最大等级！"},
        [20202] = {20202, "可分配经验不足！"},
        [20203] = {20203, "卡牌等级不能超过角色等级，请先提升角色等级！"},
        
        --卡牌星级
        [20301] = {20301, "卡牌已达最大星级！"},
        [20302] = {20302, "升星所需卡牌碎片不足！"},
        [20303] = {20303, "升星所需兵牌数量不足！"},
        
        --技能
        [20401] = {20401, "技能已达最大等级！"},
        [20402] = {20402, "卡牌达到%d星解锁！"},
        [20403] = {20403, "卡牌等级不能大于卡牌阶品等级，请先提升卡牌阶品！"},
        [20404] = {20404, "技能点数不足，请前往xxx获取！"},
        
        --兵员
        [20501] = {20501, "卡牌已达最大兵员等级！"},
        [20502] = {20502, "提升兵员等级所需卡牌碎片不足！"},
        [20503] = {20503, "提升兵员等级所需兵牌数量不足！"},
        [20503] = {20503, "说明:该卡牌最多可以编队%d([00FF00]%d[-])张"},
        [20504] = {20504, "说明:该卡牌最多可以编队%d张"},
        
        --协同
        [20601] = {20601, "协同卡牌星级不足！"},
        [20602] = {20602, "协同卡牌等级不足！"},
        [20603] = {20603, "协同卡牌阶品不足！"},
        [20604] = {20604, "协同卡牌不存在！"},
        [20605] = {20605, "已达最大协同等级！"},
        [20606] = {20606, "协同升级所需兵牌数量不足！"},
        [20607] = {20607, "协同升级所需金币数量不足！"},
        [20608] = {20608, "%s%d星  [%s]%s+%d%s[-]"},
        [20609] = {20609, "%s%d级  [%s]%s+%d%s[-]"},
        [20610] = {20610, "%s%d阶  [%s]%s+%d%s[-]"},
        
        
        --卡牌基本信息
        [20701] = {20701, "没有更多卡牌！"},
        [20702] = {20702, "已有 %d 张"},

        --卡牌基本属性
        --攻击类型
        [20721] = {20721, "地面"},
        [20722] = {20722, "空中"},
        [20723] = {20723, "地空"},
        [20724] = {20724, "建筑"},

        --自身类型
        [20731] = {20731, "地面"},
        [20732] = {20732, "空中"},
        [20733] = {20733, "建筑"},

        --兵种
        [20741] = {20741, "士兵"},
        [20742] = {20742, "坦克"},
        [20743] = {20743, "战车"},
        [20744] = {20744, "火炮"},
        [20745] = {20745, "飞行器"},
        
        --攻击类型
        [20751] = {20751, "单体"},
        [20752] = {20752, "范围"},

        --子弹类型
        [20761] = {20761, "枪弹/炮弹/光束"},
        [20762] = {20762, "火箭弹/导弹"},
        [20763] = {20763, "火焰/毒"},

        --装备界面字符串
        [30101] = {30101, "没有可用装备"},
        [30102] = {30102, "穿戴装备无需修理"},
        [30103] = {30103, "装备损坏无法穿戴"},
        [30104] = {30104, "紫色以上品质的装备可以进行重铸"},
        [30105] = {30105, "重 铸"},
        [30106] = {30106, "替 换"},
        [30107] = {30107, "重铸所需材料不足"},
        [30108] = {30108, "能量点不足"},
        [30109] = {30109, "当前属性与选择替换属性相同，确认继续替换？"},


        --仓库界面字符串
        --页卡字符串
        [0xFFFF] = {0xFFFF,"全部"},
        [0xFFFE] = {0xFFFE,"装备"},
        [0xFFFD] = {0xFFFD,"碎片"},
        [0xFFFC] = {0xFFFC,"材料"},
        [0xFFFB] = {0xFFFB,"消耗品"},
        [0xFFFA] = {0xFFFA,"收藏品"},
        --装备详情界面字符串
        [0xFE11] = {0xFE11,"穿戴"},
        [0xFE12] = {0xFE12,"卸下"},
        [0xFE13] = {0xFE13,"2件套属性:"},
        [0xFE14] = {0xFE14,"3件套属性:"},
        [0xFE15] = {0xFE15,"5件套属性:"},
        [0xFE16] = {0xFE16,"修理"},
        [0xFE17] = {0xFE17,"强化"},
        [0xFE18] = {0xFE18,"重铸"},
        [0xFE19] = {0xFE19,"%d件套属性:"},

        --装备分解界面字符串
        [0xFE20] = {0xFE20,"您共选择了[01FECF]%d[-]件装备，可获得"},
        --装备分解提示字符串
        [0xFE21] = {0xFE21,"普通分解您只能获得[01ffd2]75%[-]的能量"},
        [0xFE22] = {0xFE22,"完美分解您将能获得[01ffd2]100%[-]的能量"},
        [0xFE23] = {0xFE23,"本次分解您能获得[01ffd2]100%[-]的能量"},
        [0xFE24] = {0xFE24,"分解装备中包涵高品质装备，确认是否分解"},
        --仓库物品详细界面字符串
        [0xFF01] = {0xFF01,"持有   "},
        [0xFF02] = {0xFF02,"途径"},
        [0xFF03] = {0xFF03,"合成"},
        --商店界面字符串
        [0xFD01] = {0xFD01,"购买[30D6FF]%d[-]件"},
        [0xFD02] = {0xFD02,"自动刷新：[ff7d09]%s[-]"},
        --tips界面字符串
        [0xFC01] = {0xFC01,"主属性从：%s中随机"},
    }
}
return data
