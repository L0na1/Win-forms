using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Data;
using WinFormsApp1.Models;
using WinFormsApp1.Appointmentcs;
namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private User _user;
        private int _selectedId = -1;
        private static bool IsInDesignMode
    => System.ComponentModel.LicenseManager.UsageMode
       == System.ComponentModel.LicenseUsageMode.Designtime;
        public Form2(User user)
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.None;
            _user = user;

            if (IsInDesignMode) return;   // ← защита дизайнера

            // --- CRUD записи ---
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;

            // --- Открытие других форм ---
            btnToCalendar.Click += (s, e) => new Form3().Show();

            btnMasters.Click += (s, e) =>
            {
                using (var mf = new MasterForm())
                {
                    mf.ShowDialog(this);
                }
                ReloadMasters();   // после закрытия — обновить ComboBox
            };

            // --- Смена темы ---
            btnTheme.Click += (s, e) => Theme.Toggle();

            // --- Выбор записи в таблице ---
            dgv.SelectionChanged += Dgv_SelectionChanged;

            // --- Тема ---
            Theme.ThemeChanged += ApplyTheme;
            FormClosed += (s, e) => Theme.ThemeChanged -= ApplyTheme;

            // --- Заполнить ComboBox мастеров и применить тему ---
            ReloadMasters();
            ApplyTheme();
            LoadAppointments();
        }

        // ---------- Мастера: обновить ComboBox ----------
        private void ReloadMasters()
        {
            string current = cmbMaster.SelectedItem?.ToString();

            cmbMaster.Items.Clear();
            foreach (var name in MasterStorage.GetNames())
                cmbMaster.Items.Add(name);

            // Восстановить выбор, если мастер ещё существует
            if (!string.IsNullOrEmpty(current) && cmbMaster.Items.Contains(current))
                cmbMaster.SelectedItem = current;
        }

        // ---------- Тема ----------
        private void ApplyTheme()
        {
            BackColor = Theme.Background;
            ForeColor = Theme.TextMain;

            foreach (var lbl in new[] { lblFio, lblService, lblPrice, lblDate, lblMaster })
                lbl.ForeColor = Theme.TextMuted;
            lblTitle.ForeColor = Theme.Accent;

            Theme.StyleTextBox(txtFio);
            Theme.StyleTextBox(txtService);
            Theme.StyleTextBox(txtPrice);

            dtpDate.CalendarMonthBackground = Theme.CardBg;
            dtpDate.CalendarForeColor = Theme.TextMain;
            dtpDate.BackColor = Theme.InputBg;
            dtpDate.ForeColor = Theme.TextMain;

            cmbMaster.BackColor = Theme.InputBg;
            cmbMaster.ForeColor = Theme.TextMain;
            cmbMaster.FlatStyle = FlatStyle.Flat;

            Theme.StylePrimaryButton(btnAdd);
            Theme.StylePrimaryButton(btnUpdate);
            Theme.StylePrimaryButton(btnDelete);
            Theme.StyleAccentButton(btnToCalendar);
            Theme.StyleAccentButton(btnMasters);    // ← стилизуем новую кнопку
            Theme.StylePrimaryButton(btnTheme);

            btnTheme.Text = Theme.IsDark ? "🌙 Тема" : "☀ Тема";

            Theme.StyleGrid(dgv);
        }

        // ---------- Таблица записей ----------
        private void LoadAppointments()
        {
            dgv.DataSource = null;
            dgv.DataSource = AppointmentStorage.All.ToList();

            if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;
            if (dgv.Columns["ClientName"] != null) dgv.Columns["ClientName"].HeaderText = "ФИО";
            if (dgv.Columns["Service"] != null) dgv.Columns["Service"].HeaderText = "Услуга";
            if (dgv.Columns["Price"] != null) dgv.Columns["Price"].HeaderText = "Стоимость";
            if (dgv.Columns["Date"] != null) dgv.Columns["Date"].HeaderText = "Дата";
            if (dgv.Columns["Master"] != null) dgv.Columns["Master"].HeaderText = "Мастер";
        }

        // ---------- Валидация ----------
        private bool Validate(out decimal price)
        {
            price = 0;
            if (string.IsNullOrWhiteSpace(txtFio.Text))
            { MessageBox.Show("Введите ФИО клиента"); txtFio.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtService.Text))
            { MessageBox.Show("Введите услугу"); txtService.Focus(); return false; }
            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0)
            { MessageBox.Show("Стоимость — положительное число"); txtPrice.Focus(); return false; }
            if (cmbMaster.SelectedIndex < 0)
            { MessageBox.Show("Выберите мастера"); cmbMaster.Focus(); return false; }
            return true;
        }

        // ---------- CRUD ----------
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!Validate(out decimal price)) return;
            AppointmentStorage.Add(new Appointment(
                0, txtFio.Text.Trim(), txtService.Text.Trim(),
                price, dtpDate.Value.Date, cmbMaster.SelectedItem.ToString()));
            LoadAppointments();
            ClearForm();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedId < 0) { MessageBox.Show("Выберите запись в таблице"); return; }
            if (!Validate(out decimal price)) return;
            AppointmentStorage.Update(new Appointment(
                _selectedId, txtFio.Text.Trim(), txtService.Text.Trim(),
                price, dtpDate.Value.Date, cmbMaster.SelectedItem.ToString()));
            LoadAppointments();
            ClearForm();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId < 0) { MessageBox.Show("Выберите запись в таблице"); return; }
            if (MessageBox.Show("Удалить запись?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            AppointmentStorage.Delete(_selectedId);
            LoadAppointments();
            ClearForm();
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var a = dgv.CurrentRow.DataBoundItem as Appointment;
            if (a == null) return;

            _selectedId = a.Id;
            txtFio.Text = a.ClientName;
            txtService.Text = a.Service;
            txtPrice.Text = a.Price.ToString();
            dtpDate.Value = a.Date;
            cmbMaster.SelectedItem = a.Master;
        }

        private void ClearForm()
        {
            _selectedId = -1;
            txtFio.Clear();
            txtService.Clear();
            txtPrice.Clear();
            cmbMaster.SelectedIndex = -1;
            dgv.ClearSelection();
        }

    }

}


