using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkEXC
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer injchecktimer;
        public Form1()
        {
            InitializeComponent();
            injchecktimer = new System.Timers.Timer(1000);
            injchecktimer.Elapsed += ChekInjectStat;
            injchecktimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaladAPI.MainFunctions.Inject();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaladAPI.MainFunctions.Execute(richTextBox1.Text);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SaladAPI.MainFunctions.AutoInject(checkBox1.Checked);
        }
        private void ChekInjectStat(object sender, EventArgs e)
        {
            if (SaladAPI.MainFunctions.CheckInjected())
            {
                label1.Invoke((MethodInvoker)(() => label1.Text = "injected: True"));
                var cn = SaladAPI.MainFunctions.GetClientName();
                label2.Invoke((MethodInvoker)(() => label2.Text = "Client: " + cn));
            }
            else
            {
                label1.Invoke((MethodInvoker)(() => label1.Text = "injected: True"));
                label1.Invoke((MethodInvoker)(() => label1.Text = "Client: "));
            }
        }
    }
}
