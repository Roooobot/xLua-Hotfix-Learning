-- C#添加事件 TestEvent.Static += TestEvent.StaticFunc

--Lua添加事件
CS.TestEvent.Static("+",CS.TestEvent.StaticFunc)
CS.TestEvent.CallStatic()
CS.TestEvent.Static("-",CS.TestEvent.StaticFunc)

--添加动态成员变量
local  func = function ( )
	print("来自于Lua的回调函数")
end

local obj = CS.TestEvent()
obj:Dynamic("+",func)
obj:CallDynamic()
obj:Dynamic("-",func)
