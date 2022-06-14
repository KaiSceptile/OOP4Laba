using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class frmAdd : Form
    {
        public frmAdd()
        {
            InitializeComponent();
        }

        private void AddMagazine(Magazine magazine)
        {
            //Form1 Form1 = new Form1();
            Form1 Form1 = (Form1)this.Owner;
            magazine.Name = tbName.Text;
            magazine.NumberOfPages = Convert.ToInt32(tbNumberOfPages.Text);
            magazine.PublishingHouse = tbAuthor.Text;
            magazine.Ruble = Convert.ToInt32(tbCostRubles.Text);
            magazine.Kopeck = Convert.ToInt32(tbCostKopecks.Text);
            Form1.listPrintedEdtions.Add(magazine);
        }

        private void AddFiction(Fiction fiction)
        {
            //Form1 Form1 = new Form1();
            //  frmAdd frmAdd = new frmAdd();
            Form1 Form1 = (Form1)this.Owner;
            fiction.Name = tbName.Text;
            fiction.NumberOfPages = Convert.ToInt32(tbNumberOfPages.Text);
            fiction.Author = tbAuthor.Text;
            fiction.Ruble = Convert.ToInt32(tbCostRubles.Text);
            fiction.Kopeck = Convert.ToInt32(tbCostKopecks.Text);
           // fiction.Genre = tbGenre.Text;
            Form1.listPrintedEdtions.Add(fiction);
        }

        private void AddNonFiction(Non_Fiction non_Fiction)
        {
            // Form1 Form1 = new Form1();
            Form1 Form1 = (Form1)this.Owner;
            non_Fiction.Name = tbName.Text;
            non_Fiction.NumberOfPages = Convert.ToInt32(tbNumberOfPages.Text);
            non_Fiction.Author = tbAuthor.Text;
            non_Fiction.Ruble = Convert.ToInt32(tbCostRubles.Text);
            non_Fiction.Kopeck = Convert.ToInt32(tbCostKopecks.Text);
            non_Fiction.SubjectArea = tbGenre.Text;
            Form1.listPrintedEdtions.Add(non_Fiction);
        }

        private void AddSchoolBook(SchoolBook schoolBook)
        {
            //Form1 Form1 = new Form1();
            Form1 Form1 = (Form1)this.Owner;
            schoolBook.Name = tbName.Text;
            schoolBook.NumberOfPages = Convert.ToInt32(tbNumberOfPages.Text);
            schoolBook.Author = tbAuthor.Text;
            schoolBook.Ruble = Convert.ToInt32(tbCostRubles.Text);
            schoolBook.Kopeck = Convert.ToInt32(tbCostKopecks.Text);
            schoolBook.SubjectArea = tbGenre.Text;
            schoolBook.Grade = Convert.ToInt32(tbGrade.Text);
            Form1.listPrintedEdtions.Add(schoolBook);
        }

        private void rbMagazine_CheckedChanged(object sender, EventArgs e)
        {
           // Form1 Form1 = new Form1();
            Magazine magazine = new Magazine();
            Form1 Form1 = (Form1)this.Owner;
            Form1.printedEdition = magazine;
            PrintedEdition printedEdition = Form1.printedEdition;
            lblGengre.Visible = false;
            tbGenre.Visible = false;
            tbGrade.Visible = false;
            lblGrade.Visible = false;
            lblAuthor.Text = "Издательство";
            Form1.add = printedEdition=>
            {
                /*magazine.Name = frmAdd.tbName.Text;
                magazine.NumberOfPages = Convert.ToInt32(frmAdd.tbNumberOfPages.Text);
                magazine.PublishingHouse = 
                Form1.listPrintedEdtions.Add(magazine);*/
                AddMagazine(magazine);
            };
        }

        private void rbNovel_CheckedChanged(object sender, EventArgs e)
        {
            //Form1 Form1 = new Form1();
            Form1 Form1 = (Form1)this.Owner;
            Manga manga = new Manga();
            Form1.printedEdition = manga;
            PrintedEdition printedEdition = Form1.printedEdition;
            lblAuthor.Text = "Автор";
          //  lblGengre.Text = "Жанр";
            lblGengre.Visible = false;
            tbGrade.Visible = false;
            lblGrade.Visible = false;
            tbGenre.Visible = false;
            Form1.add = printedEdition =>
            {
                AddFiction(manga);
            };
        }

        private void rbNonFiction_CheckedChanged(object sender, EventArgs e)
        {
            //Form1 Form1 = new Form1(); 
            Form1 Form1 = (Form1)this.Owner;
            Non_Fiction non_Fiction = new Non_Fiction();
            Form1.printedEdition = non_Fiction;
            PrintedEdition printedEdition = Form1.printedEdition;
            lblAuthor.Text = "Автор";
            lblGengre.Text = "Предметная область";
            lblGengre.Visible = true;
            tbGrade.Visible = false;
            lblGrade.Visible = false;
            tbGenre.Visible = true;
            Form1.add = printedEdition =>
            {
                AddNonFiction(non_Fiction);
            };
        }

        private void rbSchoolBook_CheckedChanged(object sender, EventArgs e)
        {
            //Form1 Form1 = new Form1();
            Form1 Form1 = (Form1)this.Owner;
            SchoolBook schoolBook = new SchoolBook();
            Form1.printedEdition = schoolBook;
            PrintedEdition printedEdition = Form1.printedEdition;
            lblAuthor.Text = "Автор";
            lblGengre.Text = "Предметная область";
            lblGengre.Visible = true;
            tbGenre.Visible = true;
            lblGrade.Visible = true;
            tbGrade.Visible = true;
            Form1.add = printedEdition =>
            {
                AddSchoolBook(schoolBook);
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Form1 Form1 = new Form1();
                Form1 Form1 = (Form1)this.Owner;
                
                if (Int32.Parse(tbCostKopecks.Text) < 100)
                {
                    PrintedEdition printedEdition = Form1.printedEdition;
                    Form1.add(printedEdition);
                    Form1.ShowList(Form1.listPrintedEdtions);
                } else
                {
                    MessageBox.Show("Incorrect value of kopeks");
                }
            }
            catch
            {
                MessageBox.Show("Invalid data");
            }
            Close();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form1 F = (Form1)this.Owner;
            F.listPrintedEdtions[F.index].Edit(this);
            F.ShowList(F.listPrintedEdtions);
            Close();
        }

        private void rbAdventure_CheckedChanged(object sender, EventArgs e)
        {
            Form1 Form1 = (Form1)this.Owner;
            Fantastic fantastic = new Fantastic();
            Form1.printedEdition = fantastic;
            PrintedEdition printedEdition = Form1.printedEdition;
            lblAuthor.Text = "Автор";
            //  lblGengre.Text = "Жанр";
            lblGengre.Visible = false;
            tbGrade.Visible = false;
            lblGrade.Visible = false;
            tbGenre.Visible = false;
            Form1.add = printedEdition =>
            {
                AddFiction(fantastic);
            };

        }

        private void rbDetective_CheckedChanged(object sender, EventArgs e)
        {
            Form1 Form1 = (Form1)this.Owner;
            Fantasy fantasy = new Fantasy();
            Form1.printedEdition = fantasy;
            PrintedEdition printedEdition = Form1.printedEdition;
            lblAuthor.Text = "Автор";
            //  lblGengre.Text = "Жанр";
            lblGengre.Visible = false;
            tbGenre.Visible = false;
            tbGrade.Visible = false;
            lblGrade.Visible = false;
            Form1.add = printedEdition =>
            {
                AddFiction(fantasy);
            };
        }
    }
}
