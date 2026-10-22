//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinFormsApp1.Database;         // ← нужен для UserStorage
using WinFormsApp1.Models;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private bool cursorHidden = false;

        public Form1()
        {
            InitializeComponent();

            // Placeholder'ы
            Theme.AttachPlaceholder(textBox4, "Введите логин");
            Theme.AttachPlaceholder(textBox5, "Введите пароль", isPassword: true); // ← добавлен isPassword: true

            button1.Click += button1_Click;
            btnRegister.Click += btnRegister_Click;
            btnTheme.Click += (s, e) => { Theme.Toggle(); };

            AcceptButton = button1;

            // Подписки на события
            Load += (s, e) =>
            {
                CenterControls();
                CenterCursor();
                Cursor.Position = PointToScreen(new Point(ClientSize.Width / 2, ClientSize.Height / 2));
                BeginInvoke(new Action(() =>
                {
                    ActiveControl = null;
                    PositionThemeButton();   // финальный пересчёт кнопки темы
                }));
            };
            Resize += (s, e) => CenterControls();

            Deactivate += (s, e) => ShowCursor();
            FormClosing += (s, e) => Cursor.Show();

            // Курсор: поля
            textBox4.Click += (s, e) => HideCursorOnce();
            textBox5.Click += (s, e) => HideCursorOnce();
            textBox4.MouseLeave += (s, e) => ShowCursor();
            textBox5.MouseLeave += (s, e) => ShowCursor();

            // Курсор: кнопки
            foreach (var b in new[] { button1, btnRegister, btnTheme })
            {
                b.MouseEnter += (s, e) => HideCursorOnce();
                b.MouseLeave += (s, e) => ShowCursor();
            }

            // Тема
            Theme.ThemeChanged += ApplyTheme;
            FormClosed += (s, e) => Theme.ThemeChanged -= ApplyTheme;
            ApplyTheme();
        }

        // ---------- Тема ----------
        private void ApplyTheme()
        {
            BackColor = Theme.Background;
            ForeColor = Theme.TextMain;

            lblLogo.ForeColor = Theme.Accent;
            lblSub.ForeColor = Theme.TextMuted;
            lblLogin.ForeColor = Theme.TextMuted;
            lblPass.ForeColor = Theme.TextMuted;

            Theme.StyleTextBox(textBox4);
            Theme.StyleTextBox(textBox5);
            Theme.StylePrimaryButton(button1);
            Theme.StylePrimaryButton(btnRegister);
            Theme.StylePrimaryButton(btnTheme);

            btnTheme.Text = Theme.IsDark ? "🌙 Тема" : "☀ Тема";
            btnTheme.ForeColor = Theme.TextMain;

            // Восстановить цвет placeholder'а после смены темы
            RestorePlaceholderColor(textBox4);
            RestorePlaceholderColor(textBox5);
        }

        private void RestorePlaceholderColor(TextBox tb)
        {
            if (tb.Tag is string ph && tb.Text == ph)
                tb.ForeColor = Theme.TextMuted;
            else
                tb.ForeColor = Theme.TextMain;
        }

        // ---------- Курсор ----------
        private void HideCursorOnce()
        {
            if (!cursorHidden) { Cursor.Hide(); cursorHidden = true; }
        }

        private void ShowCursor()
        {
            if (cursorHidden) { Cursor.Show(); cursorHidden = false; }
        }

        private void CenterCursor()
        {
            Cursor.Position = PointToScreen(new Point(ClientSize.Width / 2, ClientSize.Height / 2));
        }

        // ---------- Центрирование ----------
        private void CenterControls()
        {
            int width = 310;
            int left = (ClientSize.Width - width) / 2;
            int top = 170;

            lblLogin.Left = left; lblLogin.Top = top - 20;
            textBox4.Width = width; textBox4.Location = new Point(left, top);

            lblPass.Left = left; lblPass.Top = top + 45;
            textBox5.Width = width; textBox5.Location = new Point(left, top + 65);

            button1.Width = width;
            button1.Location = new Point(left, top + 120);

            btnRegister.Width = width;
            btnRegister.Location = new Point(left, top + 175);

            lblLogo.Left = 0;
            lblLogo.Width = ClientSize.Width;
            lblSub.Left = 0;
            lblSub.Width = ClientSize.Width;

            PositionThemeButton();
        }

        private void PositionThemeButton()
        {
            const int margin = 12;
            btnTheme.Left = Math.Max(0, ClientSize.Width - btnTheme.Width - margin);
            btnTheme.Top = margin;
            btnTheme.BringToFront();
        }

        // ---------- Вход ----------
        private void button1_Click(object sender, EventArgs e)
        {
            // Блокируем кнопку, чтобы не было двойных срабатываний
            button1.Enabled = false;
            try
            {
                string login = textBox4.Text == (string)textBox4.Tag ? "" : textBox4.Text.Trim();
                string password = textBox5.Text == (string)textBox5.Tag ? "" : textBox5.Text;

                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Заполните логин и пароль", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // finally вернет кнопку обратно
                }

                User user = null;
                try
                {
                    user = UserRepository.Authorize(login, password);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка БД: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox5.Clear();
                    textBox5.Focus();
                    return;
                }

                // Скрываем текущую форму ДО показа сообщения
                this.Hide();

                MessageBox.Show($"С возвращением, {user.FirstName}!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var mainForm = new Form2(user);
                mainForm.Show();

                mainForm.FormClosed += (s, args) =>
                {
                    textBox5.Clear();
                    textBox5.Text = "Введите пароль";
                    textBox5.ForeColor = Theme.TextMuted;
                    this.Show();
                };
            }
            finally
            {
                // В любом случае включаем кнопку обратно
                button1.Enabled = true;
            }
        }

        // ---------- Регистрация ----------
        private void btnRegister_Click(object sender, EventArgs e)
        {
            ShowCursor();
            var reg = new RegisterForm();
            reg.ShowDialog(this);
        }

    }
}






