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
            Novel novel = new Novel();
            Form1.printedEdition = novel;
            PrintedEdition printedEdition = Form1.printedEdition;
            lblAuthor.Text = "Автор";
          //  lblGengre.Text = "Жанр";
            lblGengre.Visible = false;
            tbGenre.Visible = false;
            Form1.add = printedEdition =>
            {
                AddFiction(novel);
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
                PrintedEdition printedEdition = Form1.printedEdition;
                Form1.add(printedEdition);
                Form1.ShowList(Form1.listPrintedEdtions);
            }
            catch
            {
                MessageBox.Show("Invalid data");
            }
            Close();
        }

      /*  private void EditMagazine(PrintedEdition edition)
        {
            (edition as Magazine).PublishingHouse = tbAuthor.Text;
        }

        private void EditNonFiciton(PrintedEdition edition)
        {
            (edition as Non_Fiction).Author = tbAuthor.Text;
            (edition as Non_Fiction).SubjectArea = tbGenre.Text;
        }

        private void EditSchoolBook(PrintedEdition edition)
        {
            (edition as SchoolBook).Author = tbAuthor.Text;
            (edition as SchoolBook).SubjectArea = tbGenre.Text;
            (edition as SchoolBook).Grade = Convert.ToInt32(tbGrade.Text);
        }

        private void EditFiction(PrintedEdition edition)
        {
            (edition as Fiction).Author = tbAuthor.Text;
        }*/

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form1 F = (Form1)this.Owner;
            /*F.listPrintedEdtions[F.index].Name = tbName.Text;
            F.listPrintedEdtions[F.index].Ruble = Convert.ToInt32(tbCostRubles.Text);
            F.listPrintedEdtions[F.index].Kopeck = Convert.ToInt32(tbCostKopecks.Text);
            F.listPrintedEdtions[F.index].NumberOfPages = Convert.ToInt32(tbNumberOfPages.Text);
            switch (F.listPrintedEdtions[F.index].type)
            {
                case "Magazine": EditMagazine(F.listPrintedEdtions[F.index]);break;
                case "Non_Fiction": EditFiction(F.listPrintedEdtions[F.index]); break;
                case "SchoolBook": EditSchoolBook(F.listPrintedEdtions[F.index]); break;
                case "Novel": EditFiction(F.listPrintedEdtions[F.index]); break;
                case "Adventure": EditFiction(F.listPrintedEdtions[F.index]); break;
                case "Detective": EditFiction(F.listPrintedEdtions[F.index]); break;
            }*/
            
            F.listPrintedEdtions[F.index].Edit(this);
            Form1.ShowList(F.listPrintedEdtions);
            Close();
        }

        private void rbAdventure_CheckedChanged(object sender, EventArgs e)
        {
            Form1 Form1 = (Form1)this.Owner;
            Adventure adventure = new Adventure();
            Form1.printedEdition = adventure;
            PrintedEdition printedEdition = Form1.printedEdition;
            lblAuthor.Text = "Автор";
            //  lblGengre.Text = "Жанр";
            lblGengre.Visible = false;
            tbGenre.Visible = false;
            Form1.add = printedEdition =>
            {
                AddFiction(adventure);
            };

        }

        private void rbDetective_CheckedChanged(object sender, EventArgs e)
        {
            Form1 Form1 = (Form1)this.Owner;
            Detective detective = new Detective();
            Form1.printedEdition = detective;
            PrintedEdition printedEdition = Form1.printedEdition;
            lblAuthor.Text = "Автор";
            //  lblGengre.Text = "Жанр";
            lblGengre.Visible = false;
            tbGenre.Visible = false;
            Form1.add = printedEdition =>
            {
                AddFiction(detective);
            };
        }
    }
}
