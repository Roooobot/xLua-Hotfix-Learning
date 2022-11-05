using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public delegate void OneStringParams(string name);
public delegate void OneStringReturn();
public delegate void TransSelf(LuaTable table);
public delegate void TransMy(LuaCore table);

//Lua的Table导出到C#的结构体，可以实现C#运行时无GC
[GCOptimize]
public struct LuaCore
{
    public int ID;
    public string Name;
    public bool IsWoman;

    public OneStringParams Func1;
    public OneStringReturn Func2;
    public TransMy Func3;
    public TransMy Func4;
}

public class CSharpCallTable : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("return require('L2C/CSharpCallTable')");

        //UseLuaTable();
    }

    public void UseLuaStruct()
    {
        LuaTable g = XLuaEnv.Instance.Global;
        //将Lua的Table导出为Core
        LuaCore core = g.Get<LuaCore>("Core");

        Debug.Log(core.Name);
        core.Func4(core);
    }

    public void UseLuaTable()
    {
        LuaTable g = XLuaEnv.Instance.Global;
        //获取的是全局变量Core，因为它在Lua中是表，所以取出的是LuaTable
        LuaTable core = g.Get<LuaTable>("Core");
        //获取Name
        //参数：table中索引名
        //类型：索引对应值的类型
        Debug.Log(core.Get<string>("Name"));

        core.Set<string, string>("Name", "admin");

        OneStringParams osp = core.Get<OneStringParams>("Func1");
        osp("admin");
        //相当于  ":"  的调用
        TransSelf ts = core.Get<TransSelf>("Func4");
        ts(core);
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
