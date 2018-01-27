using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetDimension.NanUI;

namespace BorderlessFormStyleDemoApp
{
	public partial class WebBrowserControlForm : Form
	{
		public WebBrowserControlForm()
		{
			InitializeComponent();
			nanUIWebBrower1.LoadUrl("http://www.baidu.com");
		}
	}
}
