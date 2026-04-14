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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 270);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(786, 168);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "创建Device表并插入数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCreateTempTable
            // 
            this.btnCreateTempTable.Location = new System.Drawing.Point(12, 53);
            this.btnCreateTempTable.Name = "btnCreateTempTable";
            this.btnCreateTempTable.Size = new System.Drawing.Size(180, 35);
            this.btnCreateTempTable.TabIndex = 2;
            this.btnCreateTempTable.Text = "创建温度采集历史表";
            this.btnCreateTempTable.UseVisualStyleBackColor = true;
            this.btnCreateTempTable.Click += new System.EventHandler(this.btnCreateTempTable_Click);
            // 
            // btnInsertTemp
            // 
            this.btnInsertTemp.Location = new System.Drawing.Point(198, 53);
            this.btnInsertTemp.Name = "btnInsertTemp";
            this.btnInsertTemp.Size = new System.Drawing.Size(180, 35);
            this.btnInsertTemp.TabIndex = 3;
            this.btnInsertTemp.Text = "插入PLC温度采集数据";
            this.btnInsertTemp.UseVisualStyleBackColor = true;
            this.btnInsertTemp.Click += new System.EventHandler(this.btnInsertTemp_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(198, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(180, 35);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "更新设备名称";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.Lime;
            this.txtLog.Location = new System.Drawing.Point(12, 125);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(786, 139);
            this.txtLog.TabIndex = 6;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(12, 110);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(65, 12);
            this.lblLog.TabIndex = 5;
            this.lblLog.Text = "日志信息：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsertTemp);
            this.Controls.Add(this.btnCreateTempTable);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "SQLite学习 - 第1天：SQL基础+增删改查";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCreateTempTable;
        private System.Windows.Forms.Button btnInsertTemp;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblLog;
    }
}
