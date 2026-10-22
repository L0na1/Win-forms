using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Models;
using WinFormsApp1.Json;
namespace WinFormsApp1.Data
{
    public class UserStorage
    {
        private const string FileName = "users.json";

        // Ключ = логин. Быстрый поиск O(1).
        public static Dictionary<string, User> Users { get; private set; }
            = new Dictionary<string, User>();

        // ---------- Загрузка из файла ----------
        public static void Load()
        {
            var list = JsonHelper.Load<List<User>>(FileName);

            Users = list
                .Where(u => !string.IsNullOrWhiteSpace(u.Login))
                .GroupBy(u => u.Login)
                .ToDictionary(g => g.Key, g => g.First());

            // Если файла не было — создаём демо-пользователей
            if (Users.Count == 0)
            {
                AddInitialUsers();
                Save();
            }
        }

        // ---------- Сохранение в файл ----------
        public static void Save()
        {
            JsonHelper.Save(FileName, Users.Values.ToList());
        }

        // ---------- Операции ----------
        public static bool Register(User user)
        {
            if (Users.ContainsKey(user.Login)) return false;
            Users[user.Login] = user;
            Save();   // ← автосохранение
            return true;
        }

        public static User Authorize(string login, string password)
        {
            if (Users.TryGetValue(login, out var u) && u.Password == password)
                return u;
            return null;
        }

        // ---------- Демо-данные ----------
        private static void AddInitialUsers()
        {
            Users["Dima"] = new User("Dima", "2548", "Дмитрий", "Смирнов",
                "+79990001122", "dima@barber.ru");
            Users["Max"] = new User("Max", "1111", "Максим", "Иванов",
                "+79990003344", "max@barber.ru");
        }
    }

}
