using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class MasterForm : Form
    {
        private int _selectedId = -1;
        public MasterForm()
        {
            InitializeComponent();

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            dgv.SelectionChanged += Dgv_SelectionChanged;

            Theme.ThemeChanged += ApplyTheme;
            FormClosed += (s, e) => Theme.ThemeChanged -= ApplyTheme;

            ApplyTheme();
            LoadMasters();
        }

        private void ApplyTheme()
        {
            BackColor = Theme.Background;
            ForeColor = Theme.TextMain;

            lblTitle.ForeColor = Theme.Accent;
            lblName.ForeColor = Theme.TextMuted;
            lblSpecialty.ForeColor = Theme.TextMuted;
            lblPhone.ForeColor = Theme.TextMuted;

            Theme.StyleTextBox(txtName);
            Theme.StyleTextBox(txtSpecialty);
            Theme.StyleTextBox(txtPhone);

            Theme.StylePrimaryButton(btnAdd);
            Theme.StylePrimaryButton(btnUpdate);
            Theme.StylePrimaryButton(btnDelete);

            Theme.StyleGrid(dgv);
        }

        private void LoadMasters()
        {
            dgv.DataSource = null;
            dgv.DataSource = MasterStorage.All.ToList();

            if (dgv.Columns["Id"] != null) dgv.Columns["Id"].Visible = false;
            if (dgv.Columns["FullName"] != null) dgv.Columns["FullName"].HeaderText = "ФИО";
            if (dgv.Columns["Specialty"] != null) dgv.Columns["Specialty"].HeaderText = "Специализация";
            if (dgv.Columns["Phone"] != null) dgv.Columns["Phone"].HeaderText = "Телефон";
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            { MessageBox.Show("Введите ФИО мастера"); txtName.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtSpecialty.Text))
            { MessageBox.Show("Введите специализацию"); txtSpecialty.Focus(); return false; }
            return true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!Validate()) return;
            MasterStorage.Add(new Master(0,
                txtName.Text.Trim(), txtSpecialty.Text.Trim(), txtPhone.Text.Trim()));
            LoadMasters();
            ClearForm();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedId < 0) { MessageBox.Show("Выберите мастера в таблице"); return; }
            if (!Validate()) return;
            MasterStorage.Update(new Master(_selectedId,
                txtName.Text.Trim(), txtSpecialty.Text.Trim(), txtPhone.Text.Trim()));
            LoadMasters();
            ClearForm();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId < 0) { MessageBox.Show("Выберите мастера в таблице"); return; }
            if (MessageBox.Show("Удалить мастера?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            MasterStorage.Delete(_selectedId);
            LoadMasters();
            ClearForm();
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var m = dgv.CurrentRow.DataBoundItem as Master;
            if (m == null) return;

            _selectedId = m.Id;
            txtName.Text = m.FullName;
            txtSpecialty.Text = m.Specialty;
            txtPhone.Text = m.Phone;
        }

        private void ClearForm()
        {
            _selectedId = -1;
            txtName.Clear();
            txtSpecialty.Clear();
            txtPhone.Clear();
            dgv.ClearSelection();
        }
    }
}
