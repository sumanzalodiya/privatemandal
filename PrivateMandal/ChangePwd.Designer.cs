namespace PrivateMandal
{
    partial class ChangePwd
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPayment = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUserId = new BajrangTextBox.BajrangTextbox();
            this.txtUserName = new BajrangTextBox.BajrangTextbox();
            this.txtOldPwd = new BajrangTextBox.BajrangTextbox();
            this.txtNewPwd = new BajrangTextBox.BajrangTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReNewPwd = new BajrangTextBox.BajrangTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtReNewPwd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNewPwd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOldPwd);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Controls.Add(this.lblPayment);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 353);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.ForeColor = System.Drawing.Color.Black;
            this.lblPayment.Location = new System.Drawing.Point(21, 130);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(147, 30);
            this.lblPayment.TabIndex = 73;
            this.lblPayment.Text = "Old Password";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(134, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 48);
            this.button1.TabIndex = 5;
            this.button1.Text = "Change Password";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 30);
            this.label1.TabIndex = 70;
            this.label1.Text = "User Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(21, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 30);
            this.label13.TabIndex = 69;
            this.label13.Text = "User ID";
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.Color.White;
            this.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserId.Enabled = false;
            this.txtUserId.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.txtUserId.IsNumeric = false;
            this.txtUserId.Location = new System.Drawing.Point(222, 32);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(280, 32);
            this.txtUserId.TabIndex = 74;
            this.txtUserId.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Enabled = false;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.txtUserName.IsNumeric = false;
            this.txtUserName.Location = new System.Drawing.Point(222, 82);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(280, 32);
            this.txtUserName.TabIndex = 75;
            this.txtUserName.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.Capitalize;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.BackColor = System.Drawing.Color.White;
            this.txtOldPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldPwd.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.txtOldPwd.IsNumeric = false;
            this.txtOldPwd.Location = new System.Drawing.Point(222, 132);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(280, 32);
            this.txtOldPwd.TabIndex = 76;
            this.txtOldPwd.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.None;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.BackColor = System.Drawing.Color.White;
            this.txtNewPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPwd.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.txtNewPwd.IsNumeric = false;
            this.txtNewPwd.Location = new System.Drawing.Point(222, 181);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(280, 32);
            this.txtNewPwd.TabIndex = 78;
            this.txtNewPwd.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.None;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 30);
            this.label2.TabIndex = 77;
            this.label2.Text = "New Password";
            // 
            // txtReNewPwd
            // 
            this.txtReNewPwd.BackColor = System.Drawing.Color.White;
            this.txtReNewPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReNewPwd.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.txtReNewPwd.IsNumeric = false;
            this.txtReNewPwd.Location = new System.Drawing.Point(222, 231);
            this.txtReNewPwd.Name = "txtReNewPwd";
            this.txtReNewPwd.PasswordChar = '*';
            this.txtReNewPwd.Size = new System.Drawing.Size(280, 32);
            this.txtReNewPwd.TabIndex = 80;
            this.txtReNewPwd.TextTransform = BajrangTextBox.BajrangTextbox.TextDecoration.None;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 30);
            this.label3.TabIndex = 79;
            this.label3.Text = "Re-New Password";
            // 
            // ChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(545, 369);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChangePwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePwd";
            this.Load += new System.EventHandler(this.ChangePwd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private BajrangTextBox.BajrangTextbox txtReNewPwd;
        private System.Windows.Forms.Label label3;
        private BajrangTextBox.BajrangTextbox txtNewPwd;
        private System.Windows.Forms.Label label2;
        private BajrangTextBox.BajrangTextbox txtOldPwd;
        private BajrangTextBox.BajrangTextbox txtUserName;
        private BajrangTextBox.BajrangTextbox txtUserId;
    }
}