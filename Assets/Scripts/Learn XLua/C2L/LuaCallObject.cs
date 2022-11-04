using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public Npc() { }
    public Npc(string name)
    {
        Name = name;
    }
    public string Output()
    {
        return Name;
    }
}

public class LuaCallObject : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('C2L/LuaCallObject')");
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
