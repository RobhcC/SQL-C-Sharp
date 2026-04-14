using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Winform_SQLite.BLL;

namespace Winform_SQLite
{
    public partial class Form1 : Form
    {
        private BLL.BLL bll = new BLL.BLL();
        private string logFilePath = "D:\\SQLiteData\\log.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeBLL();
            Log("程序启动");
        }

        private void InitializeBLL()
        {
            bll.OnLog += Log;
            bll.InitializeDatabase();
        }

        private void Log(string message)
        {
            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bll.CreateDeviceTableAndInsertSample();
                dataGridView1.DataSource = bll.GetAllDevices();
            }
            catch { }
        }

        private void btnCreateTempTable_Click(object sender, EventArgs e)
        {
            try
            {
                bll.CreateTemperatureTable();
            }
            catch { }
        }

        private void btnInsertTemp_Click(object sender, EventArgs e)
        {
            try
            {
                bll.InsertPLCTemperature("PLC_01", 25.6, 1);
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bll.UpdateDeviceName(1, "更新后的设备名称");
            }
            catch { }
        }
    }
}
