namespace CloningTool
{
    partial class CloningTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloningTool));
            this.DescSW = new System.Windows.Forms.Label();
            this.copyBtn = new System.Windows.Forms.Button();
            this.DriversListAll = new System.Windows.Forms.GroupBox();
            this.SelectAll = new System.Windows.Forms.CheckBox();
            this.Title = new System.Windows.Forms.Label();
            this.DriversList = new System.Windows.Forms.CheckedListBox();
            this.refresh = new System.Windows.Forms.Button();
            this.SoftwareList = new System.Windows.Forms.ComboBox();
            this.FileHash = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.version = new System.Windows.Forms.Label();
            this.completed = new System.Windows.Forms.Label();
            this.Erase_Drives = new System.Windows.Forms.Button();
            this.CheckSum_Btn = new System.Windows.Forms.Button();
            this.ItemNumRd = new System.Windows.Forms.RadioButton();
            this.SMNRd = new System.Windows.Forms.RadioButton();
            this.DriversListAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DescSW
            // 
            this.DescSW.AutoSize = true;
            this.DescSW.BackColor = System.Drawing.Color.Transparent;
            this.DescSW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescSW.Location = new System.Drawing.Point(86, 92);
            this.DescSW.Name = "DescSW";
            this.DescSW.Size = new System.Drawing.Size(179, 13);
            this.DescSW.TabIndex = 26;
            this.DescSW.Text = "Software Package Description";
            // 
            // copyBtn
            // 
            this.copyBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("copyBtn.BackgroundImage")));
            this.copyBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.copyBtn.FlatAppearance.BorderSize = 0;
            this.copyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.copyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyBtn.Location = new System.Drawing.Point(434, 442);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(75, 23);
            this.copyBtn.TabIndex = 25;
            this.copyBtn.Text = "Copy";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // DriversListAll
            // 
            this.DriversListAll.BackColor = System.Drawing.Color.Transparent;
            this.DriversListAll.Controls.Add(this.SelectAll);
            this.DriversListAll.Location = new System.Drawing.Point(151, 137);
            this.DriversListAll.Name = "DriversListAll";
            this.DriversListAll.Size = new System.Drawing.Size(277, 43);
            this.DriversListAll.TabIndex = 24;
            this.DriversListAll.TabStop = false;
            this.DriversListAll.Text = "Drivers";
            // 
            // SelectAll
            // 
            this.SelectAll.AutoSize = true;
            this.SelectAll.Location = new System.Drawing.Point(3, 22);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(70, 17);
            this.SelectAll.TabIndex = 0;
            this.SelectAll.Text = "Select All";
            this.SelectAll.UseVisualStyleBackColor = true;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Lucida Calligraphy", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Title.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Title.Location = new System.Drawing.Point(214, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(169, 28);
            this.Title.TabIndex = 23;
            this.Title.Text = "Cloning Tool";
            // 
            // DriversList
            // 
            this.DriversList.BackColor = System.Drawing.Color.White;
            this.DriversList.FormattingEnabled = true;
            this.DriversList.Location = new System.Drawing.Point(151, 177);
            this.DriversList.Name = "DriversList";
            this.DriversList.Size = new System.Drawing.Size(277, 289);
            this.DriversList.TabIndex = 22;
            // 
            // refresh
            // 
            this.refresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refresh.BackgroundImage")));
            this.refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refresh.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.refresh.FlatAppearance.BorderSize = 0;
            this.refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refresh.ForeColor = System.Drawing.SystemColors.WindowText;
            this.refresh.Location = new System.Drawing.Point(434, 152);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(25, 28);
            this.refresh.TabIndex = 21;
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // SoftwareList
            // 
            this.SoftwareList.BackColor = System.Drawing.Color.White;
            this.SoftwareList.FormattingEnabled = true;
            this.SoftwareList.Location = new System.Drawing.Point(100, 68);
            this.SoftwareList.Name = "SoftwareList";
            this.SoftwareList.Size = new System.Drawing.Size(124, 21);
            this.SoftwareList.TabIndex = 20;
            this.SoftwareList.Text = "Select Software";
            this.SoftwareList.SelectedIndexChanged += new System.EventHandler(this.SoftwareList_SelectedIndexChanged_1);
            // 
            // FileHash
            // 
            this.FileHash.AutoSize = true;
            this.FileHash.BackColor = System.Drawing.Color.Transparent;
            this.FileHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileHash.Location = new System.Drawing.Point(451, 92);
            this.FileHash.Name = "FileHash";
            this.FileHash.Size = new System.Drawing.Size(111, 13);
            this.FileHash.TabIndex = 27;
            this.FileHash.Text = "Check Sum Status";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(412, 195);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.Location = new System.Drawing.Point(0, 452);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(35, 13);
            this.version.TabIndex = 28;
            this.version.Text = "label1";
            // 
            // completed
            // 
            this.completed.AutoSize = true;
            this.completed.BackColor = System.Drawing.Color.Transparent;
            this.completed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completed.ForeColor = System.Drawing.Color.Green;
            this.completed.Location = new System.Drawing.Point(434, 423);
            this.completed.Name = "completed";
            this.completed.Size = new System.Drawing.Size(131, 13);
            this.completed.TabIndex = 31;
            this.completed.Text = "Copying is completed!";
            this.completed.Visible = false;
            // 
            // Erase_Drives
            // 
            this.Erase_Drives.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Erase_Drives.BackgroundImage")));
            this.Erase_Drives.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Erase_Drives.FlatAppearance.BorderSize = 0;
            this.Erase_Drives.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Erase_Drives.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Erase_Drives.Location = new System.Drawing.Point(515, 442);
            this.Erase_Drives.Name = "Erase_Drives";
            this.Erase_Drives.Size = new System.Drawing.Size(75, 23);
            this.Erase_Drives.TabIndex = 34;
            this.Erase_Drives.Text = "Erase Drives";
            this.Erase_Drives.UseVisualStyleBackColor = true;
            // 
            // CheckSum_Btn
            // 
            this.CheckSum_Btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CheckSum_Btn.BackgroundImage")));
            this.CheckSum_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CheckSum_Btn.FlatAppearance.BorderSize = 0;
            this.CheckSum_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CheckSum_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckSum_Btn.Location = new System.Drawing.Point(21, 413);
            this.CheckSum_Btn.Name = "CheckSum_Btn";
            this.CheckSum_Btn.Size = new System.Drawing.Size(108, 23);
            this.CheckSum_Btn.TabIndex = 37;
            this.CheckSum_Btn.Text = "Check Sum";
            this.CheckSum_Btn.UseVisualStyleBackColor = true;
            // 
            // ItemNumRd
            // 
            this.ItemNumRd.AutoSize = true;
            this.ItemNumRd.BackColor = System.Drawing.Color.Transparent;
            this.ItemNumRd.Location = new System.Drawing.Point(3, 54);
            this.ItemNumRd.Name = "ItemNumRd";
            this.ItemNumRd.Size = new System.Drawing.Size(85, 17);
            this.ItemNumRd.TabIndex = 38;
            this.ItemNumRd.TabStop = true;
            this.ItemNumRd.Text = "Item Number";
            this.ItemNumRd.UseVisualStyleBackColor = false;
            // 
            // SMNRd
            // 
            this.SMNRd.AutoSize = true;
            this.SMNRd.BackColor = System.Drawing.Color.Transparent;
            this.SMNRd.Location = new System.Drawing.Point(3, 77);
            this.SMNRd.Name = "SMNRd";
            this.SMNRd.Size = new System.Drawing.Size(49, 17);
            this.SMNRd.TabIndex = 39;
            this.SMNRd.TabStop = true;
            this.SMNRd.Text = "SMN";
            this.SMNRd.UseVisualStyleBackColor = false;
            // 
            // CloningTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(599, 468);
            this.Controls.Add(this.SMNRd);
            this.Controls.Add(this.ItemNumRd);
            this.Controls.Add(this.CheckSum_Btn);
            this.Controls.Add(this.Erase_Drives);
            this.Controls.Add(this.completed);
            this.Controls.Add(this.version);
            this.Controls.Add(this.FileHash);
            this.Controls.Add(this.DescSW);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.DriversListAll);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.DriversList);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.SoftwareList);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CloningTool";
            this.Text = "CloningTool";
            this.DriversListAll.ResumeLayout(false);
            this.DriversListAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DescSW;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.GroupBox DriversListAll;
        private System.Windows.Forms.CheckBox SelectAll;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.CheckedListBox DriversList;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.ComboBox SoftwareList;
        private System.Windows.Forms.Label FileHash;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label completed;
        private System.Windows.Forms.Button Erase_Drives;
        private System.Windows.Forms.Button CheckSum_Btn;
        private System.Windows.Forms.RadioButton ItemNumRd;
        private System.Windows.Forms.RadioButton SMNRd;
    }
}

