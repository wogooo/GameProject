---
--- Created by Administrator.
--- DateTime: 2017/7/8 17:21
---
local class = require("common/middleclass")
local UIModel = class("UIModel")

function UIModel:initialize(parent)
    self.UIModel = GameObjectExtension.InstantiateFromPacket("ui_equip", "UIModel", parent).gameObject
    self.playerModelTexture = self.UIModel.transform:Find("playerModelTexture").gameObject
    self.camera3D = self.UIModel.transform:Find("Camera3D").gameObject
    self:show3DModel()
end

function UIModel:show3DModel()
    --添加RenderTexture 实现UI上添加3d模型
    self.myTexture = UnityEngine.RenderTexture(1024, 1024, 24)
    self.myTexture:Create()
    self.camera3D:GetComponent(typeof(UnityEngine.Camera)).targetTexture = self.myTexture
    self.playerModelTexture:GetComponent(typeof(UITexture)).mainTexture = self.myTexture
    --添加玩家3d模型
    tempMod = DP_FightPrefabManage.InstantiateAvatar(CreateActorParam(AvatarCM.Infantry_R, false, 0, "xuebaotujidui", "xuebaotujidui", true, 0, 0)).transform
    --tempMod = DP_FightPrefabManage.InstantiateAvatar(CreateActorParam(AvatarCM.Infantry_R, false, 0, "gongjianbing", "gongjianbing", true, 0, 0)).transform
    tempMod.parent = self.camera3D.transform
    tempMod.localScale = Vector3(0.8, 0.8, 0.8);
    tempMod.localRotation = Quaternion(0, 180, 0, 1);
    tempMod.localPosition = Vector3(0, -7, 500);
    tempMod.gameObject:SetActive(true)
    tempMod.gameObject.layer = UnityEngine.LayerMask.NameToLayer("3DUI")

    self.playerModelTexture:GetComponent(typeof(SpinWithMouse)).target = tempMod
    UIEventListener.Get(self.playerModelTexture.gameObject).onPress = function(go, args)
        if args then
            --self:dianjikongbai()
        end
    end
end

function UIModel:setDepth(depth)
    self.UIModel:GetComponent("UIPanel").depth = depth
end


return UIModel