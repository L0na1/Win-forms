using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Json;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    internal class MasterStorage
    {
        private const string FileName = "masters.json";

        private static List<Master> _items = new List<Master>();
        private static int _nextId = 1;

        public static IReadOnlyList<Master> All => _items;

        // ---------- Загрузка ----------
        public static void Load()
        {
            _items = JsonHelper.Load<List<Master>>(FileName) ?? new List<Master>();
            _nextId = _items.Count > 0 ? _items.Max(m => m.Id) + 1 : 1;

            // Если файла не было — создаём демо-мастеров
            if (_items.Count == 0)
            {
                _items.Add(new Master(_nextId++, "Дмитрий Смирнов", "Стрижка", "+79990001122"));
                _items.Add(new Master(_nextId++, "Максим Иванов", "Бритьё", "+79990003344"));
                _items.Add(new Master(_nextId++, "Александр Петров", "Окрашивание", "+79990005566"));
                Save();
            }
        }

        // ---------- Сохранение ----------
        public static void Save()
        {
            JsonHelper.Save(FileName, _items);
        }

        // ---------- Операции ----------
        public static void Add(Master m)
        {
            m.Id = _nextId++;
            _items.Add(m);
            Save();
        }

        public static void Update(Master m)
        {
            var old = _items.FirstOrDefault(x => x.Id == m.Id);
            if (old == null) return;
            old.FullName = m.FullName;
            old.Specialty = m.Specialty;
            old.Phone = m.Phone;
            Save();
        }

        public static void Delete(int id)
        {
            _items.RemoveAll(x => x.Id == id);
            Save();
        }

        // Список имён — для ComboBox в Form2
        public static List<string> GetNames()
            => _items.Select(m => m.FullName).ToList();
    }
}
