namespace PrivateMandal
{
    partial class NewLoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewLoan));
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.txtBalance = new BajrangTextBox.BajrangTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpLoanDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVillage = new BajrangTextBox.BajrangTextbox();
            this.txtName = new BajrangTextBox.BajrangTextbox();
            this.txtNumber = new BajrangTextBox.BajrangTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEvidenceName2 = new BajrangTextBox.BajrangTextbox();
            this.txtEvidenceNumber2 = new BajrangTextBox.BajrangTextbox();
            this.lblEvidence2 = new System.Windows.Forms.Label();
            this.txtEvidenceName = new BajrangTextBox.BajrangTextbox();
            this.txtEvidenceNumber = new BajrangTextBox.BajrangTextbox();
            this.lblEvidence = new System.Windows.Forms.Label();
            this.txtInterest = new BajrangTextBox.BajrangTextbox();
            this.lblInterest = new System.Windows.Forms.Label();
            this.txtEMIAmount = new BajrangTextBox.BajrangTextbox();
            this.lblEMIAmount = new System.Windows.Forms.Label();
            this.cmbEmi = new System.Windows.Forms.ComboBox();
            this.lblEMICount = new System.Windows.Forms.Label();
            this.txtAmount = new BajrangTextBox.BajrangTextbox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grouper2 = new CodeVendor.Controls.Grouper();
            this.dgvLoanList = new System.Windows.Forms.DataGridView();
            this.bajrangTextbox2 = new BajrangTextBox.BajrangTextbox();
            this.grouper1.SuspendLayout();
            this.grouper2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanList)).BeginInit();
            this.SuspendLayout();
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.Color.MintCream;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.WhiteSmoke;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper1.BorderColor = System.Drawing.Color.Silver;
            this.grouper1.BorderThickness = 2F;
            this.grouper1.Controls.Add(this.txtBalance);
            this.grouper1.Controls.Add(this.label3);
            this.grouper1.Controls.Add(this.dtpLoanDate);
            this.grouper1.Controls.Add(this.label2);
            this.grouper1.Controls.Add(this.txtVillage);
            this.grouper1.Controls.Add(this.txtName);
            this.grouper1.Controls.Add(this.txtNumber);
            this.grouper1.Controls.Add(this.label1);
            this.grouper1.Controls.Add(this.txtEvidenceName2);
            this.grouper1.Controls.Add(this.txtEvidenceNumber2);
            this.grouper1.Controls.Add(this.lblEvidence2);
            this.grouper1.Controls.Add(this.txtEvidenceName);
            this.grouper1.Controls.Add(this.txtEvidenceNumber);
            this.grouper1.Controls.Add(this.lblEvidence);
            this.grouper1.Controls.Add(this.txtInterest);
            this.grouper1.Controls.Add(this.lblInterest);
            this.grouper1.Controls.Add(this.txtEMIAmount);
            this.grouper1.Controls.Add(this.lblEMIAmount);
            this.grouper1.Controls.Add(this.cmbEmi);
            this.grouper1.Controls.Add(this.lblEMICount);
            this.grouper1.Controls.Add(this.txtAmount);
            this.grouper1.Controls.Add(this.label8);
            this.grouper1.Controls.Add(this.btnClear);
            this.grouper1.Controls.Add(this.btnSave);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "Loan Details";
            this.grouper1.Location = new System.Drawing.Point(40, 95);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(20);
            this.grouper1.PaintGroupBox = false;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DimGray;
            this.grouper1.ShadowControl = true;
            this.grouper1.ShadowThickness = 2;
            this.grouper1.Size = new System.Drawing.Size(893, 472);
            this.grouper1.TabIndex = 1;
            // 
            // txtBalance
            // 
            this.txtBalance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBalance.BackColor = System.Drawing.Color.White;
            this.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBalance.Enabled = false;
            this.txtBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.IsNumeric = true;
            this.txtBalance.Location = new System.Drawing.Point(192, 355);
            this.txtBalance.MaxLength = 6;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(136, 32);
            this.txtBalance.TabIndex = 92;
            this.txtBalance.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 91;
            this.label3.Text = "Current Balance";
            // 
            // dtpLoanDate
            // 
            this.dtpLoanDate.CustomFormat = "dd-MM-yyyy";
            this.dtpLoanDate.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLoanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLoanDate.Location = new System.Drawing.Point(194, 85);
            this.dtpLoanDate.Name = "dtpLoanDate";
            this.dtpLoanDate.Size = new System.Drawing.Size(136, 32);
            this.dtpLoanDate.TabIndex = 89;
            this.dtpLoanDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NewLoan_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(21, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 90;
            this.label2.Text = "Loan Taken Date";
            // 
            // txtVillage
            // 
            this.txtVillage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtVillage.BackColor = System.Drawing.Color.White;
            this.txtVillage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVillage.Enabled = false;
            this.txtVillage.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVillage.IsNumeric = false;
            this.txtVillage.Location = new System.Drawing.Point(665, 40);
            this.txtVillage.Name = "txtVillage";
            this.txtVillage.Size = new System.Drawing.Size(205, 32);
            this.txtVillage.TabIndex = 88;
            this.txtVillage.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.IsNumeric = false;
            this.txtName.Location = new System.Drawing.Point(336, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(323, 32);
            this.txtName.TabIndex = 87;
            this.txtName.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // txtNumber
            // 
            this.txtNumber.BackColor = System.Drawing.Color.White;
            this.txtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumber.Enabled = false;
            this.txtNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumber.IsNumeric = false;
            this.txtNumber.Location = new System.Drawing.Point(194, 40);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(136, 32);
            this.txtNumber.TabIndex = 84;
            this.txtNumber.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(21, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 85;
            this.label1.Text = "Member Name";
            // 
            // txtEvidenceName2
            // 
            this.txtEvidenceName2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEvidenceName2.BackColor = System.Drawing.Color.White;
            this.txtEvidenceName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEvidenceName2.Enabled = false;
            this.txtEvidenceName2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEvidenceName2.IsNumeric = true;
            this.txtEvidenceName2.Location = new System.Drawing.Point(336, 310);
            this.txtEvidenceName2.MaxLength = 6;
            this.txtEvidenceName2.Name = "txtEvidenceName2";
            this.txtEvidenceName2.ReadOnly = true;
            this.txtEvidenceName2.Size = new System.Drawing.Size(534, 32);
            this.txtEvidenceName2.TabIndex = 79;
            this.txtEvidenceName2.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // txtEvidenceNumber2
            // 
            this.txtEvidenceNumber2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEvidenceNumber2.BackColor = System.Drawing.Color.White;
            this.txtEvidenceNumber2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEvidenceNumber2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEvidenceNumber2.IsNumeric = true;
            this.txtEvidenceNumber2.Location = new System.Drawing.Point(192, 310);
            this.txtEvidenceNumber2.MaxLength = 6;
            this.txtEvidenceNumber2.Name = "txtEvidenceNumber2";
            this.txtEvidenceNumber2.ReadOnly = true;
            this.txtEvidenceNumber2.Size = new System.Drawing.Size(136, 32);
            this.txtEvidenceNumber2.TabIndex = 15;
            this.txtEvidenceNumber2.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            this.txtEvidenceNumber2.Enter += new System.EventHandler(this.txtEvidenceNumber2_Enter);
            // 
            // lblEvidence2
            // 
            this.lblEvidence2.AutoSize = true;
            this.lblEvidence2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvidence2.ForeColor = System.Drawing.Color.Red;
            this.lblEvidence2.Location = new System.Drawing.Point(21, 313);
            this.lblEvidence2.Name = "lblEvidence2";
            this.lblEvidence2.Size = new System.Drawing.Size(172, 25);
            this.lblEvidence2.TabIndex = 77;
            this.lblEvidence2.Text = "Guarantor Name 2";
            // 
            // txtEvidenceName
            // 
            this.txtEvidenceName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEvidenceName.BackColor = System.Drawing.Color.White;
            this.txtEvidenceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEvidenceName.Enabled = false;
            this.txtEvidenceName.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEvidenceName.IsNumeric = true;
            this.txtEvidenceName.Location = new System.Drawing.Point(336, 265);
            this.txtEvidenceName.MaxLength = 6;
            this.txtEvidenceName.Name = "txtEvidenceName";
            this.txtEvidenceName.ReadOnly = true;
            this.txtEvidenceName.Size = new System.Drawing.Size(534, 32);
            this.txtEvidenceName.TabIndex = 76;
            this.txtEvidenceName.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // txtEvidenceNumber
            // 
            this.txtEvidenceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEvidenceNumber.BackColor = System.Drawing.Color.White;
            this.txtEvidenceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEvidenceNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEvidenceNumber.IsNumeric = true;
            this.txtEvidenceNumber.Location = new System.Drawing.Point(192, 265);
            this.txtEvidenceNumber.MaxLength = 6;
            this.txtEvidenceNumber.Name = "txtEvidenceNumber";
            this.txtEvidenceNumber.ReadOnly = true;
            this.txtEvidenceNumber.Size = new System.Drawing.Size(136, 32);
            this.txtEvidenceNumber.TabIndex = 14;
            this.txtEvidenceNumber.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            this.txtEvidenceNumber.Enter += new System.EventHandler(this.txtEvidenceNumber_Enter);
            // 
            // lblEvidence
            // 
            this.lblEvidence.AutoSize = true;
            this.lblEvidence.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvidence.ForeColor = System.Drawing.Color.Red;
            this.lblEvidence.Location = new System.Drawing.Point(21, 268);
            this.lblEvidence.Name = "lblEvidence";
            this.lblEvidence.Size = new System.Drawing.Size(169, 25);
            this.lblEvidence.TabIndex = 74;
            this.lblEvidence.Text = "Guarantor Name 1";
            // 
            // txtInterest
            // 
            this.txtInterest.BackColor = System.Drawing.Color.White;
            this.txtInterest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInterest.Enabled = false;
            this.txtInterest.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterest.IsNumeric = true;
            this.txtInterest.Location = new System.Drawing.Point(469, 220);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.Size = new System.Drawing.Size(136, 32);
            this.txtInterest.TabIndex = 52;
            this.txtInterest.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // lblInterest
            // 
            this.lblInterest.AutoSize = true;
            this.lblInterest.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterest.ForeColor = System.Drawing.Color.Black;
            this.lblInterest.Location = new System.Drawing.Point(340, 223);
            this.lblInterest.Name = "lblInterest";
            this.lblInterest.Size = new System.Drawing.Size(124, 25);
            this.lblInterest.TabIndex = 51;
            this.lblInterest.Text = "Loan Interest";
            // 
            // txtEMIAmount
            // 
            this.txtEMIAmount.BackColor = System.Drawing.Color.White;
            this.txtEMIAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEMIAmount.Enabled = false;
            this.txtEMIAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEMIAmount.IsNumeric = true;
            this.txtEMIAmount.Location = new System.Drawing.Point(194, 220);
            this.txtEMIAmount.Name = "txtEMIAmount";
            this.txtEMIAmount.Size = new System.Drawing.Size(136, 32);
            this.txtEMIAmount.TabIndex = 49;
            this.txtEMIAmount.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // lblEMIAmount
            // 
            this.lblEMIAmount.AutoSize = true;
            this.lblEMIAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEMIAmount.ForeColor = System.Drawing.Color.Black;
            this.lblEMIAmount.Location = new System.Drawing.Point(21, 223);
            this.lblEMIAmount.Name = "lblEMIAmount";
            this.lblEMIAmount.Size = new System.Drawing.Size(121, 25);
            this.lblEMIAmount.TabIndex = 50;
            this.lblEMIAmount.Text = "EMI Amount";
            // 
            // cmbEmi
            // 
            this.cmbEmi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmi.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbEmi.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmi.FormattingEnabled = true;
            this.cmbEmi.Location = new System.Drawing.Point(194, 175);
            this.cmbEmi.Name = "cmbEmi";
            this.cmbEmi.Size = new System.Drawing.Size(136, 33);
            this.cmbEmi.TabIndex = 13;
            this.cmbEmi.SelectedIndexChanged += new System.EventHandler(this.cmbEmi_SelectedIndexChanged);
            this.cmbEmi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NewLoan_KeyUp);
            // 
            // lblEMICount
            // 
            this.lblEMICount.AutoSize = true;
            this.lblEMICount.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEMICount.ForeColor = System.Drawing.Color.Red;
            this.lblEMICount.Location = new System.Drawing.Point(21, 178);
            this.lblEMICount.Name = "lblEMICount";
            this.lblEMICount.Size = new System.Drawing.Size(103, 25);
            this.lblEMICount.TabIndex = 47;
            this.lblEMICount.Text = "EMI Count";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.IsNumeric = true;
            this.txtAmount.Location = new System.Drawing.Point(194, 130);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(136, 32);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(21, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 25);
            this.label8.TabIndex = 37;
            this.label8.Text = "Loan Amount";
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(256, 412);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(194, 37);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NewLoan_KeyUp);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(26, 412);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(194, 37);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NewLoan_KeyUp);
            // 
            // grouper2
            // 
            this.grouper2.BackgroundColor = System.Drawing.Color.MintCream;
            this.grouper2.BackgroundGradientColor = System.Drawing.Color.WhiteSmoke;
            this.grouper2.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper2.BorderColor = System.Drawing.Color.Silver;
            this.grouper2.BorderThickness = 2F;
            this.grouper2.Controls.Add(this.dgvLoanList);
            this.grouper2.Controls.Add(this.bajrangTextbox2);
            this.grouper2.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grouper2.GroupImage = null;
            this.grouper2.GroupTitle = "Loan Application List";
            this.grouper2.Location = new System.Drawing.Point(953, 95);
            this.grouper2.Name = "grouper2";
            this.grouper2.Padding = new System.Windows.Forms.Padding(20);
            this.grouper2.PaintGroupBox = false;
            this.grouper2.RoundCorners = 10;
            this.grouper2.ShadowColor = System.Drawing.Color.DimGray;
            this.grouper2.ShadowControl = true;
            this.grouper2.ShadowThickness = 2;
            this.grouper2.Size = new System.Drawing.Size(389, 472);
            this.grouper2.TabIndex = 2;
            this.grouper2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NewLoan_KeyUp);
            // 
            // dgvLoanList
            // 
            this.dgvLoanList.AllowUserToAddRows = false;
            this.dgvLoanList.AllowUserToDeleteRows = false;
            this.dgvLoanList.AllowUserToResizeColumns = false;
            this.dgvLoanList.AllowUserToResizeRows = false;
            this.dgvLoanList.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvLoanList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoanList.Location = new System.Drawing.Point(23, 41);
            this.dgvLoanList.MultiSelect = false;
            this.dgvLoanList.Name = "dgvLoanList";
            this.dgvLoanList.ReadOnly = true;
            this.dgvLoanList.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLoanList.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLoanList.RowTemplate.Height = 34;
            this.dgvLoanList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoanList.Size = new System.Drawing.Size(343, 389);
            this.dgvLoanList.TabIndex = 100;
            this.dgvLoanList.Visible = false;
            this.dgvLoanList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoanList_CellContentDoubleClick);
            this.dgvLoanList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NewLoan_KeyUp);
            // 
            // bajrangTextbox2
            // 
            this.bajrangTextbox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.bajrangTextbox2.BackColor = System.Drawing.Color.White;
            this.bajrangTextbox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bajrangTextbox2.Enabled = false;
            this.bajrangTextbox2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bajrangTextbox2.IsNumeric = false;
            this.bajrangTextbox2.Location = new System.Drawing.Point(582, 41);
            this.bajrangTextbox2.Name = "bajrangTextbox2";
            this.bajrangTextbox2.Size = new System.Drawing.Size(154, 27);
            this.bajrangTextbox2.TabIndex = 88;
            this.bajrangTextbox2.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // NewLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1354, 706);
            this.Controls.Add(this.grouper2);
            this.Controls.Add(this.grouper1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewLoan";
            this.Text = "New Loan Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NewLoanApplication_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NewLoan_KeyUp);
            this.grouper1.ResumeLayout(false);
            this.grouper1.PerformLayout();
            this.grouper2.ResumeLayout(false);
            this.grouper2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CodeVendor.Controls.Grouper grouper1;
        private BajrangTextBox.BajrangTextbox txtEvidenceName2;
        private BajrangTextBox.BajrangTextbox txtEvidenceNumber2;
        private System.Windows.Forms.Label lblEvidence2;
        private BajrangTextBox.BajrangTextbox txtEvidenceName;
        private BajrangTextBox.BajrangTextbox txtEvidenceNumber;
        private System.Windows.Forms.Label lblEvidence;
        private BajrangTextBox.BajrangTextbox txtInterest;
        private System.Windows.Forms.Label lblInterest;
        private BajrangTextBox.BajrangTextbox txtEMIAmount;
        private System.Windows.Forms.Label lblEMIAmount;
        private System.Windows.Forms.ComboBox cmbEmi;
        private System.Windows.Forms.Label lblEMICount;
        private BajrangTextBox.BajrangTextbox txtAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private BajrangTextBox.BajrangTextbox txtVillage;
        private BajrangTextBox.BajrangTextbox txtName;
        private BajrangTextBox.BajrangTextbox txtNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpLoanDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private BajrangTextBox.BajrangTextbox txtBalance;
        private CodeVendor.Controls.Grouper grouper2;
        private BajrangTextBox.BajrangTextbox bajrangTextbox2;
        private System.Windows.Forms.DataGridView dgvLoanList;
    }
}