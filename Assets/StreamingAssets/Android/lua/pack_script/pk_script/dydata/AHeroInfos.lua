--region *.lua
--Date 20160616
--英雄对象
--作者 gyt

AHeroinfosClass = classWC()
--public enum AHeroInfoState
--   {
--       idel = 0,//默认状态，[手牌:在布阵牌组中显示的武将]
--       dead = 1,//手牌已死亡
--       locks = 2,//未进入手牌
--       unlocks = 3,//已进入手牌
--       prepare = 4,//准备进入手牌 [即将出场武将]
--       onfrm = 5,//上阵 [在布阵视图中上阵]
--   }
--
--英雄属性名枚举
AHeroinfos = {
	HType = "HType",
	id = "id",
	hp = "hp",
	cd = "cd",
    State = "State",--12345
    ArmyNum = "aNum",
} 

function AHeroinfosClass:ctor(ownerPlayer)
	self.OwnerPlayer = ownerPlayer
end

function AHeroinfosClass:GetAttr(attr)
	return self.OwnerPlayer:GetValue(attr)
end
function AHeroinfosClass:ForeachAHeroinfos(callBack) 
    if(self.AHeroinfos == nil) then 
		self.AHeroinfos = OOSyncList.new( self.OwnerPlayer.PlyObj,"AHeroInfos") 
	end

   self.AHeroinfos:Foreach(callBack) 
end