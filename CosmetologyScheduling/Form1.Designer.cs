namespace CosmetologyScheduling
{
    partial class Form1
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.userInfoButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.adminButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.stylistLabel = new System.Windows.Forms.Label();
            this.stylistDropDown = new System.Windows.Forms.ComboBox();
            this.customerLabel = new System.Windows.Forms.Label();
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.searchCustButton = new System.Windows.Forms.Button();
            this.createCustButton = new System.Windows.Forms.Button();
            this.servicesLabel = new System.Windows.Forms.Label();
            this.servicesListBox = new System.Windows.Forms.ListBox();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.stationLabel = new System.Windows.Forms.Label();
            this.stationComboBox = new System.Windows.Forms.ComboBox();
            this.empObservingLabel = new System.Windows.Forms.Label();
            this.empObservingTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.apptGroupBox = new System.Windows.Forms.GroupBox();
            this.apptButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.apptGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nameLabel.Location = new System.Drawing.Point(473, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(299, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // userInfoButton
            // 
            this.userInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userInfoButton.Location = new System.Drawing.Point(697, 25);
            this.userInfoButton.Name = "userInfoButton";
            this.userInfoButton.Size = new System.Drawing.Size(75, 23);
            this.userInfoButton.TabIndex = 1;
            this.userInfoButton.Text = "&Log In";
            this.userInfoButton.UseVisualStyleBackColor = true;
            this.userInfoButton.Click += new System.EventHandler(this.userInfoButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logOutButton.Location = new System.Drawing.Point(697, 526);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(75, 23);
            this.logOutButton.TabIndex = 2;
            this.logOutButton.Text = "E&xit";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // adminButton
            // 
            this.adminButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.adminButton.Enabled = false;
            this.adminButton.Location = new System.Drawing.Point(535, 526);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(75, 23);
            this.adminButton.TabIndex = 3;
            this.adminButton.Text = "&Admin";
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Visible = false;
            // 
            // editButton
            // 
            this.editButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.editButton.Location = new System.Drawing.Point(22, 325);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 5;
            this.editButton.Text = "E&dit";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // stylistLabel
            // 
            this.stylistLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stylistLabel.AutoSize = true;
            this.stylistLabel.Location = new System.Drawing.Point(7, 20);
            this.stylistLabel.Name = "stylistLabel";
            this.stylistLabel.Size = new System.Drawing.Size(37, 13);
            this.stylistLabel.TabIndex = 0;
            this.stylistLabel.Text = "Stylist:";
            // 
            // stylistDropDown
            // 
            this.stylistDropDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stylistDropDown.FormattingEnabled = true;
            this.stylistDropDown.Location = new System.Drawing.Point(50, 17);
            this.stylistDropDown.Name = "stylistDropDown";
            this.stylistDropDown.Size = new System.Drawing.Size(144, 21);
            this.stylistDropDown.TabIndex = 5;
            this.stylistDropDown.SelectedIndexChanged += new System.EventHandler(this.stylistDropDown_SelectedIndexChanged);
            // 
            // customerLabel
            // 
            this.customerLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.customerLabel.AutoSize = true;
            this.customerLabel.Location = new System.Drawing.Point(6, 52);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(54, 13);
            this.customerLabel.TabIndex = 6;
            this.customerLabel.Text = "Customer:";
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.customerNameTextBox.Location = new System.Drawing.Point(66, 49);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.ReadOnly = true;
            this.customerNameTextBox.Size = new System.Drawing.Size(128, 20);
            this.customerNameTextBox.TabIndex = 7;
            // 
            // searchCustButton
            // 
            this.searchCustButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchCustButton.Location = new System.Drawing.Point(22, 75);
            this.searchCustButton.Name = "searchCustButton";
            this.searchCustButton.Size = new System.Drawing.Size(75, 23);
            this.searchCustButton.TabIndex = 8;
            this.searchCustButton.Text = "&Search";
            this.searchCustButton.UseVisualStyleBackColor = true;
            this.searchCustButton.Click += new System.EventHandler(this.searchCustButton_Click);
            // 
            // createCustButton
            // 
            this.createCustButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.createCustButton.Location = new System.Drawing.Point(104, 75);
            this.createCustButton.Name = "createCustButton";
            this.createCustButton.Size = new System.Drawing.Size(75, 23);
            this.createCustButton.TabIndex = 9;
            this.createCustButton.Text = "&Create";
            this.createCustButton.UseVisualStyleBackColor = true;
            this.createCustButton.Click += new System.EventHandler(this.createCustButton_Click);
            // 
            // servicesLabel
            // 
            this.servicesLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.servicesLabel.AutoSize = true;
            this.servicesLabel.Location = new System.Drawing.Point(6, 101);
            this.servicesLabel.Name = "servicesLabel";
            this.servicesLabel.Size = new System.Drawing.Size(51, 13);
            this.servicesLabel.TabIndex = 10;
            this.servicesLabel.Text = "Services:";
            // 
            // servicesListBox
            // 
            this.servicesListBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.servicesListBox.FormattingEnabled = true;
            this.servicesListBox.Location = new System.Drawing.Point(9, 117);
            this.servicesListBox.Name = "servicesListBox";
            this.servicesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.servicesListBox.Size = new System.Drawing.Size(185, 82);
            this.servicesListBox.TabIndex = 11;
            this.servicesListBox.SelectedIndexChanged += new System.EventHandler(this.servicesListBox_SelectedIndexChanged);
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(6, 202);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(58, 13);
            this.startTimeLabel.TabIndex = 12;
            this.startTimeLabel.Text = "Start Time:";
            // 
            // stationLabel
            // 
            this.stationLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stationLabel.AutoSize = true;
            this.stationLabel.Location = new System.Drawing.Point(6, 247);
            this.stationLabel.Name = "stationLabel";
            this.stationLabel.Size = new System.Drawing.Size(83, 13);
            this.stationLabel.TabIndex = 16;
            this.stationLabel.Text = "Station Number:";
            // 
            // stationComboBox
            // 
            this.stationComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.stationComboBox.FormattingEnabled = true;
            this.stationComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.stationComboBox.Location = new System.Drawing.Point(95, 244);
            this.stationComboBox.Name = "stationComboBox";
            this.stationComboBox.Size = new System.Drawing.Size(99, 21);
            this.stationComboBox.TabIndex = 17;
            // 
            // empObservingLabel
            // 
            this.empObservingLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.empObservingLabel.AutoSize = true;
            this.empObservingLabel.Location = new System.Drawing.Point(7, 278);
            this.empObservingLabel.Name = "empObservingLabel";
            this.empObservingLabel.Size = new System.Drawing.Size(155, 13);
            this.empObservingLabel.TabIndex = 18;
            this.empObservingLabel.Text = "Employee Observing (Optional):";
            // 
            // empObservingTextBox
            // 
            this.empObservingTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.empObservingTextBox.Location = new System.Drawing.Point(9, 294);
            this.empObservingTextBox.Name = "empObservingTextBox";
            this.empObservingTextBox.Size = new System.Drawing.Size(185, 20);
            this.empObservingTextBox.TabIndex = 19;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.clearButton.Location = new System.Drawing.Point(104, 325);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 22;
            this.clearButton.Text = "Ca&ncel";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.submitButton.Location = new System.Drawing.Point(22, 325);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 23;
            this.submitButton.Text = "S&ubmit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // startDatePicker
            // 
            this.startDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(9, 218);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(80, 20);
            this.startDatePicker.TabIndex = 24;
            // 
            // startTimePicker
            // 
            this.startTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimePicker.Location = new System.Drawing.Point(104, 218);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(90, 20);
            this.startTimePicker.TabIndex = 25;
            this.startTimePicker.Value = new System.DateTime(2017, 4, 13, 9, 49, 7, 0);
            // 
            // apptGroupBox
            // 
            this.apptGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.apptGroupBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.apptGroupBox.Controls.Add(this.startTimePicker);
            this.apptGroupBox.Controls.Add(this.startDatePicker);
            this.apptGroupBox.Controls.Add(this.submitButton);
            this.apptGroupBox.Controls.Add(this.clearButton);
            this.apptGroupBox.Controls.Add(this.empObservingTextBox);
            this.apptGroupBox.Controls.Add(this.empObservingLabel);
            this.apptGroupBox.Controls.Add(this.stationComboBox);
            this.apptGroupBox.Controls.Add(this.stationLabel);
            this.apptGroupBox.Controls.Add(this.startTimeLabel);
            this.apptGroupBox.Controls.Add(this.servicesListBox);
            this.apptGroupBox.Controls.Add(this.servicesLabel);
            this.apptGroupBox.Controls.Add(this.createCustButton);
            this.apptGroupBox.Controls.Add(this.searchCustButton);
            this.apptGroupBox.Controls.Add(this.customerNameTextBox);
            this.apptGroupBox.Controls.Add(this.customerLabel);
            this.apptGroupBox.Controls.Add(this.stylistDropDown);
            this.apptGroupBox.Controls.Add(this.stylistLabel);
            this.apptGroupBox.Controls.Add(this.editButton);
            this.apptGroupBox.Enabled = false;
            this.apptGroupBox.Location = new System.Drawing.Point(572, 157);
            this.apptGroupBox.Name = "apptGroupBox";
            this.apptGroupBox.Size = new System.Drawing.Size(200, 361);
            this.apptGroupBox.TabIndex = 4;
            this.apptGroupBox.TabStop = false;
            this.apptGroupBox.Text = "Appointments";
            this.apptGroupBox.Visible = false;
            // 
            // apptButton
            // 
            this.apptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.apptButton.Enabled = false;
            this.apptButton.Location = new System.Drawing.Point(450, 526);
            this.apptButton.Name = "apptButton";
            this.apptButton.Size = new System.Drawing.Size(79, 23);
            this.apptButton.TabIndex = 5;
            this.apptButton.Text = "A&ppointments";
            this.apptButton.UseVisualStyleBackColor = true;
            this.apptButton.Visible = false;
            this.apptButton.Click += new System.EventHandler(this.apptButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Enabled = false;
            this.settingsButton.Location = new System.Drawing.Point(616, 526);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(75, 23);
            this.settingsButton.TabIndex = 6;
            this.settingsButton.Text = "Se&ttings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.apptButton);
            this.Controls.Add(this.apptGroupBox);
            this.Controls.Add(this.adminButton);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.userInfoButton);
            this.Controls.Add(this.nameLabel);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCC Cosmetology Department";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.apptGroupBox.ResumeLayout(false);
            this.apptGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button userInfoButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label stylistLabel;
        private System.Windows.Forms.ComboBox stylistDropDown;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Button searchCustButton;
        private System.Windows.Forms.Button createCustButton;
        private System.Windows.Forms.Label servicesLabel;
        private System.Windows.Forms.ListBox servicesListBox;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label stationLabel;
        private System.Windows.Forms.ComboBox stationComboBox;
        private System.Windows.Forms.Label empObservingLabel;
        private System.Windows.Forms.TextBox empObservingTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.GroupBox apptGroupBox;
        private System.Windows.Forms.Button apptButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.TextBox customerNameTextBox;
    }
}

