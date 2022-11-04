using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father
{
    public string Name = "Father";
    public void Talk()
    {
        Debug.Log("这是父类中的方法");
    }
    public virtual void Override()
    {
        Debug.Log("这是父类中的虚方法");
    }
}

public class Child : Father
{
    public override void Override()
    {
        Debug.Log("这是子类中的重写方法");
    }
}

public class LuaCallBase : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('C2L/LuaCallBase')");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
