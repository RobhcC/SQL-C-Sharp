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
            string dbPath = "device.db";
            string connectionString = $"Data Source={dbPath};";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // 创建表（如果不存在）
                string createTableSql = @"
                    CREATE TABLE IF NOT EXISTS Device (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Type TEXT,
                        CreateTime DATETIME
                    )";
                using (var cmd = new SQLiteCommand(createTableSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // 插入一条示例数据
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
                using (var adapter = new SQLiteDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }

                dataGridView1.DataSource = dt;
            }
        }
    }
}
    
