using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1.Database
{
    public partial class ConnectionForm : Form
    {

        public ConnectionForm()
        {
            InitializeComponent();

            ApplyTheme();

            // 1. Загружаем сохранённые настройки
            var settings = ConnectionSettings.Load();
            txtHost.Text = settings.Host;
            txtPort.Text = settings.Port.ToString();
            txtDb.Text = settings.Database;
            txtUser.Text = settings.User;

            // Пароль подставляем только если стоит галочка "Запомнить"
            if (settings.Remember)
            {
                txtPass.Text = settings.Password;
                chkRemember.Checked = true;
            }

            btnConnect.Click += BtnConnect_Click;
            AcceptButton = btnConnect;
        }

        private void ApplyTheme()
        {
            BackColor = Theme.Background;
            ForeColor = Theme.TextMain;

            lblTitle.ForeColor = Theme.Accent;

            foreach (var l in new[] { lblHost, lblPort, lblDb, lblUser, lblPass })
                l.ForeColor = Theme.TextMuted;

            Theme.StyleTextBox(txtHost);
            Theme.StyleTextBox(txtPort);
            Theme.StyleTextBox(txtDb);
            Theme.StyleTextBox(txtUser);
            Theme.StyleTextBox(txtPass);

            Theme.StylePrimaryButton(btnConnect);

            lblStatus.ForeColor = Color.Red;
            if (chkRemember != null) chkRemember.ForeColor = Theme.TextMain;
        }

        public void AutoConnect()
        {
            BtnConnect_Click(this, EventArgs.Empty);
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            string host = txtHost.Text.Trim();
            string db = txtDb.Text.Trim();
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text;

            if (!int.TryParse(txtPort.Text.Trim(), out int port) || port <= 0)
            {
                lblStatus.Text = "Порт — число больше 0";
                return;
            }

            if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(db) || string.IsNullOrEmpty(user))
            {
                lblStatus.Text = "Заполните все поля";
                return;
            }

            lblStatus.ForeColor = Color.Gray;
            lblStatus.Text = "Подключение...";
            btnConnect.Enabled = false;

            try
            {
                // Обращаемся к DbManager (мы переименовали класс)
                Database.SetConnection(host, port, db, user, pass);
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Успешно подключено!";

                // 2. СОХРАНЯЕМ НАСТРОЙКИ
                var settings = new ConnectionSettings
                {
                    Host = host,
                    Port = port,
                    Database = db,
                    User = user,
                    Remember = chkRemember.Checked,
                    Password = chkRemember.Checked ? pass : "" // Если галочка не стоит - пароль пустой
                };
                settings.Save();

                // Открываем главную форму
                var form1 = new Form1();
                form1.Show();
                this.Hide();
                form1.FormClosed += (s, args) => this.Close();
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Ошибка подключения:\n" + ex.Message;
            }
            finally
            {
                btnConnect.Enabled = true;
            }
        }
    }
}
