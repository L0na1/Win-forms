using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Master
    {
        public int Id { get; set; }
        public string FullName { get; set; }    // ФИО мастера
        public string Specialty { get; set; }   // специализация (Стрижка, Бритьё, Окрашивание)
        public string Phone { get; set; }       // телефон

        public Master() { }

        public Master(int id, string fullName, string specialty, string phone)
        {
            Id = id;
            FullName = fullName;
            Specialty = specialty;
            Phone = phone;
        }

        // Чтобы ComboBox показывал имя мастера
        public override string ToString() => FullName;
    }
}
