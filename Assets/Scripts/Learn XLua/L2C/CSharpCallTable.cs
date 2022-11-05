using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public delegate void OneStringParams(string name);
public delegate void OneStringReturn();
public delegate void TransSelf(LuaTable table);
public delegate void TransMy(LuaCore table);

//Lua��Table������C#�Ľṹ�壬����ʵ��C#����ʱ��GC
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
        //��Lua��Table����ΪCore
        LuaCore core = g.Get<LuaCore>("Core");

        Debug.Log(core.Name);
        core.Func4(core);
    }

    public void UseLuaTable()
    {
        LuaTable g = XLuaEnv.Instance.Global;
        //��ȡ����ȫ�ֱ���Core����Ϊ����Lua���Ǳ�����ȡ������LuaTable
        LuaTable core = g.Get<LuaTable>("Core");
        //��ȡName
        //������table��������
        //���ͣ�������Ӧֵ������
        Debug.Log(core.Get<string>("Name"));

        core.Set<string, string>("Name", "admin");

        OneStringParams osp = core.Get<OneStringParams>("Func1");
        osp("admin");
        //�൱��  ":"  �ĵ���
        TransSelf ts = core.Get<TransSelf>("Func4");
        ts(core);
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
