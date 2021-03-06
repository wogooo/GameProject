--region *.lua
--Date 20160616
--英雄对象

GKInfoClass = classWC()

--英雄属性名枚举
GKAttrNames = {  
    GKTotalTime = "GKTT",--总通关时间
    GKTotalGCount = "GKTGC", --总通关数
}

GKTarget =
{
    zfPos = "zfPos"
}

GKSaveFileAttrNames =
{
    GKType = "gkt",--关卡类型
    SFType = "sft",--存档类型 0:Now,1:Best
    ProvinceID = "s",--省
    CityID = "c",--城
    MissionID = "g",--关
    isDistCard = "isC",--是否已分发手牌
    isWin = "isW",--是否通关
    EZDL = "ezdl",
    ZYNum = "ZY",--增援人数
}
GKCityBoxsAttrNames =
{
    City = "c",
    NormalState = "PTpass",--0未通过 1通过未领奖 2已领奖
    HardState = "WMpass",--0未通过 1通过未领奖 2已领奖
}


function GKInfoClass:ctor(ownerPlayer) 
	--self.Obj = syncObj
	self.OwnerPlayer = ownerPlayer
end


--获取属性
function GKInfoClass:GetAttr(attr)
	return self.OwnerPlayer:GetAttr(attr)
end

--遍历存档
function GKInfoClass:ForeachSaveFiles(callBack) 
    --print("ForeachSaveFiles",callBack)
    --如果尚未取得存档队列则创建之
    if(self.SaveFiles == nil) then self.SaveFiles = OOSyncList.new( self.OwnerPlayer.PlyObj ,"gkSaveFiles") end

    self.SaveFiles:Foreach(callBack) 
end

function GKInfoClass:ForeachTargets(callBack) 

    --如果尚未队列则创建之
    if(self.Targets == nil) then self.Targets = OOSyncList.new( self.OwnerPlayer.PlyObj ,"gkTargets") end

    self.Targets:Foreach(callBack) 
end



function GKInfoClass:ForeachCityBoxs(callBack) 

    --如果尚未队列则创建之
    if(self.CityBoxs == nil) then self.CityBoxs = OOSyncList.new( self.OwnerPlayer.PlyObj ,"gkCityBoxs") end

    self.CityBoxs:Foreach(callBack) 
end

function GKInfoClass:ForeachPoutputs(callBack) 

    --如果尚未队列则创建之
    if(self.Poutputs == nil) then self.Poutputs = OOSyncList.new( self.OwnerPlayer.PlyObj ,"gkPoutputs") end

    self.Poutputs:Foreach(callBack) 
end

 
  
--endregion
