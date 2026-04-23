using System;
using System.Data;
using Winform_SQLite.DAL;
using Winform_SQLite.Models;

namespace Winform_SQLite.BLL
{
    public class BLL
    {
        #region 事件定义和日志方法
        public event Action<string> OnLog;

        private void Log(string message)
        {
            OnLog?.Invoke(message);
        }
        #endregion

        #region 数据库初始化
        public void InitializeDatabase()
        {
            try
            {
                DAL.DAL.InitializeDatabase();
                Log("数据库初始化完成");
            }
            catch (Exception ex)
            {
                Log($"[错误] 数据库初始化失败: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Device表操作
        public void CreateDeviceTable()
        {
            try
            {
                Log("开始创建Device表...");
                DAL.DAL.CreateDeviceTable();
                Log("Device表创建成功");
            }
            catch (Exception ex)
            {
                Log($"[错误] 创建Device表失败: {ex.Message}");
                throw;
            }
        }

        public void UpdateDeviceName(int id, string newName)
        {
            try
            {
                Log("开始更新设备名称...");
                Device device = new Device { Id = id, Name = newName };
                int rowsAffected = DAL.DAL.UpdateDevice(device);
                Log($"更新完成，影响 {rowsAffected} 条记录");
            }
            catch (Exception ex)
            {
                Log($"[错误] 更新失败: {ex.Message}");
                throw;
            }
        }

        public void DeleteDevice(int id)
        {
            try
            {
                Log("开始删除设备记录...");
                int rowsAffected = DAL.DAL.DeleteDevice(id);
                Log($"删除完成，影响 {rowsAffected} 条记录");
            }
            catch (Exception ex)
            {
                Log($"[错误] 删除失败: {ex.Message}");
                throw;
            }
        }

        public DataTable GetAllDevices()
        {
            try
            {
                return DAL.DAL.GetAllDevices();
            }
            catch (Exception ex)
            {
                Log($"[错误] 查询设备数据失败: {ex.Message}");
                throw;
            }
        }

        public int GetDeviceCount()
        {
            try
            {
                return DAL.DAL.GetDeviceCount();
            }
            catch (Exception ex)
            {
                Log($"[错误] 获取设备数量失败: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region TemperatureHistory表操作
        public void CreateTemperatureTable()
        {
            try
            {
                Log("开始创建温度采集历史表...");
                DAL.DAL.CreateTemperatureTable();
                Log("TemperatureHistory表创建成功");
            }
            catch (Exception ex)
            {
                Log($"[错误] 创建表失败: {ex.Message}");
                throw;
            }
        }

        public void InsertPLCTemperature(string deviceName, double temperature, int qualityStamp)
        {
            try
            {
                Log("开始插入PLC温度采集数据...");
                TemperatureHistory record = new TemperatureHistory
                {
                    DeviceName = deviceName,
                    Temperature = temperature,
                    CollectTime = DateTime.Now,
                    QualityStamp = qualityStamp
                };
                int result = DAL.DAL.InsertTemperature(record);
                Log($"插入数据成功: {deviceName}, 温度={temperature}");
            }
            catch (Exception ex)
            {
                Log($"[错误] 插入数据失败: {ex.Message}");
                throw;
            }
        }

        public DataTable GetAllTemperatures()
        {
            try
            {
                return DAL.DAL.GetAllTemperatures();
            }
            catch (Exception ex)
            {
                Log($"[错误] 查询温度数据失败: {ex.Message}");
                throw;
            }
        }

        public DataTable GetTemperaturesByDeviceName(string deviceName)
        {
            try
            {
                Log($"按设备名查询温度数据: {deviceName}");
                DataTable dt = DAL.DAL.GetTemperaturesByDeviceName(deviceName);
                Log($"查询完成，共 {dt.Rows.Count} 条记录");
                return dt;
            }
            catch (Exception ex)
            {
                Log($"[错误] 查询失败: {ex.Message}");
                throw;
            }
        }

        public DataTable GetTemperaturesByRange(double minTemp, double maxTemp)
        {
            try
            {
                Log($"按温度范围查询: {minTemp}~{maxTemp}");
                DataTable dt = DAL.DAL.GetTemperaturesByRange(minTemp, maxTemp);
                Log($"查询完成，共 {dt.Rows.Count} 条记录");
                return dt;
            }
            catch (Exception ex)
            {
                Log($"[错误] 查询失败: {ex.Message}");
                throw;
            }
        }

        public void DeleteTemperature(int id)
        {
            try
            {
                Log($"开始删除温度记录 ID={id}...");
                int rowsAffected = DAL.DAL.DeleteTemperature(id);
                Log($"删除完成，影响 {rowsAffected} 条记录");
            }
            catch (Exception ex)
            {
                Log($"[错误] 删除失败: {ex.Message}");
                throw;
            }
        }

        public int GetTemperatureCount()
        {
            try
            {
                return DAL.DAL.GetTemperatureCount();
            }
            catch (Exception ex)
            {
                Log($"[错误] 获取温度数据数量失败: {ex.Message}");
                throw;
            }
        }

        public void GetRecordCounts(out int deviceCount, out int tempCount)
        {
            try
            {
                deviceCount = DAL.DAL.GetDeviceCount();
                tempCount = DAL.DAL.GetTemperatureCount();
                Log($"统计完成: 设备 {deviceCount} 条, 温度 {tempCount} 条");
            }
            catch (Exception ex)
            {
                deviceCount = 0;
                tempCount = 0;
                Log($"[错误] 统计失败: {ex.Message}");
                throw;
            }
        }
        #endregion
    }
}
