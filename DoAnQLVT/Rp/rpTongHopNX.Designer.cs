namespace DoAnQLVT.Rp
{
    partial class rpTongHopNX
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DEBegin = new DevExpress.XtraEditors.DateEdit();
            this.DEEnd = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.BTNPRINT = new System.Windows.Forms.Button();
            this.BTNTHOAT = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTenCN = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DEBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEEnd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "TỔNG HỢP NHẬP XUẤT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "NGÀY BĐ";
            // 
            // DEBegin
            // 
            this.DEBegin.EditValue = null;
            this.DEBegin.Location = new System.Drawing.Point(239, 178);
            this.DEBegin.Name = "DEBegin";
            this.DEBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEBegin.Size = new System.Drawing.Size(257, 22);
            this.DEBegin.TabIndex = 2;
            // 
            // DEEnd
            // 
            this.DEEnd.EditValue = null;
            this.DEEnd.Location = new System.Drawing.Point(239, 248);
            this.DEEnd.Name = "DEEnd";
            this.DEEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DEEnd.Size = new System.Drawing.Size(257, 22);
            this.DEEnd.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "NGÀY KT";
            // 
            // BTNPRINT
            // 
            this.BTNPRINT.Location = new System.Drawing.Point(167, 327);
            this.BTNPRINT.Name = "BTNPRINT";
            this.BTNPRINT.Size = new System.Drawing.Size(143, 47);
            this.BTNPRINT.TabIndex = 5;
            this.BTNPRINT.Text = "IN BÁO CÁO";
            this.BTNPRINT.UseVisualStyleBackColor = true;
            this.BTNPRINT.Click += new System.EventHandler(this.BTNPRINT_Click);
            // 
            // BTNTHOAT
            // 
            this.BTNTHOAT.Location = new System.Drawing.Point(418, 327);
            this.BTNTHOAT.Name = "BTNTHOAT";
            this.BTNTHOAT.Size = new System.Drawing.Size(117, 47);
            this.BTNTHOAT.TabIndex = 6;
            this.BTNTHOAT.Text = "THOÁT";
            this.BTNTHOAT.UseVisualStyleBackColor = true;
            this.BTNTHOAT.Click += new System.EventHandler(this.BTNTHOAT_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "MÃ CN";
            // 
            // cmbTenCN
            // 
            this.cmbTenCN.FormattingEnabled = true;
            this.cmbTenCN.Location = new System.Drawing.Point(239, 102);
            this.cmbTenCN.Name = "cmbTenCN";
            this.cmbTenCN.Size = new System.Drawing.Size(257, 24);
            this.cmbTenCN.TabIndex = 8;
            this.cmbTenCN.SelectedIndexChanged += new System.EventHandler(this.cmbTenCN_SelectedIndexChanged);
            // 
            // rpTongHopNX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 420);
            this.Controls.Add(this.cmbTenCN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BTNTHOAT);
            this.Controls.Add(this.BTNPRINT);
            this.Controls.Add(this.DEEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DEBegin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "rpTongHopNX";
            this.Text = "rpTongHopNX";
            this.Load += new System.EventHandler(this.rpTongHopNX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DEBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DEEnd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit DEBegin;
        private DevExpress.XtraEditors.DateEdit DEEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTNPRINT;
        private System.Windows.Forms.Button BTNTHOAT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTenCN;
    }
}