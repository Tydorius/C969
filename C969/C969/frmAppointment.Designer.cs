
namespace C969
{
    partial class frmAppointment
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
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.txtbxTitle = new System.Windows.Forms.TextBox();
            this.datetimeStart = new System.Windows.Forms.DateTimePicker();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.datetimeEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtbxCustomer = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtbxDescription = new System.Windows.Forms.TextBox();
            this.txtbxLocation = new System.Windows.Forms.TextBox();
            this.txtbxContact = new System.Windows.Forms.TextBox();
            this.txtbxType = new System.Windows.Forms.TextBox();
            this.txtbxURL = new System.Windows.Forms.TextBox();
            this.lblURL = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(12, 12);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(600, 179);
            this.dgvCustomers.TabIndex = 1;
            this.dgvCustomers.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellContentDoubleClick);
            // 
            // txtbxTitle
            // 
            this.txtbxTitle.Location = new System.Drawing.Point(89, 195);
            this.txtbxTitle.Name = "txtbxTitle";
            this.txtbxTitle.Size = new System.Drawing.Size(200, 20);
            this.txtbxTitle.TabIndex = 2;
            this.txtbxTitle.TextChanged += new System.EventHandler(this.txtbxTitle_TextChanged);
            // 
            // datetimeStart
            // 
            this.datetimeStart.CustomFormat = "yyyy-MM-dd hh:mm tt";
            this.datetimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeStart.Location = new System.Drawing.Point(89, 221);
            this.datetimeStart.Name = "datetimeStart";
            this.datetimeStart.Size = new System.Drawing.Size(200, 20);
            this.datetimeStart.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(8, 198);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Title";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(9, 227);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(29, 13);
            this.lblStart.TabIndex = 5;
            this.lblStart.Text = "Start";
            // 
            // datetimeEnd
            // 
            this.datetimeEnd.CustomFormat = "yyyy-MM-dd hh:mm tt";
            this.datetimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetimeEnd.Location = new System.Drawing.Point(89, 247);
            this.datetimeEnd.Name = "datetimeEnd";
            this.datetimeEnd.Size = new System.Drawing.Size(200, 20);
            this.datetimeEnd.TabIndex = 4;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(9, 253);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(26, 13);
            this.lblEnd.TabIndex = 5;
            this.lblEnd.Text = "End";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 273);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(6, 299);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 5;
            this.lblLocation.Text = "Location";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(6, 403);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 5;
            this.lblCustomer.Text = "Customer";
            // 
            // txtbxCustomer
            // 
            this.txtbxCustomer.Location = new System.Drawing.Point(89, 400);
            this.txtbxCustomer.Name = "txtbxCustomer";
            this.txtbxCustomer.ReadOnly = true;
            this.txtbxCustomer.Size = new System.Drawing.Size(200, 20);
            this.txtbxCustomer.TabIndex = 3;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(6, 325);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(44, 13);
            this.lblContact.TabIndex = 5;
            this.lblContact.Text = "Contact";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 348);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "Type";
            // 
            // txtbxDescription
            // 
            this.txtbxDescription.Location = new System.Drawing.Point(89, 270);
            this.txtbxDescription.Name = "txtbxDescription";
            this.txtbxDescription.Size = new System.Drawing.Size(200, 20);
            this.txtbxDescription.TabIndex = 5;
            // 
            // txtbxLocation
            // 
            this.txtbxLocation.Location = new System.Drawing.Point(89, 296);
            this.txtbxLocation.Name = "txtbxLocation";
            this.txtbxLocation.Size = new System.Drawing.Size(200, 20);
            this.txtbxLocation.TabIndex = 6;
            // 
            // txtbxContact
            // 
            this.txtbxContact.Location = new System.Drawing.Point(89, 322);
            this.txtbxContact.Name = "txtbxContact";
            this.txtbxContact.Size = new System.Drawing.Size(200, 20);
            this.txtbxContact.TabIndex = 7;
            // 
            // txtbxType
            // 
            this.txtbxType.Location = new System.Drawing.Point(89, 348);
            this.txtbxType.Name = "txtbxType";
            this.txtbxType.Size = new System.Drawing.Size(200, 20);
            this.txtbxType.TabIndex = 8;
            // 
            // txtbxURL
            // 
            this.txtbxURL.Location = new System.Drawing.Point(89, 374);
            this.txtbxURL.Name = "txtbxURL";
            this.txtbxURL.Size = new System.Drawing.Size(200, 20);
            this.txtbxURL.TabIndex = 9;
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(6, 377);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(29, 13);
            this.lblURL.TabIndex = 5;
            this.lblURL.Text = "URL";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(537, 406);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(456, 197);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(156, 23);
            this.btnSelect.TabIndex = 10;
            this.btnSelect.Text = "Select Customer";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(456, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.datetimeEnd);
            this.Controls.Add(this.datetimeStart);
            this.Controls.Add(this.txtbxCustomer);
            this.Controls.Add(this.txtbxURL);
            this.Controls.Add(this.txtbxType);
            this.Controls.Add(this.txtbxContact);
            this.Controls.Add(this.txtbxLocation);
            this.Controls.Add(this.txtbxDescription);
            this.Controls.Add(this.txtbxTitle);
            this.Controls.Add(this.dgvCustomers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAppointment";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C969 | Appointment";
            this.Load += new System.EventHandler(this.frmAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.TextBox txtbxTitle;
        private System.Windows.Forms.DateTimePicker datetimeStart;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker datetimeEnd;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtbxCustomer;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtbxDescription;
        private System.Windows.Forms.TextBox txtbxLocation;
        private System.Windows.Forms.TextBox txtbxContact;
        private System.Windows.Forms.TextBox txtbxType;
        private System.Windows.Forms.TextBox txtbxURL;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnSave;
    }
}