using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WD
{
    public static class TestStatic
    {
        public static int ID = 99;
        public static string Name
        {
            get;
            set;
        }
        public static string Output()
        {
            return "static";
        }
        public static void Default(string str = "abc")
        {
            Debug.Log(str);
        }
    }
}

public class LuaCallStatic : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('C2L/LuaCallStatic')");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
