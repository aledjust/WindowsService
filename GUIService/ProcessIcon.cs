using System;
using System.Diagnostics;
using System.Windows.Forms;
using GUIService.Properties;
using System.Reflection;

namespace GUIService
{
  
    class ProcessIcon : IDisposable
    {
        
        NotifyIcon ni;

        public ProcessIcon()
        {
            // Instantiate the NotifyIcon object.
            ni = new NotifyIcon();
        }

        public void Display()
        {
            // Put the icon in the system tray and allow it react to mouse clicks.			
            ni.MouseClick += new MouseEventHandler(ni_MouseClick);
            ni.Icon = Resources.computer;
            ni.Text = "AMTS Application Services";
            ni.Visible = true;
            ni.ShowBalloonTip(100, "AMTS v5", "AMTS Running..", ToolTipIcon.Info);

            // Attach a context menu.
            ni.ContextMenuStrip = new TaskTrayApplication().Create();
        }

        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            ni.Dispose();
        }

        void ni_MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                // Start Windows Explorer.
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(ni, null);
            }
        }
    }
}