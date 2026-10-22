using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using WinFormsApp1.Models;
namespace WinFormsApp1.Database
{
    public static class MasterRepository
    {
        public static List<Master> GetAll()
        {
            var list = new List<Master>();
            using var conn = Database.CreateConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand(
                "SELECT id, full_name, specialty, phone FROM masters ORDER BY full_name", conn);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new Master(
                    r.GetInt32(0),
                    r.GetString(1),
                    r.IsDBNull(2) ? "" : r.GetString(2),
                    r.IsDBNull(3) ? "" : r.GetString(3)
                ));
            }
            return list;
        }

        public static List<string> GetNames()
        {
            var list = new List<string>();
            using var conn = Database.CreateConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT full_name FROM masters ORDER BY full_name", conn);
            using var r = cmd.ExecuteReader();
            while (r.Read()) list.Add(r.GetString(0));
            return list;
        }

        public static void Add(Master m)
        {
            using var conn = Database.CreateConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand(
                "INSERT INTO masters (full_name, specialty, phone) VALUES (@f, @s, @p)", conn);
            cmd.Parameters.AddWithValue("f", m.FullName);
            cmd.Parameters.AddWithValue("s", m.Specialty ?? "");
            cmd.Parameters.AddWithValue("p", m.Phone ?? "");
            cmd.ExecuteNonQuery();
        }

        public static void Update(Master m)
        {
            using var conn = Database.CreateConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand(
                "UPDATE masters SET full_name = @f, specialty = @s, phone = @p WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", m.Id);
            cmd.Parameters.AddWithValue("f", m.FullName);
            cmd.Parameters.AddWithValue("s", m.Specialty ?? "");
            cmd.Parameters.AddWithValue("p", m.Phone ?? "");
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            using var conn = Database.CreateConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand("DELETE FROM masters WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
