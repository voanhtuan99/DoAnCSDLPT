namespace DoAnQLVT
{
    partial class formAddAccount
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label mANVLabel;
            this.DS = new DoAnQLVT.DS();
            this.bdsNhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVienTableAdapter = new DoAnQLVT.DSTableAdapters.NhanVienTableAdapter();
            this.tableAdapterManager = new DoAnQLVT.DSTableAdapters.TableAdapterManager();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.txtUserNameA = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radUserA = new System.Windows.Forms.RadioButton();
            this.radChiNhanhA = new System.Windows.Forms.RadioButton();
            this.radCtyA = new System.Windows.Forms.RadioButton();
            this.radGroup = new DevExpress.XtraEditors.RadioGroup();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConfirmPassA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoginNameA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            mANVLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNhanVien)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Location = new System.Drawing.Point(213, 397);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(75, 17);
            mANVLabel.TabIndex = 34;
            mANVLabel.Text = "UserName";
            mANVLabel.Click += new System.EventHandler(this.mANVLabel_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsNhanVien
            // 
            this.bdsNhanVien.DataMember = "NhanVien";
            this.bdsNhanVien.DataSource = this.DS;
            // 
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = this.nhanVienTableAdapter;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DoAnQLVT.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnDangKy);
            this.groupBox1.Controls.Add(this.txtUserNameA);
            this.groupBox1.Controls.Add(mANVLabel);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.radUserA);
            this.groupBox1.Controls.Add(this.radChiNhanhA);
            this.groupBox1.Controls.Add(this.radCtyA);
            this.groupBox1.Controls.Add(this.radGroup);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtConfirmPassA);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPassA);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLoginNameA);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1210, 650);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(711, 569);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(249, 64);
            this.button2.TabIndex = 37;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(413, 569);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(249, 64);
            this.btnDangKy.TabIndex = 36;
            this.btnDangKy.Text = "Đăng Ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click_1);
            // 
            // txtUserNameA
            // 
            this.txtUserNameA.Location = new System.Drawing.Point(449, 391);
            this.txtUserNameA.Name = "txtUserNameA";
            this.txtUserNameA.Size = new System.Drawing.Size(411, 22);
            this.txtUserNameA.TabIndex = 35;
            this.txtUserNameA.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(932, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 31);
            this.button1.TabIndex = 33;
            this.button1.Text = "Danh Sách Nhân Viên";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // radUserA
            // 
            this.radUserA.AutoSize = true;
            this.radUserA.Location = new System.Drawing.Point(745, 473);
            this.radUserA.Name = "radUserA";
            this.radUserA.Size = new System.Drawing.Size(67, 21);
            this.radUserA.TabIndex = 32;
            this.radUserA.TabStop = true;
            this.radUserA.Text = "USER";
            this.radUserA.UseVisualStyleBackColor = true;
            this.radUserA.CheckedChanged += new System.EventHandler(this.radUser_CheckedChanged);
            // 
            // radChiNhanhA
            // 
            this.radChiNhanhA.AutoSize = true;
            this.radChiNhanhA.Location = new System.Drawing.Point(598, 473);
            this.radChiNhanhA.Name = "radChiNhanhA";
            this.radChiNhanhA.Size = new System.Drawing.Size(100, 21);
            this.radChiNhanhA.TabIndex = 31;
            this.radChiNhanhA.TabStop = true;
            this.radChiNhanhA.Text = "CHINHANH";
            this.radChiNhanhA.UseVisualStyleBackColor = true;
            this.radChiNhanhA.CheckedChanged += new System.EventHandler(this.radChiNhanh_CheckedChanged);
            // 
            // radCtyA
            // 
            this.radCtyA.AutoSize = true;
            this.radCtyA.Location = new System.Drawing.Point(470, 473);
            this.radCtyA.Name = "radCtyA";
            this.radCtyA.Size = new System.Drawing.Size(88, 21);
            this.radCtyA.TabIndex = 30;
            this.radCtyA.TabStop = true;
            this.radCtyA.Text = "CONGTY";
            this.radCtyA.UseVisualStyleBackColor = true;
            this.radCtyA.CheckedChanged += new System.EventHandler(this.radCty_CheckedChanged);
            // 
            // radGroup
            // 
            this.radGroup.Location = new System.Drawing.Point(449, 459);
            this.radGroup.Name = "radGroup";
            this.radGroup.Size = new System.Drawing.Size(411, 55);
            this.radGroup.TabIndex = 29;
            this.radGroup.SelectedIndexChanged += new System.EventHandler(this.radGroup_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 478);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Role";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtConfirmPassA
            // 
            this.txtConfirmPassA.Location = new System.Drawing.Point(449, 322);
            this.txtConfirmPassA.Name = "txtConfirmPassA";
            this.txtConfirmPassA.Size = new System.Drawing.Size(411, 22);
            this.txtConfirmPassA.TabIndex = 27;
            this.txtConfirmPassA.UseSystemPasswordChar = true;
            this.txtConfirmPassA.TextChanged += new System.EventHandler(this.txtConfirmPass_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Confirm Password";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtPassA
            // 
            this.txtPassA.Location = new System.Drawing.Point(449, 261);
            this.txtPassA.Name = "txtPassA";
            this.txtPassA.Size = new System.Drawing.Size(411, 22);
            this.txtPassA.TabIndex = 25;
            this.txtPassA.UseSystemPasswordChar = true;
            this.txtPassA.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtLoginNameA
            // 
            this.txtLoginNameA.Location = new System.Drawing.Point(449, 191);
            this.txtLoginNameA.Name = "txtLoginNameA";
            this.txtLoginNameA.Size = new System.Drawing.Size(411, 22);
            this.txtLoginNameA.TabIndex = 23;
            this.txtLoginNameA.TextChanged += new System.EventHandler(this.txtLoginName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "LoginName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(492, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 49);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tạo Tài Khoản";
            // 
            // formAddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 674);
            this.Controls.Add(this.groupBox1);
            this.Name = "formAddAccount";
            this.Text = "formAddAccount";
            this.Load += new System.EventHandler(this.formAddAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNhanVien)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroup.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DS DS;
        private System.Windows.Forms.BindingSource bdsNhanVien;
        private DSTableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDangKy;
        public System.Windows.Forms.TextBox txtUserNameA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radUserA;
        private System.Windows.Forms.RadioButton radChiNhanhA;
        private System.Windows.Forms.RadioButton radCtyA;
        private DevExpress.XtraEditors.RadioGroup radGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConfirmPassA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoginNameA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}