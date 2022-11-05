using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public delegate void Func1();
public delegate void Func2(string name);
public delegate string Func3();

[CSharpCallLua]//ӳ�����ʱ��xLua��ʾ�ӵ�
public delegate void Func4(out string name, out int id);
public class CSharpCallFunction : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("return require('L2C/CSharpCallFunction')");

        LuaTable g = XLuaEnv.Instance.Global;

        //Lua�ĺ����ᵼ��ΪC#��ί������
        Func1 func1=g.Get<Func1>("func1");
        func1();
        //��Lua������������
        Func2 func2 = g.Get<Func2>("func2");
        func2("admin");
        //����Lua�����ķ���ֵ
        Func3 func3 = g.Get<Func3>("func3");
        Debug.Log(func3()+"��C#��ӡ");
        //Lua�෵��ֵ
        Func4 func4 = g.Get<Func4>("func4");

        func4(out string name, out int id);
        Debug.Log(name +","+ id);
    }
    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
