namespace PrivateMandal
{
    partial class ChangeEMIAmount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeEMIAmount));
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.dgvEMIHistory = new System.Windows.Forms.DataGridView();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEMI = new BajrangTextBox.BajrangTextbox();
            this.grouper1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEMIHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.Color.MintCream;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.WhiteSmoke;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper1.BorderColor = System.Drawing.Color.Silver;
            this.grouper1.BorderThickness = 2F;
            this.grouper1.Controls.Add(this.txtEMI);
            this.grouper1.Controls.Add(this.label2);
            this.grouper1.Controls.Add(this.btnSave);
            this.grouper1.Controls.Add(this.dgvEMIHistory);
            this.grouper1.Controls.Add(this.cmbYear);
            this.grouper1.Controls.Add(this.cmbMonth);
            this.grouper1.Controls.Add(this.label1);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "Change EMI Amount";
            this.grouper1.Location = new System.Drawing.Point(40, 95);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(20);
            this.grouper1.PaintGroupBox = false;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DimGray;
            this.grouper1.ShadowControl = true;
            this.grouper1.ShadowThickness = 2;
            this.grouper1.Size = new System.Drawing.Size(685, 337);
            this.grouper1.TabIndex = 0;
            this.grouper1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grouper1_KeyUp);
            // 
            // dgvEMIHistory
            // 
            this.dgvEMIHistory.AllowUserToAddRows = false;
            this.dgvEMIHistory.AllowUserToDeleteRows = false;
            this.dgvEMIHistory.AllowUserToResizeColumns = false;
            this.dgvEMIHistory.AllowUserToResizeRows = false;
            this.dgvEMIHistory.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvEMIHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEMIHistory.Location = new System.Drawing.Point(346, 43);
            this.dgvEMIHistory.MultiSelect = false;
            this.dgvEMIHistory.Name = "dgvEMIHistory";
            this.dgvEMIHistory.ReadOnly = true;
            this.dgvEMIHistory.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvEMIHistory.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEMIHistory.RowTemplate.Height = 40;
            this.dgvEMIHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEMIHistory.Size = new System.Drawing.Size(306, 267);
            this.dgvEMIHistory.TabIndex = 99;
            this.dgvEMIHistory.Visible = false;
            this.dgvEMIHistory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grouper1_KeyUp);
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbYear.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(179, 87);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(136, 33);
            this.cmbYear.TabIndex = 2;
            this.cmbYear.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grouper1_KeyUp);
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "Auugust",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(26, 87);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(136, 33);
            this.cmbMonth.TabIndex = 1;
            this.cmbMonth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grouper1_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(21, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 85;
            this.label1.Text = "New EMI From";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(26, 273);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(289, 37);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Change EMI";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grouper1_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(21, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 102;
            this.label2.Text = "New EMI From";
            // 
            // txtEMI
            // 
            this.txtEMI.BackColor = System.Drawing.Color.White;
            this.txtEMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEMI.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.txtEMI.IsNumeric = true;
            this.txtEMI.Location = new System.Drawing.Point(26, 188);
            this.txtEMI.MaxLength = 5;
            this.txtEMI.Name = "txtEMI";
            this.txtEMI.Size = new System.Drawing.Size(135, 32);
            this.txtEMI.TabIndex = 3;
            this.txtEMI.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // ChangeEMIAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1220, 604);
            this.Controls.Add(this.grouper1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeEMIAmount";
            this.Text = "Change EMI Amount";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ChangeEMIAmount_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grouper1_KeyUp);
            this.grouper1.ResumeLayout(false);
            this.grouper1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEMIHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CodeVendor.Controls.Grouper grouper1;
        private System.Windows.Forms.DataGridView dgvEMIHistory;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private BajrangTextBox.BajrangTextbox txtEMI;
        private System.Windows.Forms.Label label2;
    }
}