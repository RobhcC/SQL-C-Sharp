using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Winform_SQLite.BLL;

namespace Winform_SQLite
{
    public partial class Form1 : Form
    {
        #region 字段定义
        private BLL.BLL bll = new BLL.BLL();
        private string logFilePath = @"D:\SQLiteData\log.txt";
        #endregion

        #region 构造函数和初始化
        public Form1()
        {
            InitializeComponent();
            InitializeBLL();
            Log("程序启动");
        }

        private void InitializeBLL()
        {
            try
            {
                bll.OnLog += Log;
                bll.InitializeDatabase();
            }
            catch (Exception ex)
            {
                Log($"[错误] BLL初始化失败: {ex.Message}");
            }
        }
        #endregion

        #region 日志方法
        private void Log(string message)
        {
            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            
            try
            {
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch
            {
            }
            
            if (listLog != null && !listLog.IsDisposed)
            {
                if (listLog.InvokeRequired)
                {
                    listLog.Invoke(new Action(() =>
                    {
                        listLog.Items.Add(logMessage);
                        listLog.TopIndex = listLog.Items.Count - 1;
                    }));
                }
                else
                {
                    listLog.Items.Add(logMessage);
                    listLog.TopIndex = listLog.Items.Count - 1;
                }
            }
        }
        #endregion

        #region Device表操作事件
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bll.CreateDeviceTableAndInsertSample();
                dataGridView1.DataSource = bll.GetAllDevices();
            }
            catch (Exception ex)
            {
                Log($"[错误] 创建Device表并插入数据失败: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtDeviceId.Text, out int id))
                {
                    string newName = txtNewDeviceName.Text.Trim();
                    if (!string.IsNullOrEmpty(newName))
                    {
                        bll.UpdateDeviceName(id, newName);
                        dataGridView1.DataSource = bll.GetAllDevices();
                        txtNewDeviceName.Clear();
                    }
                    else
                    {
                        Log("[提示] 设备名称不能为空");
                    }
                }
                else
                {
                    Log("[提示] 请输入有效的设备ID");
                }
            }
            catch (Exception ex)
            {
                Log($"[错误] 更新设备名称失败: {ex.Message}");
            }
        }

        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtDeviceId.Text, out int id))
                {
                    bll.DeleteDevice(id);
                    dataGridView1.DataSource = bll.GetAllDevices();
                }
                else
                {
                    Log("[提示] 请输入有效的设备ID");
                }
            }
            catch (Exception ex)
            {
                Log($"[错误] 删除设备失败: {ex.Message}");
            }
        }

        private void btnQueryAllDevices_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = bll.GetAllDevices();
            }
            catch (Exception ex)
            {
                Log($"[错误] 查询设备数据失败: {ex.Message}");
            }
        }
        #endregion

        #region TemperatureHistory表操作事件
        private void btnCreateTempTable_Click(object sender, EventArgs e)
        {
            try
            {
                bll.CreateTemperatureTable();
            }
            catch (Exception ex)
            {
                Log($"[错误] 创建TemperatureHistory表失败: {ex.Message}");
            }
        }

        private void btnInsertTemp_Click(object sender, EventArgs e)
        {
            try
            {
                bll.InsertPLCTemperature("PLC_01", 25.6, 1);
            }
            catch (Exception ex)
            {
                Log($"[错误] 插入温度数据失败: {ex.Message}");
            }
        }

        private void btnQueryAllTemp_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = bll.GetAllTemperatures();
            }
            catch (Exception ex)
            {
                Log($"[错误] 查询温度数据失败: {ex.Message}");
            }
        }

        private void btnQueryByDevice_Click(object sender, EventArgs e)
        {
            try
            {
                string deviceName = txtDeviceName.Text.Trim();
                if (!string.IsNullOrEmpty(deviceName))
                {
                    dataGridView1.DataSource = bll.GetTemperaturesByDeviceName(deviceName);
                }
                else
                {
                    Log("[提示] 请输入设备名称");
                }
            }
            catch (Exception ex)
            {
                Log($"[错误] 按设备名称查询失败: {ex.Message}");
            }
        }

        private void btnQueryByRange_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(txtMinTemp.Text, out double minTemp) &&
                    double.TryParse(txtMaxTemp.Text, out double maxTemp))
                {
                    dataGridView1.DataSource = bll.GetTemperaturesByRange(minTemp, maxTemp);
                }
                else
                {
                    Log("[提示] 请输入有效的温度范围");
                }
            }
            catch (Exception ex)
            {
                Log($"[错误] 按温度范围查询失败: {ex.Message}");
            }
        }

        private void btnDeleteTemp_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtTempId.Text, out int id))
                {
                    bll.DeleteTemperature(id);
                    dataGridView1.DataSource = bll.GetAllTemperatures();
                }
                else
                {
                    Log("[提示] 请输入有效的温度记录ID");
                }
            }
            catch (Exception ex)
            {
                Log($"[错误] 删除温度数据失败: {ex.Message}");
            }
        }
        #endregion

        #region 统计功能事件
        private void btnStats_Click(object sender, EventArgs e)
        {
            try
            {
                int deviceCount, tempCount;
                bll.GetRecordCounts(out deviceCount, out tempCount);
            }
            catch (Exception ex)
            {
                Log($"[错误] 统计数据失败: {ex.Message}");
            }
        }
        #endregion
    }
}
