namespace Winform_SQLite
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCreateTempTable = new System.Windows.Forms.Button();
            this.btnInsertTemp = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.listLog = new System.Windows.Forms.ListBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.btnDeleteDevice = new System.Windows.Forms.Button();
            this.txtDeviceId = new System.Windows.Forms.TextBox();
            this.lblDeviceId = new System.Windows.Forms.Label();
            this.btnQueryAllTemp = new System.Windows.Forms.Button();
            this.btnQueryByDevice = new System.Windows.Forms.Button();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.btnQueryByRange = new System.Windows.Forms.Button();
            this.txtMinTemp = new System.Windows.Forms.TextBox();
            this.txtMaxTemp = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnDeleteTemp = new System.Windows.Forms.Button();
            this.txtTempId = new System.Windows.Forms.TextBox();
            this.lblTempId = new System.Windows.Forms.Label();
            this.btnStats = new System.Windows.Forms.Button();
            this.btnQueryAllDevices = new System.Windows.Forms.Button();
            this.grpDevice = new System.Windows.Forms.GroupBox();
            this.grpTemp = new System.Windows.Forms.GroupBox();
            this.grpQuery = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpDevice.SuspendLayout();
            this.grpTemp.SuspendLayout();
            this.grpQuery.SuspendLayout();
            this.SuspendLayout();
            //
            // grpDevice
            //
            this.grpDevice.Controls.Add(this.button1);
            this.grpDevice.Controls.Add(this.btnQueryAllDevices);
            this.grpDevice.Controls.Add(this.btnUpdate);
            this.grpDevice.Controls.Add(this.lblDeviceId);
            this.grpDevice.Controls.Add(this.txtDeviceId);
            this.grpDevice.Controls.Add(this.btnDeleteDevice);
            this.grpDevice.Location = new System.Drawing.Point(12, 8);
            this.grpDevice.Name = "grpDevice";
            this.grpDevice.Size = new System.Drawing.Size(776, 50);
            this.grpDevice.TabIndex = 10;
            this.grpDevice.TabStop = false;
            this.grpDevice.Text = "设备操作";
            //
            // button1
            //
            this.button1.Location = new System.Drawing.Point(6, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "创建Device表并插入数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            //
            // btnQueryAllDevices
            //
            this.btnQueryAllDevices.Location = new System.Drawing.Point(182, 18);
            this.btnQueryAllDevices.Name = "btnQueryAllDevices";
            this.btnQueryAllDevices.Size = new System.Drawing.Size(120, 28);
            this.btnQueryAllDevices.TabIndex = 11;
            this.btnQueryAllDevices.Text = "查询所有设备";
            this.btnQueryAllDevices.UseVisualStyleBackColor = true;
            this.btnQueryAllDevices.Click += new System.EventHandler(this.btnQueryAllDevices_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.Location = new System.Drawing.Point(308, 18);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 28);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "更新设备名称";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // lblDeviceId
            //
            this.lblDeviceId.AutoSize = true;
            this.lblDeviceId.Location = new System.Drawing.Point(440, 23);
            this.lblDeviceId.Name = "lblDeviceId";
            this.lblDeviceId.Size = new System.Drawing.Size(53, 12);
            this.lblDeviceId.TabIndex = 12;
            this.lblDeviceId.Text = "设备ID：";
            //
            // txtDeviceId
            //
            this.txtDeviceId.Location = new System.Drawing.Point(499, 20);
            this.txtDeviceId.Name = "txtDeviceId";
            this.txtDeviceId.Size = new System.Drawing.Size(50, 21);
            this.txtDeviceId.TabIndex = 13;
            this.txtDeviceId.Text = "1";
            //
            // btnDeleteDevice
            //
            this.btnDeleteDevice.Location = new System.Drawing.Point(555, 18);
            this.btnDeleteDevice.Name = "btnDeleteDevice";
            this.btnDeleteDevice.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteDevice.TabIndex = 14;
            this.btnDeleteDevice.Text = "删除设备";
            this.btnDeleteDevice.UseVisualStyleBackColor = true;
            this.btnDeleteDevice.Click += new System.EventHandler(this.btnDeleteDevice_Click);
            //
            // grpTemp
            //
            this.grpTemp.Controls.Add(this.btnCreateTempTable);
            this.grpTemp.Controls.Add(this.btnInsertTemp);
            this.grpTemp.Controls.Add(this.btnQueryAllTemp);
            this.grpTemp.Controls.Add(this.lblTempId);
            this.grpTemp.Controls.Add(this.txtTempId);
            this.grpTemp.Controls.Add(this.btnDeleteTemp);
            this.grpTemp.Location = new System.Drawing.Point(12, 64);
            this.grpTemp.Name = "grpTemp";
            this.grpTemp.Size = new System.Drawing.Size(776, 50);
            this.grpTemp.TabIndex = 15;
            this.grpTemp.TabStop = false;
            this.grpTemp.Text = "温度操作";
            //
            // btnCreateTempTable
            //
            this.btnCreateTempTable.Location = new System.Drawing.Point(6, 18);
            this.btnCreateTempTable.Name = "btnCreateTempTable";
            this.btnCreateTempTable.Size = new System.Drawing.Size(170, 28);
            this.btnCreateTempTable.TabIndex = 2;
            this.btnCreateTempTable.Text = "创建温度采集历史表";
            this.btnCreateTempTable.UseVisualStyleBackColor = true;
            this.btnCreateTempTable.Click += new System.EventHandler(this.btnCreateTempTable_Click);
            //
            // btnInsertTemp
            //
            this.btnInsertTemp.Location = new System.Drawing.Point(182, 18);
            this.btnInsertTemp.Name = "btnInsertTemp";
            this.btnInsertTemp.Size = new System.Drawing.Size(120, 28);
            this.btnInsertTemp.TabIndex = 3;
            this.btnInsertTemp.Text = "插入温度数据";
            this.btnInsertTemp.UseVisualStyleBackColor = true;
            this.btnInsertTemp.Click += new System.EventHandler(this.btnInsertTemp_Click);
            //
            // btnQueryAllTemp
            //
            this.btnQueryAllTemp.Location = new System.Drawing.Point(308, 18);
            this.btnQueryAllTemp.Name = "btnQueryAllTemp";
            this.btnQueryAllTemp.Size = new System.Drawing.Size(120, 28);
            this.btnQueryAllTemp.TabIndex = 16;
            this.btnQueryAllTemp.Text = "查询所有温度";
            this.btnQueryAllTemp.UseVisualStyleBackColor = true;
            this.btnQueryAllTemp.Click += new System.EventHandler(this.btnQueryAllTemp_Click);
            //
            // lblTempId
            //
            this.lblTempId.AutoSize = true;
            this.lblTempId.Location = new System.Drawing.Point(440, 23);
            this.lblTempId.Name = "lblTempId";
            this.lblTempId.Size = new System.Drawing.Size(65, 12);
            this.lblTempId.TabIndex = 17;
            this.lblTempId.Text = "温度ID：";
            //
            // txtTempId
            //
            this.txtTempId.Location = new System.Drawing.Point(511, 20);
            this.txtTempId.Name = "txtTempId";
            this.txtTempId.Size = new System.Drawing.Size(50, 21);
            this.txtTempId.TabIndex = 18;
            this.txtTempId.Text = "1";
            //
            // btnDeleteTemp
            //
            this.btnDeleteTemp.Location = new System.Drawing.Point(567, 18);
            this.btnDeleteTemp.Name = "btnDeleteTemp";
            this.btnDeleteTemp.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteTemp.TabIndex = 19;
            this.btnDeleteTemp.Text = "删除温度记录";
            this.btnDeleteTemp.UseVisualStyleBackColor = true;
            this.btnDeleteTemp.Click += new System.EventHandler(this.btnDeleteTemp_Click);
            //
            // grpQuery
            //
            this.grpQuery.Controls.Add(this.btnQueryByDevice);
            this.grpQuery.Controls.Add(this.txtDeviceName);
            this.grpQuery.Controls.Add(this.btnQueryByRange);
            this.grpQuery.Controls.Add(this.txtMinTemp);
            this.grpQuery.Controls.Add(this.lblTo);
            this.grpQuery.Controls.Add(this.txtMaxTemp);
            this.grpQuery.Controls.Add(this.btnStats);
            this.grpQuery.Location = new System.Drawing.Point(12, 120);
            this.grpQuery.Name = "grpQuery";
            this.grpQuery.Size = new System.Drawing.Size(776, 50);
            this.grpQuery.TabIndex = 20;
            this.grpQuery.TabStop = false;
            this.grpQuery.Text = "条件查询";
            //
            // btnQueryByDevice
            //
            this.btnQueryByDevice.Location = new System.Drawing.Point(6, 18);
            this.btnQueryByDevice.Name = "btnQueryByDevice";
            this.btnQueryByDevice.Size = new System.Drawing.Size(130, 28);
            this.btnQueryByDevice.TabIndex = 21;
            this.btnQueryByDevice.Text = "按设备名查询";
            this.btnQueryByDevice.UseVisualStyleBackColor = true;
            this.btnQueryByDevice.Click += new System.EventHandler(this.btnQueryByDevice_Click);
            //
            // txtDeviceName
            //
            this.txtDeviceName.Location = new System.Drawing.Point(142, 20);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(80, 21);
            this.txtDeviceName.TabIndex = 22;
            this.txtDeviceName.Text = "PLC_01";
            //
            // btnQueryByRange
            //
            this.btnQueryByRange.Location = new System.Drawing.Point(232, 18);
            this.btnQueryByRange.Name = "btnQueryByRange";
            this.btnQueryByRange.Size = new System.Drawing.Size(130, 28);
            this.btnQueryByRange.TabIndex = 23;
            this.btnQueryByRange.Text = "按温度范围查询";
            this.btnQueryByRange.UseVisualStyleBackColor = true;
            this.btnQueryByRange.Click += new System.EventHandler(this.btnQueryByRange_Click);
            //
            // txtMinTemp
            //
            this.txtMinTemp.Location = new System.Drawing.Point(368, 20);
            this.txtMinTemp.Name = "txtMinTemp";
            this.txtMinTemp.Size = new System.Drawing.Size(50, 21);
            this.txtMinTemp.TabIndex = 24;
            this.txtMinTemp.Text = "20";
            //
            // lblTo
            //
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(424, 23);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(17, 12);
            this.lblTo.TabIndex = 25;
            this.lblTo.Text = "至";
            //
            // txtMaxTemp
            //
            this.txtMaxTemp.Location = new System.Drawing.Point(447, 20);
            this.txtMaxTemp.Name = "txtMaxTemp";
            this.txtMaxTemp.Size = new System.Drawing.Size(50, 21);
            this.txtMaxTemp.TabIndex = 26;
            this.txtMaxTemp.Text = "30";
            //
            // btnStats
            //
            this.btnStats.Location = new System.Drawing.Point(510, 18);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(100, 28);
            this.btnStats.TabIndex = 27;
            this.btnStats.Text = "统计记录数";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            //
            // lblLog
            //
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(12, 178);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(65, 12);
            this.lblLog.TabIndex = 5;
            this.lblLog.Text = "日志信息：";
            //
            // listLog
            //
            this.listLog.FormattingEnabled = true;
            this.listLog.ItemHeight = 12;
            this.listLog.Location = new System.Drawing.Point(12, 193);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(776, 100);
            this.listLog.TabIndex = 6;
            //
            // dataGridView1
            //
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 305);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(776, 175);
            this.dataGridView1.TabIndex = 0;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 490);
            this.Controls.Add(this.grpQuery);
            this.Controls.Add(this.grpTemp);
            this.Controls.Add(this.grpDevice);
            this.Controls.Add(this.listLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "SQLite学习 - 第2天：条件查询与删除";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpDevice.ResumeLayout(false);
            this.grpDevice.PerformLayout();
            this.grpTemp.ResumeLayout(false);
            this.grpTemp.PerformLayout();
            this.grpQuery.ResumeLayout(false);
            this.grpQuery.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCreateTempTable;
        private System.Windows.Forms.Button btnInsertTemp;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Button btnDeleteDevice;
        private System.Windows.Forms.TextBox txtDeviceId;
        private System.Windows.Forms.Label lblDeviceId;
        private System.Windows.Forms.Button btnQueryAllTemp;
        private System.Windows.Forms.Button btnQueryByDevice;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Button btnQueryByRange;
        private System.Windows.Forms.TextBox txtMinTemp;
        private System.Windows.Forms.TextBox txtMaxTemp;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnDeleteTemp;
        private System.Windows.Forms.TextBox txtTempId;
        private System.Windows.Forms.Label lblTempId;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnQueryAllDevices;
        private System.Windows.Forms.GroupBox grpDevice;
        private System.Windows.Forms.GroupBox grpTemp;
        private System.Windows.Forms.GroupBox grpQuery;
    }
}
