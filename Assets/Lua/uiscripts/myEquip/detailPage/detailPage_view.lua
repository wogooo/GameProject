---
--- Created by Administrator.
--- DateTime: 2017/6/30 17:57
---
local detailPage_view = {}
local view
function detailPage_view:init_view(args)
    view = args
    self.rightDetail = view.transform:Find("rightDetailParent").gameObject
end
return detailPage_view