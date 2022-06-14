using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class PrintedEdition
    {
        public string Name;
        public int Kopeck;
        public int Ruble;
        public int NumberOfPages;
        public string type;

        public virtual void ShowInList(DataGridView dgv)
        {
           
        }
        public virtual void ShowForEditEdition(frmAdd frmAdd)
        {

        }
        public virtual void Edit(frmAdd frmAdd)
        {
      
        }
    }
}
