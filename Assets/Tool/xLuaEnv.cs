using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XLua;

public class XLuaEnv
{
    //Ŀ���Ƿ�װLuaEnv�������ⲿӰ�죬���е���ģʽ
    #region ����LuaEnv
    private LuaEnv luaEnv;

    private XLuaEnv()
    {
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(ProjectLoader);
    }
    #endregion

    #region Singleton
    private static XLuaEnv instance = null;

    public static XLuaEnv Instance
    {
        get
        {
            if (instance == null) { instance = new XLuaEnv(); }
            return instance;
        }
    }
    #endregion

    #region �Զ��������
    //�Զ��������
    //�Զ��������������ϵͳ���ü�����ִ�У����Զ�����������ص��ļ��󣬺����ļ������򲻻����ִ��
    //��Lua����ִ��require()����ʱ���Զ���������᳢�Ի���ļ�����
    //������������Lua�ļ���·��
    //�����Ҫ���ص��ļ������ڣ��ǵ÷���null
    private byte[] ProjectLoader(ref string filepath)
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
    #endregion

    #region �ͷ�Lua����
    public void Free()
    {
        luaEnv.Dispose();
        instance=null;
    }
    #endregion

    #region Run Lua
    public object[] DoString(string code)
    {
        return luaEnv.DoString(code);
    } 
    #endregion
}
