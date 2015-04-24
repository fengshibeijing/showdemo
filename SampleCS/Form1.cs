using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


using Sharpnow;
using System.Runtime.InteropServices;
using System.Threading;

namespace SampleCS
{
    //public Device mm=Device.getmain();
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //下行代码使程序中处理form外其他线程可以控制form中的空间做出改变
            Control.CheckForIllegalCrossThreadCalls = false;
            //实例化并开启已经定义好的线程
            Thread mythread;
            mythread = new Thread(new ThreadStart(createThread));
            mythread.Start();
        }
		//定义监听手势信息的线程
        public void createThread()
        {
            this.label1.Text = "jahcjahd";
            while (true)
            {
                SDK.RetrieveFrame(0);
                IntPtr getFrameInfoPtr = SDK.GetFrameInfo();
                IntPtr getFingerPtr = SDK.GetFinger(0);
                IntPtr getFingerFocusPtr = SDK.GetFingerFocus();
                IntPtr getHandPtr = SDK.GetHand(0);
                IntPtr getHandFocusPtr = SDK.GetHandFocus();
                
                Frame frame = (Frame)Marshal.PtrToStructure(getFrameInfoPtr, typeof(Frame));
             
                
              //  Hand handFocused = (Hand)Marshal.PtrToStructure(getHandPtr, typeof(Hand));
                if (frame.updated != 0)
                {

                    if (!getFingerFocusPtr.Equals(IntPtr.Zero))
                    {
                        Finger fingerFocused = (Finger)Marshal.PtrToStructure(getFingerFocusPtr, typeof(Finger));
						//demo使用tap与poke两个动态手势完成图片的显示与消失，可以更换为其他手势
                        if (fingerFocused.tap == 1)
                        {
                            this.pictureBox1.Visible = true;
                            this.label1.Text = "敲击";
                        }
                        if (fingerFocused.poke == 1)
                        {
                            this.pictureBox1.Visible = false;
                        }
                    }
                  
                    // Get Frame
                    // Console.WriteLine("Frame Has been Updated");
                    //Console.WriteLine(frame.mode.ToString());
                    //Console.WriteLine(frame.blindfold);
                    // Console.WriteLine(frame.finger_number);
                    //Console.WriteLine(frame.nick_name.ToString());
              
                    if (frame.blindfold == 2)
                    {
                        this.label1.Text = "aaaaaaaaa";
                        //Application.Run(new Form1());
                        // break;
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
