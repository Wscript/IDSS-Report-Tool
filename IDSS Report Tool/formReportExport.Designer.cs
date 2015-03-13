namespace IDSS_Report_Tool
{
    partial class formReportExport
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent ()
        {
            this.radioNonParameter = new System.Windows.Forms.RadioButton();
            this.radioHasParameter = new System.Windows.Forms.RadioButton();
            this.comboReportList = new System.Windows.Forms.ComboBox();
            this.groupReportType = new System.Windows.Forms.GroupBox();
            this.labelReportName = new System.Windows.Forms.Label();
            this.richDescription = new System.Windows.Forms.RichTextBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelParameter = new System.Windows.Forms.Label();
            this.textParameter = new System.Windows.Forms.TextBox();
            this.groupReportType.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioNonParameter
            // 
            this.radioNonParameter.AutoSize = true;
            this.radioNonParameter.Location = new System.Drawing.Point(40, 30);
            this.radioNonParameter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioNonParameter.Name = "radioNonParameter";
            this.radioNonParameter.Size = new System.Drawing.Size(83, 24);
            this.radioNonParameter.TabIndex = 0;
            this.radioNonParameter.TabStop = true;
            this.radioNonParameter.Text = "不含参数";
            this.radioNonParameter.UseVisualStyleBackColor = true;
            this.radioNonParameter.CheckedChanged += new System.EventHandler(this.radioNonParameter_CheckedChanged);
            // 
            // radioHasParameter
            // 
            this.radioHasParameter.AutoSize = true;
            this.radioHasParameter.Location = new System.Drawing.Point(208, 30);
            this.radioHasParameter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioHasParameter.Name = "radioHasParameter";
            this.radioHasParameter.Size = new System.Drawing.Size(83, 24);
            this.radioHasParameter.TabIndex = 1;
            this.radioHasParameter.TabStop = true;
            this.radioHasParameter.Text = "包含参数";
            this.radioHasParameter.UseVisualStyleBackColor = true;
            this.radioHasParameter.CheckedChanged += new System.EventHandler(this.radioHasParameter_CheckedChanged);
            // 
            // comboReportList
            // 
            this.comboReportList.FormattingEnabled = true;
            this.comboReportList.Location = new System.Drawing.Point(9, 139);
            this.comboReportList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboReportList.Name = "comboReportList";
            this.comboReportList.Size = new System.Drawing.Size(337, 28);
            this.comboReportList.TabIndex = 2;
            this.comboReportList.SelectedIndexChanged += new System.EventHandler(this.comboReportList_SelectedIndexChanged);
            // 
            // groupReportType
            // 
            this.groupReportType.Controls.Add(this.radioNonParameter);
            this.groupReportType.Controls.Add(this.radioHasParameter);
            this.groupReportType.Location = new System.Drawing.Point(9, 11);
            this.groupReportType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupReportType.Name = "groupReportType";
            this.groupReportType.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupReportType.Size = new System.Drawing.Size(335, 74);
            this.groupReportType.TabIndex = 3;
            this.groupReportType.TabStop = false;
            this.groupReportType.Text = "Report 类型";
            // 
            // labelReportName
            // 
            this.labelReportName.AutoSize = true;
            this.labelReportName.Location = new System.Drawing.Point(6, 114);
            this.labelReportName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelReportName.Name = "labelReportName";
            this.labelReportName.Size = new System.Drawing.Size(86, 20);
            this.labelReportName.TabIndex = 4;
            this.labelReportName.Text = "Report 名称";
            // 
            // richDescription
            // 
            this.richDescription.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.richDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richDescription.Location = new System.Drawing.Point(9, 179);
            this.richDescription.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.richDescription.Name = "richDescription";
            this.richDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richDescription.Size = new System.Drawing.Size(335, 154);
            this.richDescription.TabIndex = 6;
            this.richDescription.Text = "";
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(125, 384);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(101, 39);
            this.buttonExport.TabIndex = 7;
            this.buttonExport.Text = "导出";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // labelParameter
            // 
            this.labelParameter.AutoSize = true;
            this.labelParameter.Location = new System.Drawing.Point(14, 347);
            this.labelParameter.Name = "labelParameter";
            this.labelParameter.Size = new System.Drawing.Size(37, 20);
            this.labelParameter.TabIndex = 8;
            this.labelParameter.Text = "参数";
            // 
            // textParameter
            // 
            this.textParameter.Location = new System.Drawing.Point(57, 343);
            this.textParameter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textParameter.Name = "textParameter";
            this.textParameter.Size = new System.Drawing.Size(286, 26);
            this.textParameter.TabIndex = 9;
            // 
            // formReportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 436);
            this.Controls.Add(this.textParameter);
            this.Controls.Add(this.labelParameter);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.richDescription);
            this.Controls.Add(this.labelReportName);
            this.Controls.Add(this.groupReportType);
            this.Controls.Add(this.comboReportList);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formReportExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IDSS Report 导出工具";
            this.Load += new System.EventHandler(this.formMain_Load);
            this.groupReportType.ResumeLayout(false);
            this.groupReportType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioNonParameter;
        private System.Windows.Forms.RadioButton radioHasParameter;
        private System.Windows.Forms.ComboBox comboReportList;
        private System.Windows.Forms.GroupBox groupReportType;
        private System.Windows.Forms.Label labelReportName;
        private System.Windows.Forms.RichTextBox richDescription;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label labelParameter;
        private System.Windows.Forms.TextBox textParameter;
    }
}

