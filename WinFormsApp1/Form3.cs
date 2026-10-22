using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Database;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {

            InitializeComponent();
            monthCalendar.DateChanged += (s, e) => LoadForDate(monthCalendar.SelectionStart);
            btnTheme.Click += (s, e) => Theme.Toggle();

            Theme.ThemeChanged += ApplyTheme;
            FormClosed += (s, e) => Theme.ThemeChanged -= ApplyTheme;

            ApplyTheme();
            LoadForDate(monthCalendar.SelectionStart);
        }

        private void ApplyTheme()
        {
            BackColor = Theme.Background;
            ForeColor = Theme.TextMain;
            lblTitle.ForeColor = Theme.Accent;

            monthCalendar.BackColor = Theme.Background;
            monthCalendar.ForeColor = Theme.TextMain;
            monthCalendar.TitleBackColor = Theme.CardBg;
            monthCalendar.TitleForeColor = Theme.TextMain;
            monthCalendar.TrailingForeColor = Theme.TextMuted;

            Theme.StyleGrid(dgv);
            Theme.StylePrimaryButton(btnTheme);
            btnTheme.Text = Theme.IsDark ? "🌙 Тема" : "☀ Тема";
        }

        private void LoadForDate(DateTime date)
        {
            try
            {
                dgv.DataSource = null;
                // ← ЗАМЕНА: AppointmentStorage.ByDate → AppointmentRepository.ByDate
                dgv.DataSource = AppointmentRepository.ByDate(date);

                if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;
                if (dgv.Columns["ClientName"] != null) dgv.Columns["ClientName"].HeaderText = "ФИО";
                if (dgv.Columns["Service"] != null) dgv.Columns["Service"].HeaderText = "Услуга";
                if (dgv.Columns["Price"] != null) dgv.Columns["Price"].HeaderText = "Стоимость";
                if (dgv.Columns["Date"] != null) dgv.Columns["Date"].HeaderText = "Дата";
                if (dgv.Columns["Master"] != null) dgv.Columns["Master"].HeaderText = "Мастер";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка БД: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        } 
    }
}

