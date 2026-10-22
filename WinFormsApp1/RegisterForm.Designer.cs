namespace WinFormsApp1
{
    partial class RegisterForm
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
            this.lblLogin = new Label();
            this.txtLogin = new TextBox();
            this.lblPass = new Label();
            this.txtPass = new TextBox();
            this.lblFirst = new Label();
            this.txtFirst = new TextBox();
            this.lblLast = new Label();
            this.txtLast = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.btnReg = new Button();
            this.btnBack = new Button();
            this.SuspendLayout();

            int left = 60, width = 340, y = 90, step = 55;

            // lblTitle
            this.lblTitle.Text = "СОЗДАТЬ АККАУНТ";
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.AutoSize = false;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Size = new Size(460, 50);
            this.lblTitle.Location = new Point(0, 25);

            // ЛОГИН
            this.lblLogin.Text = "ЛОГИН";
            this.lblLogin.Location = new Point(left, y); this.lblLogin.AutoSize = true;
            this.txtLogin.Location = new Point(left, y + 18);
            this.txtLogin.Size = new Size(width, 27);
            this.txtLogin.PlaceholderText = "Придумайте логин";

            // ПАРОЛЬ
            y += step;
            this.lblPass.Text = "ПАРОЛЬ";
            this.lblPass.Location = new Point(left, y); this.lblPass.AutoSize = true;
            this.txtPass.Location = new Point(left, y + 18);
            this.txtPass.Size = new Size(width, 27);
            this.txtPass.PlaceholderText = "Придумайте пароль";
            this.txtPass.UseSystemPasswordChar = true;

            // ИМЯ
            y += step;
            this.lblFirst.Text = "ИМЯ";
            this.lblFirst.Location = new Point(left, y); this.lblFirst.AutoSize = true;
            this.txtFirst.Location = new Point(left, y + 18);
            this.txtFirst.Size = new Size(width, 27);
            this.txtFirst.PlaceholderText = "Ваше имя";

            // ФАМИЛИЯ
            y += step;
            this.lblLast.Text = "ФАМИЛИЯ";
            this.lblLast.Location = new Point(left, y); this.lblLast.AutoSize = true;
            this.txtLast.Location = new Point(left, y + 18);
            this.txtLast.Size = new Size(width, 27);
            this.txtLast.PlaceholderText = "Ваша фамилия";

            // ТЕЛЕФОН
            y += step;
            this.lblPhone.Text = "ТЕЛЕФОН";
            this.lblPhone.Location = new Point(left, y); this.lblPhone.AutoSize = true;
            this.txtPhone.Location = new Point(left, y + 18);
            this.txtPhone.Size = new Size(width, 27);
            this.txtPhone.PlaceholderText = "+7 (___) ___-__-__";

            // EMAIL
            y += step;
            this.lblEmail.Text = "EMAIL";
            this.lblEmail.Location = new Point(left, y); this.lblEmail.AutoSize = true;
            this.txtEmail.Location = new Point(left, y + 18);
            this.txtEmail.Size = new Size(width, 27);
            this.txtEmail.PlaceholderText = "example@mail.ru";

            // Кнопка регистрации
            y += step + 10;
            this.btnReg.Location = new Point(left, y);
            this.btnReg.Size = new Size(width, 44);
            this.btnReg.Text = "ЗАРЕГИСТРИРОВАТЬСЯ";

            // Кнопка назад
            this.btnBack.Location = new Point(left, y + 52);
            this.btnBack.Size = new Size(width, 30);
            this.btnBack.Text = "← Назад ко входу";

            // RegisterForm
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(460, 720);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblFirst);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.lblLast);
            this.Controls.Add(this.txtLast);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "BarberShop — Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTitle, lblLogin, lblPass, lblFirst, lblLast, lblPhone, lblEmail;
        private TextBox txtLogin, txtPass, txtFirst, txtLast, txtPhone, txtEmail;
        private Button btnReg, btnBack;
    }

       

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
       

        
}
