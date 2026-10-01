using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace BasicThreadTP
{
    public partial class frmTrackThread : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        MyThreadClass threadStart;
        public frmTrackThread()
        {
            InitializeComponent();
            threadStart = new MyThreadClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllocConsole();
            Console.WriteLine("-Thread Starts-");

            Thread threadA = new Thread(new ThreadStart(MyThreadClass.Thread1));
            Thread threadB = new Thread(new ThreadStart(MyThreadClass.Thread1));
            Thread threadC = new Thread(new ThreadStart(MyThreadClass.Thread2));
            Thread threadD = new Thread(new ThreadStart(MyThreadClass.Thread2));

            threadA.Name = "Thread A";
            threadB.Name = "Thread B";
            threadC.Name = "Thread C";
            threadD.Name = "Thread D";

            threadA.Priority = ThreadPriority.Highest;
            threadB.Priority = ThreadPriority.Normal;
            threadC.Priority = ThreadPriority.AboveNormal;
            threadD.Priority = ThreadPriority.BelowNormal;

            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            Console.WriteLine("-End of Thread-");
            label1.Text = "-End of Thread-";
        }
    }
}
