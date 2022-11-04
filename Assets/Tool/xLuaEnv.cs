using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XLua;

public class XLuaEnv
{
    //目的是封装LuaEnv，避免外部影响，还有单例模式
    #region 创建LuaEnv
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

    #region 自定义加载器
    //自定义加载器
    //自定义加载器会先于系统内置加载器执行，当自定义加载器加载到文件后，后续的加载器则不会继续执行
    //当Lua代码执行require()函数时，自定义加载器会尝试获得文件内容
    //参数：被加载Lua文件的路径
    //如果需要加载的文件不存在，记得返回null
    private byte[] ProjectLoader(ref string filepath)
    {
        //filepath来自于Lua的require("文件名")
        //构造路径，才能将require加载的文件指向我们想放的Lua路径下去
        //路径可以任意定制（能不能将Lua代码放入AB包？可以）
        string path = Application.dataPath;
        path = path + "/Lua/" + filepath + ".lua";
        //将Lua文件读取为字节数组
        //xLua的解析环境，会执行我们自定义加载器返回的Lua代码
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

    #region 释放Lua环境
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
