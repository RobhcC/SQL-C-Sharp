# Winform_SQLite 每日练习项目

## 项目简介
这是一个简单的 Windows Forms 应用程序，用于练习 C# 与 SQLite 数据库的基本操作。

## 功能说明
- 连接 SQLite 数据库（device.db）
- 自动创建 Device 表（如果不存在）
- 插入一条示例数据（温度传感器）
- 查询并显示数据库中的所有设备信息

## 技术栈
- C#
- Windows Forms
- SQLite 数据库

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
└── packages.config      # 包配置文件
```

## 如何运行
1. 打开 Visual Studio
2. 加载 Winform_SQLite.slnx 解决方案
3. 运行项目（F5 或点击运行按钮）
4. 在弹出的窗体中点击按钮，程序会自动创建数据库、插入数据并显示结果

## 使用说明
1. 运行程序后，点击窗体上的按钮
2. 程序会自动：
   - 创建 device.db 数据库文件
   - 创建 Device 表
   - 插入一条温度传感器数据
   - 在 DataGridView 中显示所有设备信息
3. 每次点击按钮都会重复上述操作，可能会插入多条相同的数据

## 注意事项
- 第一次运行时会自动创建数据库文件
- 数据库文件会保存在程序运行目录
- 点击按钮会重复插入数据，用于练习数据库操作

## 练习目标
- 学习 C# 中如何连接 SQLite 数据库
- 练习 SQL 语句的基本使用
- 了解 Windows Forms 中 DataGridView 的使用
- 掌握 using 语句的正确使用方式