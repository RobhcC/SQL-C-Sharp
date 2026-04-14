using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Winform_SQLite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dbPath = "D:\\SQLiteData\\device.db";
            string connectionString = $"Data Source={dbPath};";
            // 创建数据库连接
            using (var conn = new SQLiteConnection(connectionString))
            {
                // 打开数据库连接
                conn.Open();

                // 创建表（如果不存在）设置主键为Id，自动递增且不可为空，Name和Type为文本类型，CreateTime为日期时间类型
                string createTableSql = @"
                    CREATE TABLE IF NOT EXISTS Device (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Type TEXT,
                        CreateTime DATETIME
                    )";
                    // 执行创建表命令
                using (var cmd = new SQLiteCommand(createTableSql, conn))//创建命令对象
                {
                    cmd.ExecuteNonQuery();//执行命令
                }

                // 插入一条示例数据，设置Name为温度传感器，Type为传感器，CreateTime为当前时间
                string insertSql = @"
                    INSERT INTO Device (Name, Type, CreateTime)
                    VALUES (@name, @type, @time)";
                using (var cmd = new SQLiteCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", "温度传感器");
                    cmd.Parameters.AddWithValue("@type", "传感器");
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }

                //  查询并显示到DataGridView
                string query = "SELECT * FROM Device";
                DataTable dt = new DataTable();
                // 创建DataAdapter数据适配器并填充DataTable
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }

                dataGridView1.DataSource = dt;
            }
        }
    }
}
    
