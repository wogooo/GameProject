local class = require("common/middleclass")
local ui_keji_jiasu = class("ui_keji_jiasu", wnd_base)
function ui_keji_jiasu:OnShowDone()
    ui_keji_jiasu = self
    local bg = self.transform:Find("bg")
    self.backBtn = bg:Find("backBtn")--返回按钮
    UIEventListener.Get(self.backBtn.gameObject).onClick = function(go)--返回按钮回调
        ui_manager:GetWB(WNDTYPE.ui_kejitree).ui_keji_jiasu = nil
        ui_manager:DestroyWB(self)
    end
    self.jiasu = bg:Find("jiasu")--加速按钮
    UIEventListener.Get(self.jiasu.gameObject).onClick = function(go)--加速按钮回调
        end
    
    self.kejiNameUL = bg:Find("info1"):GetComponent(typeof(UILabel))--科技名称
    self.timeUL = bg:Find("info3"):GetComponent(typeof(UILabel))--耗时
    self.costUL = bg:Find("bg/info4"):GetComponent(typeof(UILabel))--消耗
    local kejiLevel = kejiP[nowPageIndex][nowInfoIndex].kejiLevel
    local kejiID = tonumber(kejiP[nowPageIndex][nowInfoIndex].kejiID .. string.format("%03d", kejiLevel))
    self.kejiNameUL.text = sdata_tech_data:GetFieldV("TechName", kejiID)
    --调整字体位置居中
    local p = self.kejiNameUL.transform.localPosition
    self.kejiNameUL.transform.localPosition = Vector3((self.kejiNameUL.width - bg:Find("info1/info2"):GetComponent(typeof(UIWidget)).width) / 2, p.y, p.z)
    
    local timer = allTimeTickerTb["ui_kejitree_shengji" .. nowPageIndex .. nowInfoIndex]
    self.timeUL.text = GetRemainTime(timer.OverTime)
    
    ui_manager:GetWB(WNDTYPE.ui_kejitree).ui_keji_jiasu = self
end

return ui_keji_jiasu
