using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Loader;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        private static Dictionary<string, IPlugin> Plugins = new Dictionary<string, IPlugin>();
        public delegate void Add(PrintedEdition printedEdition);
        public delegate void Edit(PrintedEdition printedEdition);

        public Add add;
        public Edit edit;
        
        public int index; 
        public List<PrintedEdition> listPrintedEdtions = new List<PrintedEdition>();
        public static PrintedEdition printedEdition = new PrintedEdition();
        public Form1()
        {
            Instance = this;
            string pathToPlugins = Path.GetFullPath(@"Plugins");

            foreach (var dll in Directory.GetFiles(pathToPlugins, "*.dll"))
            {
                AssemblyLoadContext assemblyLoadContext = new AssemblyLoadContext(dll);
                Assembly assembly = assemblyLoadContext.LoadFromAssemblyPath(dll);
                IPlugin plugin = Activator.CreateInstance(assembly.GetTypes()[0]) as IPlugin;
                if (SignIsCorrect(plugin, dll))
                {
                    Plugins.Add(Path.GetFileNameWithoutExtension(dll), plugin);
                }
                else MessageBox.Show("Incorrect");
            }
            foreach (var key in Plugins.Keys)
            {
                Plugins[key].Run();
            }
            InitializeComponent();

        }

        private bool SignIsCorrect(IPlugin plugin, string path)
        {
            long p = 41, q = 59, d = 133;
            long r = p * q, fr = (p - 1)*(q - 1);
            long E = Euclid(d, fr);
            try
            {
                StreamReader reader = new StreamReader(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + ".txt"); 
                long ECPforCheck = long.Parse(reader.ReadLine());
                string fileDate = reader.ReadLine();
                reader.Close();
                reader = new StreamReader(path);
                int symbol; long hashCheck = 100;
                string[] data = File.ReadAllLines(path);
                int c = reader.Read();
                    while (c != -1)
                    {
                        hashCheck = (hashCheck + c) * (hashCheck + c) % (p * q);
                        c = reader.Read();
                    }
                    //if (i != data.Length - 2) hashCheck = (hashCheck + symbol) * (hashCheck + symbol) % r;
                
                long hashEncr = powByMod(ECPforCheck, E, r);

                if (hashCheck == hashEncr && fileDate == File.GetCreationTime(path).ToString())
                {
                    return true;
                }
                else
                {
                    if (hashCheck != hashEncr) MessageBox.Show("1..");
                    if (fileDate != File.GetCreationTime(path).ToString()) MessageBox.Show(File.GetCreationTime(path).ToString);
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
            //return false;
        }
        static long Euclid(long a, long b)
        {
            long x2 = 1, x1 = 0, y2 = 0, y1 = 1;
            while (b > 0)
            {
                long q = a / b, r = a - q * b, x = x2 - q * x1, y = y2 - q * y1;
                a = b;
                b = r;
                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;
            }
            return (y2 > 0) ? y2 : x2;
        }
        public static long powByMod(long a, long b, long m)
        {
            if (b == 0)
                return 1;
            if (b % 2 == 0)
            {
                long t = powByMod(a, b / 2, m);
                return t * t % m;
            }

            return a * powByMod(a, b - 1, m) % m;
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

       
        public static void ShowList(List<PrintedEdition> list)
        {
            Instance.dgvBooks.Rows.Clear();
            for (int i=0; i<list.Count; i++)
            {
                list[i].ShowInList(Instance.dgvBooks);           
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAdd frmAdd = new frmAdd();
            frmAdd.Owner = this;
            frmAdd.btnEdit.Visible = true;
            frmAdd.btnAdd.Visible = false;
            index = dgvBooks.CurrentRow.Index;
           /* frmAdd.tbName.Text = listPrintedEdtions[index].Name;
            frmAdd.tbNumberOfPages.Text = Convert.ToString(listPrintedEdtions[index].NumberOfPages);
            frmAdd.tbCostRubles.Text = Convert.ToString(listPrintedEdtions[index].Ruble);
            frmAdd.tbCostKopecks.Text = Convert.ToString(listPrintedEdtions[index].Kopeck);*/
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
            /*  switch (listPrintedEdtions[index].type)
              {
                  case "Magazine": EditMagazine(frmAdd, listPrintedEdtions[index]); break;
                  case "Non_Fiction": EditNonFiction(frmAdd, listPrintedEdtions[index]);break;
                  case "SchoolBook": EditSchoolBook(frmAdd, listPrintedEdtions[index]);break;
                  case "Novel": EditFiction(frmAdd, listPrintedEdtions[index]); break;
                  case "Adventure": EditFiction(frmAdd, listPrintedEdtions[index]);break;
                  case "Detective": EditFiction(frmAdd, listPrintedEdtions[index]);break;
              }*/
            listPrintedEdtions[index].ShowForEditEdition(frmAdd);
            frmAdd.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            index = dgvBooks.CurrentRow.Index;
            listPrintedEdtions.RemoveAt(index);
            ShowList(listPrintedEdtions);
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {

        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            if (openFD.ShowDialog() == DialogResult.OK) {
                Deserialization deserialization = Deserialization.GetDeserialization(openFD.FileName);
                listPrintedEdtions.Clear();
                listPrintedEdtions= deserialization.Deserialize();
                if (listPrintedEdtions!=null)
                    ShowList(listPrintedEdtions);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }
    }
}
