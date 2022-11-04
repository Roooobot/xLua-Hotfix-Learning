using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XLua;             //ʹ��XLua�����ռ�

public class First : MonoBehaviour
{
    void Start()
    {
        MyLoader();
    }
    //ʹ��ϵͳ������
    public void SystemLoader()
    {
        //����Lua������
        LuaEnv luaEnv = new();
        //����������Lua���룬���ַ�������Lua����ִ��
        luaEnv.DoString("print('Hello world')");
        //Lua����C#���루CS.�����ռ�.����.����������������
        luaEnv.DoString("CS.UnityEngine.Debug.Log(\"Good night.\")");
        //C#��ȡLua�ķ���ֵ
        object[] objects = luaEnv.DoString("return 100, true");
        Debug.Log(objects[0] + "+" + objects[1]);
        //����Lua�ű�
        luaEnv.DoString("require ('Test')");
        //�������ͷ�
        luaEnv.Dispose();
    }

    //ʹ���Զ��������
    public void MyLoader()
    {
        LuaEnv luaEnv = new();
        //���Ҷ���ļ��������뵽xLua�Ľ���������
        luaEnv.AddLoader(ProjectLoader);

        luaEnv.DoString("require ('Test')");
        luaEnv.Dispose();

    }
    //�Զ��������
    //�Զ��������������ϵͳ���ü�����ִ�У����Զ�����������ص��ļ��󣬺����ļ������򲻻����ִ��
    //��Lua����ִ��require()����ʱ���Զ���������᳢�Ի���ļ�����
    //������������Lua�ļ���·��
    //�����Ҫ���ص��ļ������ڣ��ǵ÷���null
    public byte[] ProjectLoader(ref string filepath)
    {
        //filepath������Lua��require("�ļ���")
        //����·�������ܽ�require���ص��ļ�ָ��������ŵ�Lua·����ȥ
        //·���������ⶨ�ƣ��ܲ��ܽ�Lua�������AB�������ԣ�
        string path = Application.dataPath;
        path = path + "/Lua/" + filepath + ".lua";
        //��Lua�ļ���ȡΪ�ֽ�����
        //xLua�Ľ�����������ִ�������Զ�����������ص�Lua����
        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else
        {
            return null;
        }
    }
}
