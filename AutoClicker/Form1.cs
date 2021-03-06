﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class AutoClicker : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int LEFTUP = 0x0004;
        private const int LEFTDOWN = 0x0002;
        public int interval = 1;
        public bool threads = false;

        public int intervals = 5;
        public bool Click = false;
        public int parsedValue;
        public AutoClicker()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread AC = new Thread(AutoClick) { IsBackground = true };
            backgroundWorker1.RunWorkerAsync();
            AC.Start();
        }
        private void AutoClick()
        {
            while (true)
            {
                if (threads == true)
                {
                    mouse_event(dwFlags: LEFTUP, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
                    Thread.Sleep(1);
                    mouse_event(dwFlags: LEFTDOWN, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
                    Thread.Sleep(interval);
                }
                Thread.Sleep(2);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (checkBox1.Checked)
                {
                    Thread.Sleep(00);
                    threads = true;
                    
                }
                else
                {
                Thread.Sleep(1);
                    threads = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(!int.TryParse(textBox1.Text, out parsedValue))
            {
                MessageBox.Show("Please enter an number!!");
                return;
            }
            else 
            {
                intervals = int.Parse(textBox1.Text);
                Console.WriteLine(intervals);
            }
        }
    }
}
