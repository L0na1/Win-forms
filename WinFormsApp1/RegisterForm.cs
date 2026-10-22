using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Database;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class RegisterForm : Form
    {


        public RegisterForm()
        {
            InitializeComponent();

            Theme.ThemeChanged += ApplyTheme;
            FormClosed += (s, e) => Theme.ThemeChanged -= ApplyTheme;

            AcceptButton = btnReg;
            btnReg.Click += BtnReg_Click;
            btnBack.Click += (s, e) => Close();

            ApplyTheme();
        }

        private void ApplyTheme()
        {
            BackColor = Theme.Background;
            ForeColor = Theme.TextMain;

            lblTitle.ForeColor = Theme.Accent;
            foreach (var l in new[] { lblLogin, lblPass, lblFirst, lblLast, lblPhone, lblEmail })
                l.ForeColor = Theme.TextMuted;

            Theme.StyleTextBox(txtLogin);
            Theme.StyleTextBox(txtPass);
            Theme.StyleTextBox(txtFirst);
            Theme.StyleTextBox(txtLast);
            Theme.StyleTextBox(txtPhone);
            Theme.StyleTextBox(txtEmail);

            Theme.StylePrimaryButton(btnReg);
            Theme.StylePrimaryButton(btnBack);
        }

        private void BtnReg_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string pass = txtPass.Text;
            string fn = txtFirst.Text.Trim();
            string ln = txtLast.Text.Trim();
            string ph = txtPhone.Text.Trim();
            string em = txtEmail.Text.Trim();

            // Валидация
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass) ||
                string.IsNullOrEmpty(fn) || string.IsNullOrEmpty(ln) ||
                string.IsNullOrEmpty(ph))
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass.Length < 4)
            {
                MessageBox.Show("Пароль должен быть не короче 4 символов", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Сохранение в БД
            try
            {
                var user = new User(login, pass, fn, ln, ph, em);

                if (!UserRepository.Register(user))
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLogin.Focus();
                    return;
                }

                MessageBox.Show($"Добро пожаловать, {fn}!\nТеперь войдите в систему.",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка БД: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
