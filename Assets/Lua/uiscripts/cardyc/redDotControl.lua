local redDotControl = {}

redDotFlag = {}
redDotFlag.RD_UPSTAR = false
redDotFlag.RD_UPLEVEL = false
redDotFlag.RD_SOLDIER = false
redDotFlag.RD_INFORMATION = false
redDotFlag.RD_SKILL = false
redDotFlag.RD_SKILLITEMS = {}
redDotFlag.RD_SYNERGY = false
redDotFlag.RD_SYNERGYITEMS = {}
local data
function redDotControl:refresh_cardyc(cardId,cardIndex)
    print("init_redDot")
    self:getRD_UPSTAR(cardId)
    self:getRD_UPLEVEL(cardIndex)
    self:getRD_INFORMATION(cardIndex)
    self:getRD_SKILL(cardIndex)
    self:getRD_SOLDIER(cardIndex)
    self:getRD_SYNERGY(cardIndex)
end
function redDotControl:getRD_UPSTAR(cardId)
    data = require("uiscripts/cardyc/upStar/upStar_model")
    if data:isCan_UpStar(cardId) == 0 then
        redDotFlag.RD_UPSTAR = true
    else 
        redDotFlag.RD_UPSTAR = false
    end
    Memory.free("uiscripts/cardyc/upStar/upStar_model")
end


function redDotControl:getRD_UPLEVEL(cardIndex)
    data = require("uiscripts/cardyc/upLevel/upLevel_model")
    if data:isCan_UpLevel() == 0 then 
        redDotFlag.RD_UPLEVEL = true
    else 
        redDotFlag.RD_UPLEVEL = false
    end
    Memory.free("uiscripts/cardyc/upLevel/upLevel_model")
end

function redDotControl:getRD_INFORMATION(cardIndex)
    data = require("uiscripts/cardyc/information/information_model")
    for i = 0, #data.slotState do 
        if data.slotState[i] == qualityUtil.EquipState.Enable_Enough then 
            redDotFlag.RD_INFORMATION = true
        end
    end
    if data:isCan_UpQuality() == 0 then 
        redDotFlag.RD_INFORMATION = true
    else 
        redDotFlag.RD_INFORMATION = false
    end
    Memory.free("uiscripts/cardyc/information/information_model")
end

function redDotControl:getRD_SKILL(cardIndex)
    data = require("uiscripts/cardyc/upSkill/upSkill_model")
    redDotFlag.RD_SKILL = false
    for i = 1, #data.skill_Lv_Table do
        redDotFlag.RD_SKILLITEMS[i] = false
        if data:isCan_UpSkill(i) == 0 then 
            redDotFlag.RD_SKILL = true
            redDotFlag.RD_SKILLITEMS[i] = true
        end
    end
    Memory.free("uiscripts/cardyc/upSkill/upSkill_model")
end

function redDotControl:getRD_SOLDIER(cardIndex)
    data = require("uiscripts/cardyc/upSoldier/upSoldier_model")
    if data:isCan_UpSoldier() == 0 then 
        redDotFlag.RD_SOLDIER = true
    else 
        redDotFlag.RD_SOLDIER = false
    end
    Memory.free("uiscripts/cardyc/upSoldier/upSoldier_model")
end


function redDotControl:getRD_SYNERGY(cardIndex)
    data = require("uiscripts/cardyc/upSynergy/upSynergy_model")
    redDotFlag.RD_SYNERGY = false
    for i = 1, #data.synergyLvTbl do
        redDotFlag.RD_SYNERGYITEMS[i] = false
        if data:isCan_UpSynergy(i) == 0 then 
            redDotFlag.RD_SYNERGY = true
            redDotFlag.RD_SYNERGYITEMS[i] = true
        end
    end
    Memory.free("uiscripts/cardyc/upSynergy/upSynergy_model")
end


function redDotControl:mainCall()
    local cardTbl = cardModel:getCardTbl()

    for cardId,_ in pairs(cardTbl) do
        self:getRD_UPSTAR(cardId)
        if redDotFlag.RD_UPSTAR then
            return 1
        end
        --self:getRD_UPLEVEL(cardID)
        --if redDotFlag.RD_UPSTAR then
        --    return 1
        --end
        --self:getRD_INFORMATION(cardID)
        --if redDotFlag.RD_UPSTAR then
        --    return 1
        --end
        --self:getRD_SKILL(cardID)
        --if redDotFlag.RD_UPSTAR then
        --    return 1
        --end
        --self:getRD_SOLDIER(cardID)
        --if redDotFlag.RD_UPSTAR then
        --    return 1
        --end
        --self:getRD_SYNERGY(cardID)
        --if redDotFlag.RD_UPSTAR then
        --    return 1
        --end
    end
    return 0
end

function redDotControl:OnDestroyDone()
end

return redDotControl