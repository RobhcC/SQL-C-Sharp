# Winform_SQLite 学习项目

## 项目简介
这是一个基于 C# Windows Forms 的 SQLite 数据库学习项目，用于练习 SQL 基础操作和参数化查询。

## 功能说明
- 自动创建数据库文件夹和文件（D:\SQLiteData\device.db）
- 创建 Device 表并插入示例数据
- 创建温度采集历史表（TemperatureHistory）
- 插入 PLC 温度采集数据
- 显示所有设备和温度数据
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

### 2. 数据展示
- **显示所有设备**：展示Device表中的所有设备记录
- **显示所有温度数据**：展示TemperatureHistory表中的所有温度采集数据

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

## 学习目标
- 掌握 C# 中 SQLite 数据库的连接和操作
- 学习 SQL 基础语法（CREATE TABLE、INSERT、SELECT）
- 理解参数化查询的重要性（防止 SQL 注入）
- 学习 Windows Forms 中 DataGridView 的使用
- 掌握 using 语句的正确使用方式（自动管理资源）

## 注意事项
- 数据库文件存储在 `D:\SQLiteData\device.db`
- 程序会自动创建数据库文件夹（如果不存在）
- 每次点击按钮会重复插入数据，用于练习数据库操作

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