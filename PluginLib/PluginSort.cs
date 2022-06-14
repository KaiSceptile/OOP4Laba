using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1;


namespace PluginLib
{
    public class PluginSort : IPlugin
    {
        /*public string Name
        {
            get
            {
                return "PluginSort";
            }
        }*/


        public void SortList(object sender, EventArgs e)
        {
            //Form1 form = (Form1)Form1.ActiveForm;
            Form1.Instance.listPrintedEdtions.Sort((a, b)=>a.Name.CompareTo(b.Name));
            //DataGridView dgv = form.dgvBooks;
            
            Form1.ShowList(Form1.Instance.listPrintedEdtions);

        }
        public void Run()
        {
            Form1 form = (Form1)Form1.ActiveForm;
            
            Button SortButton = new Button();
            SortButton.Text = "Сортировать";
            SortButton.Top = 397;
            SortButton.Left = 450;
            SortButton.Width = 120;
            SortButton.Height = 30;
            SortButton.Click += SortList;

            //form.Controls.Add(SortButton);
            //form.Invoke(new Action(() => form.Controls.Add(SortButton)));
            Form1.Instance.Controls.Add(SortButton);

        }

    }
}
