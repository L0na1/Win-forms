namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox4
            // 
            textBox4.Location = new Point(223, 136);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Введите номер телефона или почту";
            textBox4.Size = new Size(310, 27);
            textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(223, 189);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Пароль";
            textBox5.Size = new Size(310, 27);
            textBox5.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(274, 251);
            button1.Name = "button1";
            button1.Size = new Size(210, 29);
            button1.TabIndex = 6;
            button1.Text = "Войти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 450);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Name = "Form1";
            Text = "Вход в систему";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button1;
    }
}
