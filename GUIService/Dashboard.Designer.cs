namespace GUIService
{
    partial class Dashboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnSvcStart = new System.Windows.Forms.Button();
            this.btnSvcStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(58, 57);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(100, 20);
            this.txtStatus.TabIndex = 0;
            // 
            // btnSvcStart
            // 
            this.btnSvcStart.Location = new System.Drawing.Point(185, 55);
            this.btnSvcStart.Name = "btnSvcStart";
            this.btnSvcStart.Size = new System.Drawing.Size(75, 23);
            this.btnSvcStart.TabIndex = 1;
            this.btnSvcStart.Text = "Start";
            this.btnSvcStart.UseVisualStyleBackColor = true;
            this.btnSvcStart.Click += new System.EventHandler(this.btnSvcStart_Click);
            // 
            // btnSvcStop
            // 
            this.btnSvcStop.Location = new System.Drawing.Point(275, 55);
            this.btnSvcStop.Name = "btnSvcStop";
            this.btnSvcStop.Size = new System.Drawing.Size(75, 23);
            this.btnSvcStop.TabIndex = 2;
            this.btnSvcStop.Text = "Stop";
            this.btnSvcStop.UseVisualStyleBackColor = true;
            this.btnSvcStop.Click += new System.EventHandler(this.btnSvcStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "AMTS v5 Dashboard Service";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 260);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSvcStop);
            this.Controls.Add(this.btnSvcStart);
            this.Controls.Add(this.txtStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dashboard";
            this.Text = "AMTS v5 Service";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnSvcStart;
        private System.Windows.Forms.Button btnSvcStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

