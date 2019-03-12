namespace GenesisChallenge
{
    partial class MainWindow
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
            this.OrdersGridControl = new DevExpress.XtraGrid.GridControl();
            this.OrderGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLoadRecords = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdersGridControl
            // 
            this.OrdersGridControl.Location = new System.Drawing.Point(12, 12);
            this.OrdersGridControl.MainView = this.OrderGridView;
            this.OrdersGridControl.Name = "OrdersGridControl";
            this.OrdersGridControl.Size = new System.Drawing.Size(776, 426);
            this.OrdersGridControl.TabIndex = 0;
            this.OrdersGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.OrderGridView});
            // 
            // OrderGridView
            // 
            this.OrderGridView.GridControl = this.OrdersGridControl;
            this.OrderGridView.Name = "OrderGridView";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 453);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(108, 33);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLoadRecords
            // 
            this.btnLoadRecords.Location = new System.Drawing.Point(643, 453);
            this.btnLoadRecords.Name = "btnLoadRecords";
            this.btnLoadRecords.Size = new System.Drawing.Size(145, 33);
            this.btnLoadRecords.TabIndex = 2;
            this.btnLoadRecords.Text = "Load Records";
            this.btnLoadRecords.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 503);
            this.Controls.Add(this.btnLoadRecords);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.OrdersGridControl);
            this.Name = "MainWindow";
            this.Text = " Ganesis Challenge";
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl OrdersGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView OrderGridView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLoadRecords;
    }
}

