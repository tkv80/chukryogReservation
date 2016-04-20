namespace CampingReservation.Frm
{
    partial class BaseReservation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseReservation));
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gbClient = new System.Windows.Forms.GroupBox();
            this.btnGetMemberInfo = new System.Windows.Forms.Button();
            this.lbMemberInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnReserve = new System.Windows.Forms.Button();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.chbMainSite = new System.Windows.Forms.CheckBox();
            this.udDelay = new System.Windows.Forms.NumericUpDown();
            this.lbSuccessMessage = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbClient.SuspendLayout();
            this.gbSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLog.Location = new System.Drawing.Point(4, 268);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(265, 147);
            this.txtLog.TabIndex = 32;
            this.txtLog.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "delay";
            // 
            // gbClient
            // 
            this.gbClient.Controls.Add(this.label2);
            this.gbClient.Controls.Add(this.txtPwd);
            this.gbClient.Controls.Add(this.btnGetMemberInfo);
            this.gbClient.Controls.Add(this.lbMemberInfo);
            this.gbClient.Controls.Add(this.label1);
            this.gbClient.Controls.Add(this.txtID);
            this.gbClient.Location = new System.Drawing.Point(6, 3);
            this.gbClient.Name = "gbClient";
            this.gbClient.Size = new System.Drawing.Size(263, 102);
            this.gbClient.TabIndex = 30;
            this.gbClient.TabStop = false;
            this.gbClient.Text = "예약자";
            // 
            // btnGetMemberInfo
            // 
            this.btnGetMemberInfo.Location = new System.Drawing.Point(209, 12);
            this.btnGetMemberInfo.Name = "btnGetMemberInfo";
            this.btnGetMemberInfo.Size = new System.Drawing.Size(47, 23);
            this.btnGetMemberInfo.TabIndex = 9;
            this.btnGetMemberInfo.Text = "조회";
            this.btnGetMemberInfo.UseVisualStyleBackColor = true;
            this.btnGetMemberInfo.Click += new System.EventHandler(this.btnGetMemberInfo_Click);
            // 
            // lbMemberInfo
            // 
            this.lbMemberInfo.AutoSize = true;
            this.lbMemberInfo.Location = new System.Drawing.Point(6, 38);
            this.lbMemberInfo.Name = "lbMemberInfo";
            this.lbMemberInfo.Size = new System.Drawing.Size(72, 12);
            this.lbMemberInfo.TabIndex = 8;
            this.lbMemberInfo.Text = "memberInfo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtID.Location = new System.Drawing.Point(28, 15);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(76, 20);
            this.txtID.TabIndex = 6;
            this.txtID.Text = "tkv1980";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 29;
            this.label7.Text = "사이트";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "종료일";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "시작일";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(53, 48);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(201, 21);
            this.dateTimePicker2.TabIndex = 25;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(53, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 24;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(53, 75);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 20);
            this.comboBox1.TabIndex = 23;
            // 
            // btnReserve
            // 
            this.btnReserve.Location = new System.Drawing.Point(191, 242);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(75, 23);
            this.btnReserve.TabIndex = 22;
            this.btnReserve.Text = "예약걸기";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // chbAll
            // 
            this.chbAll.AutoSize = true;
            this.chbAll.Location = new System.Drawing.Point(8, 101);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(84, 16);
            this.chbAll.TabIndex = 33;
            this.chbAll.Text = "모든사이트";
            this.chbAll.UseVisualStyleBackColor = true;
            this.chbAll.CheckedChanged += new System.EventHandler(this.chbAll_CheckedChanged);
            // 
            // gbSetting
            // 
            this.gbSetting.Controls.Add(this.txtFilter);
            this.gbSetting.Controls.Add(this.chbMainSite);
            this.gbSetting.Controls.Add(this.label5);
            this.gbSetting.Controls.Add(this.chbAll);
            this.gbSetting.Controls.Add(this.comboBox1);
            this.gbSetting.Controls.Add(this.dateTimePicker1);
            this.gbSetting.Controls.Add(this.dateTimePicker2);
            this.gbSetting.Controls.Add(this.label6);
            this.gbSetting.Controls.Add(this.label7);
            this.gbSetting.Location = new System.Drawing.Point(6, 111);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(263, 129);
            this.gbSetting.TabIndex = 34;
            this.gbSetting.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(152, 101);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(101, 21);
            this.txtFilter.TabIndex = 38;
            // 
            // chbMainSite
            // 
            this.chbMainSite.AutoSize = true;
            this.chbMainSite.Location = new System.Drawing.Point(98, 101);
            this.chbMainSite.Name = "chbMainSite";
            this.chbMainSite.Size = new System.Drawing.Size(48, 16);
            this.chbMainSite.TabIndex = 34;
            this.chbMainSite.Text = "명당";
            this.chbMainSite.UseVisualStyleBackColor = true;
            // 
            // udDelay
            // 
            this.udDelay.Location = new System.Drawing.Point(51, 242);
            this.udDelay.Name = "udDelay";
            this.udDelay.Size = new System.Drawing.Size(37, 21);
            this.udDelay.TabIndex = 35;
            this.udDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.udDelay.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lbSuccessMessage
            // 
            this.lbSuccessMessage.AutoSize = true;
            this.lbSuccessMessage.Location = new System.Drawing.Point(4, 418);
            this.lbSuccessMessage.Name = "lbSuccessMessage";
            this.lbSuccessMessage.Size = new System.Drawing.Size(75, 12);
            this.lbSuccessMessage.TabIndex = 37;
            this.lbSuccessMessage.Text = "No Success";
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPwd.Location = new System.Drawing.Point(139, 15);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(64, 20);
            this.txtPwd.TabIndex = 10;
            this.txtPwd.Text = "tkv1980";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "PW";
            // 
            // BaseReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 439);
            this.Controls.Add(this.lbSuccessMessage);
            this.Controls.Add(this.udDelay);
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.gbClient);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnReserve);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseReservation";
            this.Text = "JungRangReservation";
            this.Load += new System.EventHandler(this.BaseReservation_Load);
            this.gbClient.ResumeLayout(false);
            this.gbClient.PerformLayout();
            this.gbSetting.ResumeLayout(false);
            this.gbSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbClient;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Label lbMemberInfo;
        private System.Windows.Forms.Button btnGetMemberInfo;
        private System.Windows.Forms.CheckBox chbAll;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.NumericUpDown udDelay;
        private System.Windows.Forms.Label lbSuccessMessage;
        private System.Windows.Forms.CheckBox chbMainSite;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox txtPwd;
    }
}