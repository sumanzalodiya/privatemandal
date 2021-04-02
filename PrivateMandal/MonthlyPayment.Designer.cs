namespace PrivateMandal
{
    partial class MonthlyPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlyPayment));
            this.grouper2 = new CodeVendor.Controls.Grouper();
            this.txtVillage = new BajrangTextBox.BajrangTextbox();
            this.dtpPayment = new System.Windows.Forms.DateTimePicker();
            this.lblPayment = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblAmountLabel = new System.Windows.Forms.Label();
            this.txtName = new BajrangTextBox.BajrangTextbox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtNumber = new BajrangTextBox.BajrangTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPayment = new System.Windows.Forms.DataGridView();
            this.grouper2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // grouper2
            // 
            this.grouper2.BackgroundColor = System.Drawing.Color.MintCream;
            this.grouper2.BackgroundGradientColor = System.Drawing.Color.WhiteSmoke;
            this.grouper2.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper2.BorderColor = System.Drawing.Color.Silver;
            this.grouper2.BorderThickness = 2F;
            this.grouper2.Controls.Add(this.txtVillage);
            this.grouper2.Controls.Add(this.dtpPayment);
            this.grouper2.Controls.Add(this.lblPayment);
            this.grouper2.Controls.Add(this.btnClear);
            this.grouper2.Controls.Add(this.btnSave);
            this.grouper2.Controls.Add(this.lblAmount);
            this.grouper2.Controls.Add(this.lblAmountLabel);
            this.grouper2.Controls.Add(this.txtName);
            this.grouper2.Controls.Add(this.btnSearch);
            this.grouper2.Controls.Add(this.txtNumber);
            this.grouper2.Controls.Add(this.label1);
            this.grouper2.Controls.Add(this.dgvPayment);
            this.grouper2.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grouper2.GroupImage = null;
            this.grouper2.GroupTitle = "Member Details";
            this.grouper2.Location = new System.Drawing.Point(40, 95);
            this.grouper2.Name = "grouper2";
            this.grouper2.Padding = new System.Windows.Forms.Padding(20);
            this.grouper2.PaintGroupBox = false;
            this.grouper2.RoundCorners = 10;
            this.grouper2.ShadowColor = System.Drawing.Color.DimGray;
            this.grouper2.ShadowControl = true;
            this.grouper2.ShadowThickness = 2;
            this.grouper2.Size = new System.Drawing.Size(800, 380);
            this.grouper2.TabIndex = 5;
            // 
            // txtVillage
            // 
            this.txtVillage.BackColor = System.Drawing.Color.White;
            this.txtVillage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVillage.Enabled = false;
            this.txtVillage.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVillage.IsNumeric = false;
            this.txtVillage.Location = new System.Drawing.Point(593, 36);
            this.txtVillage.Name = "txtVillage";
            this.txtVillage.Size = new System.Drawing.Size(175, 32);
            this.txtVillage.TabIndex = 31;
            this.txtVillage.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // dtpPayment
            // 
            this.dtpPayment.CustomFormat = "dd-MM-yyyy";
            this.dtpPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPayment.Location = new System.Drawing.Point(638, 264);
            this.dtpPayment.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.dtpPayment.Name = "dtpPayment";
            this.dtpPayment.Size = new System.Drawing.Size(130, 32);
            this.dtpPayment.TabIndex = 30;
            this.dtpPayment.Visible = false;
            this.dtpPayment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MonthlyPayment_KeyUp);
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.ForeColor = System.Drawing.Color.Red;
            this.lblPayment.Location = new System.Drawing.Point(502, 265);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(133, 25);
            this.lblPayment.TabIndex = 29;
            this.lblPayment.Text = "Payment Date";
            this.lblPayment.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(259, 313);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(194, 37);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "&Clear Data";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MonthlyPayment_KeyUp);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(29, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(194, 37);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Make &Payment";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MonthlyPayment_KeyUp);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Red;
            this.lblAmount.Location = new System.Drawing.Point(232, 266);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 25);
            this.lblAmount.TabIndex = 26;
            this.lblAmount.Visible = false;
            // 
            // lblAmountLabel
            // 
            this.lblAmountLabel.AutoSize = true;
            this.lblAmountLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountLabel.ForeColor = System.Drawing.Color.Red;
            this.lblAmountLabel.Location = new System.Drawing.Point(24, 266);
            this.lblAmountLabel.Name = "lblAmountLabel";
            this.lblAmountLabel.Size = new System.Drawing.Size(202, 25);
            this.lblAmountLabel.TabIndex = 25;
            this.lblAmountLabel.Text = "Total Pending Amount";
            this.lblAmountLabel.Visible = false;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.IsNumeric = false;
            this.txtName.Location = new System.Drawing.Point(291, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(296, 32);
            this.txtName.TabIndex = 24;
            this.txtName.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::PrivateMandal.Properties.Resources.search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(259, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 32);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MonthlyPayment_KeyUp);
            // 
            // txtNumber
            // 
            this.txtNumber.BackColor = System.Drawing.Color.White;
            this.txtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumber.Enabled = false;
            this.txtNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumber.IsNumeric = false;
            this.txtNumber.Location = new System.Drawing.Point(172, 36);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(88, 32);
            this.txtNumber.TabIndex = 21;
            this.txtNumber.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Search Member";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvPayment
            // 
            this.dgvPayment.AllowUserToAddRows = false;
            this.dgvPayment.AllowUserToDeleteRows = false;
            this.dgvPayment.AllowUserToResizeColumns = false;
            this.dgvPayment.AllowUserToResizeRows = false;
            this.dgvPayment.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayment.Location = new System.Drawing.Point(29, 78);
            this.dgvPayment.MultiSelect = false;
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPayment.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPayment.RowTemplate.Height = 30;
            this.dgvPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayment.Size = new System.Drawing.Size(739, 172);
            this.dgvPayment.TabIndex = 0;
            this.dgvPayment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MonthlyPayment_KeyUp);
            // 
            // MonthlyPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(984, 628);
            this.Controls.Add(this.grouper2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MonthlyPayment";
            this.Text = "Monthly Payment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MonthlyPayment_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MonthlyPayment_KeyUp);
            this.grouper2.ResumeLayout(false);
            this.grouper2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CodeVendor.Controls.Grouper grouper2;
        private BajrangTextBox.BajrangTextbox txtNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPayment;
        private System.Windows.Forms.Button btnSearch;
        private BajrangTextBox.BajrangTextbox txtName;
        private System.Windows.Forms.Label lblAmountLabel;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.DateTimePicker dtpPayment;
        private BajrangTextBox.BajrangTextbox txtVillage;
    }
}