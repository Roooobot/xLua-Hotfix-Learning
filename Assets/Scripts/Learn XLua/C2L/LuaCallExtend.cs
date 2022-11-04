using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class TestExtend
{
    public void Output()
    {
        Debug.Log("�౾����ķ���");
    }
}
//����չ����Ҫ����չ������д�ľ�̬�����[LuaCallCSharp]������Lua�޷����õ�
[LuaCallCSharp]
public static class MyExtend
{
    public static void Show(this TestExtend obj)
    {
        Debug.Log("����չʵ�ֵķ���");
    }
}

public class LuaCallExtend : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('C2L/LuaCallExtend')");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
