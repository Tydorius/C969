
namespace C969
{
    partial class frmTests
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
            this.btncreateAddress = new System.Windows.Forms.Button();
            this.btnupdateAddress = new System.Windows.Forms.Button();
            this.btnlookupAddress = new System.Windows.Forms.Button();
            this.btncreateCity = new System.Windows.Forms.Button();
            this.btnupdateCity = new System.Windows.Forms.Button();
            this.btnlookupCountryID = new System.Windows.Forms.Button();
            this.btnlookupCity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btncreateAddress
            // 
            this.btncreateAddress.Location = new System.Drawing.Point(12, 12);
            this.btncreateAddress.Name = "btncreateAddress";
            this.btncreateAddress.Size = new System.Drawing.Size(98, 23);
            this.btncreateAddress.TabIndex = 0;
            this.btncreateAddress.Text = "createAddress";
            this.btncreateAddress.UseVisualStyleBackColor = true;
            this.btncreateAddress.Click += new System.EventHandler(this.btncreateAddress_Click);
            // 
            // btnupdateAddress
            // 
            this.btnupdateAddress.Location = new System.Drawing.Point(12, 41);
            this.btnupdateAddress.Name = "btnupdateAddress";
            this.btnupdateAddress.Size = new System.Drawing.Size(98, 23);
            this.btnupdateAddress.TabIndex = 0;
            this.btnupdateAddress.Text = "updateAddress";
            this.btnupdateAddress.UseVisualStyleBackColor = true;
            this.btnupdateAddress.Click += new System.EventHandler(this.btnupdateAddress_Click);
            // 
            // btnlookupAddress
            // 
            this.btnlookupAddress.Location = new System.Drawing.Point(12, 70);
            this.btnlookupAddress.Name = "btnlookupAddress";
            this.btnlookupAddress.Size = new System.Drawing.Size(98, 23);
            this.btnlookupAddress.TabIndex = 0;
            this.btnlookupAddress.Text = "lookupAddress";
            this.btnlookupAddress.UseVisualStyleBackColor = true;
            this.btnlookupAddress.Click += new System.EventHandler(this.btnlookupAddress_Click);
            // 
            // btncreateCity
            // 
            this.btncreateCity.Location = new System.Drawing.Point(12, 132);
            this.btncreateCity.Name = "btncreateCity";
            this.btncreateCity.Size = new System.Drawing.Size(98, 23);
            this.btncreateCity.TabIndex = 0;
            this.btncreateCity.Text = "createCity";
            this.btncreateCity.UseVisualStyleBackColor = true;
            this.btncreateCity.Click += new System.EventHandler(this.btncreateCity_Click);
            // 
            // btnupdateCity
            // 
            this.btnupdateCity.Location = new System.Drawing.Point(12, 161);
            this.btnupdateCity.Name = "btnupdateCity";
            this.btnupdateCity.Size = new System.Drawing.Size(98, 23);
            this.btnupdateCity.TabIndex = 0;
            this.btnupdateCity.Text = "updateCity";
            this.btnupdateCity.UseVisualStyleBackColor = true;
            this.btnupdateCity.Click += new System.EventHandler(this.btnupdateCity_Click);
            // 
            // btnlookupCountryID
            // 
            this.btnlookupCountryID.Location = new System.Drawing.Point(12, 190);
            this.btnlookupCountryID.Name = "btnlookupCountryID";
            this.btnlookupCountryID.Size = new System.Drawing.Size(98, 23);
            this.btnlookupCountryID.TabIndex = 0;
            this.btnlookupCountryID.Text = "lookupCountryID";
            this.btnlookupCountryID.UseVisualStyleBackColor = true;
            this.btnlookupCountryID.Click += new System.EventHandler(this.btnlookupCountryID_Click);
            // 
            // btnlookupCity
            // 
            this.btnlookupCity.Location = new System.Drawing.Point(13, 220);
            this.btnlookupCity.Name = "btnlookupCity";
            this.btnlookupCity.Size = new System.Drawing.Size(97, 23);
            this.btnlookupCity.TabIndex = 1;
            this.btnlookupCity.Text = "lookupCity";
            this.btnlookupCity.UseVisualStyleBackColor = true;
            this.btnlookupCity.Click += new System.EventHandler(this.btnlookupCity_Click);
            // 
            // frmTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 287);
            this.Controls.Add(this.btnlookupCity);
            this.Controls.Add(this.btnlookupCountryID);
            this.Controls.Add(this.btnupdateCity);
            this.Controls.Add(this.btncreateCity);
            this.Controls.Add(this.btnlookupAddress);
            this.Controls.Add(this.btnupdateAddress);
            this.Controls.Add(this.btncreateAddress);
            this.Name = "frmTests";
            this.Text = "frmTests";
            this.Load += new System.EventHandler(this.frmTests_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btncreateAddress;
        private System.Windows.Forms.Button btnupdateAddress;
        private System.Windows.Forms.Button btnlookupAddress;
        private System.Windows.Forms.Button btncreateCity;
        private System.Windows.Forms.Button btnupdateCity;
        private System.Windows.Forms.Button btnlookupCountryID;
        private System.Windows.Forms.Button btnlookupCity;
    }
}