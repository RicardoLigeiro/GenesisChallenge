namespace GenesisChallenge
{
    partial class CustomerDetail
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEditFirstName = new DevExpress.XtraEditors.TextEdit();
            this.txtEditLastName = new DevExpress.XtraEditors.TextEdit();
            this.lblReference = new System.Windows.Forms.Label();
            this.lblOrderValue = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditLastName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(22, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(364, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 32);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOrderDate);
            this.groupBox1.Controls.Add(this.lblOrderValue);
            this.groupBox1.Controls.Add(this.lblReference);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(22, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 153);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Details:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Reference:";
            // 
            // txtEditFirstName
            // 
            this.txtEditFirstName.Location = new System.Drawing.Point(101, 25);
            this.txtEditFirstName.Name = "txtEditFirstName";
            this.txtEditFirstName.Properties.ValidateOnEnterKey = true;
            this.txtEditFirstName.Size = new System.Drawing.Size(338, 22);
            this.txtEditFirstName.TabIndex = 12;
            this.txtEditFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtEditFirstName_Validating);
            // 
            // txtEditLastName
            // 
            this.txtEditLastName.Location = new System.Drawing.Point(101, 65);
            this.txtEditLastName.Name = "txtEditLastName";
            this.txtEditLastName.Properties.ValidateOnEnterKey = true;
            this.txtEditLastName.Size = new System.Drawing.Size(338, 22);
            this.txtEditLastName.TabIndex = 13;
            this.txtEditLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtEditLastName_Validating);
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Location = new System.Drawing.Point(100, 36);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(0, 17);
            this.lblReference.TabIndex = 12;
            // 
            // lblOrderValue
            // 
            this.lblOrderValue.AutoSize = true;
            this.lblOrderValue.Location = new System.Drawing.Point(100, 70);
            this.lblOrderValue.Name = "lblOrderValue";
            this.lblOrderValue.Size = new System.Drawing.Size(0, 17);
            this.lblOrderValue.TabIndex = 13;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(100, 108);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(0, 17);
            this.lblOrderDate.TabIndex = 14;
            // 
            // CustomerDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 335);
            this.Controls.Add(this.txtEditLastName);
            this.Controls.Add(this.txtEditFirstName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CustomerDetail";
            this.Text = "Customer Order Detail";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEditLastName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtEditFirstName;
        private DevExpress.XtraEditors.TextEdit txtEditLastName;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblOrderValue;
        private System.Windows.Forms.Label lblReference;
    }
}