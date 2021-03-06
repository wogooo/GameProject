﻿--region *.lua
--Date 20150805
--一些事件句柄
--作者 wenchuan

EventHandles = {}

EventHandles.OnServerListChanged = Event.new() --服务器列表变更
EventHandles.OnServerSTChanged = Event.new() --服务器状态变更
EventHandles.OnLoginSuccess = Event.new() --登陆游戏成功
EventHandles.OnWndExit = Event.new() --窗体退出
EventHandles.OnQKNodeLinkBreak = Event.new() --QKNode连线中断
EventHandles.OnTopWndChanged = Event.new() --当顶层窗体发生改变
EventHandles.OnDisconnected = Event.new() --当与QKNode断开连接时
EventHandles.OnOrnamentClick = Event.new() --场景装饰物被点击

EventHandles.OnHeroCardClick = Event.new() --英雄卡片被点击
EventHandles.OnHeroCardDragStart = Event.new() --英雄卡片被拖动开始
EventHandles.OnHeroCardDrag = Event.new() --英雄卡片被拖动

EventHandles.OnHeroCardPress = Event.new() --英雄卡片被按压
--EventHandles.OnHeroCardLongPress = Event.new() --英雄卡片被长按

--endregion
 