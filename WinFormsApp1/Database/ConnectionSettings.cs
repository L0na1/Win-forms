using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace WinFormsApp1.Database
{
    public class ConnectionSettings
    {
        public string Host { get; set; } = "localhost";
        public int Port { get; set; } = 5432;
        public string Database { get; set; } = "barbershop";
        public string User { get; set; } = "postgres";
        public string Password { get; set; } = "";
        public bool Remember { get; set; } = false;

        // Сохраняем в AppData (в папку C:\Users\ТвоеИмя\AppData\Roaming\BarberShop)
        private static string FolderPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BarberShop");
        private static string FilePath => Path.Combine(FolderPath, "settings.json");

        public static ConnectionSettings Load()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    return JsonSerializer.Deserialize<ConnectionSettings>(json) ?? new ConnectionSettings();
                }
            }
            catch { }
            return new ConnectionSettings();
        }

        public void Save()
        {
            try
            {
                // Создаем папку, если ее нет
                if (!Directory.Exists(FolderPath))
                    Directory.CreateDirectory(FolderPath);

                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(this, options);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }
    }
}
