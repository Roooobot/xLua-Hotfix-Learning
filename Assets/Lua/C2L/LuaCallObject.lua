-- Lua实例化类
-- C# Npc obj = new.Npc()
-- 通过构造函数创建对象
local obj =CS.Npc()
obj.Hp = 100
print(obj.Hp)

local obj1 =CS.Npc("admin")
print(obj1.Name)

-- 表方法希望调用表成员变量（表：函数（））
-- 为什么是冒号，对象引用成员变量时，会隐性调用this,等同于Lua中的self
print(obj1:Output())

-- Lua实例化GameObject
-- C# GameObject obj = new GameObject("")
local go = CS.UnityEngine.GameObject("LuaCreatGo")
go:AddComponent(typeof(CS.UnityEngine.BoxCollider))
