using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TestEnum
{
    LOL = 0,
    DOTA2
}

public class LuaCallEnum : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('C2L/LuaCallEnum')");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
