﻿using System;
using System.Windows.Forms;
using NetDimension.NanUI;
using System.IO;
namespace BorderlessFormStyleDemoApp
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
            Bootstrap.BeforeCefInitialize = (args) => {
                //Settings for before CEF initiliazing...
                args.Settings.AcceptLanguageList = "zh-CN; en-US";
                args.Settings.LogSeverity = Chromium.CfxLogSeverity.Disable;

            };

            Bootstrap.BeforeCefCommandLineProcessing = (args) => {
                //Settings for CEF commnad line.
                args.CommandLine.AppendSwitch("disable-web-security");
            };

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
			if (Bootstrap.Load(PlatformArch.Auto, Path.Combine(Application.StartupPath, "fx"), 
                System.IO.Path.Combine(Application.StartupPath, "fx\\Resources"), 
                System.IO.Path.Combine(Application.StartupPath, "fx\\Resources\\locales")))
			{
				//Register html/css/javascript/image resources in current executing assembly. 
				//If you want to embed any kind of resource in your app, just add it to your project and set the Build Action to Embedded Resource.
				//System.Reflection.Assembly.GetExecutingAssembly();
				Bootstrap.RegisterAssemblyResources(System.Reflection.Assembly.GetExecutingAssembly());
				Application.Run(new WebBrowserControlForm());
			}

		}
	}
}
