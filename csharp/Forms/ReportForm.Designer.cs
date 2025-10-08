namespace BookCatalog.Forms
{
    partial class ReportForm
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
            txtReport = new TextBox();
            
            // 
            // txtReport
            // 
            txtReport.Dock = DockStyle.Fill;
            txtReport.Location = new Point(0, 0);
            txtReport.Multiline = true;
            txtReport.Name = "txtReport";
            txtReport.ReadOnly = true;
            txtReport.ScrollBars = ScrollBars.Vertical;
            txtReport.Size = new Size(584, 461);
            txtReport.TabIndex = 0;
            
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 461);
            Controls.Add(txtReport);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book Catalog Report";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtReport;
    }
}