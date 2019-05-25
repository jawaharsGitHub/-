namespace CenturyFinCorpApp.UsrCtrl
{
    partial class ucPollingStation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbAssembly = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbReports = new System.Windows.Forms.ComboBox();
            this.cmbScope = new System.Windows.Forms.ComboBox();
            this.cmbUnionBlocks = new System.Windows.Forms.ComboBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnBoothReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1224, 619);
            this.dataGridView1.TabIndex = 0;
            // 
            // cmbAssembly
            // 
            this.cmbAssembly.DisplayMember = "AssemblyFullName";
            this.cmbAssembly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssembly.FormattingEnabled = true;
            this.cmbAssembly.Location = new System.Drawing.Point(17, 57);
            this.cmbAssembly.Name = "cmbAssembly";
            this.cmbAssembly.Size = new System.Drawing.Size(202, 21);
            this.cmbAssembly.TabIndex = 1;
            this.cmbAssembly.ValueMember = "AssemblyNo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // cmbReports
            // 
            this.cmbReports.DisplayMember = "AssemblyFullName";
            this.cmbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReports.FormattingEnabled = true;
            this.cmbReports.Location = new System.Drawing.Point(236, 57);
            this.cmbReports.Name = "cmbReports";
            this.cmbReports.Size = new System.Drawing.Size(202, 21);
            this.cmbReports.TabIndex = 3;
            this.cmbReports.ValueMember = "AssemblyNo";
            this.cmbReports.SelectedIndexChanged += new System.EventHandler(this.cmbReports_SelectedIndexChanged);
            // 
            // cmbScope
            // 
            this.cmbScope.DisplayMember = "AssemblyNo";
            this.cmbScope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScope.FormattingEnabled = true;
            this.cmbScope.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbScope.Location = new System.Drawing.Point(455, 57);
            this.cmbScope.Name = "cmbScope";
            this.cmbScope.Size = new System.Drawing.Size(202, 21);
            this.cmbScope.TabIndex = 4;
            this.cmbScope.ValueMember = "AssemblyNo";
            this.cmbScope.SelectedIndexChanged += new System.EventHandler(this.cmbScope_SelectedIndexChanged);
            // 
            // cmbUnionBlocks
            // 
            this.cmbUnionBlocks.DisplayMember = "AssemblyNo";
            this.cmbUnionBlocks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnionBlocks.FormattingEnabled = true;
            this.cmbUnionBlocks.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbUnionBlocks.Location = new System.Drawing.Point(663, 57);
            this.cmbUnionBlocks.Name = "cmbUnionBlocks";
            this.cmbUnionBlocks.Size = new System.Drawing.Size(202, 21);
            this.cmbUnionBlocks.TabIndex = 5;
            this.cmbUnionBlocks.ValueMember = "AssemblyNo";
            this.cmbUnionBlocks.SelectedIndexChanged += new System.EventHandler(this.cmbUnionBlocks_SelectedIndexChanged);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(259, 12);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Reports";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnBoothReport
            // 
            this.btnBoothReport.Location = new System.Drawing.Point(373, 12);
            this.btnBoothReport.Name = "btnBoothReport";
            this.btnBoothReport.Size = new System.Drawing.Size(75, 23);
            this.btnBoothReport.TabIndex = 7;
            this.btnBoothReport.Text = "Booth Report";
            this.btnBoothReport.UseVisualStyleBackColor = true;
            this.btnBoothReport.Click += new System.EventHandler(this.btnBoothReport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(487, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Detailed Reports";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucPollingStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBoothReport);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.cmbUnionBlocks);
            this.Controls.Add(this.cmbScope);
            this.Controls.Add(this.cmbReports);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAssembly);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ucPollingStation";
            this.Size = new System.Drawing.Size(1257, 823);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbAssembly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbReports;
        private System.Windows.Forms.ComboBox cmbScope;
        private System.Windows.Forms.ComboBox cmbUnionBlocks;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnBoothReport;
        private System.Windows.Forms.Button button1;
    }
}
