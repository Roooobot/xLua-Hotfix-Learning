using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void EventLua();

public class TestEvent
{
    public static event EventLua Static;

    public static void StaticFunc()
    {
        Debug.Log("ÕâÊÇ¾²Ì¬º¯Êý");
    }
    public static void CallStatic()
    {
        if(Static != null)
        {
            Static();
        }
    }
    public event EventLua Dynamic;
    public void CallDynamic()
    {
        if (Dynamic != null)
        {
            Dynamic();
        }
    }
}

public class LuaCallEvent : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('C2L/LuaCallEvent')");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
