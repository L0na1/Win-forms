namespace WinFormsApp1
{
    partial class MasterForm
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
            this.lblTitle = new Label();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblSpecialty = new Label();
            this.txtSpecialty = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.dgv = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "Управление мастерами";
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(30, 20);

            // ФИО
            this.lblName.Text = "ФИО мастера";
            this.lblName.Location = new Point(30, 70);
            this.lblName.AutoSize = true;

            this.txtName.Location = new Point(30, 90);
            this.txtName.Size = new Size(260, 27);
            this.txtName.Name = "txtName";

            // Специализация
            this.lblSpecialty.Text = "Специализация";
            this.lblSpecialty.Location = new Point(30, 125);
            this.lblSpecialty.AutoSize = true;

            this.txtSpecialty.Location = new Point(30, 145);
            this.txtSpecialty.Size = new Size(260, 27);
            this.txtSpecialty.Name = "txtSpecialty";

            // Телефон
            this.lblPhone.Text = "Телефон";
            this.lblPhone.Location = new Point(30, 180);
            this.lblPhone.AutoSize = true;

            this.txtPhone.Location = new Point(30, 200);
            this.txtPhone.Size = new Size(260, 27);
            this.txtPhone.Name = "txtPhone";

            // Кнопки
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new Point(30, 260);
            this.btnAdd.Size = new Size(80, 36);
            this.btnAdd.Name = "btnAdd";

            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.Location = new Point(120, 260);
            this.btnUpdate.Size = new Size(80, 36);
            this.btnUpdate.Name = "btnUpdate";

            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new Point(210, 260);
            this.btnDelete.Size = new Size(80, 36);
            this.btnDelete.Name = "btnDelete";

            // Таблица
            this.dgv.Location = new Point(320, 70);
            this.dgv.Size = new Size(600, 420);
            this.dgv.Name = "dgv";

            // MastersForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(950, 520);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblSpecialty);
            this.Controls.Add(this.txtSpecialty);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "BarberShop — Мастера";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTitle, lblName, lblSpecialty, lblPhone;
        private TextBox txtName, txtSpecialty, txtPhone;
        private Button btnAdd, btnUpdate, btnDelete;
        private DataGridView dgv;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
       

        #endregion
    }
}