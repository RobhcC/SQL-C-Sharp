using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Winform_SQLite
{
    public partial class Form1 : Form
    {
        private string dbPath = "D:\\SQLiteData\\device.db";
        private string connectionString;
        private string logFilePath = "D:\\SQLiteData\\log.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
            Log("程序启动");
        }

        // 日志记录方法
        private void Log(string message)
        {
            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            // 写入日志文件
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            // 显示在日志文本框中
            if (txtLog != null && !txtLog.IsDisposed)
            {
                if (txtLog.InvokeRequired)
                {
                    txtLog.Invoke(new Action(() => txtLog.AppendText(logMessage + Environment.NewLine)));
                }
                else
                {
                    txtLog.AppendText(logMessage + Environment.NewLine);
                }
            }
        }

        // 初始化数据库连接
        private void InitializeDatabase()
        {
            try
            {
                // 获取数据库文件所在的文件夹路径
                string folder = Path.GetDirectoryName(dbPath);
                // 检查文件夹是否存在，如果不存在则创建
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                    Log($"创建数据库文件夹: {folder}");
                }
                // 构建数据库连接字符串
                connectionString = $"Data Source={dbPath};";
                Log("数据库初始化完成");
            }
            catch (Exception ex)
            {
                Log($"[错误] 数据库初始化失败: {ex.Message}");
            }
        }

        // 创建Device表并插入示例数据
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Log("开始创建Device表并插入数据...");
                // 使用using语句自动管理数据库连接资源
                using (var conn = new SQLiteConnection(connectionString))
                {
                    // 打开数据库连接
                    conn.Open();
                    Log("数据库连接成功");

                    // 创建Device表（如果不存在）
                    // 设置主键为Id，自动递增且不可为空
                    string createTableSql = @"
                        CREATE TABLE IF NOT EXISTS Device (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Type TEXT,
                            CreateTime DATETIME
                        )";
                    using (var cmd = new SQLiteCommand(createTableSql, conn)) // 创建命令对象
                    {
                        cmd.ExecuteNonQuery(); // 执行命令
                        Log("Device表创建成功");
                    }

                    // 插入一条示例数据
                    string insertSql = @"
                        INSERT INTO Device (Name, Type, CreateTime)
                        VALUES (@name, @type, @time)";
                    using (var cmd = new SQLiteCommand(insertSql, conn))
                    {
                        // 使用参数化查询，防止SQL注入
                        cmd.Parameters.AddWithValue("@name", "温度传感器");
                        cmd.Parameters.AddWithValue("@type", "传感器");
                        cmd.Parameters.AddWithValue("@time", DateTime.Now);
                        cmd.ExecuteNonQuery();
                        Log("插入数据成功: 温度传感器");
                    }

                    // 查询并显示到DataGridView
                    string query = "SELECT * FROM Device";
                    DataTable dt = new DataTable();
                    // 创建DataAdapter数据适配器并填充DataTable
                    using (var adapter = new SQLiteDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }

                    // 将查询结果显示到DataGridView
                    dataGridView1.DataSource = dt;
                    Log($"查询完成，共 {dt.Rows.Count} 条记录");
                }
            }
            catch (Exception ex)
            {
                Log($"[错误] 操作失败: {ex.Message}");
            }
        }

        // 创建设备温度采集历史表
        private void btnCreateTempTable_Click(object sender, EventArgs e)
        {
            try
            {
                Log("开始创建温度采集历史表...");
                // 使用using语句自动管理数据库连接资源
                using (var conn = new SQLiteConnection(connectionString))
                {
                    // 打开数据库连接
                    conn.Open();
                    Log("数据库连接成功");

                    // 创建温度采集历史表（如果不存在）
                    // 设置Id为主键，自动递增
                    string createTableSql = @"
                        CREATE TABLE IF NOT EXISTS TemperatureHistory (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            DeviceName TEXT NOT NULL,
                            Temperature REAL NOT NULL,
                            CollectTime DATETIME NOT NULL,
                            QualityStamp INTEGER DEFAULT 0
                        )";
                    using (var cmd = new SQLiteCommand(createTableSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Log("TemperatureHistory表创建成功");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"[错误] 创建表失败: {ex.Message}");
            }
        }

        // 插入PLC温度采集数据
        private void btnInsertTemp_Click(object sender, EventArgs e)
        {
            try
            {
                Log("开始插入PLC温度采集数据...");
                // 使用using语句自动管理数据库连接资源
                using (var conn = new SQLiteConnection(connectionString))
                {
                    // 打开数据库连接
                    conn.Open();
                    Log("数据库连接成功");

                    // 插入一条PLC温度采集数据
                    // DeviceName为设备名称，Temperature为温度值，CollectTime为采集时间，QualityStamp为质量戳
                    string insertSql = @"
                        INSERT INTO TemperatureHistory (DeviceName, Temperature, CollectTime, QualityStamp)
                        VALUES (@deviceName, @temperature, @collectTime, @qualityStamp)";
                    using (var cmd = new SQLiteCommand(insertSql, conn))
                    {
                        // 使用参数化查询，防止SQL注入
                        cmd.Parameters.AddWithValue("@deviceName", "PLC_01");
                        cmd.Parameters.AddWithValue("@temperature", 25.6);
                        cmd.Parameters.AddWithValue("@collectTime", DateTime.Now);
                        cmd.Parameters.AddWithValue("@qualityStamp", 1);
                        cmd.ExecuteNonQuery();
                        Log("插入数据成功: PLC_01, 温度=25.6");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"[错误] 插入数据失败: {ex.Message}");
            }
        }

        // 更新设备名称
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Log("开始更新设备名称...");
                // 使用using语句自动管理数据库连接资源
                using (var conn = new SQLiteConnection(connectionString))
                {
                    // 打开数据库连接
                    conn.Open();
                    Log("数据库连接成功");

                    // 更新Device表中Id为1的记录的Name字段
                    // UPDATE语句用于修改已有数据
                    string updateSql = @"
                        UPDATE Device 
                        SET Name = @newName 
                        WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(updateSql, conn))
                    {
                        // 使用参数化查询，防止SQL注入
                        cmd.Parameters.AddWithValue("@newName", "更新后的设备名称");
                        cmd.Parameters.AddWithValue("@id", 1);
                        // ExecuteNonQuery返回受影响的行数
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Log($"更新完成，影响 {rowsAffected} 条记录");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"[错误] 更新失败: {ex.Message}");
            }
        }
    }
}
