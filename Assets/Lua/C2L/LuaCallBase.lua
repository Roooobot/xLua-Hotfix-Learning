-- 调用Father
local father= CS.Father()
print(father.Name)
father:Override()

-- 调用Child
local child=CS.Child()
print(child.Name)
child:Talk()
child:Override()