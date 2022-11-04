-- C# TestEnum.LOL
-- CS.命名空间.枚举名.枚举值
-- 枚举获得的是userdata自定义数据类型，获得卡语言数据类型时，就是userdata
print(CS.TestEnum.LOL)
print(CS.TestEnum.DOTA2)

-- 转换获得枚举值
print(CS.TestEnum.__CastFrom(0))
print(CS.TestEnum.__CastFrom("DOTA2"))
