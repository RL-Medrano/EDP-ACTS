using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicThreading
{
    public partial class FrmBasicThread : Form
    {
        Thread threadA = new Thread(MyThreadClass.Thread1);
        Thread threadB = new Thread(MyThreadClass.Thread1);
        public FrmBasicThread()
        {
            InitializeComponent();
            threadA.Name = "Thread A Process = ";
            threadB.Name = "Thread B Process = ";
        }

        private void FrmBasicThread_Load(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Console.WriteLine("-Before starting thread-");
            threadA.Start();
            threadB.Start();

            threadA.Join();
            threadB.Join();

            lblThread.Text = "-End of thread-";
            Console.WriteLine("-End of thread-");
        }
    }
}
