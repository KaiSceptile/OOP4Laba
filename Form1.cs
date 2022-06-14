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
        public delegate void Add(PrintedEdition printedEdition);
        public delegate void Edit(PrintedEdition printedEdition);

        public Add add;
        public Edit edit;
        
        public int index; 
        public List<PrintedEdition> listPrintedEdtions = new List<PrintedEdition>();
        private static Dictionary<string, IPlugin> Plugins = new Dictionary<string, IPlugin>();

        public PrintedEdition printedEdition = new PrintedEdition();
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
            long r = p * q, fr = (p - 1) * (q - 1);
            long E = Euclid(d, fr);
            try
            {
                StreamReader reader = new StreamReader(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + ".txt");
                long ECPforCheck = long.Parse(reader.ReadLine());
                string fileDate = reader.ReadLine();
                reader.Close();
                reader = new StreamReader(path);
                long hashCheck = 100;
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
