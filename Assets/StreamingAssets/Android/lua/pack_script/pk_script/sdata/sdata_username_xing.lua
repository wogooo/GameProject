local data = require "username_xing"
local class_sdata_username_xing = classWC(luacsv) 

--- <summary>
--- 随机取一个
--- </summary>
function class_sdata_username_xing:RandItem()
    local count = #self.mData.body
    local key = math.floor(math.random(1,count))
    return self:GetFieldV("Xing",key)
end
return  class_sdata_username_xing.new(data)