namespace AMTSServicev5
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AMTSServiceProcess = new System.ServiceProcess.ServiceProcessInstaller();
            this.AMTSInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // AMTSServiceProcess
            // 
            this.AMTSServiceProcess.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.AMTSServiceProcess.Password = null;
            this.AMTSServiceProcess.Username = null;
            // 
            // AMTSInstaller
            // 
            this.AMTSInstaller.ServiceName = "AMTS Services";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.AMTSServiceProcess,
            this.AMTSInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller AMTSServiceProcess;
        private System.ServiceProcess.ServiceInstaller AMTSInstaller;
    }
}