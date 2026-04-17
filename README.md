# Winform_SQLite 学习项目

## 项目简介
这是一个基于 C# Windows Forms 的 SQLite 数据库学习项目，采用简化的三层架构，用于练习 SQL 基础操作和参数化查询。

## 功能说明
- 自动创建数据库文件夹和文件（D:\SQLiteData\device.db）
- 创建 Device 表并插入示例数据
- 创建温度采集历史表（TemperatureHistory）
- 插入 PLC 温度采集数据
- 更新/删除设备记录
- 条件查询（按设备名、按温度范围）
- 统计记录数量
- 实时日志显示和日志文件记录
- 完善的异常处理机制
- 支持参数化查询，防止 SQL 注入

## 技术栈
- C#
- Windows Forms
- SQLite 数据库
- .NET Framework 4.6

## 项目结构
```
Winform_SQLite/
├── Models/                     # 模型层
│   ├── Device.cs              # 设备模型
│   └── TemperatureHistory.cs  # 温度历史模型
├── DAL/                        # 数据访问层
│   └── DAL.cs                 # 数据库操作类
├── BLL/                        # 业务逻辑层
│   └── BLL.cs                 # 业务逻辑类
├── Form1.cs                    # UI层 - 界面交互
├── Form1.Designer.cs           # 窗体设计文件
├── Program.cs                  # 程序入口
└── README.md                   # 项目说明文件
```

## 架构说明

### 三层架构
| 层 | 文件 | 职责 |
|---|------|------|
| Models | Device.cs, TemperatureHistory.cs | 数据模型定义 |
| DAL | DAL.cs | 数据库操作（CRUD） |
| BLL | BLL.cs | 业务逻辑处理 |
| UI | Form1.cs | 界面交互 |

### 各层职责
- **Models层**：定义数据模型，对应数据库表结构
- **DAL层**：封装所有数据库操作，包括连接管理、SQL执行
- **BLL层**：处理业务逻辑，调用DAL层方法，处理异常
- **UI层**：只负责界面交互，调用BLL层方法

## 如何运行
1. 打开 Visual Studio
2. 加载 Winform_SQLite.slnx 解决方案
3. 运行项目（F5 或点击运行按钮）
4. 在弹出的窗体中点击相应按钮执行操作

## 功能模块

### 1. 设备操作
- **创建Device表并插入数据**：创建设备表并插入示例数据
- **查询所有设备**：查询Device表所有记录并显示在DataGridView
- **更新设备名称**：使用UPDATE语句修改设备名称
- **删除设备**：输入设备ID，使用DELETE语句删除记录

### 2. 温度操作
- **创建温度采集历史表**：创建用于存储温度采集数据的表
- **插入温度数据**：向温度表中插入模拟的PLC温度数据
- **查询所有温度**：查询TemperatureHistory表所有记录
- **删除温度记录**：输入记录ID，删除指定温度记录

### 3. 条件查询
- **按设备名查询**：使用 WHERE DeviceName = @deviceName 条件查询
- **按温度范围查询**：使用 WHERE Temperature >= @min AND Temperature <= @max 范围查询
- **统计记录数**：使用 COUNT(*) 聚合函数统计各表记录数

### 4. 日志功能
- **实时日志显示**：窗体下方显示操作日志
- **日志文件记录**：日志自动保存到 `D:\SQLiteData\log.txt`
- **异常捕获**：所有操作都有try-catch异常处理

## 数据库设计

### Device表
| 字段名 | 数据类型 | 约束 | 描述 |
|--------|---------|------|------|
| Id | INTEGER | PRIMARY KEY AUTOINCREMENT | 设备ID |
| Name | TEXT | NOT NULL | 设备名称 |
| Type | TEXT | | 设备类型 |
| CreateTime | DATETIME | | 创建时间 |

### TemperatureHistory表
| 字段名 | 数据类型 | 约束 | 描述 |
|--------|---------|------|------|
| Id | INTEGER | PRIMARY KEY AUTOINCREMENT | 记录ID |
| DeviceName | TEXT | NOT NULL | 设备名称 |
| Temperature | REAL | NOT NULL | 温度值 |
| CollectTime | DATETIME | NOT NULL | 采集时间 |
| QualityStamp | INTEGER | DEFAULT 0 | 质量戳 |

## SQL语句学习要点

### 条件查询（WHERE）
```sql
-- 精确匹配
SELECT * FROM TemperatureHistory WHERE DeviceName = 'PLC_01'

-- 范围查询
SELECT * FROM TemperatureHistory WHERE Temperature >= 20 AND Temperature <= 30

-- 排序
SELECT * FROM TemperatureHistory ORDER BY CollectTime DESC
```

### 删除操作（DELETE）
```sql
DELETE FROM Device WHERE Id = 1
DELETE FROM TemperatureHistory WHERE Id = 1
```

### 聚合函数
```sql
SELECT COUNT(*) FROM Device
SELECT COUNT(*) FROM TemperatureHistory
```

### 参数化查询（防止SQL注入）
```csharp
// 错误写法 - 有SQL注入风险
string sql = $"SELECT * FROM Device WHERE Name = '{name}'";

// 正确写法 - 使用参数化查询
string sql = "SELECT * FROM Device WHERE Name = @name";
cmd.Parameters.AddWithValue("@name", name);
```

## 日志功能说明

### 日志格式
```
[2026-04-14 10:30:45] 程序启动
[2026-04-14 10:30:47] 数据库初始化完成
[2026-04-14 10:30:50] 按设备名查询温度数据: PLC_01
[2026-04-14 10:30:50] 查询完成，共 5 条记录
[2026-04-14 10:30:55] 统计完成: 设备 3 条, 温度 10 条
```

### 日志特点
- **双重记录**：同时显示在界面和保存到文件
- **时间戳**：每条日志都有精确的时间记录
- **异常捕获**：错误信息会被完整记录
- **线程安全**：支持跨线程调用

## 学习目标
- 掌握 C# 中 SQLite 数据库的连接和操作
- 学习 SQL 基础语法（CREATE TABLE、INSERT、UPDATE、DELETE、SELECT）
- 学习条件查询（WHERE、ORDER BY）
- 学习聚合函数（COUNT）
- 理解参数化查询的重要性（防止 SQL 注入）
- 学习 Windows Forms 中 DataGridView 的使用
- 掌握 using 语句的正确使用方式（自动管理资源）
- 学习日志记录和异常处理的最佳实践
- 理解三层架构的基本概念

## 注意事项
- 数据库文件存储在 `D:\SQLiteData\device.db`
- 日志文件存储在 `D:\SQLiteData\log.txt`
- 程序会自动创建数据库文件夹（如果不存在）
- 所有数据库操作都有异常处理，不会导致程序崩溃
- 删除操作不可逆，请谨慎操作

## 许可证
MIT License

## 作者
学习项目 - SQLite 基础练习

---

### 第1天学习内容
- SQL 基础概念
- 增删改查操作
- 参数化查询
- 工控场景 SQL 语句练习
- 日志记录和异常处理
- 三层架构基础

### 第2天学习内容
- WHERE 条件查询
- 范围查询（BETWEEN / >= AND <=）
- ORDER BY 排序
- DELETE 删除操作
- COUNT 聚合函数
- ExecuteScalar 方法（返回单个值）
- GroupBox 分组布局
- out 参数传递
