
namespace C969
{
    partial class frmCalendar
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
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDeleteApt = new System.Windows.Forms.Button();
            this.btnNewApt = new System.Windows.Forms.Button();
            this.btnEditApt = new System.Windows.Forms.Button();
            this.dgvEventList = new System.Windows.Forms.DataGridView();
            this.mcCalendar = new System.Windows.Forms.MonthCalendar();
            this.rbSunday = new System.Windows.Forms.RadioButton();
            this.rbMonday = new System.Windows.Forms.RadioButton();
            this.rbTuesday = new System.Windows.Forms.RadioButton();
            this.rbWednesday = new System.Windows.Forms.RadioButton();
            this.rbThursday = new System.Windows.Forms.RadioButton();
            this.rbFriday = new System.Windows.Forms.RadioButton();
            this.rbSaturday = new System.Windows.Forms.RadioButton();
            this.btnTestData = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(552, 3);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(60, 23);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Location = new System.Drawing.Point(13, 3);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(69, 23);
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Reports";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnDeleteApt
            // 
            this.btnDeleteApt.Location = new System.Drawing.Point(471, 406);
            this.btnDeleteApt.Name = "btnDeleteApt";
            this.btnDeleteApt.Size = new System.Drawing.Size(135, 23);
            this.btnDeleteApt.TabIndex = 3;
            this.btnDeleteApt.Text = "Delete Appointment";
            this.btnDeleteApt.UseVisualStyleBackColor = true;
            this.btnDeleteApt.Click += new System.EventHandler(this.btnDeleteApt_Click);
            // 
            // btnNewApt
            // 
            this.btnNewApt.Location = new System.Drawing.Point(330, 406);
            this.btnNewApt.Name = "btnNewApt";
            this.btnNewApt.Size = new System.Drawing.Size(135, 23);
            this.btnNewApt.TabIndex = 3;
            this.btnNewApt.Text = "New Appointment";
            this.btnNewApt.UseVisualStyleBackColor = true;
            this.btnNewApt.Click += new System.EventHandler(this.btnNewApt_Click);
            // 
            // btnEditApt
            // 
            this.btnEditApt.Location = new System.Drawing.Point(189, 406);
            this.btnEditApt.Name = "btnEditApt";
            this.btnEditApt.Size = new System.Drawing.Size(135, 23);
            this.btnEditApt.TabIndex = 3;
            this.btnEditApt.Text = "Edit Appointment";
            this.btnEditApt.UseVisualStyleBackColor = true;
            this.btnEditApt.Click += new System.EventHandler(this.btnEditApt_Click);
            // 
            // dgvEventList
            // 
            this.dgvEventList.AllowUserToAddRows = false;
            this.dgvEventList.AllowUserToDeleteRows = false;
            this.dgvEventList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEventList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventList.Location = new System.Drawing.Point(12, 35);
            this.dgvEventList.MultiSelect = false;
            this.dgvEventList.Name = "dgvEventList";
            this.dgvEventList.ReadOnly = true;
            this.dgvEventList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEventList.Size = new System.Drawing.Size(600, 162);
            this.dgvEventList.TabIndex = 5;
            this.dgvEventList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEventList_CellContentDoubleClick);
            // 
            // mcCalendar
            // 
            this.mcCalendar.Location = new System.Drawing.Point(379, 214);
            this.mcCalendar.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.mcCalendar.MaxSelectionCount = 1;
            this.mcCalendar.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.mcCalendar.Name = "mcCalendar";
            this.mcCalendar.TabIndex = 6;
            this.mcCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcCalendar_DateChanged);
            // 
            // rbSunday
            // 
            this.rbSunday.AutoSize = true;
            this.rbSunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSunday.Location = new System.Drawing.Point(13, 198);
            this.rbSunday.Name = "rbSunday";
            this.rbSunday.Size = new System.Drawing.Size(68, 28);
            this.rbSunday.TabIndex = 8;
            this.rbSunday.TabStop = true;
            this.rbSunday.Text = "date";
            this.rbSunday.UseVisualStyleBackColor = true;
            this.rbSunday.CheckedChanged += new System.EventHandler(this.rbSunday_CheckedChanged);
            // 
            // rbMonday
            // 
            this.rbMonday.AutoSize = true;
            this.rbMonday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMonday.Location = new System.Drawing.Point(13, 228);
            this.rbMonday.Name = "rbMonday";
            this.rbMonday.Size = new System.Drawing.Size(68, 28);
            this.rbMonday.TabIndex = 8;
            this.rbMonday.TabStop = true;
            this.rbMonday.Text = "date";
            this.rbMonday.UseVisualStyleBackColor = true;
            this.rbMonday.CheckedChanged += new System.EventHandler(this.rbMonday_CheckedChanged);
            // 
            // rbTuesday
            // 
            this.rbTuesday.AutoSize = true;
            this.rbTuesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTuesday.Location = new System.Drawing.Point(15, 258);
            this.rbTuesday.Name = "rbTuesday";
            this.rbTuesday.Size = new System.Drawing.Size(68, 28);
            this.rbTuesday.TabIndex = 8;
            this.rbTuesday.TabStop = true;
            this.rbTuesday.Text = "date";
            this.rbTuesday.UseVisualStyleBackColor = true;
            this.rbTuesday.CheckedChanged += new System.EventHandler(this.rbTuesday_CheckedChanged);
            // 
            // rbWednesday
            // 
            this.rbWednesday.AutoSize = true;
            this.rbWednesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWednesday.Location = new System.Drawing.Point(15, 288);
            this.rbWednesday.Name = "rbWednesday";
            this.rbWednesday.Size = new System.Drawing.Size(68, 28);
            this.rbWednesday.TabIndex = 8;
            this.rbWednesday.TabStop = true;
            this.rbWednesday.Text = "date";
            this.rbWednesday.UseVisualStyleBackColor = true;
            this.rbWednesday.CheckedChanged += new System.EventHandler(this.rbWednesday_CheckedChanged);
            // 
            // rbThursday
            // 
            this.rbThursday.AutoSize = true;
            this.rbThursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbThursday.Location = new System.Drawing.Point(15, 318);
            this.rbThursday.Name = "rbThursday";
            this.rbThursday.Size = new System.Drawing.Size(68, 28);
            this.rbThursday.TabIndex = 8;
            this.rbThursday.TabStop = true;
            this.rbThursday.Text = "date";
            this.rbThursday.UseVisualStyleBackColor = true;
            this.rbThursday.CheckedChanged += new System.EventHandler(this.rbThursday_CheckedChanged);
            // 
            // rbFriday
            // 
            this.rbFriday.AutoSize = true;
            this.rbFriday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFriday.Location = new System.Drawing.Point(15, 348);
            this.rbFriday.Name = "rbFriday";
            this.rbFriday.Size = new System.Drawing.Size(68, 28);
            this.rbFriday.TabIndex = 8;
            this.rbFriday.TabStop = true;
            this.rbFriday.Text = "date";
            this.rbFriday.UseVisualStyleBackColor = true;
            this.rbFriday.CheckedChanged += new System.EventHandler(this.rbFriday_CheckedChanged);
            // 
            // rbSaturday
            // 
            this.rbSaturday.AutoSize = true;
            this.rbSaturday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSaturday.Location = new System.Drawing.Point(15, 378);
            this.rbSaturday.Name = "rbSaturday";
            this.rbSaturday.Size = new System.Drawing.Size(68, 28);
            this.rbSaturday.TabIndex = 8;
            this.rbSaturday.TabStop = true;
            this.rbSaturday.Text = "date";
            this.rbSaturday.UseVisualStyleBackColor = true;
            this.rbSaturday.CheckedChanged += new System.EventHandler(this.rbSaturday_CheckedChanged);
            // 
            // btnTestData
            // 
            this.btnTestData.Location = new System.Drawing.Point(232, 3);
            this.btnTestData.Name = "btnTestData";
            this.btnTestData.Size = new System.Drawing.Size(168, 23);
            this.btnTestData.TabIndex = 9;
            this.btnTestData.Text = "Populate Example Events";
            this.btnTestData.UseVisualStyleBackColor = true;
            this.btnTestData.Click += new System.EventHandler(this.btnTestData_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(407, 2);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(99, 23);
            this.btnClean.TabIndex = 10;
            this.btnClean.Text = "Clean Database";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // frmCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnTestData);
            this.Controls.Add(this.rbSaturday);
            this.Controls.Add(this.rbFriday);
            this.Controls.Add(this.rbThursday);
            this.Controls.Add(this.rbWednesday);
            this.Controls.Add(this.rbTuesday);
            this.Controls.Add(this.rbMonday);
            this.Controls.Add(this.rbSunday);
            this.Controls.Add(this.mcCalendar);
            this.Controls.Add(this.dgvEventList);
            this.Controls.Add(this.btnEditApt);
            this.Controls.Add(this.btnNewApt);
            this.Controls.Add(this.btnDeleteApt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnLogOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCalendar";
            this.Text = "C969 | Calendar";
            this.Load += new System.EventHandler(this.frmCalendar_Load);
            this.VisibleChanged += new System.EventHandler(this.frmCalendar_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDeleteApt;
        private System.Windows.Forms.Button btnNewApt;
        private System.Windows.Forms.Button btnEditApt;
        private System.Windows.Forms.DataGridView dgvEventList;
        private System.Windows.Forms.MonthCalendar mcCalendar;
        private System.Windows.Forms.RadioButton rbSunday;
        private System.Windows.Forms.RadioButton rbMonday;
        private System.Windows.Forms.RadioButton rbTuesday;
        private System.Windows.Forms.RadioButton rbWednesday;
        private System.Windows.Forms.RadioButton rbThursday;
        private System.Windows.Forms.RadioButton rbFriday;
        private System.Windows.Forms.RadioButton rbSaturday;
        private System.Windows.Forms.Button btnTestData;
        private System.Windows.Forms.Button btnClean;
    }
}