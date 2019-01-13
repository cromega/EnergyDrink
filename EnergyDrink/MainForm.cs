using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EnergyDrink
{
    public partial class MainForm : Form
    {
        private enum ThreadState : uint {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001,
            ES_USER_PRESENT = 0x00000004
        }


        [DllImport("Kernel32.dll", EntryPoint = "SetThreadExecutionState", CallingConvention = CallingConvention.Winapi)]
        private static extern ThreadState SetThreadExecutionState(ThreadState state);

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var requiredFlags = ThreadState.ES_DISPLAY_REQUIRED | ThreadState.ES_CONTINUOUS;
            ThreadState NewState = SetThreadExecutionState(requiredFlags);


            if (NewState == ThreadState.ES_CONTINUOUS)
            {
                toolStripStatusLabel2.Text = "Energydrink drunk";
            }
            else
            {
                toolStripStatusLabel2.Text = "error";
            }
        }
    }
}
