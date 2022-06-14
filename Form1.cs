using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public delegate void Add(PrintedEdition printedEdition);
        public delegate void Edit(PrintedEdition printedEdition);

        public Add add;
        public Edit edit;
        
        public int index; 
        public List<PrintedEdition> listPrintedEdtions = new List<PrintedEdition>();

        public PrintedEdition printedEdition = new PrintedEdition();
        public Form1()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd frmAdd = new frmAdd();
            frmAdd.Owner = this;
            frmAdd.btnAdd.Visible = true;
            frmAdd.btnEdit.Visible = false;
            frmAdd.lblAuthor.Visible = true;
            frmAdd.tbAuthor.Visible = true;
            frmAdd.rbNovel.Visible = true;
            frmAdd.rbMagazine.Visible = true;
            frmAdd.rbNonFiction.Visible = true;
            frmAdd.rbSchoolBook.Visible = true;
            frmAdd.Show();
        }

       
        public void ShowList(List<PrintedEdition> list)
        {
            dgvBooks.Rows.Clear();
            for (int i=0; i<list.Count; i++)
            {
                list[i].ShowInList(dgvBooks);           
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAdd frmAdd = new frmAdd();
            frmAdd.Owner = this;
            frmAdd.btnEdit.Visible = true;
            frmAdd.btnAdd.Visible = false;
            index = dgvBooks.CurrentRow.Index;
            frmAdd.lblAuthor.Visible = true;
            frmAdd.tbAuthor.Visible = true;
            frmAdd.lblGengre.Visible = false;
            frmAdd.tbGenre.Visible = false;
            frmAdd.lblGrade.Visible = false;
            frmAdd.tbGrade.Visible = false;
            frmAdd.rbNovel.Visible = false;
            frmAdd.rbMagazine.Visible = false;
            frmAdd.rbNonFiction.Visible = false;
            frmAdd.rbSchoolBook.Visible = false;
            frmAdd.rbAdventure.Visible = false;
            frmAdd.rbDetective.Visible = false;
            listPrintedEdtions[index].ShowForEditEdition(frmAdd);
            frmAdd.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            index = dgvBooks.CurrentRow.Index;
            listPrintedEdtions.RemoveAt(index);
            ShowList(listPrintedEdtions);
        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            List<PrintedEdition> currentlistPrintedEdtions = new List<PrintedEdition>();
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                currentlistPrintedEdtions = listPrintedEdtions;
                Deserialization deserialization = Deserialization.GetDeserialization(openFD.FileName);
                if (listPrintedEdtions != null) listPrintedEdtions.Clear();
                listPrintedEdtions = deserialization.Deserialize(openFD.FileName);
                if (listPrintedEdtions == null) listPrintedEdtions = currentlistPrintedEdtions;
                if (listPrintedEdtions != null) ShowList(listPrintedEdtions);
            }
        }
        private void btnSerialize_Click(object sender, EventArgs e)
        {
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(saveFD.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(f);
                for (int i = 0; i < listPrintedEdtions.Count; i++)
                {
                    writer.WriteLine("NewElement:"+listPrintedEdtions[i].type );
                    foreach (FieldInfo field in listPrintedEdtions[i].GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static
                        | BindingFlags.NonPublic))
                    {
                        string s = field.Name+" "+field.GetValue(listPrintedEdtions[i]).ToString();
                        writer.WriteLine(s);
                                              
                    }
                    writer.WriteLine("end");
                }
                writer.Close();
                f.Close();
            }
        }     
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
