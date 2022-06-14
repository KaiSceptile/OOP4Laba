using System;
using WinFormsApp1;
using System.Windows.Forms;
using System.Drawing;
namespace PluginDarkTheme
{
    public class DarkTheme: IPlugin
    {
        Color color;
        public void ChangeTheme(object sender, EventArgs e)
        {
            if (Form1.Instance.BackColor == Color.DarkGray)
            {
                Form1.Instance.BackColor = color;
                foreach (Control control in Form1.Instance.Controls)
                {
                    control.BackColor = color;
                }
            }
            else
            {
                color = Form1.Instance.BackColor;
                Form1.Instance.BackColor = Color.DarkGray;
                foreach(Control control in Form1.Instance.Controls)
                {
                    control.BackColor = Color.DarkGray;
                }
            }
        }
        public void Run()
        {
            Button btnTheme = new Button();
            btnTheme.Top = 457;
            btnTheme.Left = 600;
            btnTheme.Height = 30;
            btnTheme.Text = "Тема";
            btnTheme.Click += ChangeTheme;
           // btnTheme.BackColor = Form1.Instance.BackColor;
            Form1.Instance.Controls.Add(btnTheme);
        }
    }
}
