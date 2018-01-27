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
                // Load embedded html/css resources in assembly.
                Bootstrap.RegisterAssemblyResources(System.Reflection.Assembly.GetExecutingAssembly());
                Application.Run(new Form2());//Html5testForm
            }

        }
	}
}
