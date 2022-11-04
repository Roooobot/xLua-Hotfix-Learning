using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOverload
{
    public static void Test(int id)
    {
        Debug.Log("数字类型"+id);
    }
    public static void Test(string name)
    {
        Debug.Log("字符串类型" + name);
    }
    public static void Test(int id, string name)
    {
        Debug.Log("两个数值"+ id +"+" + name);
    }
}

public class LuaCallOverload : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('C2L/LuaCallOverload')");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
