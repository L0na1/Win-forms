using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Models;
namespace WinFormsApp1.Database
{
    public static class UserRepository
    {

        public static bool Register(User user)
        {
            using var conn = Database.CreateConnection();
            conn.Open();

            // Проверка — логин уже существует?
            using (var check = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE login = @l", conn))
            {
                check.Parameters.AddWithValue("l", user.Login);
                long count = (long)check.ExecuteScalar();
                if (count > 0) return false;
            }

            using (var cmd = new NpgsqlCommand(
                "INSERT INTO users (login, password, first_name, last_name, phone, email) " +
                "VALUES (@l, @p, @f, @ln, @ph, @em)", conn))
            {
                cmd.Parameters.AddWithValue("l", user.Login);
                cmd.Parameters.AddWithValue("p", user.Password);
                cmd.Parameters.AddWithValue("f", user.FirstName ?? "");
                cmd.Parameters.AddWithValue("ln", user.LastName ?? "");
                cmd.Parameters.AddWithValue("ph", user.Phone ?? "");
                cmd.Parameters.AddWithValue("em", user.Email ?? "");
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public static User Authorize(string login, string password)
        {
            using var conn = Database.CreateConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand(
                "SELECT login, password, first_name, last_name, phone, email " +
                "FROM users WHERE login = @l AND password = @p", conn);
            cmd.Parameters.AddWithValue("l", login);
            cmd.Parameters.AddWithValue("p", password);

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;

            return new User(
                r.GetString(0),
                r.GetString(1),
                r.IsDBNull(2) ? "" : r.GetString(2),
                r.IsDBNull(3) ? "" : r.GetString(3),
                r.IsDBNull(4) ? "" : r.GetString(4),
                r.IsDBNull(5) ? "" : r.GetString(5)
            );
        }
    }
}
