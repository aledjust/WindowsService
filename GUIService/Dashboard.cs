using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;

namespace GUIService
{
    public partial class Dashboard : Form
    {
        ServiceController sc = new ServiceController("AMTS Services");
        bool alive = true;
        System.Threading.Thread threadSvcStatus;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            txtStatus.Enabled = false;
            threadSvcStatus = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadSvcStatus));
            threadSvcStatus.IsBackground = true;
           // threadSvcStatus.Start();
           txtStatus.Text = CheckSvcStatus(sc);
        }

       

        private String CheckSvcStatus(ServiceController sc)
        {
            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    return "Running";
                case ServiceControllerStatus.Stopped:
                    return "Stopped";
                case ServiceControllerStatus.Paused:
                    return "Paused";
                case ServiceControllerStatus.StopPending:
                    return "Stopping";
                case ServiceControllerStatus.StartPending:
                    return "Starting";
                case ServiceControllerStatus.ContinuePending:
                    return "Resuming";
                default:
                    return "Status Changing";
            }
        }

        private void ThreadSvcStatus() {
            while (alive) {
                txtStatus.Text = CheckSvcStatus(sc);
                System.Threading.Thread.Sleep(5000);
            }
        }

        private void btnSvcStart_Click(object sender, EventArgs e)
        {
           
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                txtStatus.Text = "Attempting to Start!";
                sc.Start();

                while (sc.Status != ServiceControllerStatus.Running)
                {
                    sc.Refresh();
                }

                txtStatus.Text = sc.Status.ToString();
            }
        }

        private void btnSvcStop_Click(object sender, EventArgs e)
        {
            if (sc.Status == ServiceControllerStatus.Running)
            {
                txtStatus.Text = "Attempting to Stop!";
                sc.Stop();

                while (sc.Status != ServiceControllerStatus.Stopped)
                {
                    sc.Refresh();
                }

                txtStatus.Text = sc.Status.ToString();
            }
        }

    }
}
