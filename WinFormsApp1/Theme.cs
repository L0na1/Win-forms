using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace WinFormsApp1
{
    public static class Theme
    {
        public static bool IsDark { get; private set; } = false;
        public static event Action ThemeChanged;

        // Цвета (меняются при переключении)
        public static Color Background { get; private set; }  // фон формы
        public static Color CardBg { get; private set; }  // карточки / таблицы
        public static Color InputBg { get; private set; }  // поля (псевдо-прозрачные)
        public static Color InputBorder { get; private set; }  // рамка полей
        public static Color Accent { get; private set; }  // акцент (светло-серый)
        public static Color AccentHover { get; private set; }  // hover акцента
        public static Color TextMain { get; private set; }  // основной текст
        public static Color TextMuted { get; private set; }  // приглушённый текст
        public static Color BtnBg { get; private set; }  // фон кнопок
        public static Color BtnHover { get; private set; }  // hover кнопок

        public static readonly Font TitleFont = new Font("Segoe UI", 20, FontStyle.Bold);
        public static readonly Font SubFont = new Font("Segoe UI", 14);
        public static readonly Font InputFont = new Font("Segoe UI", 11);
        public static readonly Font BtnFont = new Font("Segoe UI", 11, FontStyle.Bold);

        static Theme() { SetLight(); }

        public static void SetDark()
        {
            IsDark = true;

            // Фон — тёмно-серый
            Background = Color.FromArgb(38, 38, 42);

            // Карточки — чуть светлее фона
            CardBg = Color.FromArgb(48, 48, 52);

            // Поля — полупрозрачный серый (эмуляция: смешали фон + белый)
            // Если бы поле было реально с alpha=40% белого на фоне 38,38,42 → ~125,125,130
            InputBg = Color.FromArgb(90, 90, 96);
            InputBorder = Color.FromArgb(115, 115, 122);

            // Акцент — светло-серый (не золотой)
            Accent = Color.FromArgb(180, 180, 188);
            AccentHover = Color.FromArgb(210, 210, 218);

            // Текст
            TextMain = Color.FromArgb(235, 235, 238);
            TextMuted = Color.FromArgb(150, 150, 158);

            // Кнопки
            BtnBg = Color.FromArgb(75, 75, 82);
            BtnHover = Color.FromArgb(100, 100, 108);
        }

        public static void SetLight()
        {
            IsDark = false;

            //Background = Color.FromArgb(240, 240, 243);
            //CardBg = Color.FromArgb(255, 255, 255);

            //// Полупрозрачный серый на светлом фоне
            //InputBg = Color.FromArgb(220, 220, 224);
            //InputBorder = Color.FromArgb(190, 190, 196);

            //Accent = Color.FromArgb(120, 120, 130);
            //AccentHover = Color.FromArgb(90, 90, 100);

            //TextMain = Color.FromArgb(30, 30, 35);
            //TextMuted = Color.FromArgb(110, 110, 118);

            //BtnBg = Color.FromArgb(225, 225, 230);
            //BtnHover = Color.FromArgb(205, 205, 212);
            // Фон — почти белый
            Background = Color.FromArgb(250, 250, 252);

            // Карточки — чисто белые
            CardBg = Color.FromArgb(255, 255, 255);

            // Поля ввода — светло-серые, но с чёткой рамкой
            InputBg = Color.FromArgb(235, 235, 238);
            InputBorder = Color.FromArgb(180, 180, 185);

            // Акцент — ТЁМНО-СЕРЫЙ (для заголовка, чтобы был контраст)
            Accent = Color.FromArgb(45, 45, 52);
            AccentHover = Color.FromArgb(20, 20, 25);

            // Текст — почти чёрный
            TextMain = Color.FromArgb(25, 25, 30);
            TextMuted = Color.FromArgb(90, 90, 100);

            // Кнопки — светло-серые с тёмным текстом
            BtnBg = Color.FromArgb(225, 225, 230);
            BtnHover = Color.FromArgb(205, 205, 212);
        }

        public static void Toggle()
        {
            if (IsDark) SetLight(); else SetDark();
            ThemeChanged?.Invoke();
        }

        // ---------- Утилиты стилизации ----------

        public static void StyleTextBox(TextBox tb)
        {
            tb.BackColor = InputBg;
            tb.ForeColor = TextMain;
            tb.Font = InputFont;
            tb.BorderStyle = BorderStyle.FixedSingle;
        }

        public static void StylePrimaryButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = BtnBg;
            btn.ForeColor = TextMain;
            btn.Font = BtnFont;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => btn.BackColor = BtnHover;
            btn.MouseLeave += (s, e) => btn.BackColor = BtnBg;
        }

        public static void StyleAccentButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Accent;
            btn.ForeColor = IsDark ? Color.FromArgb(20, 20, 20) : Color.White;
            btn.Font = BtnFont;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) => btn.BackColor = AccentHover;
            btn.MouseLeave += (s, e) => btn.BackColor = Accent;
        }

        public static void StyleGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = CardBg;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = CardBg;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextMain;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = CardBg;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = TextMain;

            dgv.DefaultCellStyle.BackColor = InputBg;
            dgv.DefaultCellStyle.ForeColor = TextMain;
            dgv.DefaultCellStyle.SelectionBackColor = Accent;
            dgv.DefaultCellStyle.SelectionForeColor = IsDark ? Color.Black : Color.White;

            dgv.GridColor = InputBorder;
        }
        // Свой placeholder: серый текст, который исчезает при фокусе и на вводе
        public static void AttachPlaceholder(TextBox tb, string placeholder, bool isPassword = false)
        {
            // Защита от повторной подписки (если метод вызовут дважды)
            if (tb.Tag is string existing && existing == placeholder)
                return;

            tb.Text = placeholder;
            tb.ForeColor = TextMuted;
            tb.Tag = placeholder;
            tb.UseSystemPasswordChar = false;

            // ИСПОЛЬЗУЕМ Enter/Leave ВМЕСТО GotFocus/LostFocus
            tb.Enter += (s, e) =>
            {
                if (tb.Text == (string)tb.Tag)
                {
                    tb.Text = "";
                    tb.ForeColor = TextMain;
                    if (isPassword) tb.UseSystemPasswordChar = true;
                }
            };

            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = placeholder;
                    tb.ForeColor = TextMuted;
                    if (isPassword) tb.UseSystemPasswordChar = false;
                }
            };

            tb.TextChanged += (s, e) =>
            {
                if (tb.Text != (string)tb.Tag)
                    tb.ForeColor = TextMain;
            };
        }
    }
}

