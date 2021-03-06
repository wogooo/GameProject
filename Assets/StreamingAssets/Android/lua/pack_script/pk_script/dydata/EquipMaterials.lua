--region *.lua
--Date 20160708
--洗练对象
--作者 gyt


EquipMaterialsClass = classWC()

--角色属性名枚举
EquipMaterialsAttrNames = {
		DataID = "DataID",--ID
		NUM = "NUM",--数量
}


function EquipMaterialsClass:ctor(ownerPlayer)
	self.OwnerPlayer = ownerPlayer
end

function EquipMaterialsClass:GetAttr(attr)
	return self.OwnerPlayer:GetValue(attr)
end

function EquipMaterialsClass:ForeachEquipMaterials(callBack) 
    if(self.EquipMaterials == nil) then 
		self.EquipMaterials = OOSyncList.new( self.OwnerPlayer.PlyObj,"EquipMaterials") 
	end

   self.EquipMaterials:Foreach(callBack) 
end