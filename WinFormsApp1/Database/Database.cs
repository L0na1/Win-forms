using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
namespace WinFormsApp1.Database
{
    public static class Database
    {
        public static string ConnectionString { get; private set; }

        public static bool IsConnected => !string.IsNullOrEmpty(ConnectionString);

        // Установить подключение
        public static void SetConnection(string host, int port, string db,
                                         string user, string password)
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = host,
                Port = port,
                Database = db,
                Username = user,
                Password = password,
                Timeout = 5,
                CommandTimeout = 5
            };

            ConnectionString = builder.ConnectionString;

            // Проверка — реально ли подключается
            using var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            // если не упало — всё ок
        }

        public static NpgsqlConnection CreateConnection()
        {
            if (!IsConnected)
                throw new InvalidOperationException("Нет подключения к базе данных.");
            return new NpgsqlConnection(ConnectionString);
        }

    }
}
