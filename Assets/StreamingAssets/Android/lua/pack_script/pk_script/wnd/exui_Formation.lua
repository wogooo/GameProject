--region *.lua
--Date 2015014
--阵型控件

local zwName2ID = {
    ["zw1"] = 1,
    ["zw2"] = 2,
    ["zw3"] = 3,
    ["zw4"] = 4,
    ["zw5"] = 5,
    ["zw6"] = 6,
    ["zw7"] = 7,
}

exui_Formation = classWC()

function exui_Formation:ctor() 
	self.isReadOnly = isReadOnly
    self.UIZW = {}--UI阵位
	self.OnDragDropOut = Delegate.new() --英雄被拖出
	self.OnSwapOut = Delegate.new() --和阵位上的英雄交换，被换出的英雄
	self.OnZWDockCheck = Delegate.new()--阵位停靠检查
end
 
--设置阵型
function exui_Formation:SetFormation(formation,dyHeroInfo)
	 --清空阵位上的英雄控件
     for i=1,7 do  
        if(self.UIZW[i]~=nil and self.UIZW[i].item~=nil) then
            self.UIZW[i].item:Destroy()
            self.UIZW[i].item = nil
        end
    end 

	--创建item
	for i=1,7 do
		local dyID = formation.zw[i]
		if(dyID>0) then
			self:CreateZWItem(i,dyID,dyHeroInfo[dyID].sid)
		end
	end 

	--根据阵法锁定栏位
	self:SetZF(formation.zf)
end

--设置阵法
function exui_Formation:SetZF(zf) 
	local zfData = sdata_Buzhenxuanze:GetRow(zf)
	local zwList = {}
	if(zfData~=nil) then
		local zws = zfData[ sdata_Buzhenxuanze.I_Zhenwei]
		local zsList_str = string.split(zws,";")
		for _,v in pairs(zsList_str) do 
			local vnumber = tonumber(v)
			zwList[vnumber] = vnumber
		end  
	end

	for i=1,7 do
		local lockObj = self.UIZW[i].lock
		local slotObj = self.UIZW[i].slot
		if(lockObj~=nil) then
			lockObj:SetActive( zwList[i]==nil )
		end

		slotObj:SetActive( zwList[i]~=nil )
	end
end

--阵上的英雄开始拖拽
function exui_Formation:OnSlotDragDropStart(dragDropItem) 
	local ownerSurface = dragDropItem:GetOwnerSurface() --取得停靠的插槽对象
	local zwid = zwName2ID[ownerSurface:GetParent():GetName()] 
	if(zwid==nil) then return end

	local zwInfo = self.UIZW[zwid]
	zwInfo.item = nil--被拖出，交出英雄控件所有权 

	self.StartDropZW = zwid --记录是从哪个阵位拖出的 
end


function exui_Formation:OnNewInstance(formationGameObject,ItemMB) 
	self.FormationGameObject = formationGameObject
	self.m_ItemMB = ItemMB

	for i=1,7 do 
        local slotname = string.sformat("zw{0}/slot",i)
        local slotobj = self.FormationGameObject:FindChild( slotname )
        local lockobj = self.FormationGameObject:FindChild(string.sformat("zw{0}/lock",i) )
        self.UIZW[i] = { slot = slotobj,lock = lockobj,item = nil}

        --绑定阵位插槽拖拽相关事件
        local cmSlotSurface = slotobj:GetComponent(CMDragDropSurface.Name)
		if(cmSlotSurface~=nil) then
			cmSlotSurface:GetDragDropJoinItemEvent():AddDragDropCallback(self,self.OnSlotDragDropJoinItem)
			cmSlotSurface:GetDragDropStartEvent():AddDragDropCallback(self,self.OnSlotDragDropStart)
			cmSlotSurface:GetDragDropCancelEvent():AddDragDropCallback(self,self.OnSlotDragDropCancel)
			cmSlotSurface:GetDragDropEndEvent():AddDragDropCallback(self,self.OnSlotDragDropEnd)

			--设置dock检查函数
			cmSlotSurface:SetDockCheckFunc(self,self.ZWDockCheck,i)
		end
    end  
end


--有道具将要停靠到阵位上时，的检查函数
function exui_Formation:ZWDockCheck(_dragDropItem,_zwid)
	if self.OnZWDockCheck:IsEmpty() then return true end 
	return self.OnZWDockCheck:Call({dragDropItem = _dragDropItem,zwid = _zwid})    
end



 --阵位上交换两个位置，飞行动画完成
 function exui_Formation:OnSlotFlyEnd(info)  
    local dyzw = self.UIZW[info.zw]
    dyzw.item = info.item--变更类成员中的item
    dyzw.item:SetName("zw"..info.zw)--设置游戏物体的名字
    dyzw.item:SetParent(dyzw.slot)--设置所属父
    local cmDragDropItem = dyzw.item:GetComponent(CMDragDropItem.Name)--取出拖拽物组件    
    cmDragDropItem:SetOwnerSurface(dyzw.slot)--设置所属拖拽表面
 end

 --插槽上有新的对象进入
 function exui_Formation:OnSlotDragDropJoinItem(dragDropItem)
    local StartDropZW = self.StartDropZW
	self.StartDropZW = -1
	
	local ownerSurface = dragDropItem:GetOwnerSurface() --取得停靠的插槽对象

    local zwid = zwName2ID[ownerSurface:GetParent():GetName()]
    if(zwid==nil) then return end

    local zwInfo = self.UIZW[zwid]
    if(zwInfo.item~=nil) then  --位置上原来有物体绑定
        if(StartDropZW > 0) then--是从另一个阵位拖出的
            local slotPos = self.UIZW[self.StartDropZW].slot:GetPosition()--取得插槽的世界位置
            local cmFly = CMUIFly.Go(zwInfo.item,slotPos,15) --自动绑定飞行组件
            
            local flyEndEvt = cmFly:GetFlyFinishedEvent()--获取飞行完成事件
            flyEndEvt:AddCallback(self,self.OnSlotFlyEnd)--绑定事件
            cmFly:SetFlyFinishedParam( { zw=StartDropZW,item=zwInfo.item } ) --设置飞行完成参数
            cmFly:StartFly()--开始飞 
        else --是从英雄列表中拖出的
			print("exui_Formation:self.OnSwapOut#1")
			if(not self.OnSwapOut:IsEmpty()) then
				print("exui_Formation:self.OnSwapOut#2")
				self.OnSwapOut:Call(zwInfo.item)
			end
			print("exui_Formation:self.OnSwapOut#3")
        end
    end
    
    zwInfo.item = dragDropItem.gameObject;--绑定上新的游戏物体 
    self:SetZWItemParam( zwInfo.item )--设置阵位上的游戏对象组件属性
    zwInfo.item:SetName("zw"..zwid)--设置游戏物体的名字
 end


 
--- <summary>
--- 创建阵位上的英雄
--- </summary>
function exui_Formation:CreateZWItem(zwid,dyHeroID,staticHeroID)
    if(dyHeroID<=0) then return end

    local item = GameObject.InstantiateFromPreobj(self.m_ItemMB,self.UIZW[zwid].slot)
	item:SetActive(true)--激活新创建的游戏物体
    item:SetLocalPosition(Vector3.Zero())--位置出生位置
    item:SetName("zw"..zwid)--设置新建游戏物体的名字
    
	 
	local headObj = item:FindChild("head")
	local cmHead = headObj:GetComponent(CMUISprite.Name)
	local heroData = SData_Hero.GetHeroData( staticHeroID )
	cmHead:SetSpriteName( heroData:HeroFace() )

    self.UIZW[zwid].item = item--新创建的游戏物体添加到类成员中

    local cmDragDropItem = item:GetComponent(CMDragDropItem.Name)--取出拖拽物组件
	if(cmDragDropItem~=nil) then
		cmDragDropItem:SetUserData(dyHeroID)--将动态英雄id绑定到拖拽对象上
		cmDragDropItem:SetOwnerSurface(self.UIZW[zwid].slot)--设置对象的所属表面
    end
    self:SetZWItemParam(item)
end
 
--设置阵位上的道具参数
function exui_Formation:SetZWItemParam(item)
    local cmDragDropItem = item:GetComponent(CMDragDropItem.Name)--取出拖拽物组件
	if(cmDragDropItem~=nil) then
		cmDragDropItem:SetCloneOnDrag(false)--设置拖拽时，不克隆对象
		cmDragDropItem:SetRestriction(DragDropRestriction.None)--设置拖拽限制
    end
    --移除滚动视组件
    local cmDragScrollView = item:GetComponent(CMUIDragScrollView.Name)
    if(cmDragScrollView~=nil) then item:RemoveComponent(cmDragScrollView) end
end




 --阵上的英雄拖拽取消
 function exui_Formation:OnSlotDragDropCancel(dragDropItem) 
	local StartDropZW = self.StartDropZW
	self.StartDropZW = -1
	 
	if(self.OnDragDropOut:IsEmpty() or  not self.OnDragDropOut:Call(dragDropItem)) then --外部逻辑没有做出处理
		--飞回原位置 
	end 
 end

 --拖拽完成
 function exui_Formation:OnSlotDragDropEnd(dragDropItem)
	self.StartDropZW = -1
 end

--endregion
