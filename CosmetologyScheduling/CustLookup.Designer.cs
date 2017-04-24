namespace CosmetologyScheduling
{
    partial class CustLookup
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
            this.instructionLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.phoneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.outputListView = new System.Windows.Forms.ListView();
            this.fNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phoneCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addressCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cityCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stateCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zipCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bannedCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memoCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Location = new System.Drawing.Point(12, 9);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(237, 13);
            this.instructionLabel.TabIndex = 0;
            this.instructionLabel.Text = "Enter Customer Phone Number or Email Address:";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(12, 32);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(41, 13);
            this.phoneLabel.TabIndex = 1;
            this.phoneLabel.Text = "Phone:";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(59, 29);
            this.phoneTextBox.Mask = "(000)000-0000";
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(77, 20);
            this.phoneTextBox.TabIndex = 2;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(163, 32);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(76, 13);
            this.emailLabel.TabIndex = 3;
            this.emailLabel.Text = "Email Address:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(245, 29);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(100, 20);
            this.emailTextBox.TabIndex = 4;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(270, 55);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "S&earch";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(270, 185);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(189, 185);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "&Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // outputListView
            // 
            this.outputListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fNameCol,
            this.lNameCol,
            this.phoneCol,
            this.emailCol,
            this.addressCol,
            this.cityCol,
            this.stateCol,
            this.zipCol,
            this.bannedCol,
            this.memoCol});
            this.outputListView.Location = new System.Drawing.Point(12, 82);
            this.outputListView.MultiSelect = false;
            this.outputListView.Name = "outputListView";
            this.outputListView.Size = new System.Drawing.Size(333, 97);
            this.outputListView.TabIndex = 10;
            this.outputListView.UseCompatibleStateImageBehavior = false;
            this.outputListView.View = System.Windows.Forms.View.Details;
            this.outputListView.SelectedIndexChanged += new System.EventHandler(this.outputListView_SelectedIndexChanged);
            // 
            // fNameCol
            // 
            this.fNameCol.Text = "Fisrt Name";
            // 
            // lNameCol
            // 
            this.lNameCol.Text = "Last Name";
            // 
            // phoneCol
            // 
            this.phoneCol.Text = "Phone";
            // 
            // emailCol
            // 
            this.emailCol.Text = "Email";
            // 
            // addressCol
            // 
            this.addressCol.Text = "Address";
            // 
            // cityCol
            // 
            this.cityCol.Text = "City";
            // 
            // stateCol
            // 
            this.stateCol.Text = "State";
            // 
            // zipCol
            // 
            this.zipCol.Text = "Zip";
            // 
            // bannedCol
            // 
            this.bannedCol.Text = "Banned";
            // 
            // memoCol
            // 
            this.memoCol.Text = "Memo";
            // 
            // CustLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 218);
            this.Controls.Add(this.outputListView);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.instructionLabel);
            this.Name = "CustLookup";
            this.Text = "Customer Lookup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.MaskedTextBox phoneTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.ListView outputListView;
        private System.Windows.Forms.ColumnHeader fNameCol;
        private System.Windows.Forms.ColumnHeader lNameCol;
        private System.Windows.Forms.ColumnHeader phoneCol;
        private System.Windows.Forms.ColumnHeader emailCol;
        private System.Windows.Forms.ColumnHeader addressCol;
        private System.Windows.Forms.ColumnHeader cityCol;
        private System.Windows.Forms.ColumnHeader stateCol;
        private System.Windows.Forms.ColumnHeader zipCol;
        private System.Windows.Forms.ColumnHeader bannedCol;
        private System.Windows.Forms.ColumnHeader memoCol;
    }
}