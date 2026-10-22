namespace WinFormsApp1
{
    partial class Form2
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
            this.lblFio = new Label();
            this.txtFio = new TextBox();
            this.lblService = new Label();
            this.txtService = new TextBox();
            this.lblPrice = new Label();
            this.txtPrice = new TextBox();
            this.lblDate = new Label();
            this.dtpDate = new DateTimePicker();
            this.lblMaster = new Label();
            this.cmbMaster = new ComboBox();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.dgv = new DataGridView();
            this.btnToCalendar = new Button();
            this.btnTheme = new Button();
            this.btnMasters = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "Администратор — Управление записями";
            this.lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(30, 20);

            // lblFio + txtFio
            this.lblFio.Text = "ФИО клиента";
            this.lblFio.Location = new Point(30, 70);
            this.lblFio.AutoSize = true;

            this.txtFio.Location = new Point(30, 90);
            this.txtFio.Size = new Size(260, 27);
            this.txtFio.Name = "txtFio";

            // lblService + txtService
            this.lblService.Text = "Что хочет клиент";
            this.lblService.Location = new Point(30, 125);
            this.lblService.AutoSize = true;

            this.txtService.Location = new Point(30, 145);
            this.txtService.Size = new Size(260, 27);
            this.txtService.Name = "txtService";

            // lblPrice + txtPrice
            this.lblPrice.Text = "Стоимость (₽)";
            this.lblPrice.Location = new Point(30, 180);
            this.lblPrice.AutoSize = true;

            this.txtPrice.Location = new Point(30, 200);
            this.txtPrice.Size = new Size(260, 27);
            this.txtPrice.Name = "txtPrice";

            // lblDate + dtpDate
            this.lblDate.Text = "Дата записи";
            this.lblDate.Location = new Point(30, 235);
            this.lblDate.AutoSize = true;

            this.dtpDate.Location = new Point(30, 255);
            this.dtpDate.Size = new Size(260, 27);
            this.dtpDate.Format = DateTimePickerFormat.Short;
            this.dtpDate.Name = "dtpDate";

            // lblMaster + cmbMaster
            this.lblMaster.Text = "Мастер";
            this.lblMaster.Location = new Point(30, 290);
            this.lblMaster.AutoSize = true;

            this.cmbMaster.Location = new Point(30, 310);
            this.cmbMaster.Size = new Size(260, 27);
            this.cmbMaster.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMaster.Name = "cmbMaster";

            // Кнопки CRUD
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new Point(35, 360);
            this.btnAdd.AutoSize = true;
            this.btnAdd.Size = new Size(85, 36);
            this.btnAdd.Name = "btnAdd";

            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.Location = new Point(123, 360);
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Size = new Size(85, 36);
            this.btnUpdate.Name = "btnUpdate";

            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new Point(210, 360);
            this.btnDelete.AutoSize = true;
            this.btnDelete.Size = new Size(85, 36);
            this.btnDelete.Name = "btnDelete";

            // Таблица
            this.dgv.Location = new Point(320, 70);
            this.dgv.Size = new Size(620, 420);
            this.dgv.Name = "dgv";

            // Кнопка "Мастера"
            this.btnMasters.Text = "👤 Мастера";
            this.btnMasters.Location = new Point(430, 20);
            this.btnMasters.Size = new Size(140, 36);
            this.btnMasters.Name = "btnMasters";

            // Кнопка календаря
            this.btnToCalendar.Text = "📅 Календарь";
            this.btnToCalendar.Location = new Point(580, 20);
            this.btnToCalendar.Size = new Size(160, 36);
            this.btnToCalendar.Name = "btnToCalendar";

            // Кнопка темы
            this.btnTheme.Text = "🌙 Тема";
            this.btnTheme.Location = new Point(850, 20);
            this.btnTheme.Size = new Size(90, 32);
            this.btnTheme.Name = "btnTheme";

            // Form2
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(970, 520);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFio);
            this.Controls.Add(this.txtFio);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.txtService);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblMaster);
            this.Controls.Add(this.cmbMaster);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnMasters);        // ← ДОБАВЛЕНО
            this.Controls.Add(this.btnToCalendar);
            this.Controls.Add(this.btnTheme);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "BarberShop — Администратор";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private Label lblTitle, lblFio, lblService, lblPrice, lblDate, lblMaster;
        private TextBox txtFio, txtService, txtPrice;
        private DateTimePicker dtpDate;
        private ComboBox cmbMaster;
        private Button btnAdd, btnUpdate, btnDelete, btnToCalendar, btnTheme, btnMasters;   // ← btnMasters ДОБАВЛЕН
        private DataGridView dgv;

    }
}