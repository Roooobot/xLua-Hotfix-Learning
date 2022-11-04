using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XLua;             //使用XLua命名空间

public class First : MonoBehaviour
{
    void Start()
    {
        MyLoader();
    }
    //使用系统加载器
    public void SystemLoader()
    {
        //生成Lua解释器
        LuaEnv luaEnv = new();
        //解释器运行Lua代码，把字符串当成Lua代码执行
        luaEnv.DoString("print('Hello world')");
        //Lua调用C#代码（CS.命名空间.类名.方法名（参数））
        luaEnv.DoString("CS.UnityEngine.Debug.Log(\"Good night.\")");
        //C#获取Lua的返回值
        object[] objects = luaEnv.DoString("return 100, true");
        Debug.Log(objects[0] + "+" + objects[1]);
        //加载Lua脚本
        luaEnv.DoString("require ('Test')");
        //解释器释放
        luaEnv.Dispose();
    }

    //使用自定义加载器
    public void MyLoader()
    {
        LuaEnv luaEnv = new();
        //将我定义的加载器加入到xLua的解析环境中
        luaEnv.AddLoader(ProjectLoader);

        luaEnv.DoString("require ('Test')");
        luaEnv.Dispose();

    }
    //自定义加载器
    //自定义加载器会先于系统内置加载器执行，当自定义加载器加载到文件后，后续的加载器则不会继续执行
    //当Lua代码执行require()函数时，自定义加载器会尝试获得文件内容
    //参数：被加载Lua文件的路径
    //如果需要加载的文件不存在，记得返回null
    public byte[] ProjectLoader(ref string filepath)
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
}
