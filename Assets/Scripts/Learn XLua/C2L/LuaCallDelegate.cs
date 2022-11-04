using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void DelegateLua();

public class TestDelegate
{
    public static DelegateLua Static;

    public DelegateLua Dynamic;

    public static  void StaticFunc()
    {
        Debug.Log("C#¾²Ì¬³ÉÔ±º¯Êý");
    }
}

public class LuaCallDelegate : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('C2L/LuaCallDelegate')");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
