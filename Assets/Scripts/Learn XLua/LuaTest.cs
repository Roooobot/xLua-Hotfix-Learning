using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaTest : MonoBehaviour
{

    void Start()
    {
        XLuaEnv.Instance.DoString("require('Test')");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }

}
