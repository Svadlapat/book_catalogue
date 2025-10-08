namespace BookCatalog.Forms
{
    partial class AddEditBookForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblAuthor = new Label();
            txtAuthor = new TextBox();
            lblGenre = new Label();
            txtGenre = new TextBox();
            lblYear = new Label();
            numYear = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            SuspendLayout();
            
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(32, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title:";
            
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(89, 12);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(283, 23);
            txtTitle.TabIndex = 1;
            
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(12, 44);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(47, 15);
            lblAuthor.TabIndex = 2;
            lblAuthor.Text = "Author:";
            
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(89, 41);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(283, 23);
            txtAuthor.TabIndex = 3;
            
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(12, 73);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(41, 15);
            lblGenre.TabIndex = 4;
            lblGenre.Text = "Genre:";
            
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(89, 70);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(283, 23);
            txtGenre.TabIndex = 5;
            
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(12, 102);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(32, 15);
            lblYear.TabIndex = 6;
            lblYear.Text = "Year:";
            
            // 
            // numYear
            // 
            numYear.Location = new Point(89, 99);
            numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(120, 23);
            numYear.TabIndex = 7;
            numYear.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            
            // 
            // btnSave
            // 
            btnSave.Location = new Point(216, 143);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(297, 143);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            
            // 
            // AddEditBookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 178);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numYear);
            Controls.Add(lblYear);
            Controls.Add(txtGenre);
            Controls.Add(lblGenre);
            Controls.Add(txtAuthor);
            Controls.Add(lblAuthor);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditBookForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Book";
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblAuthor;
        private TextBox txtAuthor;
        private Label lblGenre;
        private TextBox txtGenre;
        private Label lblYear;
        private NumericUpDown numYear;
        private Button btnSave;
        private Button btnCancel;
    }
}