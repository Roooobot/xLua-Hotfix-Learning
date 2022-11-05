using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CSharpCallVariable : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('L2C/CSharpCallVariable')");

        //LuaEnv提供了一个成员变量Global，它可以用于C#获取Lua的全局变量
        //Global的数据类型是C#实现的LuaTable，LuaTable是xLua实现的C#和Lua中表对应的数据结构
        //xLua会将Lua的全局变量以Table的方式全部存储在Global中

        //通过运行环境，导出全局变量，类型是LuaTable
        //LuaTable是C#的数据对象，用于和Lua中的全局变量存储的table对应
        LuaTable g = XLuaEnv.Instance.Global;

        //从Lua中，将全局变量提取出来
        //参数：Lua中全局变量的名称
        //类型：Lua中全局变量的名称对应的类型
        //返回值：变量的值
        int num = g.Get<int>("num");
        float rate = g.Get<float>("rate");
        bool isWoman = g.Get<bool>("isWoman");
        string name = g.Get<string>("name");

        Debug.Log(num);
        Debug.Log(rate);
        Debug.Log(isWoman);
        Debug.Log(name);
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
