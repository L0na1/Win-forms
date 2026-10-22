
using WinFormsApp1.Database;
using WinFormsApp1.Models;
namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Загружаем сохранённые настройки
            var settings = ConnectionSettings.Load();

            // 2. Если стоит галочка "Запомнить" и есть пароль — пробуем подключиться сразу
            if (settings.Remember && !string.IsNullOrEmpty(settings.Password))
            {
                try
                {
                    // Пробуем установить соединение (ВОТ ЗДЕСЬ ДОБАВИЛСЯ .SetConnection)
                    Database.Database.SetConnection(settings.Host, settings.Port, settings.Database, settings.User, settings.Password);

                    // Если всё ок — сразу запускаем вход
                    Application.Run(new Form1());
                    return; // Завершаем Main, чтобы не запускать ConnectionForm
                }
                catch
                {
                    // Если подключиться не удалось (например, БД выключена) — 
                    // идём дальше и показываем форму подключения
                }
            }

            // 3. Если галочки нет или подключение не удалось — показываем форму подключения
            Application.Run(new ConnectionForm());
        }

    
    }
}