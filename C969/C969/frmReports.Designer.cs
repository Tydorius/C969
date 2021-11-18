
namespace C969
{
    partial class frmReports
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
            this.dgvReportOutput = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogins = new System.Windows.Forms.Button();
            this.btnSchedules = new System.Windows.Forms.Button();
            this.btnTypes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReportOutput
            // 
            this.dgvReportOutput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvReportOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportOutput.Location = new System.Drawing.Point(12, 12);
            this.dgvReportOutput.Name = "dgvReportOutput";
            this.dgvReportOutput.ReadOnly = true;
            this.dgvReportOutput.Size = new System.Drawing.Size(776, 330);
            this.dgvReportOutput.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(713, 415);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogins
            // 
            this.btnLogins.Location = new System.Drawing.Point(12, 348);
            this.btnLogins.Name = "btnLogins";
            this.btnLogins.Size = new System.Drawing.Size(126, 23);
            this.btnLogins.TabIndex = 1;
            this.btnLogins.Text = "Machine Logins";
            this.btnLogins.UseVisualStyleBackColor = true;
            this.btnLogins.Click += new System.EventHandler(this.btnLogins_Click);
            // 
            // btnSchedules
            // 
            this.btnSchedules.Location = new System.Drawing.Point(12, 377);
            this.btnSchedules.Name = "btnSchedules";
            this.btnSchedules.Size = new System.Drawing.Size(126, 23);
            this.btnSchedules.TabIndex = 1;
            this.btnSchedules.Text = "Consultant Schedules";
            this.btnSchedules.UseVisualStyleBackColor = true;
            this.btnSchedules.Click += new System.EventHandler(this.btnSchedules_Click);
            // 
            // btnTypes
            // 
            this.btnTypes.Location = new System.Drawing.Point(12, 406);
            this.btnTypes.Name = "btnTypes";
            this.btnTypes.Size = new System.Drawing.Size(126, 23);
            this.btnTypes.TabIndex = 1;
            this.btnTypes.Text = "Appointment Types";
            this.btnTypes.UseVisualStyleBackColor = true;
            this.btnTypes.Click += new System.EventHandler(this.btnTypes_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTypes);
            this.Controls.Add(this.btnSchedules);
            this.Controls.Add(this.btnLogins);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvReportOutput);
            this.Name = "frmReports";
            this.Text = "C969 | Reports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReportOutput;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogins;
        private System.Windows.Forms.Button btnSchedules;
        private System.Windows.Forms.Button btnTypes;
    }
}