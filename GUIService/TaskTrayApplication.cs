using System;
using System.Diagnostics;
using System.Windows.Forms;
using GUIService.Properties;
using System.Drawing;

namespace GUIService
{
    class TaskTrayApplication
    {
        bool isAboutLoaded = false;

        public ContextMenuStrip Create()
        {
            // Add the default menu options.
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;
            ToolStripSeparator sep;

            // Services Panel.
            item = new ToolStripMenuItem();
            item.Text = "Services";
            item.Click += new EventHandler(Services_Click);
            item.Image = Resources.launcher_icon;
            menu.Items.Add(item);

            // About.
            item = new ToolStripMenuItem();
            item.Text = "About";
            item.Click += new EventHandler(About_Click);
            menu.Items.Add(item);

            // Separator.
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            // Exit.
            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new System.EventHandler(Exit_Click);
            item.Image = Resources.Exit;
            menu.Items.Add(item);

            return menu;
        }

        void Services_Click(object sender, EventArgs e)
        {
            //Process.Start("explorer", null);
            if (!isAboutLoaded)
            {
                isAboutLoaded = true;
                new Dashboard().ShowDialog();
                isAboutLoaded = false;
            }
        }

        void About_Click(object sender, EventArgs e)
        {
            if (!isAboutLoaded)
            {
                isAboutLoaded = true;
               // new AboutBox().ShowDialog();
                isAboutLoaded = false;
            }
        }

        void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
