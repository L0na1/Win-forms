using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private bool cursorHidden = false;
        public Form1()
        {
            InitializeComponent();

            // Один обработчик Load вместо двух — иначе CenterCursor вызывается дважды
            Load += (s, e) =>
            {
                CenterControls();
                CenterCursor();
                //курсор будет в центре области формы
                Cursor.Position = PointToScreen(new Point(ClientSize.Width / 2, ClientSize.Height / 2));
                 BeginInvoke(new Action(() => ActiveControl = null));// снять фокус с textBox1, чтобы в нём не мигала
                                                                     // каретка
            };
            Resize += (s, e) => CenterControls();

            Deactivate += (s, e) => ShowCursor(); // страховки от «залипшего» скрытого курсора
            FormClosing += (s, e) => Cursor.Show();

            textBox4.Click += (s, e) => HideCursorOnce();
            textBox5.Click += (s, e) => HideCursorOnce();
            textBox4.MouseLeave += (s, e) => ShowCursor();
            textBox5.MouseLeave += (s, e) => ShowCursor();

            // Enter = клик по кнопке "Войти"
            AcceptButton = button1;

            // Клик по кнопке "Войти"
            button1.Click += button1_Click;
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            //если наводимся на курсор, он скрывается
            HideCursorOnce();
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            //а тут наоборот, при покидании окна, он появляется
            ShowCursor();
        }

        // Вспомогательные методы для курсора — чтобы не «залипнуть» на счётчике Hide/Show
        private void HideCursorOnce()
        {
            if (!cursorHidden)
            {
                Cursor.Hide();
                cursorHidden = true;
            }
        }

        private void ShowCursor()
        {
            if (cursorHidden)
            {
                Cursor.Show();
                cursorHidden = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void CenterControls()
        {
            // --- размеры группы ---
            int width = 300;   // ширина полей и кнопки
            int gap = 10;    // отступ между контролами

            // сколько всего по высоте
            int totalH = textBox4.Height + gap + textBox5.Height + gap + button1.Height;// сумма высот полей
                                                                // (логин и так далее) и расстояни между ними

            // верхний левый угол группы
            int left = (ClientSize.Width - width) / 2;//ClientSize.Width — ширина клиентской области формы, то есть
                                                      //внутренней части окна без рамки, заголовка и кнопок сверху.
            int top = (ClientSize.Height - totalH) / 2;

            // применяем
            textBox4.Width = width;
            textBox5.Width = width;
            button1.Width = width;

            textBox4.Location = new Point(left, top);
            textBox5.Location = new Point(left, top + textBox4.Height + gap);
            button1.Location = new Point(left, top + textBox4.Height + textBox5.Height + 2 * gap);
        }



        private void CenterCursor()
        {
            Cursor.Position = PointToScreen(new Point(ClientSize.Width / 2, ClientSize.Height / 2));
        }
        /*
         * ClientSize.Width / 2, ClientSize.Height / 2 — координаты центра формы в клиентских координатах. Например, 
         * если клиентская область 800×400, получится (400, 200).
           new Point(...) — создаём точку с этими координатами. Это ещё клиентские координаты, не экранные.
           PointToScreen(...) — метод формы, который переводит клиентские координаты в экранные. То есть «где эта точка
           находится на мониторе относительно левого верхнего угла экрана».
           Cursor.Position = ... — статическое свойство, задающее позицию курсора мыши в экранных координатах. Сюда и 
           присваиваем результат.
         * 
         */
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox4.Text.Trim();//Trim убирает пробелы по краям
            string password = textBox5.Text;

            // ВАЖНО: сначала проверяем оба поля вместе — иначе ветка «оба пустые» недостижима,
            // потому что первое же условие (login пустой) сработает раньше
            if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните логин и пароль");
                textBox4.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Заполните логин");
                textBox4.Clear();
                textBox4.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните пароль");
                textBox5.Clear();
                textBox5.Focus();
                return;
            }

            if ((login == "Dima" && password == "2548") || (login == "Max" && password == "1111"))
            {
                // Обязательно показать курсор перед переходом на Form2,
                // иначе новая форма откроется со скрытым курсором
                ShowCursor();
                if (login =="Dima")
                {
                    MessageBox.Show("С возвращением, Дмитрий");
                }
                else if(login=="Max")
                {
                    MessageBox.Show("С возвращением, Максим-тян");
                }
                var mainForm = new Form2();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                // Ветка на неверный логин/пароль — раньше её не было вообще,
                // и пользователь не понимал, что произошло
                MessageBox.Show("Неверный логин или пароль");
                textBox5.Clear();
                textBox5.Focus();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

