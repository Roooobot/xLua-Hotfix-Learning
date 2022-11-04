using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TestStruct
{
    public string Name;
    public string Output()
    {
        return Name;
    }
}


public class LuaCallStruct : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('C2L/LuaCallStruct')");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
