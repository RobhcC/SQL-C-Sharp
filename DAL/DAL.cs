using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Winform_SQLite.Models;

namespace Winform_SQLite.DAL
{
    public class DAL
    {
        #region 数据库初始化
        private static string dbPath = @"D:\SQLiteData\device.db";
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
            try
            {
                string folder = Path.GetDirectoryName(dbPath);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"数据库初始化失败: {ex.Message}", ex);
            }
        }

        public static SQLiteConnection GetConnection()
        {
            try
            {
                return new SQLiteConnection(ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception($"创建数据库连接失败: {ex.Message}", ex);
            }
        }
        #endregion

        #region Device表操作
        public static void CreateDeviceTable()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"创建Device表失败: {ex.Message}", ex);
            }
        }

        public static int InsertDevice(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device), "设备对象不能为空");
            }

            if (string.IsNullOrEmpty(device.Name))
            {
                throw new ArgumentException("设备名称不能为空", nameof(device.Name));
            }

            try
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
            catch (Exception ex)
            {
                throw new Exception($"插入设备数据失败: {ex.Message}", ex);
            }
        }

        public static int UpdateDevice(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device), "设备对象不能为空");
            }

            try
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
            catch (Exception ex)
            {
                throw new Exception($"更新设备数据失败: {ex.Message}", ex);
            }
        }

        public static int DeleteDevice(int id)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"删除设备数据失败: {ex.Message}", ex);
            }
        }

        public static DataTable GetAllDevices()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"查询设备数据失败: {ex.Message}", ex);
            }
        }

        public static int GetDeviceCount()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Device";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"获取设备数量失败: {ex.Message}", ex);
            }
        }
        #endregion

        #region TemperatureHistory表操作
        public static void CreateTemperatureTable()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"创建TemperatureHistory表失败: {ex.Message}", ex);
            }
        }

        public static int InsertTemperature(TemperatureHistory record)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"插入温度数据失败: {ex.Message}", ex);
            }
        }

        public static DataTable GetAllTemperatures()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"查询温度数据失败: {ex.Message}", ex);
            }
        }

        public static DataTable GetTemperaturesByDeviceName(string deviceName)
        {
            try
            {
                DataTable dt = new DataTable();
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM TemperatureHistory WHERE DeviceName = @deviceName";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@deviceName", deviceName);
                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception($"按设备名称查询温度数据失败: {ex.Message}", ex);
            }
        }

        public static DataTable GetTemperaturesByRange(double minTemp, double maxTemp)
        {
            try
            {
                DataTable dt = new DataTable();
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM TemperatureHistory WHERE Temperature >= @minTemp AND Temperature <= @maxTemp ORDER BY CollectTime DESC";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@minTemp", minTemp);
                        cmd.Parameters.AddWithValue("@maxTemp", maxTemp);
                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception($"按温度范围查询数据失败: {ex.Message}", ex);
            }
        }

        public static int DeleteTemperature(int id)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM TemperatureHistory WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"删除温度数据失败: {ex.Message}", ex);
            }
        }

        public static int GetTemperatureCount()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM TemperatureHistory";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"获取温度数据数量失败: {ex.Message}", ex);
            }
        }
        #endregion
    }
}
