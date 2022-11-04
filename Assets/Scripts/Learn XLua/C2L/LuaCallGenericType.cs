using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGenericType
{
    public void Output<T>(T data)
    {
        Debug.Log("·ºÐÍ·½·¨"+data.ToString());
    }
    public void Output(float data)
    {
        Output<float>(data);
    }
    public void Output(string data)
    {
        Output<string>(data);
    }
}

public class LuaCallGenericType : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('C2L/LuaCallGenericType')");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
