using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Winform_SQLite.Models;

namespace Winform_SQLite.DAL
{
    public class DAL
    {
        private static string dbPath = "D:\\SQLiteData\\device.db";
        private static string connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = $"Data Source={dbPath};";
                }
                return connectionString;
            }
        }

        public static void InitializeDatabase()
        {
            string folder = Path.GetDirectoryName(dbPath);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        // Device相关操作
        public static void CreateDeviceTable()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    CREATE TABLE IF NOT EXISTS Device (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Type TEXT,
                        CreateTime DATETIME
                    )";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int InsertDevice(Device device)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO Device (Name, Type, CreateTime)
                    VALUES (@name, @type, @time)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", device.Name);
                    cmd.Parameters.AddWithValue("@type", device.Type ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@time", device.CreateTime ?? DateTime.Now);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int UpdateDevice(Device device)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    UPDATE Device 
                    SET Name = @name 
                    WHERE Id = @id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", device.Name);
                    cmd.Parameters.AddWithValue("@id", device.Id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int DeleteDevice(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM Device WHERE Id = @id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetAllDevices()
        {
            DataTable dt = new DataTable();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Device";
                using (var adapter = new SQLiteDataAdapter(sql, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // TemperatureHistory相关操作
        public static void CreateTemperatureTable()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    CREATE TABLE IF NOT EXISTS TemperatureHistory (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        DeviceName TEXT NOT NULL,
                        Temperature REAL NOT NULL,
                        CollectTime DATETIME NOT NULL,
                        QualityStamp INTEGER DEFAULT 0
                    )";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int InsertTemperature(TemperatureHistory record)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO TemperatureHistory (DeviceName, Temperature, CollectTime, QualityStamp)
                    VALUES (@deviceName, @temperature, @collectTime, @qualityStamp)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@deviceName", record.DeviceName);
                    cmd.Parameters.AddWithValue("@temperature", record.Temperature);
                    cmd.Parameters.AddWithValue("@collectTime", record.CollectTime);
                    cmd.Parameters.AddWithValue("@qualityStamp", record.QualityStamp);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetAllTemperatures()
        {
            DataTable dt = new DataTable();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM TemperatureHistory";
                using (var adapter = new SQLiteDataAdapter(sql, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}
