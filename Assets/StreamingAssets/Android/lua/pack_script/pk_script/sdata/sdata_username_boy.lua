
local data = require "username_boy"
local class_sdata_username_boy = classWC(luacsv) 

--- <summary>
--- 随机取一个
--- </summary>
function class_sdata_username_boy:RandItem()
    local count = #self.mData.body
    local key = math.floor(math.random(1,count))
    return self:GetFieldV("NameBoy",key)
end

return  class_sdata_username_boy.new(data)
