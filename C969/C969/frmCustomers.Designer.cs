
namespace C969
{
    partial class frmCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomers));
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtbxCustomerName = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.mtxtbxPhone = new System.Windows.Forms.MaskedTextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtbxAddress1 = new System.Windows.Forms.TextBox();
            this.txtbxAddress2 = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtbxCity = new System.Windows.Forms.TextBox();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblPostal = new System.Windows.Forms.Label();
            this.txtbxPostal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(537, 197);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(456, 197);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(375, 197);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(456, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbCountry
            // 
            this.cbCountry.AutoCompleteCustomSource.AddRange(new string[] {
            "US",
            "Canada",
            "Norway"});
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Items.AddRange(new object[] {
            "US",
            "Canada",
            "Norway"});
            this.cbCountry.Location = new System.Drawing.Point(136, 385);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(121, 21);
            this.cbCountry.TabIndex = 9;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 203);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Customer Name";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 234);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 261);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(78, 13);
            this.lblPhone.TabIndex = 3;
            this.lblPhone.Text = "Phone Number";
            // 
            // txtbxCustomerName
            // 
            this.txtbxCustomerName.Location = new System.Drawing.Point(136, 200);
            this.txtbxCustomerName.MaxLength = 45;
            this.txtbxCustomerName.Name = "txtbxCustomerName";
            this.txtbxCustomerName.Size = new System.Drawing.Size(231, 20);
            this.txtbxCustomerName.TabIndex = 2;
            this.txtbxCustomerName.TextChanged += new System.EventHandler(this.txtbxCustomerName_TextChanged);
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbStatus.Location = new System.Drawing.Point(136, 229);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 3;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // mtxtbxPhone
            // 
            this.mtxtbxPhone.Location = new System.Drawing.Point(136, 256);
            this.mtxtbxPhone.Mask = "+999-000-000-0000";
            this.mtxtbxPhone.Name = "mtxtbxPhone";
            this.mtxtbxPhone.Size = new System.Drawing.Size(100, 20);
            this.mtxtbxPhone.TabIndex = 4;
            this.mtxtbxPhone.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxtbxPhone_MaskInputRejected);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 288);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "Address";
            // 
            // txtbxAddress1
            // 
            this.txtbxAddress1.Location = new System.Drawing.Point(136, 281);
            this.txtbxAddress1.MaxLength = 50;
            this.txtbxAddress1.Name = "txtbxAddress1";
            this.txtbxAddress1.Size = new System.Drawing.Size(231, 20);
            this.txtbxAddress1.TabIndex = 5;
            this.txtbxAddress1.TextChanged += new System.EventHandler(this.txtbxAddress1_TextChanged);
            // 
            // txtbxAddress2
            // 
            this.txtbxAddress2.Location = new System.Drawing.Point(136, 307);
            this.txtbxAddress2.MaxLength = 50;
            this.txtbxAddress2.Name = "txtbxAddress2";
            this.txtbxAddress2.Size = new System.Drawing.Size(231, 20);
            this.txtbxAddress2.TabIndex = 6;
            this.txtbxAddress2.TextChanged += new System.EventHandler(this.txtbxAddress2_TextChanged);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(14, 362);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 3;
            this.lblCity.Text = "City";
            // 
            // txtbxCity
            // 
            this.txtbxCity.Location = new System.Drawing.Point(136, 359);
            this.txtbxCity.MaxLength = 50;
            this.txtbxCity.Name = "txtbxCity";
            this.txtbxCity.Size = new System.Drawing.Size(231, 20);
            this.txtbxCity.TabIndex = 8;
            this.txtbxCity.TextChanged += new System.EventHandler(this.txtbxCity_TextChanged);
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(12, 314);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(93, 13);
            this.lblAddress2.TabIndex = 3;
            this.lblAddress2.Text = "Address (Optional)";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(14, 388);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 3;
            this.lblCountry.Text = "Country";
            // 
            // lblPostal
            // 
            this.lblPostal.AutoSize = true;
            this.lblPostal.Location = new System.Drawing.Point(12, 340);
            this.lblPostal.Name = "lblPostal";
            this.lblPostal.Size = new System.Drawing.Size(64, 13);
            this.lblPostal.TabIndex = 3;
            this.lblPostal.Text = "Postal Code";
            // 
            // txtbxPostal
            // 
            this.txtbxPostal.Location = new System.Drawing.Point(136, 333);
            this.txtbxPostal.MaxLength = 10;
            this.txtbxPostal.Name = "txtbxPostal";
            this.txtbxPostal.Size = new System.Drawing.Size(231, 20);
            this.txtbxPostal.TabIndex = 7;
            this.txtbxPostal.TextChanged += new System.EventHandler(this.txtbxPostal_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(375, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 152);
            this.label1.TabIndex = 14;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // frmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxtbxPhone);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.txtbxCity);
            this.Controls.Add(this.txtbxPostal);
            this.Controls.Add(this.txtbxAddress2);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblPostal);
            this.Controls.Add(this.txtbxAddress1);
            this.Controls.Add(this.lblAddress2);
            this.Controls.Add(this.txtbxCustomerName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvCustomers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCustomers";
            this.Text = "C969 | Customers";
            this.Load += new System.EventHandler(this.frmCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtbxCustomerName;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.MaskedTextBox mtxtbxPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtbxAddress1;
        private System.Windows.Forms.TextBox txtbxAddress2;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtbxCity;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblPostal;
        private System.Windows.Forms.TextBox txtbxPostal;
        private System.Windows.Forms.Label label1;
    }
}