using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public delegate void Func1();
public delegate void Func2(string name);
public delegate string Func3();

[CSharpCallLua]//映射产生时，xLua提示加的
public delegate void Func4(out string name, out int id);
public class CSharpCallFunction : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("return require('L2C/CSharpCallFunction')");

        LuaTable g = XLuaEnv.Instance.Global;

        //Lua的函数会导出为C#的委托类型
        Func1 func1=g.Get<Func1>("func1");
        func1();
        //向Lua函数传递数据
        Func2 func2 = g.Get<Func2>("func2");
        func2("admin");
        //接受Lua函数的返回值
        Func3 func3 = g.Get<Func3>("func3");
        Debug.Log(func3()+"被C#打印");
        //Lua多返回值
        Func4 func4 = g.Get<Func4>("func4");

        func4(out string name, out int id);
        Debug.Log(name +","+ id);
    }
    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
