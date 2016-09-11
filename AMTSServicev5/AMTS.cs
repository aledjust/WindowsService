using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace AMTSServicev5
{
    partial class AMTS : ServiceBase
    {

        System.Threading.Thread threadAMTS;

        public AMTS()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            threadAMTS = new System.Threading.Thread(new System.Threading.ThreadStart(test123));
            threadAMTS.IsBackground = true;

            String applicationName = @"D:\GUIService.exe";

            //// launch the application
            ApplicationLoader.PROCESS_INFORMATION procInfo;
            ApplicationLoader.StartProcessAndBypassUAC(applicationName, out procInfo);
            
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        private void test123()
        { }

    }
}
