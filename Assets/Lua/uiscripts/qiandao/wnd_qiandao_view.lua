--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--header
--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

wnd_qiandao_view = {
    CloseBtn,
    MainPanel,
    QiandaoData = {
        QiandaoCishu,
        Time,
    },

    qiandao_res_list = {},

    qiandao_res_panel,
    initview,
    AddcolliderforRes

}

local this = wnd_qiandao_view
local model = nil

function wnd_qiandao_view:initview(root)
    self = root
    this.CloseBtn = self.transform:Find("ui_qiandao_btn/CloseBtn").gameObject
    this.QiandaoData.QiandaoCishu = self.transform:Find("ui_qiandao_data/QiandaoCishu").gameObject
    this.QiandaoData.Time = self.transform:Find("ui_qiandao_data/Time").gameObject

    this.qiandao_res_list[1] = self.transform:Find("ui_qiandao_respanel/ui_qiandao_resgrid/qiandao_res").gameObject

    for index = 2,30 do
    this.qiandao_res_list[index] = self.transform:Find("ui_qiandao_respanel/ui_qiandao_resgrid/qiandao_res ("..tostring(index-1)..")").gameObject
   end

    this.qiandao_res_panel = self.transform:Find("ui_qiandao_respanel").gameObject
    this.MainPanel = self.transform.gameObject
    this:AddcolliderforRes()
end


function wnd_qiandao_view:AddcolliderforRes()
    for i = 1,30 do
        collider = this.qiandao_res_list[i].transform:Find("qiandao_res_quality").gameObject:AddComponent(typeof(UnityEngine.BoxCollider))
        collider.isTrigger = true
        collider.center = Vector3.zero
        collider.size = Vector3(collider.gameObject:GetComponent(typeof(UIWidget)).localSize.x,collider.gameObject:GetComponent(typeof(UIWidget)).localSize.y,0)

        uidragsv = this.qiandao_res_list[i].transform:Find("qiandao_res_quality").gameObject:AddComponent(typeof(UIDragScrollView))
        uidragsv.scrollView = this.qiandao_res_panel:GetComponent("UIScrollView")
    end
end






return wnd_qiandao_view

