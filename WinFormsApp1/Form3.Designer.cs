namespace WinFormsApp1
{
    partial class Form3
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
        private void InitializeComponent()
        {
            monthCalendar = new MonthCalendar();
            lblTitle = new Label();
            dgv = new DataGridView();
            btnTheme = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Font = new Font("Segoe UI", 14F);   // ← ЭТО ГЛАВНОЕ
            this.monthCalendar.Location = new Point(30, 70);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.Size = new Size(320, 260);          // ← тоже добавь
            this.monthCalendar.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(218, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📅 Календарь записей";
            // 
            // dgv
            // 
            dgv.Location = new Point(230, 70);
            dgv.Name = "dgv";
            dgv.Size = new Size(780, 400);
            dgv.TabIndex = 2;
            // 
            // btnTheme
            // 
            btnTheme.Location = new Point(930, 20);
            btnTheme.Name = "btnTheme";
            btnTheme.Size = new Size(90, 32);
            btnTheme.TabIndex = 3;
            btnTheme.Text = "🌙 Тема";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1050, 560);
            Controls.Add(lblTitle);
            Controls.Add(monthCalendar);
            Controls.Add(dgv);
            Controls.Add(btnTheme);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BarberShop — Календарь";
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private MonthCalendar monthCalendar;
        private Label lblTitle;
        private DataGridView dgv;
        private Button btnTheme;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
       

        #endregion
    }
}