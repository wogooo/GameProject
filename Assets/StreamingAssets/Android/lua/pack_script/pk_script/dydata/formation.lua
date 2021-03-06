--region *.lua
--Date 20150812
--阵型

Formation = classWC()

function Formation:ctor()
    self.zw = {-1,-1,-1,-1,-1,-1,-1}
    self.zf = -1
end

--- <summary>
--- 功能 : 返回某个动态英雄id所在的阵位id,如果英雄不在阵上则返回-1
--- </summary>
function Formation:GetZWID(dyID)
    for zwid,hid in pairs(self.zw) do 
        if(hid == dyID) then return zwid end
    end  
    return -1
end


FormationCtor = {}

--- <summary>
--- 功能 : 从QKJsonDoc构造一个阵实例
--- jsonNode : QKJsonDoc
--- </summary>
--- <returns type="Formation"></returns>
function FormationCtor.FromJsonNode(jsonNode)
    local newFormation = Formation.new()
    local first = JsonParse.JsonDocKey2NumberArray( jsonNode:GetValue("First") )
    local second = JsonParse.JsonDocKey2NumberArray( jsonNode:GetValue("Second") )
    local third = JsonParse.JsonDocKey2NumberArray( jsonNode:GetValue("Third") )
     
    newFormation.zf = tonumber( jsonNode:GetValue("zf") )
    local zw = {}
    zw[1] = first[2]
    zw[2] = second[1]
    zw[3] = second[2]
    zw[4] = second[3]
    zw[5] = third[1]
    zw[6] = third[2]
    zw[7] = third[3]
    newFormation.zw = zw
    return newFormation
end

--endregion
