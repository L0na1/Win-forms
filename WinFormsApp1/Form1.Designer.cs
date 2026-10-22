namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            lblLogo = new Label();
            lblSub = new Label();
            lblLogin = new Label();
            lblPass = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button1 = new Button();
            btnRegister = new Button();
            btnTheme = new Button();
            SuspendLayout();
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblLogo.Location = new Point(0, 30);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(800, 70);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "✂ Barbershop Entre";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSub
            // 
            lblSub.Font = new Font("Segoe UI", 14F);
            lblSub.Location = new Point(0, 100);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(800, 30);
            lblSub.TabIndex = 1;
            lblSub.Text = "Войдите в свой аккаунт";
            lblSub.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 10F);
            lblLogin.Location = new Point(245, 150);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(47, 19);
            lblLogin.TabIndex = 2;
            lblLogin.Text = "Логин";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10F);
            lblPass.Location = new Point(245, 215);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(56, 19);
            lblPass.TabIndex = 3;
            lblPass.Text = "Пароль";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(245, 172);
            textBox4.Name = "textBox4";
           // textBox4.PlaceholderText = "Введите логин";
            textBox4.Size = new Size(310, 23);
            textBox4.TabIndex = 0;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(245, 237);
            textBox5.Name = "textBox5";
           // textBox5.PlaceholderText = "Введите пароль";
            textBox5.Size = new Size(310, 23);
            textBox5.TabIndex = 1;
            textBox5.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.Location = new Point(245, 290);
            button1.Name = "button1";
            button1.Size = new Size(310, 34);
            button1.TabIndex = 2;
            button1.Text = "Войти";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(245, 330);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(310, 34);
            btnRegister.TabIndex = 3;
            btnRegister.Text = "Нет аккаунта? Зарегистрироваться";
            // 
            // btnTheme
            // 
            btnTheme.Location = new Point(700, 15);
            btnTheme.Name = "btnTheme";
            btnTheme.Size = new Size(85, 32);
            btnTheme.TabIndex = 10;
            btnTheme.Text = "🌙 Тема";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(lblLogo);
            Controls.Add(lblSub);
            Controls.Add(lblLogin);
            Controls.Add(textBox4);
            Controls.Add(lblPass);
            Controls.Add(textBox5);
            Controls.Add(button1);
            Controls.Add(btnRegister);
            Controls.Add(btnTheme);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BarberShop — Вход";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblLogo, lblSub, lblLogin, lblPass;
        private TextBox textBox4, textBox5;
        private Button button1, btnRegister, btnTheme;

    }
}
