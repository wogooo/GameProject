--region *.lua
--Date
--此文件由[BabeLua]插件自动生成
class_sdata_username_xingming = classWC(luacsv)


local data_xing = require "username_xing"
local data_nvMing = require"username_girl"
local data_nanMing = require"username_boy"


function GetXing()
    local key= math.ceil( math.random(1, 264))
    return GetFieldUserName(data_xing,key)
    
end

function GetManMing()

    local key = math.ceil( math.random(1, 446))
    return GetFieldUserName(data_nanMing, key)
end


function GetWomanMing()
    local key = math.ceil( math.random(1, 1443))
    return GetFieldUserName(data_nvMing, key)
end

function GetFieldUserName(t,key)
    return t.body[key][2]
end

return class_sdata_username_xingming.new
--endregion
