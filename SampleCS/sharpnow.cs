


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharpnow;
using System.Runtime.InteropServices;
using System.Threading;
using SampleCS;
using System.Windows.Forms;

namespace SampleDLL
{
    unsafe class Program
    {
        static void Main(string[] args)
        {
            //主程序中启动form窗体程序
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());   
           
        }

    }

}
