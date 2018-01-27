using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetDimension.NanUI;
using FirstNanUIApplication;

namespace BasicUsageDemoApp
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            Bootstrap.BeforeCefInitialize = (CefInitArgs) => {
                //禁用日志
                CefInitArgs.Settings.LogSeverity = Chromium.CfxLogSeverity.Disable;

                //指定中文为当前CEF环境的默认语言
                CefInitArgs.Settings.AcceptLanguageList = "zh-CN";
                CefInitArgs.Settings.Locale = "zh-CN";
            };

            Bootstrap.BeforeCefCommandLineProcessing = (CefCmdArgs) =>
            {
                //在启动参数中添加disable-web-security开关，禁用跨域安全检测
                CefCmdArgs.CommandLine.AppendSwitch("disable-web-security");
            };

            //指定CEF架构和文件目录结构，并初始化CEF
            if (Bootstrap.Load(PlatformArch.Auto, 
                System.IO.Path.Combine(Application.StartupPath, "fx"), 
                System.IO.Path.Combine(Application.StartupPath, "fx\\Resources"), 
                System.IO.Path.Combine(Application.StartupPath, "fx\\Resources\\locales")))
            {
                //注册嵌入资源，并为指定资源指定一个假的域名my.resource.local
                //Register html/css/javascript/image resources in current executing assembly. 
                //If you want to embed any kind of resource in your app, just add it to your project and set the Build Action to Embedded Resource.
                Bootstrap.RegisterAssemblyResources(System.Reflection.Assembly.GetExecutingAssembly(), "my.resource.local");

                //加载分离式的资源
                //Also, you can load embedded resources from other assemblies.
                var anotherAssembly = System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(Application.StartupPath, "EmbeddedResourcesInSplitAssembly.dll"));
                //注册外部的嵌入资源，并为指定资源指定一个假的域名separate.resource.local
                Bootstrap.RegisterAssemblyResources(anotherAssembly, "separate.resource.local");

                Application.Run(new Form2());//Html5testForm
            }

        }
	}
}
