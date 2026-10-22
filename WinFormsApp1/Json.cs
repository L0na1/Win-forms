using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WinFormsApp1.Json
{
    public static class JsonHelper
    {
        private static string BaseDir => AppDomain.CurrentDomain.BaseDirectory;

        public static string GetPath(string fileName)
            => Path.Combine(BaseDir, fileName);

        // --- Сохранение ---
        public static void Save<T>(string fileName, T data)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,   // красиво форматировать (человекочитаемо)
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    // ↑ чтобы русские буквы не превращались в \u0410\u0411...
                };

                string json = JsonSerializer.Serialize(data, options);
                File.WriteAllText(GetPath(fileName), json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить {fileName}:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Загрузка ---
        public static T Load<T>(string fileName) where T : new()
        {
            try
            {
                string path = GetPath(fileName);
                if (!File.Exists(path)) return new T();   // файла нет — вернём пустой

                string json = File.ReadAllText(path);
                if (string.IsNullOrWhiteSpace(json)) return new T();

                var result = JsonSerializer.Deserialize<T>(json);
                return result ?? new T();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить {fileName}:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new T();
            }
        }
    }
}
