using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father
{
    public string Name = "Father";
    public void Talk()
    {
        Debug.Log("���Ǹ����еķ���");
    }
    public virtual void Override()
    {
        Debug.Log("���Ǹ����е��鷽��");
    }
}

public class Child : Father
{
    public override void Override()
    {
        Debug.Log("���������е���д����");
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
