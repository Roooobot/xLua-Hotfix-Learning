--Lua调用静态类

--规则"CS.命名空间.类名.成员变量"
print(CS.WD.TestStatic.ID)

--给静态属性赋值
CS.WD.TestStatic.Name = "admin"
print(CS.WD.TestStatic.Name)

--静态成员方法调用
--规则"CS.命名空间.类名.方法名()"
print(CS.WD.TestStatic.Output())

--使用默认值
CS.WD.TestStatic.Default()
--使用Lua传递的值
CS.WD.TestStatic.Default("def")