using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Appointmentcs;
using WinFormsApp1.Json;

namespace WinFormsApp1.Data
{
    public  class AppointmentStorage
    {

        private const string FileName = "appointments.json";

        private static List<Appointment> _items = new List<Appointment>();
        private static int _nextId = 1;

        public static IReadOnlyList<Appointment> All => _items;

        // ---------- Загрузка ----------
        public static void Load()
        {
            _items = JsonHelper.Load<List<Appointment>>(FileName) ?? new List<Appointment>();

            // восстанавливаем _nextId = max(Id) + 1
            _nextId = _items.Count > 0 ? _items.Max(x => x.Id) + 1 : 1;

            // Если файла не было — создаём демо
            if (_items.Count == 0)
            {
                AddInitialAppointments();
                Save();
            }
        }

        // ---------- Сохранение ----------
        public static void Save()
        {
            JsonHelper.Save(FileName, _items);
        }

        // ---------- Операции ----------
        public static void Add(Appointment a)
        {
            a.Id = _nextId++;
            _items.Add(a);
            Save();
        }

        public static void Update(Appointment a)
        {
            var old = _items.FirstOrDefault(x => x.Id == a.Id);
            if (old == null) return;
            old.ClientName = a.ClientName;
            old.Service = a.Service;
            old.Price = a.Price;
            old.Date = a.Date;
            old.Master = a.Master;
            Save();
        }

        public static void Delete(int id)
        {
            _items.RemoveAll(x => x.Id == id);
            Save();
        }

        public static List<Appointment> ByDate(DateTime date)
            => _items.Where(x => x.Date.Date == date.Date)
                     .OrderBy(x => x.Master).ToList();

        // ---------- Демо ----------
        private static void AddInitialAppointments()
        {
            var today = DateTime.Today;
            _items.Add(new Appointment(_nextId++, "Иванов Иван Иванович", "Стрижка + борода",
                1500m, today, "Дмитрий"));
            _items.Add(new Appointment(_nextId++, "Петров Пётр", "Бритьё головы",
                800m, today, "Максим"));
            _items.Add(new Appointment(_nextId++, "Сидорова Анна", "Окрашивание",
                3500m, today.AddDays(1), "Дмитрий"));
        }

    }
}

