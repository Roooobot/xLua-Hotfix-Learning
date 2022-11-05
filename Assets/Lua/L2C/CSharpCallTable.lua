Core ={}

Core.ID = 100;
Core.Name ="root"
Core.IsWoman = false

Core.Func1 = function(name)
	print("这是Core表的Func1函数，接受到C#的数据"..name)
end

Core.Func2 = function()
	return "这是Core表的Func2函数"
end

Core.Func3 = function(self)
	print("这是Core表的Func3函数，Core表的成员变量Name是"..self.Name)
end

function Core:Func4()
	print("这是Core表的Func4函数，Core表的成员变量Name是"..self.Name)
end