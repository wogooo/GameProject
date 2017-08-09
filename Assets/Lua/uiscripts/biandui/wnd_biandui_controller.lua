
require('uiscripts/skill/ui_skill_controller')

wnd_biandui_controller ={}
--[[目录：
    wnd_biandui_controller:
        variable:
            ---卡牌相关---
            CardItemList ={},        --卡组区域卡牌数据列表
            DayingItemList = {},     --大营区域卡牌数据列表
            QianfengItemList = {},   --前锋区域卡牌数据列表
            carditem_pic_list = {},  --卡组区域卡牌图片资源列表
            dayingitem_pic_list = {},--大营区域卡牌图片资源列表
            qianfengmodllst = {}，   --前锋模型列表

            ---兵力相关---
            dayinglimit,             --大营兵力上限
            dayingbingli_now,        --大营当前兵力
            qianfenglimit,           --前锋兵力上限
            qianfengbingli_now,      --前锋当前兵力
            zongbinglilimit,         --总兵力上限
            zongbingli_now,          --当前总兵力
            pjbingli,                --平均兵力

            ---拖动相关---
            deltax                   --前锋与大营距离
            isstop                   --卡库牌组移动是否停止
            isClone,                 --拖动的卡牌是否克隆完成
            DayingCanbeAdd,          --拖动的卡牌在松手时是否应被加入到大营
            QianfengCanbeAdd         --拖动的卡牌在松手时是否应被加入到前锋
            isLongorDragPress,       --当前是否在长按或者拖动
            this.modelpos = {}，     --前锋1-6位置信息
            this.ModeDragState = ""  --前锋模型拖动状态

            ---点击及长按相关---
            startlongadd,            --是否允许进行长按添加
            lastclickobj,            --上一次点击的物体

        function:
            --初始化相关---
            OnShowDone() extend wnd_base:OnShowDone()
            initListener,            --添加监听
            InitData，               --初始化数据   
            InitItemList             --初始化本地的大营和前锋数据
            MakeDayingItem,          --新建大营区域卡牌数据
            MakeQianfengItem         --新建前锋区域卡牌数据
            InitPicItem，            --初始化卡牌图片

            ---卡牌增删相关---
            AddCardToDaying,         --卡牌加入到大营
            DeleteDayingItem,        --大营卡牌删除
            AddCardToQianfeng        --卡牌加入前锋
            ChangeModel              --模型换位
            BackModelToCard          --模型移出前锋


            ---卡牌控制相关---
            CardOnClick,             --卡牌单击响应
            CardPressCtr,            --卡牌点击控制
            DeletePressCtr           --删除按钮单击控制
            DragCtr，                --卡牌拖动状态判定
            AddCloneCardToArmy,      --卡牌上下拖动处理

            DragEndCtr,              --拖动结束控制
            MoveCardList             --移动卡库区域

            ---工具方法相关---
            MoveCardList             --移动卡组区域
            SetStar,                 --设置卡牌星星
            MoveCardList             --移动卡库区域
            CloseSkillPanel          --关闭技能面板
            CprDayingData            --与服务器获取的比较大营数据
            CprQianfengData          --与服务器获取的比较前锋数据
            UpdateArmyData           --更新本地和服务器的大营以及前锋数据
]]

local class = require("common/middleclass")
wnd_biandui_controller = class("wnd_biandui_controller", wnd_base)
local this = wnd_biandui_controller
require("uiscripts/commonGameObj/Model")
---初始化相关-----------------------------------
function wnd_biandui_controller:OnShowDone()


    this.view = require("uiscripts/biandui/wnd_biandui_view")
    this.view:initview(self)

    this.model = require("uiscripts/biandui/wnd_biandui_model")
    this.model:initModel()

    this:InitData()
    ---测试用代码---
    this:InitItemList()
    this:InitPicItem()
    this:SetLimit(5000, 2000)

    this:SetBlingli()
    this:initListener()



    print("wnd_biandui +++++++ OnShowDone")
end

--@Des 初始化数据，各项标志位，图标以及图标数据的表
function wnd_biandui_controller:InitData()
    this.isDrag = false
    this.islfDrag = false
    this.isudDrag = false
    this.isClone = false
    this.isLongorDragPress = false
    this.lastclickobj = nil

    this.CardItemList = {}
    this.DayingItemList = {}
    this.QianfengItemList = {}
    this.carditem_pic_list = {}
    this.dayingitem_pic_list ={}
    this.qianfengmodllst = {}

    this.qianfenglimit = 0
    this.dayinglimit = 0
    this.dayingbingli_now = 0
    this.zongbingli_now = 0
    this.pjbingli = 0
    this.qianfengbingli_now =0
    this.DayingCanbeAdd = false
    this.QianfengCanbeAdd = false

    this.Cloneobj = nil
    this.Clonemod = nil

    this.startlongadd = false
    this.isstop = true
    this.firstcardpos = nil
    this.lastcardpos = nil
    this.lastselectskill = nil
    this.deltax = this.view.qianfeng_item_panel_bg.transform.localPosition.x
                  -this.view.daying_item_panel_col.transform.localPosition.x
                  -this.view.daying_item_panel_col:GetComponent("UIWidget").localSize.x/2
                  -this.view.qianfeng_item_panel_bg:GetComponent("UIWidget").localSize.x/2

    this.pos = 0
    this.modelpos = {}
    this.modelpos[1] = Vector3(-14,14,57)
    this.modelpos[2] = Vector3(10,14,57)
    this.modelpos[3] = Vector3(-14,-4,50)
    this.modelpos[4] = Vector3(10,-4,50)
    this.modelpos[5] = Vector3(-14,-19,43)
    this.modelpos[6] = Vector3(10,-19,43)


    this.ModeDragState = ""
end

--@Des 初始化控制层卡库/大营/前锋数据
function wnd_biandui_controller:InitItemList()
    local ItemID = {}
    local ItemLv = {}
    for i=1,#this.model.CardItemList do
        ItemID[i] = this.model.CardItemList[i]["ArmyCardID"]
        ItemLv[i] = this.model.CardItemList[i]["Level"]
        table.insert(this.CardItemList,this.model.CardItemList[i])
    end
    Model:setZhenXingData(ItemID,ItemLv)

    for k,v in pairs(this.model.DayingItemList) do
        this:MakeDayingItem(v["cardId"],v["num"])
    end

    for k,v in pairs(this.model.QianfengItemList) do
        this:MakeQianfengItem(v["cardId"],v["pos"])
    end
end

--@Des 新建大营区域卡牌数据
--@params ArmyCardID(number):卡牌ID
--        Num(number):卡牌数量
function wnd_biandui_controller:MakeDayingItem(ArmyCardID,Num)
    -----初始化大营数据元素列表----
    for k,v in pairs(this.CardItemList) do
        if(v["ArmyCardID"] == ArmyCardID) then
            v["Num"] = v["Num"] - Num --卡组区域中卡牌的数量 = 使用上限-目前大营中对应卡牌的数量
            local Item = {}
            Item["cardId"] = v["ArmyCardID"]
            Item["num"] = Num
            table.insert(this.DayingItemList,Item)
            return
        end
    end
end

--@Des 新建前锋区域卡牌数据
--@params ArmyCardID(number):卡牌ID
--        pos(number):卡牌位置
function wnd_biandui_controller:MakeQianfengItem(ArmyCardID,pos)
    -----初始化前锋数据元素列表----
    for k,v in pairs(this.CardItemList) do
        if(v["ArmyCardID"] == ArmyCardID) then
            v["Num"] = v["Num"] - 1 --卡组区域中卡牌的数量 = 使用上限-目前大营中对应卡牌的数量
            local Item = {}
            Item["cardId"] = v["ArmyCardID"]
            Item["pos"] = pos
            this.QianfengItemList[pos] = Item
            return
        end
    end
end


--@Des 初始化所有卡牌图片(仅第一次打开时运行！)
function wnd_biandui_controller:InitPicItem()
    ----初始化卡牌区域----
    if(#this.CardItemList == 0) then
        return
    end
    local go = nil
    for index = 1,#this.CardItemList do
        if(index == 1) then
            go = this.view.cardItem
            go.transform:Find("card_item_frame/card_item_level_bg/btn_dayingitem_delete").gameObject:SetActive(false)
        else
            go =  GameObjectExtension.InstantiateFromPreobj(this.view.card_clone_item,this.view.card_item_grid)
            this.view.card_item_grid:GetComponent("UIGrid"):AddChild(go.transform,false)
        end
        go.transform.name = tostring(this.CardItemList[index]["ArmyCardID"])
        -----star---level---quality----type---num---consume---
        this:SetStar(go,this.CardItemList[index]["Star"])
        go.transform:Find("card_item_frame/card_item_numc_bg/card_item_consume"):GetComponent("UILabel").text = tostring(this.CardItemList[index]["TrainCost"])
        go.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text = "x"..tostring(this.CardItemList[index]["Num"])
        go.transform:Find("card_item_frame/card_item_level_bg/card_item_level_frame/card_item_level_label"):GetComponent("UILabel").text = "LV."..tostring(this.CardItemList[index]["Level"])
        this.carditem_pic_list[index] = go
        go:SetActive(true)
    end
    this.firstcardpos = this.carditem_pic_list[1].transform.position
    if(#this.carditem_pic_list >=7) then
        this.lastcardpos = this.carditem_pic_list[7].transform.position
    end

    local dygo = nil
    ----初始化大营区域----
    if(#this.DayingItemList == 0) then
        GameObject.Destroy(this.view.dayingItem)
    end
    for index = 1,#this.DayingItemList do
        if(index == 1) then
            dygo = this.view.dayingItem
        else
            dygo =  GameObjectExtension.InstantiateFromPreobj(this.view.card_clone_item,this.view.daying_item_grid)
            this.view.daying_item_grid:GetComponent("UIGrid"):AddChild(dygo.transform,false)
            dygo.transform:Find("card_item_frame/card_item_level_bg/btn_dayingitem_delete").gameObject:SetActive(true)
            dygo.transform:Find("card_item_frame/card_item_icon_bg/card_item_icon").gameObject:GetComponent("UIDragScrollView").scrollView = this.view.daying_item_panel:GetComponent("UIScrollView")
        end

        for i=1,#this.CardItemList do
            if(this.DayingItemList[index]["cardId"] == this.CardItemList[i]["ArmyCardID"]) then
                dygo.transform.name = tostring(this.CardItemList[i]["ArmyCardID"])
                -----star---level---quality----type---num---consume---
                this:SetStar(dygo,this.CardItemList[i]["Star"])
                dygo.transform:Find("card_item_frame/card_item_numc_bg/card_item_consume"):GetComponent("UILabel").text = tostring(this.CardItemList[i]["TrainCost"])
                dygo.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text ="x"..tostring(this.DayingItemList[index]["num"])
                dygo.transform:Find("card_item_frame/card_item_level_bg/card_item_level_frame/card_item_level_label"):GetComponent("UILabel").text = "LV."..tostring(this.CardItemList[i]["Level"])
                this.dayingitem_pic_list[index] = dygo
            end
        end
        dygo:SetActive(true)
    end
    ---将加号图片始终置于大营区域队列的最后方---
    this.view.AddIcon.transform:SetAsLastSibling()
    this.view.daying_item_grid:GetComponent("UIGrid").enabled = true

    ---初始化前锋区域-----
    if(this.QianfengItemList == nil) then
        return
    end

    for k,v in pairs(this.QianfengItemList) do
        tempMod = Model:CreateZhenXing(v["cardId"])
        tempMod.parent = this.view.camera3D.transform
        tempMod.gameObject.name = tostring(v["pos"])
        tempMod.localScale = Vector3(1, 1, 1);
        tempMod.localRotation = Quaternion(0, 1.4, 0, 1);
        tempMod.localPosition = this.modelpos[v["pos"]]
        tempMod.gameObject:SetActive(true)
        tempMod.gameObject.layer = UnityEngine.LayerMask.NameToLayer("3DUI")
        this.qianfengmodllst[v["pos"]] = tempMod
        this.view.pos[v["pos"]]:SetActive(true)
    end
end
----------------------------------------------------------

---工具方法相关----------------------------------------
--@Des 生成每个卡牌的星星
--@params go(GameObject):需要设置星星的卡牌（必须是预制卡牌的克隆体）
--        starnum(number):需要设置的星星数量
function wnd_biandui_controller:SetStar(go,starnum)
    local sgo = nil
    local star = go.transform:Find("card_item_frame/card_item_star_frame/card_item_star_grid/star").gameObject
    local sgrid = go.transform:Find("card_item_frame/card_item_star_frame/card_item_star_grid").gameObject
    for i = 1,starnum do
        if(i == 1) then
            star:SetActive(true)
        else
            sgo = GameObjectExtension.InstantiateFromPreobj(star,sgrid)
            sgrid:GetComponent("UIGrid"):AddChild(sgo.transform,false)
            sgo:SetActive(true)
        end
    end
end

--@Des 设置兵力上限
function wnd_biandui_controller:SetLimit(DayingLimit,QianfengLimit)
    this.dayinglimit = DayingLimit
    this.qianfenglimit = QianfengLimit
    this.zongbinglilimit = DayingLimit+QianfengLimit

    this.view.daying_bingli_limit:GetComponent("UILabel").text = tostring(DayingLimit)
    this.view.qianfeng_bingli_limit:GetComponent("UILabel").text = tostring(QianfengLimit)
    this.view.zongbingli_limit:GetComponent("UILabel").text = tostring(DayingLimit+QianfengLimit)
end

--@Des 刷新当前兵力
function wnd_biandui_controller:SetBlingli()
    ------对当前已部署的大营兵力，前锋兵力，总兵力，进行数据更新-----------
    this.dayingbingli_now = 0
    this.qianfengbingli_now = 0
    this.zongbingli_now = 0

    local cardnum = 0
    local nowcardbingli = 0

    ----遍历大营元素，循环递加每个元素的数目，将大营兵力加在一起-----
    for k,v in pairs(this.DayingItemList) do

        for i=1,#this.CardItemList do
            if(v["cardId"] == this.CardItemList[i]["ArmyCardID"]) then
                nowcardbingli = this.CardItemList[i]["TrainCost"]
            end
        end

        for index =1,v["num"] do
            cardnum = cardnum+1
            this.dayingbingli_now =this.dayingbingli_now + nowcardbingli
        end
    end
    this.view.daying_bingli_now:GetComponent("UILabel").text = tostring(this.dayingbingli_now)

    ----由于前锋每种牌只可以放一张，所以并不需要循环递加每个元素的数目，直接遍历前锋列表计算前锋兵力即可---
    for k,v in pairs(this.QianfengItemList) do
        cardnum = cardnum+1
        for i=1,#this.CardItemList do
            if(v["cardId"] == this.CardItemList[i]["ArmyCardID"]) then
                nowcardbingli = this.CardItemList[i]["TrainCost"]
            end
        end
        this.qianfengbingli_now =this.qianfengbingli_now + nowcardbingli
    end
    this.view.qianfeng_bingli_now:GetComponent("UILabel").text = tostring(this.qianfengbingli_now)

    ---总兵力 = 大营兵力+前锋兵力-----
    this.zongbingli_now = this.dayingbingli_now+this.qianfengbingli_now
    this.view.zongbingli_now:GetComponent("UILabel").text = tostring(this.zongbingli_now)

    ---平均兵力 = 总兵力除卡牌数量---
    if(cardnum == 0) then
        this.pjbingli = 0
    else
        this.pjbingli = math.ceil(this.zongbingli_now/cardnum)
    end
    this.view.pjbingli:GetComponent("UILabel").text = tostring(this.pjbingli)
end

--@Des 卡组/大营区域卡牌添加响应，TriggerBox/大营触摸碰撞面板/卡牌区域触摸碰撞面板添加响应
function wnd_biandui_controller:initListener()
    for i = 1,#this.carditem_pic_list do
        UIEventListener.Get(this.carditem_pic_list[i].transform:Find("card_item_frame/card_item_icon_bg/card_item_icon").gameObject).onDragStart = function(go)
            --拖动事件
            print("onDragStart")
            this.isDrag = true
        end
        ----拖动当中的方法，用于判断左右还是上下拖动，从而进行列表移动和克隆物体的处理-----
        UIEventListener.Get(this.carditem_pic_list[i].transform:Find("card_item_frame/card_item_icon_bg/card_item_icon").gameObject).onDrag = function(go,TouchPosition)
            --拖动事件
            this:DragCtr(go,TouchPosition)
            this.isDrag = true
        end
        -----拖动结束的方法，用于判断卡牌是否拖入了兵营或者前锋，然后做数据的拖动结束处理----
        UIEventListener.Get(this.carditem_pic_list[i].transform:Find("card_item_frame/card_item_icon_bg/card_item_icon").gameObject).onDragEnd = function(go)
            --拖动事件
            print("onDragStartEND")
            if(this.DayingCanbeAdd) then
                this:AddCardToDaying(go)
            elseif (this.QianfengCanbeAdd) then
                this:AddCardToQianfeng(go)
            else
                --if(this.pos ~=0 and this.qianfengmodllst[this.pos] == nil) then
                --    this.view.pos[this.pos]:SetActive(false)
                --end
                local item = go.transform.parent.parent.parent.gameObject
                local CardData = nil
                for a,b in pairs(this.CardItemList) do
                    if(tostring(b["ArmyCardID"]) == item.name) then
                        CardData = b
                    end
                end
                item.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text ="x"..tostring(CardData["Num"])
                this.view.daying_bingli_now:GetComponent("UILabel").text = this.dayingbingli_now
                this.view.qianfeng_bingli_now:GetComponent("UILabel").text = this.qianfengbingli_now
                this.view.zongbingli_now:GetComponent("UILabel").text = this.zongbingli_now
            end
            this:DragEndCtr()
            if(not go:GetComponent("UIDragScrollView").enabled) then
                go:GetComponent("UIDragScrollView").enabled = true
            end
        end
        ----加入卡牌区域物体的单击以及长按处理-----
        UIEventListener.Get(this.carditem_pic_list[i].transform:Find("card_item_frame/card_item_icon_bg/card_item_icon").gameObject).onPress = function (go,isPressed)
            this:CardPressCtr(go,isPressed,1)
        end
    end

    -----加入大营区域卡牌的单击处理-----
    for index = 1,#this.dayingitem_pic_list do
        UIEventListener.Get(this.dayingitem_pic_list[index].transform:Find("card_item_frame/card_item_icon_bg/card_item_icon").gameObject).onPress = function (go,isPressed)
            this:CardPressCtr(go,isPressed,2)
        end

        -----加入大营区域卡牌的拖动开始处理，在开始拖动的时候关闭当前打开的单击面板---
        UIEventListener.Get(this.dayingitem_pic_list[index].transform:Find("card_item_frame/card_item_icon_bg/card_item_icon").gameObject).onDragStart = function(go)
            --拖动事件
            this.isDrag = true
            this:CloseSelectCardPanel()
            this:CloseSkillPanel()
        end

        -----加入大营区域卡牌的拖动结束处理，在结束拖动的时候设置标志位，防止弹起时打开单击面板---
        UIEventListener.Get(this.dayingitem_pic_list[index].transform:Find("card_item_frame/card_item_icon_bg/card_item_icon").gameObject).onDragEnd = function(go)
            this.isDrag = false
            this.isLongorDragPress = true
        end

        ----加入大营区域卡牌右上角的删除按钮的响应处理------
        UIEventListener.Get(this.dayingitem_pic_list[index].transform:Find("card_item_frame/card_item_level_bg/btn_dayingitem_delete").gameObject).onPress = function(go,isPressed)
            this:DeletePressCtr(go,isPressed)
        end
    end

    ----加入外部TriggerBox,大营触摸碰撞面板，以及卡牌区域触摸碰撞面板的响应----
    UIEventListener.Get(this.view.TriggerBox).onPress = function (go,isPressed)
        this:TriggerCtr(go,isPressed)
    end

    UIEventListener.Get(this.view.daying_item_panel_col).onPress = function (go,isPressed)
        this:TriggerCtr(go,isPressed)
    end

    UIEventListener.Get(this.view.card_item_panel_col).onPress = function (go,isPressed)
        this:TriggerCtr(go,isPressed)
    end

    ---加入左右滑动按钮的点击响应
    UIEventListener.Get(this.view.biandui_btn["LeftDragBtn"]).onPress = function (go,isPressed)
        this:MoveCardList(go,isPressed)
    end

    UIEventListener.Get(this.view.biandui_btn["RightDragBtn"]).onPress = function (go,isPressed)
        this:MoveCardList(go,isPressed)
    end

    ---返回按钮
    UIEventListener.Get(this.view.biandui_btn["BackBtn"]).onClick = function()
        this:UpdateArmyData()
    end

    ---技能按钮
    UIEventListener.Get(this.view.skill1).onPress = function (go,isPressed)
        this:OnSkillPress(go,isPressed)
    end
    UIEventListener.Get(this.view.skill2).onPress = function (go,isPressed)
        this:OnSkillPress(go,isPressed)
    end
    UIEventListener.Get(this.view.skill3).onPress = function (go,isPressed)
        this:OnSkillPress(go,isPressed)
    end

    ---为高亮底板碰撞体添加模型拖动响应---
    for i = 1,6 do
        -----模型拖动开始---
        UIEventListener.Get(this.view.pos_col[i]).onDragStart = function(go)
            --拖动事件
            this:CloseSelectCardPanel()
            this:CloseSkillPanel()
            print("模型onDragStart")
        end
        ----模型拖动-----
        UIEventListener.Get(this.view.pos_col[i]).onDrag = function(go,TouchPosition)
            --拖动事件
            print("模型onDrag")
            this:OnDragModel(go,TouchPosition)
        end
        -----模型拖动结束----
        UIEventListener.Get(this.view.pos_col[i]).onDragEnd = function(go)
            print("模型onDragEND")
            if(this.ModeDragState == "change") then
                this:ChangeModel(go)
            elseif (this.ModeDragState == "back") then
                this:BackModelToCard(go)
            end

            this.view.card_clone_panel:SetActive(false)
            Object.Destroy(this.Cloneobj)
            if(this.Clonemod ~= nil) then
                Object.Destroy(this.Clonemod.gameObject)
            end
            this.isClone = false
            this.Clonemod = nil
            this.Cloneobj = nil
            this.pos = 0
        end
    end


end

--@Des 移动卡库区域
function wnd_biandui_controller:MoveCardList(go,isPressed)
    this:CloseSelectCardPanel()
    this:CloseSkillPanel()
    this.lastclickobj = go
    if(#this.CardItemList<=7) then

        return
    end

    if(isPressed) then
        this.isstop = false
    else
        this.isstop = true
        return
    end
end

--@Des 卡库移动处理
function wnd_biandui_controller:Update()
    if(not this.isstop) then
        local v3 = nil
        if(this.lastclickobj.name == "btn_left") then
            v3 = Vector3(-30,0,0)
            if(this.carditem_pic_list[#this.carditem_pic_list].transform.position.x <= this.lastcardpos.x+0.15) then
                return
            end
        else
            if(this.carditem_pic_list[1].transform.position.x >= this.firstcardpos.x) then
                return
            end
            v3 = Vector3(30,0,0)
        end
        this.view.card_item_panel:GetComponent("UIScrollView"):MoveRelative(v3)
    end
end

--@Des 点击别处关闭单击卡牌面板
--@params go(GameObject)：点击的物体
--        isPressed(bool)：鼠标是否在按下状态
function wnd_biandui_controller:TriggerCtr(go,isPressed)
    ---如果鼠标弹起则返回—-----
    ---鼠标按下则直接关闭单击面板---
    if(not isPressed) then
        return
    end
    ----关闭面板，关闭当前展开的box碰撞器---
    this:CloseSelectCardPanel()
    this:CloseSkillPanel()
    if(this.view.TriggerBox.activeSelf) then
        this.view.TriggerBox:SetActive(false)
    end
end

--@Des 关闭单击面板
function wnd_biandui_controller:CloseSelectCardPanel()
    if(not this.view.select_card_panel.activeSelf) then
        return
    end
    if(this.lastclickobj~=nil and this.lastclickobj.name~="btn_dayingitem_delete" ) then
        if(this.lastclickobj.name == "card_item_icon") then
            this.view.select_card_panel:SetActive(false)
            this.lastclickobj.transform.parent.parent.parent.localScale = Vector3(1,1,1)
        end
    end
end

--@Des 更新本地和服务器的大营以及前锋数据
function wnd_biandui_controller:UpdateArmyData()
    local dayingchange = this:CprDayingData()
    local qianfengchange = this:CprQianfengData()


    local on_10035_rec = function(body)
        --print("on_10035_rec call")
        --Event.RemoveListener("10035", on_10035_rec)
        ----   UIToast.Show("已接收到来自服务器的签到信息.",nil,UIToast.ShowType.Queue)
        --local gw2c = gw2c_pb:SetCardGf()
        --gw2c:ParseFromString(body)
        ------   this:updateServData(gw2c.currency,nil)
    end

    if(dayingchange) then
        print("大营改变了")
        --TODO:覆盖model层大营数据

        this.model.DayingItemList = {}
        for k,v in pairs(this.DayingItemList) do
            local Item = {}
            Item["cardId"] = v["cardId"]
            Item["num"] = v["num"]
            table.insert(this.model.DayingItemList,Item)
        end
        --Message_Manager:SendPB_10035(this.DayingItemList,on_10035_rec)
    else
        print("大营没变")
    end

    local on_10036_rec = function(body)
        --print("on_10036_rec call")
        --Event.RemoveListener("10036", on_10036_rec)
        ----   UIToast.Show("已接收到来自服务器的签到信息.",nil,UIToast.ShowType.Queue)
        --local gw2c = gw2c_pb:SetCardGf()
        --gw2c:ParseFromString(body)
        ------   this:updateServData(gw2c.currency,nil)
    end

    if(qianfengchange) then
        --TODO:覆盖model层前锋数据
        print("前锋改变了")
        this.model.QianfengItemList = {}
        for i=1,6  do
            if(this.QianfengItemList[i] == nil) then
                this.model.QianfengItemList[i] = nil
            else
                local Item = {}
                Item["cardId"] = this.QianfengItemList[i]["cardId"]
                Item["pos"] = this.QianfengItemList[i]["pos"]
                this.model.QianfengItemList[i] = Item
            end
        end
        -- Message_Manager:SendPB_10036(this.QianfengItemList,on_10036_rec)
    else
        print("前锋没变")
    end
end


--@Des 大营数据本地/服务器对比
--@return 数据是否改变
function wnd_biandui_controller:CprDayingData()
    local change = true
    local num = 0
    if(#this.DayingItemList ~= 0 and #this.model.DayingItemList == 0) then
        return true
    elseif #this.DayingItemList == 0 and #this.model.DayingItemList ~= 0 then
        return true
    elseif #this.DayingItemList == 0 and #this.model.DayingItemList == 0 then
        return false
    elseif #this.DayingItemList~=#this.model.DayingItemList then
        return true
    end

    for i =1,#this.DayingItemList do
        for k = 1,#this.model.DayingItemList do
            if(this.DayingItemList[i]["cardId"] == this.model.DayingItemList[k]["cardId"]) then
                if(this.DayingItemList[i]["num"] == this.model.DayingItemList[k]["num"]) then
                    num = num+1
                end
            end
        end
    end

    if(num == #this.DayingItemList) then
        change = false
    end

    return change
end

--@Des 前锋数据本地/服务器对比
--@return 数据是否改变
function wnd_biandui_controller:CprQianfengData()
    local change = true
    local num = 0

    for i=1,6  do
        if(this.QianfengItemList[i] == nil and this.model.QianfengItemList[i] == nil) then num = num+1
        else
            if(this.QianfengItemList[i]~=nil and this.model.QianfengItemList[i]~=nil) then
                if(this.QianfengItemList[i]["cardId"] == this.model.QianfengItemList[i]["cardId"]) then
                    if(this.QianfengItemList[i]["pos"] == this.model.QianfengItemList[i]["pos"]) then num = num+1
                    end
                end
            end
        end
    end
    print("num"..tostring(num))
    if(num == 6) then
        change = false
    end
    return change
end

--@Des 关闭技能面板
function wnd_biandui_controller:CloseSkillPanel()
    if(ui_skill_controller.bIsShowing) then
        ui_skill_controller:Hide()
    end
end

--@Des 根据元素名字查找卡牌元素
--@return 卡牌图片，卡牌数据
function wnd_biandui_controller:FindCardItemDataByName(itemname)
    local CardItem = nil
    local CardData = nil

    for k,v in pairs(this.carditem_pic_list) do
        if(v.name == itemname) then
            CardItem = v
            for a,b in pairs(this.CardItemList) do
                if(tostring(b["ArmyCardID"]) == itemname) then
                    CardData = b
                end
            end
        end
    end
    return CardItem,CardData
end

----------------------------------------------------

---卡牌操作装态判定及响应相关------------------------
--@Des 卡牌区域元素单击/长按处理
--@params go(GameObject)：点击的卡牌图标
--        isPressed(bool)：鼠标是否在按下状态
--        index(number)：用来区分点击的是大营区域卡牌还是卡组区域的卡牌
--                       1为卡组区域，2为大营区域  
function wnd_biandui_controller:CardPressCtr(go,isPressed,index)
    ---当长按计时完成后的响应回调函数----
    OnComplete = function()
        this.OnPressTimer:Kill()
        if(this.isDrag or this.lastclickobj~=go) then
            return
        else
            this.startlongadd =true
            if(not this.view.select_card_panel.activeSelf) then
                return
            end
            print("已经完成了计时!!")
            this.isLongorDragPress = true
            ----匀速添加功能
            local fun = function()
                while isPressed == true do
                    if(not this.startlongadd) then
                        return
                    end
                    coroutine.wait(0.1)
                    this:AddCardToDaying(go)
                end
            end
            coroutine.start(fun)
        end
    end
    print("现在我按没按！"..tostring(isPressed))

    if isPressed then
        if this.OnPressTimer then
            this.OnPressTimer:Kill()
        end
        this.OnPressTimer = TimeUtil:CreateTimer(1.5,OnComplete)
    else
        this.startlongadd =false
        this.OnPressTimer:Kill()
        print("为什么抬不起来-------"..tostring(this.isLongorDragPress))

        if(this.isLongorDragPress == true) then
            this.isLongorDragPress = false
        else
            this:CloseSelectCardPanel()
            this:CloseSkillPanel()
            this:CardOnClick(go,index)
            print("我的手抬起来了！")
        end
    end
end

--@Des 卡牌单击响应
--@params go(GameObject)：点击的卡牌图标
--        index(number)：用来区分点击的是大营区域卡牌还是卡组区域的卡牌
--                       1为卡组区域，2为大营区域
function wnd_biandui_controller:CardOnClick(go,index)
    this.lastclickobj = go ---记录当次点击的物体
    local Item = go.transform.parent.parent.parent
    this.view.select_card_panel:SetActive(true)
    Item.localScale = Vector3(1.1,1.1,1) ---放大卡牌
    local v3 = Vector3 (go.transform.position.x,go.transform.position.y,go.transform.position.z)
    if(index == 1) then
        v3.y = v3.y+0.3----做单击面板显示在卡牌区域的处理,把选择面板置于上方
    else
        v3.y = v3.y-0.3----做单击面板显示在大营区域的处理，把选择面板置于下方
    end
    this.view.select_card_panel.transform.position = v3
    this.view.select_card_panel:SetActive(true)
    ---为打开的单击面板的添加按钮添加响应，传入当前点击的卡牌-----
    UIEventListener.Get(this.view.select_card_panel.transform:Find("select_card_bg/select_card_add").gameObject).onClick = function ()
        this:AddCardToDaying(go)
    end
    this.view.TriggerBox:SetActive(true)
    print("单击！单击！单击！")
end


--@Des 卡牌拖动状态判定
--@params go(GameObject)：拖动的卡牌的图标
--        TouchPosition(Vector2)：每一帧拖动的位移
function wnd_biandui_controller:DragCtr(go,TouchPosition)
    local DragsumX = 0
    local DragsumY = 0

    ---如果已经处于一个在左右拖动或者上下拖动的状态，左右拖动则返回，上下拖动则进行卡牌的移动-----
    if(not this.isudDrag and this.islfDrag) then
        return
    elseif(this.isudDrag and not this.islfDrag) then
        this:AddCloneCardToArmy(go,TouchPosition)
    else
        -----如果当前没有左右和上下拖动，则进行拖动判定------
        print("onDrag")
        print(TouchPosition.x,TouchPosition.y)
        DragsumX = TouchPosition.x
        DragsumY = TouchPosition.y

        if(TouchPosition.y<0) then
            DragsumY = -DragsumY
        end
        if(TouchPosition.x<0) then
            DragsumX = -DragsumX
        end

        ------根据计算的拖动角度比例，判断当前是左右拖动还是上下拖动------
        print("角度计算是.........."..tostring(DragsumY/DragsumX))
        if(DragsumY/DragsumX >0.36) then
            this.isudDrag = true
            this.islfDrag = false
        elseif(DragsumY/DragsumX <0.36) then
            this.isudDrag = false
            this.islfDrag = true
        end

        -----如果是上下拖动，则关闭当前单击面板，关闭列表拖动空间，开始进行克隆卡牌并往大营拖动的处理---
        if(this.isudDrag and not this.islfDrag) then
            print("上下上下上下")
            this:CloseSelectCardPanel()
            this:CloseSkillPanel()
            go:GetComponent("UIDragScrollView").enabled = false
            this:AddCloneCardToArmy(go,TouchPosition)

            -----如果是左右拖动则进行单击面板的关闭---
        elseif (not this.isudDrag and this.islfDrag) then
            this:CloseSelectCardPanel()
            this:CloseSkillPanel()
            print("左右左右左右")
        end
    end
end


--@Des 卡牌拖动结束处理
function wnd_biandui_controller:DragEndCtr()
    this.isDrag = false
    this.isudDrag = false
    this.islfDrag = false
    this.isLongorDragPress = true
    this.DayingCanbeAdd = false
    this.QianfengCanbeAdd = false
    this.isClone = false
    this.view.card_clone_panel:SetActive(false)
    Object.Destroy(this.Cloneobj)
    if(this.Clonemod ~= nil) then
        Object.Destroy(this.Clonemod.gameObject)
    end

    this.Clonemod = nil
    this.Cloneobj = nil
    this.pos = 0
    this.view.qianfeng_bingli_now:GetComponent("UILabel").color = Color(255,255,255)
    this.view.daying_bingli_now:GetComponent("UILabel").color = Color(255,255,255)
    this.view.zongbingli_now:GetComponent("UILabel").color = Color(255,255,255)
end


--@Des 卡牌上下拖动处理，生成克隆体，判断是否拖入大营或者前锋，修改兵力
--@params go(GameObject)：拖动的物体
--        TouchPosition(Vector2)：每一帧拖动的位移
function wnd_biandui_controller:AddCloneCardToArmy(go,TouchPosition)
    local tempDayingbl = 0
    local tempZongbl = 0
    local tempQianfengbl = 0
    local item = go.transform.parent.parent.parent.gameObject
    local CardData = nil
    local CardItem = nil

    CardItem,CardData = this:FindCardItemDataByName(item.name)
    if(CardData["Num"] == 0) then
        return
    end
    if(not this.isClone) then
        this.isClone = true
        this.view.card_clone_panel:SetActive(true)
        this.Cloneobj = GameObjectExtension.InstantiateFromPreobj(this.view.card_clone_item,this.view.card_clone_panel)
        this.Cloneobj.name = item.name
        this:SetStar(this.Cloneobj,CardData["Star"])
        this.Cloneobj.transform:Find("card_item_frame/card_item_numc_bg/card_item_consume"):GetComponent("UILabel").text = tostring(CardData["TrainCost"])
        this.Cloneobj.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text ="x1"
        this.Cloneobj.transform:Find("card_item_frame/card_item_level_bg/card_item_level_frame/card_item_level_label"):GetComponent("UILabel").text = "LV."..tostring(CardData["Level"])
        item.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text ="x"..tostring(CardData["Num"]-1)
        ---------这里还需要加入很多数据，彻底复制一个拖动的物体---------
        this.Cloneobj.transform.localScale = Vector3(1,1,1)
        this.Cloneobj.transform.position = item.transform.position
        this.view.card_clone_item:SetActive(false)
        this.Cloneobj:SetActive(true)

    elseif(this.isClone and this.Cloneobj~=nil) then
        if(not this.Cloneobj.activeSelf) then
            this.Cloneobj:SetActive(true)
        end
        local v =  Vector3(this.Cloneobj.transform.localPosition.x+TouchPosition.x,this.Cloneobj.transform.localPosition.y+TouchPosition.y,this.Cloneobj.transform.localPosition.z)
        this.Cloneobj.transform.localPosition = v
    end

    local c_p = this.Cloneobj.transform.localPosition
    local p_s = this.view.daying_item_panel_col:GetComponent("UIWidget").localSize


    ---如果卡牌的相对位置在大营区域内则判断拖入了大营---
    if(c_p.x > -p_s.x/2 and c_p.x<p_s.x/2 and c_p.y > -p_s.y/2 and c_p.y<p_s.y/2) then
        if(this.Clonemod ~= nil) then
            this.Clonemod.gameObject:SetActive(false)
        end
        this.QianfengCanbeAdd = false
        tempDayingbl = this.dayingbingli_now + CardData["TrainCost"]
        tempQianfengbl = this.qianfengbingli_now
        tempZongbl = this.zongbingli_now + CardData["TrainCost"]

        if(tempDayingbl <= this.dayinglimit and tempZongbl <= this.zongbinglilimit) then
            this.DayingCanbeAdd = true
        else
            this.DayingCanbeAdd = false
        end

        this.pos = 0

        print("我拖进去大营啦！！！！")
    elseif (c_p.x > p_s.x/2+this.deltax and c_p.x<p_s.x/2+this.deltax+this.view.qianfeng_item_panel_bg:GetComponent("UIWidget").localSize.x and c_p.y > -p_s.y/2 and c_p.y<p_s.y/2) then
        ---如果卡牌相对位置在前锋区域内则判断拖入了前锋
        print("我拖进去前锋啦！！！！")
        --TODO：显示模型
        --看其他人的代码
        ---松手的时候加入模型进入前锋区域，更新数据
        this.Cloneobj:SetActive(false)
        this.view.CloneTexture:SetActive(true)
        if(this.Clonemod == nil) then
            --this.Clonemod = DP_FightPrefabManage.InstantiateAvatar(CreateActorParam(1, false, 0, "xuebaotujidui", "xuebaotujidui", true, 101001001, 0)).transform
            this.Clonemod = Model:CreateZhenXing(CardData["ArmyCardID"])
            this.Clonemod.parent = this.view.CloneCamera.transform
            this.Clonemod.gameObject.name = "clone"
            this.Clonemod.localScale = Vector3(1, 1, 1);
            this.Clonemod.localRotation = Quaternion(0, 1.4, 0, 1);
            this.Clonemod.localPosition = Vector3(0,0,120)
            this.Clonemod.gameObject:SetActive(true)
            this.Clonemod.gameObject.layer = UnityEngine.LayerMask.NameToLayer("3DUI")

            this.view.CloneTexture.transform.localPosition = this.Cloneobj.transform.localPosition
        else
            if(this.Clonemod ~= nil) then
                this.Clonemod.gameObject:SetActive(true)
            end
            this.view.CloneTexture.transform.localPosition = this.Cloneobj.transform.localPosition
            --this.Clonemod.localPosition = this.Cloneobj.transform.localPosition
        end
        local nowitembingli = 0
        this:GetQianfengPos(c_p)
        if(this.pos ~=0 and this.qianfengmodllst[this.pos] ~= nil) then
            for k,v in pairs(this.CardItemList) do
                if(v["ArmyCardID"] == this.QianfengItemList[this.pos]["cardId"]) then
                    nowitembingli = v["TrainCost"]
                end
            end
        end
        this.DayingCanbeAdd = false
        tempQianfengbl = this.qianfengbingli_now - nowitembingli + CardData["TrainCost"]
        tempDayingbl = this.dayingbingli_now
        tempZongbl = this.zongbingli_now - nowitembingli + CardData["TrainCost"]

        if(tempQianfengbl <= this.qianfenglimit and tempZongbl <= this.zongbinglilimit and this.pos~=0) then
            this.QianfengCanbeAdd = true
        else
            this.QianfengCanbeAdd = false
        end
    else
        if(this.Clonemod ~= nil) then
            this.Clonemod.gameObject:SetActive(false)
        end
        this.pos = 0
        this.DayingCanbeAdd = false
        this.QianfengCanbeAdd = false
        tempDayingbl = this.dayingbingli_now
        tempQianfengbl = this.qianfengbingli_now
        tempZongbl = this.zongbingli_now
    end

    -----临时性显示高亮---
    for i=1,6 do
        if(this.pos == 0) then
            if(this.qianfengmodllst[i] ~= nil) then
                this.view.pos[i]:SetActive(true)
            else
                this.view.pos[i]:SetActive(false)
            end
        else
            if(this.qianfengmodllst[i] ~= nil or i == this.pos) then
                this.view.pos[i]:SetActive(true)
            else
                this.view.pos[i]:SetActive(false)
            end
        end
    end


    this.view.qianfeng_bingli_now:GetComponent("UILabel").text = tostring(tempQianfengbl)
    if(tempQianfengbl > this.qianfenglimit) then
        this.view.qianfeng_bingli_now:GetComponent("UILabel").color = Color(255,0,0)

    else
        this.view.qianfeng_bingli_now:GetComponent("UILabel").color = Color(255,255,255)
    end

    this.view.daying_bingli_now:GetComponent("UILabel").text = tostring(tempDayingbl)
    if(tempDayingbl > this.dayinglimit) then
        this.view.daying_bingli_now:GetComponent("UILabel").color = Color(255,0,0)
    else
        this.view.daying_bingli_now:GetComponent("UILabel").color = Color(255,255,255)
    end

    this.view.zongbingli_now:GetComponent("UILabel").text = tostring(tempZongbl)
    if(tempZongbl > this.zongbinglilimit) then
        this.view.zongbingli_now:GetComponent("UILabel").color = Color(255,0,0)
    else
        this.view.zongbingli_now:GetComponent("UILabel").color = Color(255,255,255)
    end
end
-----------------------------------------------

--@Des 获取卡牌进入前锋的6个位置
--@params c_p(Vector2)：卡牌位置
function wnd_biandui_controller:GetQianfengPos(c_p)
    local i = 0
    local qianfengpanelsize = this.view.qianfeng_item_panel_bg:GetComponent("UIWidget").localSize
    local dayingpanelsize   = this.view.daying_item_panel_col:GetComponent("UIWidget").localSize
    if(c_p.x>dayingpanelsize.x/2+this.deltax and c_p.x<dayingpanelsize.x/2+this.deltax+this.deltax+qianfengpanelsize.x/2) then
        if(c_p.y<qianfengpanelsize.y/6 and c_p.y>0-qianfengpanelsize.y/6) then
            this.pos = 3
        elseif (c_p.y<qianfengpanelsize.y/2 and c_p.y>qianfengpanelsize.y/6) then
            this.pos = 1
        elseif (c_p.y<0-qianfengpanelsize.y/6 and c_p.y>0-qianfengpanelsize.y/2) then
            this.pos = 5
        end

    elseif (c_p.x>dayingpanelsize.x/2+this.deltax+this.deltax+qianfengpanelsize.x/2 and c_p.x<dayingpanelsize.x/2+this.deltax+this.deltax+qianfengpanelsize.x) then
        if(c_p.y<qianfengpanelsize.y/6 and c_p.y>0-qianfengpanelsize.y/6) then
            this.pos = 4
        elseif (c_p.y<qianfengpanelsize.y/2 and c_p.y>qianfengpanelsize.y/6) then
            this.pos = 2
        elseif (c_p.y<0-qianfengpanelsize.y/6 and c_p.y>0-qianfengpanelsize.y/2) then
            this.pos = 6
        end
    else
        this.pos =0
    end
end

------卡牌增删相关-----------------------------------------
--@Des 添加卡牌至大营
--@params go(GameObject)：需要添加到大营的卡牌的图标
function wnd_biandui_controller:AddCardToDaying(go)
    local item = go.transform.parent.parent.parent.gameObject

    local CardData = nil
    local CardItem = nil

    local DayingData = nil
    local DayingItem = nil

    CardItem,CardData = this:FindCardItemDataByName(item.name)

    if(CardData == nil or CardItem == nil) then
        print("卡牌查找失败---")
        return
    end

    if(CardData["Num"] == 0) then
        print("卡牌数量不够啦！")
        return
    end

    if(this.dayingbingli_now + CardData["TrainCost"] > this.dayinglimit or this.zongbingli_now + CardData["TrainCost"]>this.zongbinglilimit) then
        print("大营兵力超出啦---")
        return
    end

    for k,v in pairs(this.dayingitem_pic_list) do
        if(v.name == item.name) then
            DayingItem = v
            for a,b in pairs(this.DayingItemList) do
                if(tostring(b["cardId"]) == item.name) then
                    DayingData = b
                end
            end
        end
    end

    -----------------------为新建卡牌添加响应--------------------
    if(DayingData == nil or DayingItem == nil) then

        print("我走这一句啦啦啦啦")

        local dygo =  GameObjectExtension.InstantiateFromPreobj(this.view.card_clone_item,this.view.daying_item_grid)
        this.view.daying_item_grid:GetComponent("UIGrid"):AddChild(dygo.transform,false)

        dygo.transform.name = tostring(CardData["ArmyCardID"])
        -----star---level---quality----type---num---consume---
        this:SetStar(dygo,CardData["Star"])
        dygo.transform:Find("card_item_frame/card_item_numc_bg/card_item_consume"):GetComponent("UILabel").text = tostring(CardData["TrainCost"])
        dygo.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text ="x1"
        dygo.transform:Find("card_item_frame/card_item_level_bg/card_item_level_frame/card_item_level_label"):GetComponent("UILabel").text = "LV."..tostring(CardData["Level"])
        this.dayingitem_pic_list[#this.dayingitem_pic_list+1] = dygo
        dygo:SetActive(true)

        this:MakeDayingItem(CardData["ArmyCardID"],1)

        dygo.transform:Find("card_item_frame/card_item_icon_bg/card_item_icon").gameObject:GetComponent("UIDragScrollView").scrollView = this.view.daying_item_panel:GetComponent("UIScrollView")

        UIEventListener.Get(dygo.transform:Find("card_item_frame/card_item_icon_bg/card_item_icon").gameObject).onPress = function (go,isPressed)
            this:CardPressCtr(go,isPressed,2)
        end

        -----加入大营区域卡牌的拖动开始处理，在开始拖动的时候关闭当前打开的单击面板---
        UIEventListener.Get(dygo.transform:Find("card_item_frame/card_item_icon_bg/card_item_icon").gameObject).onDragStart = function(go)
            --拖动事件
            this.isDrag = true
            this:CloseSelectCardPanel()
            this:CloseSkillPanel()
        end

        -----加入大营区域卡牌的拖动结束处理，在结束拖动的时候设置标志位为这是一个长按拖动，防止弹起时打开单击面板---
        UIEventListener.Get(dygo.transform:Find("card_item_frame/card_item_icon_bg/card_item_icon").gameObject).onDragEnd = function(go)
            this.isDrag = false
            this.isLongorDragPress = true
        end

        dygo.transform:Find("card_item_frame/card_item_level_bg/btn_dayingitem_delete").gameObject:SetActive(true)
        ----加入大营区域卡牌右上角的删除按钮的响应处理------
        UIEventListener.Get(dygo.transform:Find("card_item_frame/card_item_level_bg/btn_dayingitem_delete").gameObject).onPress = function(go,isPressed)
            this:DeletePressCtr(go,isPressed)
        end

        this.view.AddIcon.transform:SetAsLastSibling()
        this.view.daying_item_grid:GetComponent("UIGrid"):Reposition()
    else
        CardData["Num"] = CardData["Num"]-1
        DayingData["num"] = DayingData["num"]+1
        print(DayingData["num"])
        DayingItem.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text = "x"..tostring(DayingData["num"])
    end


    CardItem.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text = "x"..tostring(CardData["Num"])
    this:SetBlingli()

end

--@Des 添加卡牌至前锋
--@params go(GameObject)：需要添加到前锋的卡牌的图标
function wnd_biandui_controller:AddCardToQianfeng(go)
    local item = go.transform.parent.parent.parent.gameObject
    local CardData = nil
    local CardItem = nil

    CardItem,CardData = this:FindCardItemDataByName(item.name)
    if(CardData == nil or CardItem == nil) then
        print("卡牌查找失败---")
        return
    end
    if(CardData["Num"] == 0) then
        print("卡牌数量不够啦！")
        return
    end

    print("-------------"..tostring(this.pos))
    if(this.qianfengmodllst[this.pos] ~= nil) then
        local id = 0
        local num = 0
        for a,b in pairs(this.CardItemList) do
            if(b["ArmyCardID"] == this.QianfengItemList[this.pos]["cardId"]) then
                b["Num"] = b["Num"]+1
                num  = b["Num"]
                id = b["ArmyCardID"]
            end
        end
        for k,v in pairs(this.carditem_pic_list) do
            if(v.gameObject.name == tostring(id)) then
                v.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text = "x"..tostring(num)
            end
        end
        GameObject.Destroy(this.qianfengmodllst[this.pos].gameObject)
        this.qianfengmodllst[this.pos] = nil --TODO：删除方法有待商榷
        this.QianfengItemList[this.pos] = nil
    end
    tempMod = Model:CreateZhenXing(CardData["ArmyCardID"])
    tempMod.parent = this.view.camera3D.transform
    tempMod.gameObject.name = tostring(this.pos)
    tempMod.localScale = Vector3(1, 1, 1);
    tempMod.localRotation = Quaternion(0, 1.4, 0, 1);
    tempMod.localPosition = this.modelpos[this.pos]
    tempMod.gameObject:SetActive(true)
    tempMod.gameObject.layer = UnityEngine.LayerMask.NameToLayer("3DUI")
    this.qianfengmodllst[this.pos] = tempMod
    local Item = {}
    Item["pos"] = this.pos
    Item["cardId"] = tonumber(item.name)
    this.QianfengItemList[this.pos] = Item


    CardData["Num"] = CardData["Num"]-1
    CardItem.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text ="x"..tostring(CardData["Num"])
    this:SetBlingli()
end


--@Des 删除按钮点击响应
--@params go(GameObject)：点击的卡牌图标
--        isPressed(bool)：鼠标是否在按下状态
function wnd_biandui_controller:DeletePressCtr(go,isPressed)
    ---当长按计时完成后的响应回调函数----
    --this.lastclickobj = go
    this:CloseSelectCardPanel()
    this:CloseSkillPanel()

    OnComplete = function()
        this.OnPressTimer:Kill()
        this.startlongadd =true
        print("已经完成了计时!!")
        ----匀速删除功能
        local fun = function()
            while isPressed == true do
                if(not this.startlongadd or go == nil) then
                    return
                end
                coroutine.wait(0.1)
                this:DeleteDayingItem(go)
            end
        end
        coroutine.start(fun)
    end
    print("现在我按没按！"..tostring(isPressed))
    if isPressed then
        if this.OnPressTimer then
            this.OnPressTimer:Kill()
        end
        this.OnPressTimer = TimeUtil:CreateTimer(1.5,OnComplete)
    else
        this.OnPressTimer:Kill()
        if(this.startlongadd ==true) then
            this.startlongadd =false
            return
        end
        if go~=nil then
            this:DeleteDayingItem(go)
        end
    end
end

--@Des 删除大营区域的相应卡牌
--@params go(GameObject)：点击的卡牌图标
function wnd_biandui_controller:DeleteDayingItem(go)
    local item = go.transform.parent.parent.parent.gameObject
    if(item == nil) then
        return
    end
    local key1
    local key2
    local DayingData = nil
    local DayingItem = nil
    local CardData = nil
    local CardItem = nil
    for k,v in pairs(this.dayingitem_pic_list) do
        if(v.name == item.name) then
            key1 = k
            DayingItem = v
            for a,b in pairs(this.DayingItemList) do
                if(tostring(b["cardId"]) == item.name) then
                    key2 = a
                    DayingData = b
                end
            end
        end
    end

    CardItem,CardData = this:FindCardItemDataByName(item.name)
    if(DayingData == nil or DayingItem == nil) then
        return
    end

    CardData["Num"] = CardData["Num"]+1
    CardItem.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text = "x"..tostring(CardData["Num"])

    DayingData["num"] = DayingData["num"]-1
    DayingItem.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text = "x"..tostring(DayingData["num"])

    if(DayingData["num"] == 0) then
        this.startlongadd =false
        DayingItem:SetActive(false)
        table.remove(this.dayingitem_pic_list,key1)
        this.view.AddIcon.transform:SetAsLastSibling()
        table.remove(this.DayingItemList,key2)
        if(this.view.select_card_panel.activeSelf) then
            this.view.select_card_panel:SetActive(false)
        end
        GameObject.Destroy(DayingItem)
        this.view.AddIcon.transform:SetAsLastSibling()
        this.view.daying_item_grid:GetComponent("UIGrid").enabled = true
    end
    this:SetBlingli()
end
-----------------------------------------------------------


------技能按钮----------------------------------------
--@Des 技能面板按下响应
--@params go(GameObject)：点击的技能图标
--        isPressed(bool)：是否按下
function wnd_biandui_controller:OnSkillPress(go,isPressed)
    if(not isPressed) then
        return
    end

    if(this.lastselectskill == nil) then
        this.lastselectskill = go
    else
        this.lastselectskill:GetComponent(typeof(UISprite)).spriteName = "jinengxuanze_anniu_jinengkuang_weizhaungbei"
        this.lastselectskill = go
    end

    go:GetComponent(typeof(UISprite)).spriteName = "jinengxuanze_anniu_jinengkuang_zhaungbei"
    if(this.view.TriggerBox.activeSelf == false) then
        this.view.TriggerBox:SetActive(true)
    end

    local v3 = Vector3(-254,0,0)
    ui_skill_controller:Show(this.view.skill1,this.view.skill2,this.view.skill3,go,v3)
end

-------------------------------------------------------
--@Des 模型拖动响应
--@params go(GameObject)：拖动的高亮面板碰撞体（碰撞体名字为1-6）
--        TouchPosition(bool)：每次响应位移距离
function wnd_biandui_controller:OnDragModel(go,TouchPosition)
    if(this.qianfengmodllst[tonumber(go.name)] == nil) then
        return
    end

    local tempZongbl = 0
    local tempQianfengbl = 0

    local pos = tonumber(go.name)
    local CardData = nil
    local CardItem = nil

    CardItem,CardData = this:FindCardItemDataByName(tostring(this.QianfengItemList[pos]["cardId"]))
    this.qianfengmodllst[pos].gameObject:SetActive(false) --TODO：删除方法有待商榷

    if(not this.isClone) then
        this.isClone = true
        this.view.card_clone_panel:SetActive(true)
        this.Cloneobj = GameObjectExtension.InstantiateFromPreobj(this.view.card_clone_item,this.view.card_clone_panel)
        this.Cloneobj.name = tostring(this.QianfengItemList[pos]["cardId"])
        this:SetStar(this.Cloneobj,CardData["Star"])
        this.Cloneobj.transform:Find("card_item_frame/card_item_numc_bg/card_item_consume"):GetComponent("UILabel").text = tostring(CardData["TrainCost"])
        this.Cloneobj.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text ="x1"
        this.Cloneobj.transform:Find("card_item_frame/card_item_level_bg/card_item_level_frame/card_item_level_label"):GetComponent("UILabel").text = "LV."..tostring(CardData["Level"])
        ---------这里还需要加入很多数据，彻底复制一个拖动的物体---------
        this.Cloneobj.transform.localScale = Vector3(1,1,1)
        this.Cloneobj.transform.position = go.transform.position
        this.view.card_clone_item:SetActive(false)
        this.Cloneobj:SetActive(true)
    elseif(this.isClone and this.Cloneobj~=nil) then

        if(not this.Cloneobj.activeSelf) then
            this.Cloneobj:SetActive(true)
        end
        local v =  Vector3(this.Cloneobj.transform.localPosition.x+TouchPosition.x,this.Cloneobj.transform.localPosition.y+TouchPosition.y,this.Cloneobj.transform.localPosition.z)
        this.Cloneobj.transform.localPosition = v
    end

    local c_p = this.Cloneobj.transform.localPosition
    local p_s = this.view.daying_item_panel_col:GetComponent("UIWidget").localSize

    if (c_p.x > p_s.x/2+this.deltax and c_p.x<p_s.x/2+this.deltax+this.view.qianfeng_item_panel_bg:GetComponent("UIWidget").localSize.x and c_p.y > -p_s.y/2 and c_p.y<p_s.y/2) then
        ---如果卡牌相对位置在前锋区域内则判断拖入了前锋
        print("我拖进去前锋啦！！！！")
        --TODO：显示模型
        --看其他人的代码
        ---松手的时候加入模型进入前锋区域，更新数据
        this.Cloneobj:SetActive(false)
        this.view.CloneTexture:SetActive(true)
        if(this.Clonemod == nil) then
            this.Clonemod = Model:CreateZhenXing(CardData["ArmyCardID"])
            this.Clonemod.parent = this.view.CloneCamera.transform
            this.Clonemod.gameObject.name = "clone"
            this.Clonemod.localScale = Vector3(1, 1, 1);
            this.Clonemod.localRotation = Quaternion(0, 1.4, 0, 1);
            this.Clonemod.localPosition = Vector3(0,0,120)
            this.Clonemod.gameObject:SetActive(true)
            this.Clonemod.gameObject.layer = UnityEngine.LayerMask.NameToLayer("3DUI")
            this.view.CloneTexture.transform.localPosition = this.Cloneobj.transform.localPosition
        else
            if(this.Clonemod ~= nil) then
                this.Clonemod.gameObject:SetActive(true)
            end
            this.view.CloneTexture.transform.localPosition = this.Cloneobj.transform.localPosition
        end

        this.ModeDragState = "change"
        tempQianfengbl = this.qianfengbingli_now
        tempZongbl = this.zongbingli_now
        this:GetQianfengPos(c_p)
    else
        this.ModeDragState = "back"

        if(this.Clonemod ~= nil) then
            this.Clonemod.gameObject:SetActive(false)
        end

        this.pos = 0
        this.DayingCanbeAdd = false
        this.QianfengCanbeAdd = false
        tempQianfengbl = this.qianfengbingli_now - CardData["TrainCost"]
        tempZongbl = this.zongbingli_now - CardData["TrainCost"]
    end

    for i=1,6 do
        if(this.pos == 0) then
            if(this.qianfengmodllst[i] ~= nil and i ~= pos) then
                this.view.pos[i]:SetActive(true)
            else
                this.view.pos[i]:SetActive(false)
            end
        else
            if((this.qianfengmodllst[i] ~= nil and i ~= pos) or i == this.pos ) then
                this.view.pos[i]:SetActive(true)
            else
                this.view.pos[i]:SetActive(false)
            end
        end
    end

    this.view.qianfeng_bingli_now:GetComponent("UILabel").text = tostring(tempQianfengbl)
    this.view.zongbingli_now:GetComponent("UILabel").text = tostring(tempZongbl)
end

--@Des 模型换位置
--@params go(GameObject)：拖动的高亮面板碰撞体（碰撞体名字为1-6）
function wnd_biandui_controller:ChangeModel(go)

    local pos = tonumber(go.name)
    if(this.pos == pos) then
        this.qianfengmodllst[this.pos].gameObject:SetActive(true)
        return
    end
    if(this.qianfengmodllst[this.pos] == nil and this.QianfengItemList[this.pos] == nil) then
        this.qianfengmodllst[this.pos] = this.qianfengmodllst[pos]
        this.QianfengItemList[this.pos] = this.QianfengItemList[pos]
        this.qianfengmodllst[this.pos].gameObject.name = tostring(this.pos)
        this.qianfengmodllst[this.pos].localPosition = this.modelpos[this.pos]
        this.qianfengmodllst[this.pos].gameObject:SetActive(true)

        --GameObject.Destroy(this.qianfengmodllst[pos].gameObject)
        this.qianfengmodllst[pos] = nil --TODO：删除方法有待商榷
        this.QianfengItemList[pos] = nil
        return
    end


    if(this.qianfengmodllst[this.pos] ~= nil and this.QianfengItemList[this.pos] ~= nil) then
        local tempmod = nil
        tempmod = this.qianfengmodllst[pos]
        this.qianfengmodllst[pos] = this.qianfengmodllst[this.pos]
        this.qianfengmodllst[pos].gameObject.name = tostring(pos)
        this.qianfengmodllst[pos].localPosition = this.modelpos[pos]
        this.view.pos[pos]:SetActive(true)

        this.qianfengmodllst[this.pos] = tempmod
        this.qianfengmodllst[this.pos].gameObject.name = tostring(this.pos)
        this.qianfengmodllst[this.pos].localPosition = this.modelpos[this.pos]
        this.qianfengmodllst[this.pos].gameObject:SetActive(true)

        local tempdata = {}
        tempdata = this.QianfengItemList[pos]
        this.QianfengItemList[pos] = this.QianfengItemList[this.pos]
        this.QianfengItemList[this.pos] = tempdata
    end
    print(tostring(this.pos))
end

--@Des 模型拖出前锋
--@params go(GameObject)：拖动的高亮面板碰撞体（碰撞体名字为1-6）
function wnd_biandui_controller:BackModelToCard(go)
    local pos = tonumber(go.name)
    local CardData = nil
    local CardItem = nil

    CardItem,CardData = this:FindCardItemDataByName(tostring(this.QianfengItemList[pos]["cardId"]))
    CardData["Num"] = CardData["Num"] +1
    CardItem.transform:Find("card_item_frame/card_item_numc_bg/card_item_num"):GetComponent("UILabel").text = "x"..tostring(CardData["Num"])

    GameObject.Destroy(this.qianfengmodllst[pos].gameObject)
    this.qianfengmodllst[pos] = nil --TODO：删除方法有待商榷
    this.QianfengItemList[pos] = nil

    this:SetBlingli()
    print(tostring(this.pos))
end


return wnd_biandui_controller