--region *.lua
--Date 20160616
--英雄对象

AvaHeroClass = classWC()

--英雄属性名枚举
AvaInfo = {
	HeroID = "HeroID",
    States = "States",
} 

function AvaHeroClass:BindSyncObj(ownerPlayer,syncObj)
	self.Obj = syncObj
	self.OwnerPlayer = ownerPlayer
end

function AvaHeroClass:GetAttr(attr)
	return self.Obj:GetValue(attr)
end
function AvaHeroClass:GetNumberAttr(attr)
	return tonumber(self:GetAttr(attr))
end

 
--endregion
