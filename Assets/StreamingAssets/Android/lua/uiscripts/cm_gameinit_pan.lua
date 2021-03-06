-- 游戏初始化组件
require "LuaLibs/classWC"

gameinit = classWC()

-- 单例
GameInit = nil


require "LuaLibs/exmath"
require "LuaLibs/exVector3"
require "LuaLibs/exVector2"
require "LuaLibs/exlua"
require "LuaLibs/delegate"
require "LuaLibs/event"
require "LuaLibs/extable"
require "LuaLibs/exstring"
require "LuaLibs/luacsv"
require "LuaLibs/debug"
require "LuaLibs/progress_statistical"
require "LuaLibs/resultwait"
require "uiscripts/wnd_base"
require "LuaLibs/sceneJump"

require "init._requirefiles"
require "wnd._wnddefine"
require "EventHandles"
sdata_uidefine = require "sdata.sdata_uidefine"
-- 登录窗体组件名列表
local lgwnds = {
    {name = WND.Healthadvice, cm = "uiscripts/wnd_healthadvice"}
}


-- 非登录窗体组件名列表
-- 窗体枚举 --对应的类名
local wndlist = {
    {name = WND.Login, cm = "uiscripts/wndtz_login"},
    {name = WND.fight_ui, cm = "uiscripts/ui_fight"},
    {name = WND.pause_ui, cm = "uiscripts/ui_pause"},
}

function gameinit:InitWnd(cmName)
    local newWndFunc = require(cmName);
    local wndcm = newWndFunc()
    wndcm:RegStart()
end

--TODODO
function gameinit:InitWnds2()
    local wndcount = #wndlist
    local currIndex = 1
    local eachfunc = function(_, wndInfo)
        local cmName = wndInfo.cm
        -- 设置装载进度
        self:InitWnd(cmName)
        -- 初始化窗体
        currIndex = currIndex + 1
    end
    table.foreach(wndlist, eachfunc)
-- 遍历初始化所有窗体
end

--- <summary>
--- 初始化窗体
--- </summary>
function gameinit:InitWnds(initPogressManage, wnds)
    local wndcount = #wnds
    local currIndex = 1
    local eachfunc = function(_, wndInfo)
        local cmName = wndInfo.cm
        -- 设置装载进度
        self:InitWnd(cmName)
        -- 初始化窗体
        currIndex = currIndex + 1
    end
    table.foreach(wnds, eachfunc)
end


-- 注册ui组建
function gameinit:RegUI()
    print("gameinit:RegUI#1")
    local i_name = sdata_uidefine:Name2I("Name")
    local i_dependPacks = sdata_uidefine:Name2I("DependPacks")
    local i_sort = sdata_uidefine:Name2I("Sort")
    local i_cacheTime = sdata_uidefine:Name2I("CacheTime")
    local i_fadeMode = sdata_uidefine:Name2I("FadeMode")
    local i_animationMode = sdata_uidefine:Name2I("AnimationMode")
    
    local eachfunc = function(key, value)
        local name = value[i_name]
        local dependPacks = value[i_dependPacks]
        local sort = value[i_sort]
        local cacheTime = value[i_cacheTime]
        local fadeMode = value[i_fadeMode]
        local animationMode = value[i_animationMode]
        
        WndManage.Single:RegWnd1(name, dependPacks, sort, cacheTime, fadeMode, animationMode)
    -- 注册界面
    end
    sdata_uidefine:Foreach(eachfunc)
end


function gameinit:InitCSharpLogic(initPogressManage)
    WndManage.Single:LogicInit_Go()
    StartCoroutine(ok)
end

function ok()
    local progress = WndManage.Single:LogicInit_GetInitProgress()
    if (progress < 1) then
        WaitForSeconds(1)
        StartCoroutine(ok)
        return
    end
end
function gameinit:FadeTitlesVideo(initPogressManage)
    Yield(0.2)
    initPogressManage:SetMissionPogress(0.2)
    Yield(0.2)
    initPogressManage:SetMissionPogress(0.4)
    Yield(0.2)
    initPogressManage:SetMissionPogress(0.6)
    Yield(0.2)
    initPogressManage:SetMissionPogress(0.8)
    Yield(0.2)
end


local PreloadPackets = nil -- 预装的界面资源包
function gameinit:PreloadLoadPacks(initPogressManage)
    -- 预装资源
    local packetLoader = PacketLoader.new()
    -- 创建一个包加载器
    PreloadPackets = WndManage.GetDependPackets(WND.Main, WND.Login, WND.PlayerCreate)
    
    packetLoader:Start(PreloadPackets)
    
    while (not packetLoader:IsDone()) do
        if (packetLoader:HasError()) then
            debug.LogError("预装资源包遇到错误");
            Application.Quit();
            while (true) do Yield() end
        end
        
        -- 设置装载进度
        local progress = packetLoader:GetProgress()
        initPogressManage:SetMissionPogress(progress)
        Yield()
    end
    
    -- 绑定登陆成功事件
    EventHandles.OnLoginSuccess:AddListener(self, self.OnLoginSuccess)
end

function gameinit:OnLoginSuccess(_)
    -- 卸载未被引用的预装包
    for _, packetName in pairs(PreloadPackets) do
        PacketManage.UnLoadUnusedPack(packetName)
    end
end


function gameinit:LoadSharedGameData(initPogressManage)
    local gamePlatform = GameObject.Find("/GamePlatform")
    
    local sdk = gamePlatform:GetComponent(CMGSCloudSDK.Name)
    local cmSharedGameDataLoad = SharedGameDataLoader.Load(sdk, "yq2", SystemInfo.deviceUniqueIdentifier())
    --
    while (cmSharedGameDataLoad:ResultKeyValues() == nil) do
        Yield()
        if (cmSharedGameDataLoad:ResultIsError()) then
            -- 发生了错误
            -- 弹出对话框
            local resultwait = MsgboxResultWait.new()
            -- 创建一个结果等待器
            MsgBox.Show("从网络获取用户数据遇到错误，是否重试?", "否", "是", resultwait, resultwait.OnMsgBoxClose)
            -- 显示对话框
            local result = resultwait:GetResult()
            -- 读取对话框返回结果
            if (result == 2) then
                -- 用户选择重新尝试
                cmSharedGameDataLoad = SharedGameDataLoader.Load(sdk, "yq2", SystemInfo.deviceUniqueIdentifier())
            else
                Application.Quit()
                -- 退出游戏
                while (true) do Yield() end
            -- 编辑器模式无法执行退出逻辑，因此用这行阻挡后面的逻辑
            end
        end
    end
end

function gameinit:coStartGame(parm)
    -- GameInit = self
    -- 注册ui界面
    self:RegUI()
    self:InitWnds(initPogressManage, lgwnds)
    require "uiscripts/ui_manager"
    ui_manager = fw_facade:instance():add_mgr(mgr_name.UI_MGR, ui_manager())
    ui_manager:show_wnd_base(wnd_healthadvice)
    self:coLoading();
end


-- 后台装资源
function gameinit:coLoading(parm)
    self:InitCSharpLogic(initPogressManage)
    
    FileRequire.RequireSData(initPogressManage)
    
    self:InitWnds(initPogressManage, wndlist)
end

function gameinit:OnPacketDone(isDone)
    self.mPacketLoadDone = true
end

function gameinit:GameStart()
    GameObject.Find("GameManager"):AddComponent(typeof(LuaBehaviour)):Init(self)
    self.mPacketLoadDone = false
    self:coStartGame()
-- 启动一个协程
end


--贯穿整个游戏生命周期
function gameinit:Update()
    if Input.GetKeyDown(UnityEngine.KeyCode.Escape) then
        lgyPrint("EscapeEscapeEscapeEscapeEscape")
    end
end


GameInit = gameinit.new()
GameInit:GameStart()
return gameinit.new
