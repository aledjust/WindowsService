using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using System.Configuration;
using EmailComponent;

namespace AMTSServicev5
{
    partial class BirthdaySender : ServiceBase
    {
        private Timer scheduleTimer = null;
        private DateTime lastRun;
        private bool flag;

        public BirthdaySender()
        {
            InitializeComponent();

            this.AutoLog = false;
            if (!System.Diagnostics.EventLog.SourceExists("Email Source"))
            {
                System.Diagnostics.EventLog.CreateEventSource("Email Source", "Email Log");
            }

            eventLogEmail.Source = "AMTS Servicesv5";
            eventLogEmail.Log = "AMTS Log";

            scheduleTimer = new Timer();
            scheduleTimer.Interval = 500;
            scheduleTimer.Elapsed += new ElapsedEventHandler(scheduleTimer_Elapsed);

        }

        protected override void OnStart(string[] args)
        {
            flag = true;
            lastRun = DateTime.Now;
            scheduleTimer.Start();
            eventLogEmail.WriteEntry("Started");

            //String applicationName = @"D:\testnotif.exe";

            //// launch the application
            //ApplicationLoader.PROCESS_INFORMATION procInfo;
            //ApplicationLoader.StartProcessAndBypassUAC(applicationName, out procInfo);
        }

        public void scheduleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (flag == true)
            {
                ServiceEmailMethod();
                lastRun = DateTime.Now;
                flag = false;
            }
            else if (flag == false)
            {
                if (lastRun.Date < DateTime.Now.Date)
                {
                    ServiceEmailMethod();
                }
            }
        }

        public void ServiceEmailMethod()
        {
            eventLogEmail.WriteEntry("Sending Email");

            EmailComponent.GetEmailFromDb getEmails = new EmailComponent.GetEmailFromDb();
            getEmails.connectionString = ConfigurationManager.ConnectionStrings["AMTSConnectionStrings"].ConnectionString;
            getEmails.storedProcName = "GetBirthdayBuddiesEmails";
            System.Data.DataSet ds = getEmails.GetMailIds();

            EmailComponent.Email email = new EmailComponent.Email();

            email.fromEmail = "your email";
            email.fromName = "ALED";
            email.subject = "Happy Birthday";
            email.smtpServer = "smtp.gmail.com";
            email.smtpPort = 587;
            email.smptCredentials = new System.Net.NetworkCredential("youe email", "your password");

            foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            {
                email.messageBody = "<h4>Hello " + dr["CustomerName"].ToString() + "</h4><br/><h3>We Wish you a very Happy " + "Birthday to You!!! </h3><br/><h4>Thank you.</h4>" +
                    "<br/><br/><br/><br/><br/> " +
                   " <font color=red>PT. AUTOJAYA IDETECH   </font><font color=blue>PT. SOLUSI PERIFERAL</font><br/>" +
                   " Perkantoran Gunung Sahari Permai #C03 – 05<br/> " +
                   " Jl. Gunung Sahari Raya No. 60 – 63<br/> " +
                  "  Jakarta 10610<br/>" +
                   " Office : +62 21 420 8221 / +62 21 4205187<br/>" +
                   " Mobile: +62 813 184 39001<br/>" +
                   " E-mail : aled@acsgroup.co.id<br/>" +
                   " Web    : http://www.autojaya.com / http://www.solper.com";
                bool result = email.SendEmailAsync(dr["CustomerEmail"].ToString(), dr["CustomerName"].ToString());

                if (result == true)
                {
                    eventLogEmail.WriteEntry("Message Sent SUCCESS to - " + dr["CustomerEmail"].ToString() + " - " + dr["CustomerName"].ToString());
                }
                else
                {
                    eventLogEmail.WriteEntry("Message Sent FAILED to - " + dr["CustomerEmail"].ToString() + " - " + dr["CustomerName"].ToString());
                }
            }
        }

        protected override void OnStop()
        {
            scheduleTimer.Stop();
            eventLogEmail.WriteEntry("Stopped");
        }
        protected override void OnPause()
        {
            scheduleTimer.Stop(); eventLogEmail.WriteEntry("Paused");
        }
        protected override void OnContinue()
        {
            scheduleTimer.Start();
            eventLogEmail.WriteEntry("Continued");
        }
        protected override void OnShutdown()
        {
            scheduleTimer.Stop();
            eventLogEmail.WriteEntry("ShutDown");
        }
    }
}
