using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOutRef
{
    public static string Func1()
    {
        return "Func1";
    }
    public static string Func2(string str1,out string str2)
    {
        str2 = "Func2 out";
        return "Func2";
    }
    public static string Func3(string str1, ref string str2)
    {
        str2 = "Func3 Ref";
        return "Func3";
    }
    public static string Func4(ref string str1,  string str2)
    {
        str1 = "Func4 Ref";
        return "Func4";
    }
}

public class LuaCallOutRef : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('C2L/LuaCallOutRef')");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
