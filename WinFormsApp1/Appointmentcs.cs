using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Appointmentcs
{

    public class Appointment
    {
        public int Id { get; set; }
        public string ClientName { get; set; }   // ФИО
        public string Service { get; set; }      // что хочет клиент
        public decimal Price { get; set; }       // стоимость
        public DateTime Date { get; set; }       // дата записи
        public string Master { get; set; }       // мастер

        public Appointment() { }

        public Appointment(int id, string fio, string service,
                           decimal price, DateTime date, string master)
        {
            Id = id;
            ClientName = fio;
            Service = service;
            Price = price;
            Date = date;
            Master = master;
        }

        public override string ToString()
            => $"{ClientName} | {Service} | {Price}₽ | {Master}";
    }
}
