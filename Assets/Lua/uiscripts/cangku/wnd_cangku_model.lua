require('uiscripts/cangku/util/table_count')
--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--header
--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
wnd_cangku_model = {

	-- 仓库标签数据
	DepositoryTab_Count = 0,

	local_Tabs = {},-- 本地页卡表
	--[[
		local_Items{
			[ItemID] = {UseType = int,...},
			[ItemID] = {...},
		}
	]]
	local_Items = {},-- 本地Items表
	-- local_Equipment = {},-- 本地Equipment表
	--[[
		serv_Items{
			[ItemID] = {id = int,...},
			[ItemID] = {...},
		}
	]]
	serv_Items = {},-- 从服务器获取的Items数据(id,num)
	-- serv_Equipment = {},-- 从服务器获取的Equipment数据
	-- serv_fitEquipmentList = {},-- 从服务器获取的已穿戴装备的id列表

	decomposition_Equipment = {},-- 装备分解状态时使用的临时表
	Processed_Items = {},-- 处理后的仓库数据(全部,装备在前,道具在后)，用于显示在ScrollView上

	-- function
	initModel,
	initLocalTabsData,-- 读本地表页卡数据
	initLocalItemsData,-- 读本地Item表数据
	initLocalEquipData,-- 读本地装备表数据
	
	getLocalItemDetailByItemID,-- 在本地Item表查询对应ItemID的数据
	getLocalEquipmentDetailByEquipID,-- 在本地装备表查询对应EquipID的数据
	getEquipmentMainAttributeStr,-- 获取装备主属性字符串
}

local this = wnd_cangku_model

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--function def
--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
function wnd_cangku_model:initModel()
	setmetatable(self,{__index = EquipModel})
	this:initLocalTabsData()
	this:initLocalItemsData()
end

function wnd_cangku_model:initLocalTabsData()
	if sdata_pack_data == nil then
		print("没获取到以下数据：sdata_pack_data")
		return
	end

	local Tab = {}

	this.DepositoryTab_Count = #sdata_pack_data.mData.body

	local offset = 1
	for k,v in pairs(sdata_pack_data.mData.body) do
		Tab["LabelID"] = v[sdata_pack_data.mFieldName2Index['LabelID']]
		Tab["TextID"] = v[sdata_pack_data.mFieldName2Index['TextID']]
		Tab["Goods"] = v[sdata_pack_data.mFieldName2Index['Goods']]
		Tab["Maintype"] = v[sdata_pack_data.mFieldName2Index['Maintype']]
		local _LabelID = Tab["LabelID"]
		Tab["Text"] = sdata_UILiteral.mData.body[0xFFFF-_LabelID+offset][sdata_UILiteral.mFieldName2Index["Literal"]]
		table.insert(this.local_Tabs,Tab)
		Tab = {}
	end

	table.sort(this.local_Tabs,function(a,b)
		return a["LabelID"] < b["LabelID"]
	end)

	print("read "..#this.local_Tabs.." Tabs(Local).")

	-- 由于是浅拷贝的原因不能这样赋值
	-- this.local_Tabs = Tabs
end

function wnd_cangku_model:initLocalItemsData()

	if sdata_item_data == nil then
		print("没获取到以下数据：sdata_item_data")
		return
	end	

	local Item = {}

	-- mFieldName2Index
	-- mData
	for k,v in pairs(sdata_item_data.mData.body) do

		Item["ItemID"] = v[sdata_item_data.mFieldName2Index['ItemID']]
		Item["UseType"] = v[sdata_item_data.mFieldName2Index['UseType']]
		Item["RelationID"] = v[sdata_item_data.mFieldName2Index['RelationID']]
		Item["Name"] = v[sdata_item_data.mFieldName2Index['Name']]
		Item["Des"] = v[sdata_item_data.mFieldName2Index['Des']]
		Item["FunctionDes"] = v[sdata_item_data.mFieldName2Index['FunctionDes']]
		Item["Icon"] =  v[sdata_item_data.mFieldName2Index['Icon']]
		Item["AvatarMode"] = v[sdata_item_data.mFieldName2Index['AvatarMode']]
		Item["Quality"] = v[sdata_item_data.mFieldName2Index['Quality']]
		Item["OverlapUse"] = v[sdata_item_data.mFieldName2Index['OverlapUse']]
		Item["OverlapLimit"] = v[sdata_item_data.mFieldName2Index['OverlapLimit']]
		Item["SaleGold"] = v[sdata_item_data.mFieldName2Index['SaleGold']]
		Item["ComposeNum"] = v[sdata_item_data.mFieldName2Index['ComposeNum']]
		Item["SelfUse"] = v[sdata_item_data.mFieldName2Index['SelfUse']]

		-- table.insert(this.local_Items,Item)
		this.local_Items[Item["ItemID"]] = Item

		Item = {}
	end

	table.sort(this.local_Items,function(a,b)
		return a["ItemID"] < b["ItemID"]
	end)

	print("read "..table.count(this.local_Items).." Items(Local).")
end

function wnd_cangku_model:getLocalItemDetailByItemID(itemID)
	-- for i = 1,#this.local_Items do
	-- 	if this.local_Items[i]["ItemID"] == itemID then
	-- 		return table.deepcopy(this.local_Items[i])
	-- 	end
	-- end
	-- Debugger.LogWarning(itemID.." not found in wnd_cangku_model:getLocalItemDetailByItemID(itemID)")
	-- return nil
	return table.deepcopy(this.local_Items[itemID])
end
--@Des 获取本地Item数据(引用)
function wnd_cangku_model:getLocalItemDataRefByItemID(itemID)
	-- for i = 1,#this.local_Items do
	-- 	if this.local_Items[i]["ItemID"] == itemID then
	-- 		return this.local_Items[i]
	-- 	end
	-- end
	-- Debugger.LogWarning(itemID.." not found in wnd_cangku_model:getLocalItemRefByItemID(itemID)")
	-- return nil
	return this.local_Items[itemID]
end
--@Des 获取服务器Item数量
function wnd_cangku_model:getServItemCountByItemID(itemID)
	for i = 1,#this.Processed_Items do
		if this.Processed_Items[i]["ItemID"] == itemID then
			return this.Processed_Items[i].num
		end
	end
end
--@Des 获取服务器装备数量
function wnd_cangku_model:getServEquipCountByEquipID(eid)
	local count = 0
	for i = 1,#this.Processed_Items do
		if this.Processed_Items[i]["EquipID"] == eid then
			count = count + 1
		end
	end
	return count
end
--@Des 获取服务器Item数量(引用)
function wnd_cangku_model:getServCardCountByCardID(cardID)
	for i = 1,#this.Processed_Items do
		if this.Processed_Items[i]["ArmyCardID"] == cardID then
			return this.Processed_Items[i].num
		end
	end
	Debugger.LogWarning(cardID.." not found in wnd_cangku_model:getServCardCountByCardID(itemID)")
	return 0
end

function wnd_cangku_model:getUseTypeByItemID(itemID)
	-- for i = 1,#this.local_Items do
	-- 	if this.local_Items[i]["ItemID"] == itemID then
	-- 		return this.local_Items[i]["UseType"]
	-- 	end
	-- end
	-- Debugger.LogWarning(itemID.." not found in wnd_cangku_model:getUseTypeByItemID(itemID)")
	-- return nil
	return this.local_Items[itemID]["UseType"]
end

--@params id:装备唯一id
--@return 装备eid
function wnd_cangku_model:getEquipmentIDByID(id)
	for i = 1,#this.Processed_Items do
		if this.Processed_Items[i].id == id then
			return this.Processed_Items[i]["EquipID"]
		end
	end
	Debugger.LogWarning(id.." not found in wnd_cangku_model:getEquipmentIDByID(id)")
	return nil
end

--@params currentLV:装备当前等级,Quality:装备品质
--@return 分解后获得的能量
function wnd_cangku_model:getEquipmentDecomposeReturn(currentLV,Quality)
	return sdata_equippower_data.mData.body[currentLV][sdata_equippower_data.mFieldName2Index['Quality'..Quality]]
end
--@Obsolete 由于装备表结构修改,该方法已弃用
--@params id:装备唯一id
--@return 该装备在装备表中的索引
function wnd_cangku_model:getIndexByID(id)
	for k,v in ipairs(this.serv_Equipment) do
		if v.id == id then
			return k
		end
	end
	Debugger.LogWarning(id.." not found in wnd_cangku_model:getIndexByID(id)")
	return nil
end
----------------------------------------------------------------
--★Util
function wnd_cangku_model:itemWhetherExist(id)
	-- for i = 1,#this.serv_Items do
	-- 	if this.serv_Items[i].id == id then
	-- 		return true
	-- 	end
	-- end
	for _,v in pairs(this.serv_Items) do
		if v.id == id then
			return true
		end
	end
	return false
end
function wnd_cangku_model:equipWhetherExist(id)
	-- for i = 1,#this.serv_Equipment do
	-- 	if this.serv_Equipment[i].id == id then
	-- 		return true
	-- 	end
	-- end
	for _,v in pairs(this.serv_Equipment) do
		if v.id == id then
			return true
		end
	end
	return false
end
----------------------------------------------------------------
--★追加服务器数据
--@Des 添加或更新Item数据
--@Params 服务器传回的Item数据
function wnd_cangku_model:addOrUpdateItemData(gw2c_item)
	for k,v in ipairs(gw2c_item) do
		local _id = v.id
		local _num = v.num
		local _Exist = this:itemWhetherExist(_id)
		-- 如果本地存在Item,则更新本地数据，否则追加ItemData到本地Model中
		if _Exist then
			-- for i = 1,#this.serv_Items do
			-- 	if this.serv_Items[i].id == _id then
			-- 		this.serv_Items[i].num = _num
			-- 		return
			-- 	end
			-- end
			this.serv_Items[_id].num = _num
		else
			local item = {}
			item = this:getLocalItemDetailByItemID(_id)

			local _OverlapLimit = item["OverlapLimit"]
			if _OverlapLimit ~= 1 then
				if _num <= _OverlapLimit then -- 堆叠数量处理
					-- print("物品数量：".._num.."  堆叠限制：".._OverlapLimit)
					item.id = _id
					item.num = _num
					-- table.insert(this.serv_Items,item)
					this.serv_Items[_id] = item
				else 
					-- print("物品数量超出限制：".._num.."  堆叠限制：".._OverlapLimit)
					for i = 1,math.ceil(_num / _OverlapLimit) do
						item.id = _id
						if i ~= math.ceil(_num / _OverlapLimit) then
							item = table.deepcopy(item)
							item.num = _OverlapLimit
							table.insert(this.serv_Items,item)
						else
							item = table.deepcopy(item)
					 		item.num = _num - _OverlapLimit * (math.ceil(_num / _OverlapLimit) - 1)
							-- table.insert(this.serv_Items,item)
							this.serv_Items[_id] = item
						end
					end
				end
			end
		end
	end
	-- require('uiscripts/cangku/scrollview/wnd_cangku_ScrollView_controller'):sortItems(this.serv_Items)
	this.Processed_Items = {}
	require('uiscripts/cangku/wnd_cangku_controller'):mergeServData()
	require('uiscripts/cangku/wnd_cangku_controller'):sortProcessedData()
	Debugger.Log("addOrUpdateItemData() completed.")
end

return wnd_cangku_model