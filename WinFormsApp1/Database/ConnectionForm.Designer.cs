namespace WinFormsApp1.Database
{
    partial class ConnectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblHost = new Label(); this.txtHost = new TextBox();
            this.lblPort = new Label(); this.txtPort = new TextBox();
            this.lblDb = new Label(); this.txtDb = new TextBox();
            this.lblUser = new Label(); this.txtUser = new TextBox();
            this.lblPass = new Label(); this.txtPass = new TextBox();
            this.chkRemember = new CheckBox();
            this.btnConnect = new Button();
            this.lblStatus = new Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "🔌 Подключение к PostgreSQL";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(40, 20);

            int left = 40, width = 320, y = 80, step = 55;

            // Host
            this.lblHost.Text = "Хост"; this.lblHost.Location = new Point(left, y); this.lblHost.AutoSize = true;
            this.txtHost.Location = new Point(left, y + 20); this.txtHost.Size = new Size(width, 27);
            this.txtHost.Text = "localhost";

            // Port
            y += step;
            this.lblPort.Text = "Порт"; this.lblPort.Location = new Point(left, y); this.lblPort.AutoSize = true;
            this.txtPort.Location = new Point(left, y + 20); this.txtPort.Size = new Size(width, 27);
            this.txtPort.Text = "5432";

            // Database
            y += step;
            this.lblDb.Text = "База данных"; this.lblDb.Location = new Point(left, y); this.lblDb.AutoSize = true;
            this.txtDb.Location = new Point(left, y + 20); this.txtDb.Size = new Size(width, 27);
            this.txtDb.Text = "barbershop";

            // User
            y += step;
            this.lblUser.Text = "Пользователь"; this.lblUser.Location = new Point(left, y); this.lblUser.AutoSize = true;
            this.txtUser.Location = new Point(left, y + 20); this.txtUser.Size = new Size(width, 27);
            this.txtUser.Text = "postgres";

            // Password
            y += step;
            this.lblPass.Text = "Пароль"; this.lblPass.Location = new Point(left, y); this.lblPass.AutoSize = true;
            this.txtPass.Location = new Point(left, y + 20); this.txtPass.Size = new Size(width, 27);
            this.txtPass.UseSystemPasswordChar = true;

            // Галочка "Запомнить"
            y += step + 15;
            this.chkRemember.Text = "Запомнить пароль";
            this.chkRemember.Location = new Point(left, y);
            this.chkRemember.AutoSize = true;
            this.chkRemember.Name = "chkRemember";

            // Кнопка
            y += 35;
            this.btnConnect.Text = "Подключиться";
            this.btnConnect.Location = new Point(left, y);
            this.btnConnect.Size = new Size(width, 44);

            // Статус
            this.lblStatus.Text = "";
            this.lblStatus.Location = new Point(left, y + 55);
            this.lblStatus.Size = new Size(width, 40);
            this.lblStatus.ForeColor = Color.Red;
            this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;

            // ConnectionForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(420, 550);   // ← Чуть увеличили высоту (было 520)
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblHost); this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblPort); this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblDb); this.Controls.Add(this.txtDb);
            this.Controls.Add(this.lblUser); this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPass); this.Controls.Add(this.txtPass);
            this.Controls.Add(this.chkRemember);    // ← Добавили галочку
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "BarberShop — Подключение к БД";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTitle, lblHost, lblPort, lblDb, lblUser, lblPass, lblStatus;
        private TextBox txtHost, txtPort, txtDb, txtUser, txtPass;
        private CheckBox chkRemember;   // ← Объявили переменную
        private Button btnConnect;
    

    }
}