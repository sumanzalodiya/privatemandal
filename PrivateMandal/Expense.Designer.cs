namespace PrivateMandal
{
    partial class Expense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Expense));
            this.grouper2 = new CodeVendor.Controls.Grouper();
            this.lblType = new System.Windows.Forms.Label();
            this.txtName = new BajrangTextBox.BajrangTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetails = new BajrangTextBox.BajrangTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new BajrangTextBox.BajrangTextbox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblPayment = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblAmountLabel = new System.Windows.Forms.Label();
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvExpense = new System.Windows.Forms.DataGridView();
            this.btnSearchExpense = new System.Windows.Forms.Button();
            this.dtpSearchFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpSearchToDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grouper2.SuspendLayout();
            this.grouper1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).BeginInit();
            this.SuspendLayout();
            // 
            // grouper2
            // 
            this.grouper2.BackgroundColor = System.Drawing.Color.MintCream;
            this.grouper2.BackgroundGradientColor = System.Drawing.Color.WhiteSmoke;
            this.grouper2.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper2.BorderColor = System.Drawing.Color.Silver;
            this.grouper2.BorderThickness = 2F;
            this.grouper2.Controls.Add(this.lblType);
            this.grouper2.Controls.Add(this.txtName);
            this.grouper2.Controls.Add(this.label2);
            this.grouper2.Controls.Add(this.txtDetails);
            this.grouper2.Controls.Add(this.label1);
            this.grouper2.Controls.Add(this.txtAmount);
            this.grouper2.Controls.Add(this.dtpDate);
            this.grouper2.Controls.Add(this.lblPayment);
            this.grouper2.Controls.Add(this.btnClear);
            this.grouper2.Controls.Add(this.btnSave);
            this.grouper2.Controls.Add(this.lblAmount);
            this.grouper2.Controls.Add(this.lblAmountLabel);
            this.grouper2.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grouper2.GroupImage = null;
            this.grouper2.GroupTitle = "Expense Details";
            this.grouper2.Location = new System.Drawing.Point(40, 95);
            this.grouper2.Name = "grouper2";
            this.grouper2.Padding = new System.Windows.Forms.Padding(20);
            this.grouper2.PaintGroupBox = false;
            this.grouper2.RoundCorners = 10;
            this.grouper2.ShadowColor = System.Drawing.Color.DimGray;
            this.grouper2.ShadowControl = true;
            this.grouper2.ShadowThickness = 2;
            this.grouper2.Size = new System.Drawing.Size(800, 380);
            this.grouper2.TabIndex = 6;
            this.grouper2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Expense_KeyUp);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblType.Location = new System.Drawing.Point(429, 57);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 25);
            this.lblType.TabIndex = 35;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.txtName.IsNumeric = false;
            this.txtName.Location = new System.Drawing.Point(221, 216);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(430, 31);
            this.txtName.TabIndex = 3;
            this.txtName.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 34;
            this.label2.Text = "Expense Done By";
            // 
            // txtDetails
            // 
            this.txtDetails.BackColor = System.Drawing.Color.White;
            this.txtDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.txtDetails.IsNumeric = false;
            this.txtDetails.Location = new System.Drawing.Point(221, 161);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(430, 31);
            this.txtDetails.TabIndex = 2;
            this.txtDetails.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(25, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 32;
            this.label1.Text = "Expense Details";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            this.txtAmount.IsNumeric = true;
            this.txtAmount.Location = new System.Drawing.Point(221, 106);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(161, 31);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MM-yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(221, 51);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(161, 31);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Expense_KeyUp);
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.ForeColor = System.Drawing.Color.Red;
            this.lblPayment.Location = new System.Drawing.Point(25, 53);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(128, 25);
            this.lblPayment.TabIndex = 29;
            this.lblPayment.Text = "Expense Date";
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(259, 313);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(194, 37);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "&Clear Data";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Expense_KeyUp);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(29, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(194, 37);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Add Expense";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Expense_KeyUp);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Red;
            this.lblAmount.Location = new System.Drawing.Point(182, 266);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 25);
            this.lblAmount.TabIndex = 26;
            this.lblAmount.Visible = false;
            // 
            // lblAmountLabel
            // 
            this.lblAmountLabel.AutoSize = true;
            this.lblAmountLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountLabel.ForeColor = System.Drawing.Color.Red;
            this.lblAmountLabel.Location = new System.Drawing.Point(25, 108);
            this.lblAmountLabel.Name = "lblAmountLabel";
            this.lblAmountLabel.Size = new System.Drawing.Size(153, 25);
            this.lblAmountLabel.TabIndex = 25;
            this.lblAmountLabel.Text = "Expense Amount";
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.Color.MintCream;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.WhiteSmoke;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper1.BorderColor = System.Drawing.Color.Silver;
            this.grouper1.BorderThickness = 2F;
            this.grouper1.Controls.Add(this.label5);
            this.grouper1.Controls.Add(this.label4);
            this.grouper1.Controls.Add(this.dtpSearchToDate);
            this.grouper1.Controls.Add(this.label3);
            this.grouper1.Controls.Add(this.dgvExpense);
            this.grouper1.Controls.Add(this.btnSearchExpense);
            this.grouper1.Controls.Add(this.dtpSearchFromDate);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "Expense Details";
            this.grouper1.Location = new System.Drawing.Point(862, 95);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(20);
            this.grouper1.PaintGroupBox = false;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DimGray;
            this.grouper1.ShadowControl = true;
            this.grouper1.ShadowThickness = 2;
            this.grouper1.Size = new System.Drawing.Size(467, 380);
            this.grouper1.TabIndex = 7;
            this.grouper1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Expense_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Double Click : Update Expense Details";
            // 
            // dgvExpense
            // 
            this.dgvExpense.AllowUserToAddRows = false;
            this.dgvExpense.AllowUserToDeleteRows = false;
            this.dgvExpense.AllowUserToResizeColumns = false;
            this.dgvExpense.AllowUserToResizeRows = false;
            this.dgvExpense.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpense.Location = new System.Drawing.Point(17, 94);
            this.dgvExpense.MultiSelect = false;
            this.dgvExpense.Name = "dgvExpense";
            this.dgvExpense.ReadOnly = true;
            this.dgvExpense.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvExpense.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExpense.RowTemplate.Height = 26;
            this.dgvExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpense.Size = new System.Drawing.Size(432, 241);
            this.dgvExpense.TabIndex = 36;
            this.dgvExpense.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvExpense_CellMouseDoubleClick);
            this.dgvExpense.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Expense_KeyUp);
            // 
            // btnSearchExpense
            // 
            this.btnSearchExpense.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchExpense.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchExpense.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchExpense.ForeColor = System.Drawing.Color.Black;
            this.btnSearchExpense.Location = new System.Drawing.Point(331, 57);
            this.btnSearchExpense.Name = "btnSearchExpense";
            this.btnSearchExpense.Size = new System.Drawing.Size(118, 31);
            this.btnSearchExpense.TabIndex = 35;
            this.btnSearchExpense.Text = "Search";
            this.btnSearchExpense.UseVisualStyleBackColor = false;
            this.btnSearchExpense.Click += new System.EventHandler(this.btnSearchExpense_Click);
            this.btnSearchExpense.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Expense_KeyUp);
            // 
            // dtpSearchFromDate
            // 
            this.dtpSearchFromDate.CustomFormat = "dd-MM-yyyy";
            this.dtpSearchFromDate.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSearchFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSearchFromDate.Location = new System.Drawing.Point(17, 57);
            this.dtpSearchFromDate.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.dtpSearchFromDate.Name = "dtpSearchFromDate";
            this.dtpSearchFromDate.Size = new System.Drawing.Size(150, 31);
            this.dtpSearchFromDate.TabIndex = 0;
            this.dtpSearchFromDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Expense_KeyUp);
            // 
            // dtpSearchToDate
            // 
            this.dtpSearchToDate.CustomFormat = "dd-MM-yyyy";
            this.dtpSearchToDate.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSearchToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSearchToDate.Location = new System.Drawing.Point(175, 57);
            this.dtpSearchToDate.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.dtpSearchToDate.Name = "dtpSearchToDate";
            this.dtpSearchToDate.Size = new System.Drawing.Size(150, 31);
            this.dtpSearchToDate.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 25);
            this.label4.TabIndex = 39;
            this.label4.Text = "From Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(173, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 25);
            this.label5.TabIndex = 40;
            this.label5.Text = "To Date";
            // 
            // Expense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1360, 606);
            this.Controls.Add(this.grouper1);
            this.Controls.Add(this.grouper2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Expense";
            this.Text = "Expense";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Expense_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Expense_KeyUp);
            this.grouper2.ResumeLayout(false);
            this.grouper2.PerformLayout();
            this.grouper1.ResumeLayout(false);
            this.grouper1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CodeVendor.Controls.Grouper grouper2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblAmountLabel;
        private BajrangTextBox.BajrangTextbox txtAmount;
        private BajrangTextBox.BajrangTextbox txtDetails;
        private System.Windows.Forms.Label label1;
        private BajrangTextBox.BajrangTextbox txtName;
        private System.Windows.Forms.Label label2;
        private CodeVendor.Controls.Grouper grouper1;
        private System.Windows.Forms.DateTimePicker dtpSearchFromDate;
        private System.Windows.Forms.Button btnSearchExpense;
        private System.Windows.Forms.DataGridView dgvExpense;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpSearchToDate;
    }
}