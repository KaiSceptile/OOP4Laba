
namespace WinFormsApp1
{
    partial class frmAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDetective = new System.Windows.Forms.RadioButton();
            this.rbAdventure = new System.Windows.Forms.RadioButton();
            this.rbSchoolBook = new System.Windows.Forms.RadioButton();
            this.rbNonFiction = new System.Windows.Forms.RadioButton();
            this.rbNovel = new System.Windows.Forms.RadioButton();
            this.rbMagazine = new System.Windows.Forms.RadioButton();
            this.tbName = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCostRubles = new System.Windows.Forms.TextBox();
            this.tbCostKopecks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNumberOfPages = new System.Windows.Forms.TextBox();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.tbGrade = new System.Windows.Forms.TextBox();
            this.lblGengre = new System.Windows.Forms.Label();
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDetective);
            this.groupBox1.Controls.Add(this.rbAdventure);
            this.groupBox1.Controls.Add(this.rbSchoolBook);
            this.groupBox1.Controls.Add(this.rbNonFiction);
            this.groupBox1.Controls.Add(this.rbNovel);
            this.groupBox1.Controls.Add(this.rbMagazine);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rbDetective
            // 
            this.rbDetective.AutoSize = true;
            this.rbDetective.Location = new System.Drawing.Point(7, 129);
            this.rbDetective.Name = "rbDetective";
            this.rbDetective.Size = new System.Drawing.Size(92, 24);
            this.rbDetective.TabIndex = 5;
            this.rbDetective.TabStop = true;
            this.rbDetective.Text = "Детектив";
            this.rbDetective.UseVisualStyleBackColor = true;
            this.rbDetective.CheckedChanged += new System.EventHandler(this.rbDetective_CheckedChanged);
            // 
            // rbAdventure
            // 
            this.rbAdventure.AutoSize = true;
            this.rbAdventure.Location = new System.Drawing.Point(7, 109);
            this.rbAdventure.Name = "rbAdventure";
            this.rbAdventure.Size = new System.Drawing.Size(128, 24);
            this.rbAdventure.TabIndex = 4;
            this.rbAdventure.TabStop = true;
            this.rbAdventure.Text = "Приключение";
            this.rbAdventure.UseVisualStyleBackColor = true;
            this.rbAdventure.CheckedChanged += new System.EventHandler(this.rbAdventure_CheckedChanged);
            // 
            // rbSchoolBook
            // 
            this.rbSchoolBook.AutoSize = true;
            this.rbSchoolBook.Location = new System.Drawing.Point(7, 88);
            this.rbSchoolBook.Name = "rbSchoolBook";
            this.rbSchoolBook.Size = new System.Drawing.Size(183, 24);
            this.rbSchoolBook.TabIndex = 3;
            this.rbSchoolBook.Text = "Школьная литература";
            this.rbSchoolBook.UseVisualStyleBackColor = true;
            this.rbSchoolBook.CheckedChanged += new System.EventHandler(this.rbSchoolBook_CheckedChanged);
            // 
            // rbNonFiction
            // 
            this.rbNonFiction.AutoSize = true;
            this.rbNonFiction.Location = new System.Drawing.Point(7, 68);
            this.rbNonFiction.Name = "rbNonFiction";
            this.rbNonFiction.Size = new System.Drawing.Size(171, 24);
            this.rbNonFiction.TabIndex = 2;
            this.rbNonFiction.Text = "Научная литература";
            this.rbNonFiction.UseVisualStyleBackColor = true;
            this.rbNonFiction.CheckedChanged += new System.EventHandler(this.rbNonFiction_CheckedChanged);
            // 
            // rbNovel
            // 
            this.rbNovel.AutoSize = true;
            this.rbNovel.Location = new System.Drawing.Point(7, 47);
            this.rbNovel.Name = "rbNovel";
            this.rbNovel.Size = new System.Drawing.Size(75, 24);
            this.rbNovel.TabIndex = 1;
            this.rbNovel.Text = "Роман";
            this.rbNovel.UseVisualStyleBackColor = true;
            this.rbNovel.CheckedChanged += new System.EventHandler(this.rbNovel_CheckedChanged);
            // 
            // rbMagazine
            // 
            this.rbMagazine.AutoSize = true;
            this.rbMagazine.Location = new System.Drawing.Point(7, 27);
            this.rbMagazine.Name = "rbMagazine";
            this.rbMagazine.Size = new System.Drawing.Size(84, 24);
            this.rbMagazine.TabIndex = 0;
            this.rbMagazine.Text = "Журнал";
            this.rbMagazine.UseVisualStyleBackColor = true;
            this.rbMagazine.CheckedChanged += new System.EventHandler(this.rbMagazine_CheckedChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(293, 40);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(161, 27);
            this.tbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Стоимость";
            // 
            // tbCostRubles
            // 
            this.tbCostRubles.Location = new System.Drawing.Point(293, 101);
            this.tbCostRubles.Name = "tbCostRubles";
            this.tbCostRubles.Size = new System.Drawing.Size(50, 27);
            this.tbCostRubles.TabIndex = 4;
            // 
            // tbCostKopecks
            // 
            this.tbCostKopecks.Location = new System.Drawing.Point(392, 101);
            this.tbCostKopecks.Name = "tbCostKopecks";
            this.tbCostKopecks.Size = new System.Drawing.Size(50, 27);
            this.tbCostKopecks.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "р.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "к.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Количество страниц";
            // 
            // tbNumberOfPages
            // 
            this.tbNumberOfPages.Location = new System.Drawing.Point(293, 190);
            this.tbNumberOfPages.Name = "tbNumberOfPages";
            this.tbNumberOfPages.Size = new System.Drawing.Size(109, 27);
            this.tbNumberOfPages.TabIndex = 9;
            // 
            // tbAuthor
            // 
            this.tbAuthor.Location = new System.Drawing.Point(20, 258);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(125, 27);
            this.tbAuthor.TabIndex = 10;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(13, 226);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(51, 20);
            this.lblAuthor.TabIndex = 11;
            this.lblAuthor.Text = "Автор";
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(212, 226);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(48, 20);
            this.lblGrade.TabIndex = 12;
            this.lblGrade.Text = "Класс";
            this.lblGrade.Visible = false;
            // 
            // tbGrade
            // 
            this.tbGrade.Location = new System.Drawing.Point(212, 258);
            this.tbGrade.Name = "tbGrade";
            this.tbGrade.Size = new System.Drawing.Size(125, 27);
            this.tbGrade.TabIndex = 13;
            this.tbGrade.Visible = false;
            // 
            // lblGengre
            // 
            this.lblGengre.AutoSize = true;
            this.lblGengre.Location = new System.Drawing.Point(13, 305);
            this.lblGengre.Name = "lblGengre";
            this.lblGengre.Size = new System.Drawing.Size(65, 20);
            this.lblGengre.TabIndex = 14;
            this.lblGengre.Text = "lblGenre";
            this.lblGengre.Visible = false;
            // 
            // tbGenre
            // 
            this.tbGenre.Location = new System.Drawing.Point(20, 348);
            this.tbGenre.Name = "tbGenre";
            this.tbGenre.Size = new System.Drawing.Size(125, 27);
            this.tbGenre.TabIndex = 15;
            this.tbGenre.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(212, 345);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 29);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(411, 348);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 29);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 450);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbGenre);
            this.Controls.Add(this.lblGengre);
            this.Controls.Add(this.tbGrade);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.tbAuthor);
            this.Controls.Add(this.tbNumberOfPages);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCostKopecks);
            this.Controls.Add(this.tbCostRubles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAdd";
            this.Text = "frmAdd";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rbSchoolBook;
        public System.Windows.Forms.RadioButton rbNonFiction;
        public System.Windows.Forms.RadioButton rbNovel;
        public System.Windows.Forms.RadioButton rbMagazine;
        public System.Windows.Forms.TextBox tbName;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbCostRubles;
        public System.Windows.Forms.TextBox tbCostKopecks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tbNumberOfPages;
        public System.Windows.Forms.TextBox tbAuthor;
        public System.Windows.Forms.Label lblAuthor;
        public System.Windows.Forms.Label lblGrade;
        public System.Windows.Forms.TextBox tbGrade;
        public System.Windows.Forms.Label lblGengre;
        public System.Windows.Forms.TextBox tbGenre;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.RadioButton rbDetective;
        public System.Windows.Forms.RadioButton rbAdventure;
    }
}