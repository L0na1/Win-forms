using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using WinFormsApp1.Appointmentcs;
namespace WinFormsApp1.Database
{
    public static class AppointmentRepository
    {
        public static List<Appointment> GetAll()
        {
            var list = new List<Appointment>();
            using var conn = Database.CreateConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand(
                "SELECT id, client_name, service, price, date, master FROM appointments ORDER BY date", conn);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new Appointment(
                    r.GetInt32(0),
                    r.GetString(1),
                    r.IsDBNull(2) ? "" : r.GetString(2),
                    r.IsDBNull(3) ? 0m : r.GetDecimal(3),
                    r.GetDateTime(4),
                    r.IsDBNull(5) ? "" : r.GetString(5)
                ));
            }
            return list;
        }

        public static List<Appointment> ByDate(DateTime date)
        {
            var list = new List<Appointment>();
            using var conn = Database.CreateConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand(
                "SELECT id, client_name, service, price, date, master " +
                "FROM appointments WHERE date = @d ORDER BY master", conn);
            cmd.Parameters.AddWithValue("d", date.Date);

            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new Appointment(
                    r.GetInt32(0),
                    r.GetString(1),
                    r.IsDBNull(2) ? "" : r.GetString(2),
                    r.IsDBNull(3) ? 0m : r.GetDecimal(3),
                    r.GetDateTime(4),
                    r.IsDBNull(5) ? "" : r.GetString(5)
                ));
            }
            return list;
        }

        public static void Add(Appointment a)
        {
            using var conn = Database.CreateConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand(
                "INSERT INTO appointments (client_name, service, price, date, master) " +
                "VALUES (@c, @s, @p, @d, @m)", conn);
            cmd.Parameters.AddWithValue("c", a.ClientName);
            cmd.Parameters.AddWithValue("s", a.Service ?? "");
            cmd.Parameters.AddWithValue("p", a.Price);
            cmd.Parameters.AddWithValue("d", a.Date.Date);
            cmd.Parameters.AddWithValue("m", a.Master ?? "");
            cmd.ExecuteNonQuery();
        }

        public static void Update(Appointment a)
        {
            using var conn = Database.CreateConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand(
                "UPDATE appointments SET client_name=@c, service=@s, price=@p, date=@d, master=@m " +
                "WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("id", a.Id);
            cmd.Parameters.AddWithValue("c", a.ClientName);
            cmd.Parameters.AddWithValue("s", a.Service ?? "");
            cmd.Parameters.AddWithValue("p", a.Price);
            cmd.Parameters.AddWithValue("d", a.Date.Date);
            cmd.Parameters.AddWithValue("m", a.Master ?? "");
            cmd.ExecuteNonQuery();
        }

        public static void Delete(int id)
        {
            using var conn = Database.CreateConnection();
            conn.Open();

            using var cmd = new NpgsqlCommand("DELETE FROM appointments WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
    }
}