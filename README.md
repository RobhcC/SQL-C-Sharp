# Winform_SQLite 学习项目

## 项目简介
这是一个基于 C# Windows Forms 的 SQLite 数据库学习项目，用于练习 SQL 基础操作和参数化查询。

## 功能说明
- 自动创建数据库文件夹和文件（D:\SQLiteData\device.db）
- 创建 Device 表并插入示例数据
- 创建温度采集历史表（TemperatureHistory）
- 插入 PLC 温度采集数据
- 更新设备名称
- 实时日志显示和日志文件记录
- 完善的异常处理机制
- 支持参数化查询，防止 SQL 注入

## 技术栈
- C#
- Windows Forms
- SQLite 数据库
- .NET Framework

## 项目结构
```
Winform_SQLite/
├── Properties/          # 项目属性文件
├── Form1.cs             # 主窗体代码
├── Form1.Designer.cs    # 窗体设计文件
├── Form1.resx           # 窗体资源文件
├── Program.cs           # 程序入口
├── Winform_SQLite.csproj # 项目文件
├── Winform_SQLite.slnx  # 解决方案文件
├── packages.config      # 包配置文件
└── README.md            # 项目说明文件
```

## 如何运行
1. 打开 Visual Studio
2. 加载 Winform_SQLite.slnx 解决方案
3. 运行项目（F5 或点击运行按钮）
4. 在弹出的窗体中点击相应按钮执行操作

## 功能模块

### 1. 基本操作
- **创建Device表并插入数据**：创建设备表并插入示例数据
- **创建温度采集历史表**：创建用于存储温度采集数据的表
- **插入PLC温度采集数据**：向温度表中插入模拟的PLC温度数据
- **更新设备名称**：使用UPDATE语句修改设备名称

### 2. 日志功能
- **实时日志显示**：右侧黑色区域实时显示操作日志
- **日志文件记录**：日志自动保存到 `D:\SQLiteData\log.txt`
- **异常捕获**：所有操作都有try-catch异常处理

### 3. 数据展示
- **DataGridView**：显示查询结果
- **日志文本框**：显示操作日志和错误信息

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

## 日志功能说明

### 日志格式
```
[2026-04-14 10:30:45] 程序启动
[2026-04-14 10:30:47] 数据库初始化完成
[2026-04-14 10:30:50] 开始创建Device表并插入数据...
[2026-04-14 10:30:50] 数据库连接成功
[2026-04-14 10:30:50] Device表创建成功
[2026-04-14 10:30:50] 插入数据成功: 温度传感器
[2026-04-14 10:30:50] 查询完成，共 1 条记录
```

### 日志特点
- **双重记录**：同时显示在界面和保存到文件
- **时间戳**：每条日志都有精确的时间记录
- **异常捕获**：错误信息会被完整记录
- **线程安全**：支持跨线程调用

## 学习目标
- 掌握 C# 中 SQLite 数据库的连接和操作
- 学习 SQL 基础语法（CREATE TABLE、INSERT、UPDATE、SELECT）
- 理解参数化查询的重要性（防止 SQL 注入）
- 学习 Windows Forms 中 DataGridView 的使用
- 掌握 using 语句的正确使用方式（自动管理资源）
- 学习日志记录和异常处理的最佳实践

## 注意事项
- 数据库文件存储在 `D:\SQLiteData\device.db`
- 日志文件存储在 `D:\SQLiteData\log.txt`
- 程序会自动创建数据库文件夹（如果不存在）
- 所有数据库操作都有异常处理，不会导致程序崩溃

## 许可证
MIT License

## 贡献
欢迎提交 Issue 和 Pull Request 来改进这个项目！

## 作者
学习项目 - SQLite 基础练习

---

### 第1天学习内容
- SQL 基础概念
- 增删改查操作
- 参数化查询
- 工控场景 SQL 语句练习
- 日志记录和异常处理
