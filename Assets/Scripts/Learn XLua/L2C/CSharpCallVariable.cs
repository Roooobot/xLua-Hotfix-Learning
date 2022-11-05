using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CSharpCallVariable : MonoBehaviour
{
    void Start()
    {
        XLuaEnv.Instance.DoString("require('L2C/CSharpCallVariable')");

        //LuaEnv�ṩ��һ����Ա����Global������������C#��ȡLua��ȫ�ֱ���
        //Global������������C#ʵ�ֵ�LuaTable��LuaTable��xLuaʵ�ֵ�C#��Lua�б��Ӧ�����ݽṹ
        //xLua�ὫLua��ȫ�ֱ�����Table�ķ�ʽȫ���洢��Global��

        //ͨ�����л���������ȫ�ֱ�����������LuaTable
        //LuaTable��C#�����ݶ������ں�Lua�е�ȫ�ֱ����洢��table��Ӧ
        LuaTable g = XLuaEnv.Instance.Global;

        //��Lua�У���ȫ�ֱ�����ȡ����
        //������Lua��ȫ�ֱ���������
        //���ͣ�Lua��ȫ�ֱ��������ƶ�Ӧ������
        //����ֵ��������ֵ
        int num = g.Get<int>("num");
        float rate = g.Get<float>("rate");
        bool isWoman = g.Get<bool>("isWoman");
        string name = g.Get<string>("name");

        Debug.Log(num);
        Debug.Log(rate);
        Debug.Log(isWoman);
        Debug.Log(name);
    }

    private void OnDestroy()
    {
        XLuaEnv.Instance.Free();
    }
}
