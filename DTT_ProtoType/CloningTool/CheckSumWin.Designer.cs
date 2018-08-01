using System.Windows.Forms;

namespace CloningTool
{
    partial class CheckSumWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckSumWin));
            this.Title = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.SwPackagesTab = new System.Windows.Forms.TabPage();
            this.SearchBoxSw = new System.Windows.Forms.TextBox();
            this.SWFindBtn = new System.Windows.Forms.Button();
            this.SoftwarePackageTable = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SwSaveBtn = new System.Windows.Forms.Button();
            this.ValidHashesTab = new System.Windows.Forms.TabPage();
            this.SearchBoxHash = new System.Windows.Forms.TextBox();
            this.HashFindBtn = new System.Windows.Forms.Button();
            this.ValidHashTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrowseHashBtn = new System.Windows.Forms.Button();
            this.SaveHashBtn = new System.Windows.Forms.Button();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.CheckSumTab = new System.Windows.Forms.TabPage();
            this.CheckSumTable = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.SwPackagesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SoftwarePackageTable)).BeginInit();
            this.ValidHashesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValidHashTable)).BeginInit();
            this.Tabs.SuspendLayout();
            this.CheckSumTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckSumTable)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Lucida Calligraphy", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Title.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Title.Location = new System.Drawing.Point(281, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(169, 28);
            this.Title.TabIndex = 39;
            this.Title.Text = "Cloning Tool";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.Location = new System.Drawing.Point(12, 9);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(35, 13);
            this.version.TabIndex = 42;
            this.version.Text = "label1";
            // 
            // SwPackagesTab
            // 
            this.SwPackagesTab.BackColor = System.Drawing.Color.Transparent;
            this.SwPackagesTab.BackgroundImage = global::CloningTool.Properties.Resources.p8WSUkY;
            this.SwPackagesTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SwPackagesTab.Controls.Add(this.SearchBoxSw);
            this.SwPackagesTab.Controls.Add(this.SWFindBtn);
            this.SwPackagesTab.Controls.Add(this.SoftwarePackageTable);
            this.SwPackagesTab.Controls.Add(this.SwSaveBtn);
            this.SwPackagesTab.Location = new System.Drawing.Point(4, 22);
            this.SwPackagesTab.Name = "SwPackagesTab";
            this.SwPackagesTab.Padding = new System.Windows.Forms.Padding(3);
            this.SwPackagesTab.Size = new System.Drawing.Size(778, 494);
            this.SwPackagesTab.TabIndex = 2;
            this.SwPackagesTab.Text = "Software Packages";
            // 
            // SearchBoxSw
            // 
            this.SearchBoxSw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBoxSw.Location = new System.Drawing.Point(647, 435);
            this.SearchBoxSw.Name = "SearchBoxSw";
            this.SearchBoxSw.Size = new System.Drawing.Size(100, 20);
            this.SearchBoxSw.TabIndex = 11;
            this.SearchBoxSw.MouseHover += new System.EventHandler(this.SearchBoxSw_MouseHover);
            // 
            // SWFindBtn
            // 
            this.SWFindBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SWFindBtn.Location = new System.Drawing.Point(658, 461);
            this.SWFindBtn.Name = "SWFindBtn";
            this.SWFindBtn.Size = new System.Drawing.Size(75, 23);
            this.SWFindBtn.TabIndex = 8;
            this.SWFindBtn.Text = "Find";
            this.SWFindBtn.UseVisualStyleBackColor = true;
            this.SWFindBtn.Click += new System.EventHandler(this.Find_Click);
            // 
            // SoftwarePackageTable
            // 
            this.SoftwarePackageTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SoftwarePackageTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SoftwarePackageTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4});
            this.SoftwarePackageTable.Location = new System.Drawing.Point(13, 22);
            this.SoftwarePackageTable.Name = "SoftwarePackageTable";
            this.SoftwarePackageTable.Size = new System.Drawing.Size(734, 392);
            this.SoftwarePackageTable.TabIndex = 10;
            // 
            // col1
            // 
            this.col1.HeaderText = "Item Number";
            this.col1.Name = "col1";
            // 
            // col2
            // 
            this.col2.HeaderText = "SMN";
            this.col2.Name = "col2";
            // 
            // col3
            // 
            this.col3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col3.HeaderText = "Description";
            this.col3.Name = "col3";
            this.col3.Width = 85;
            // 
            // col4
            // 
            this.col4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col4.HeaderText = "Path";
            this.col4.Name = "col4";
            // 
            // SwSaveBtn
            // 
            this.SwSaveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SwSaveBtn.Location = new System.Drawing.Point(334, 449);
            this.SwSaveBtn.Name = "SwSaveBtn";
            this.SwSaveBtn.Size = new System.Drawing.Size(107, 35);
            this.SwSaveBtn.TabIndex = 7;
            this.SwSaveBtn.Text = "Save";
            this.SwSaveBtn.UseVisualStyleBackColor = true;
            this.SwSaveBtn.Click += new System.EventHandler(this.SwSaveBtn_Click);
            // 
            // ValidHashesTab
            // 
            this.ValidHashesTab.BackgroundImage = global::CloningTool.Properties.Resources.p8WSUkY;
            this.ValidHashesTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ValidHashesTab.Controls.Add(this.SearchBoxHash);
            this.ValidHashesTab.Controls.Add(this.HashFindBtn);
            this.ValidHashesTab.Controls.Add(this.ValidHashTable);
            this.ValidHashesTab.Controls.Add(this.BrowseHashBtn);
            this.ValidHashesTab.Controls.Add(this.SaveHashBtn);
            this.ValidHashesTab.Location = new System.Drawing.Point(4, 22);
            this.ValidHashesTab.Name = "ValidHashesTab";
            this.ValidHashesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ValidHashesTab.Size = new System.Drawing.Size(778, 494);
            this.ValidHashesTab.TabIndex = 1;
            this.ValidHashesTab.Text = "Valid Hashes";
            this.ValidHashesTab.UseVisualStyleBackColor = true;
            // 
            // SearchBoxHash
            // 
            this.SearchBoxHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBoxHash.Location = new System.Drawing.Point(647, 435);
            this.SearchBoxHash.Name = "SearchBoxHash";
            this.SearchBoxHash.Size = new System.Drawing.Size(100, 20);
            this.SearchBoxHash.TabIndex = 9;
            this.SearchBoxHash.MouseHover += new System.EventHandler(this.SearchBoxHash_MouseHover);
            // 
            // HashFindBtn
            // 
            this.HashFindBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HashFindBtn.Location = new System.Drawing.Point(658, 461);
            this.HashFindBtn.Name = "HashFindBtn";
            this.HashFindBtn.Size = new System.Drawing.Size(75, 23);
            this.HashFindBtn.TabIndex = 8;
            this.HashFindBtn.Text = "Find";
            this.HashFindBtn.UseVisualStyleBackColor = true;
            this.HashFindBtn.Click += new System.EventHandler(this.HashFindBtn_Click);
            // 
            // ValidHashTable
            // 
            this.ValidHashTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValidHashTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ValidHashTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.ValidHashTable.Location = new System.Drawing.Point(13, 17);
            this.ValidHashTable.Name = "ValidHashTable";
            this.ValidHashTable.Size = new System.Drawing.Size(729, 357);
            this.ValidHashTable.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Path";
            this.Column1.Name = "Column1";
            this.Column1.Width = 54;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Hash Code";
            this.Column2.Name = "Column2";
            // 
            // BrowseHashBtn
            // 
            this.BrowseHashBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BrowseHashBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BrowseHashBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BrowseHashBtn.Location = new System.Drawing.Point(357, 408);
            this.BrowseHashBtn.Name = "BrowseHashBtn";
            this.BrowseHashBtn.Size = new System.Drawing.Size(60, 35);
            this.BrowseHashBtn.TabIndex = 6;
            this.BrowseHashBtn.Text = "Add";
            this.BrowseHashBtn.UseVisualStyleBackColor = true;
            this.BrowseHashBtn.Click += new System.EventHandler(this.BrowseHashBtn_Click);
            // 
            // SaveHashBtn
            // 
            this.SaveHashBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SaveHashBtn.Location = new System.Drawing.Point(334, 449);
            this.SaveHashBtn.Name = "SaveHashBtn";
            this.SaveHashBtn.Size = new System.Drawing.Size(107, 35);
            this.SaveHashBtn.TabIndex = 3;
            this.SaveHashBtn.Text = "Save";
            this.SaveHashBtn.UseVisualStyleBackColor = true;
            this.SaveHashBtn.Click += new System.EventHandler(this.SaveHashBtn_Click);
            // 
            // Tabs
            // 
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Controls.Add(this.ValidHashesTab);
            this.Tabs.Controls.Add(this.SwPackagesTab);
            this.Tabs.Controls.Add(this.CheckSumTab);
            this.Tabs.Location = new System.Drawing.Point(-4, 52);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(786, 520);
            this.Tabs.TabIndex = 43;
            // 
            // CheckSumTab
            // 
            this.CheckSumTab.BackgroundImage = global::CloningTool.Properties.Resources.p8WSUkY;
            this.CheckSumTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CheckSumTab.Controls.Add(this.CheckSumTable);
            this.CheckSumTab.Controls.Add(this.button1);
            this.CheckSumTab.Location = new System.Drawing.Point(4, 22);
            this.CheckSumTab.Name = "CheckSumTab";
            this.CheckSumTab.Padding = new System.Windows.Forms.Padding(3);
            this.CheckSumTab.Size = new System.Drawing.Size(778, 494);
            this.CheckSumTab.TabIndex = 3;
            this.CheckSumTab.Text = "Check Sum";
            this.CheckSumTab.UseVisualStyleBackColor = true;
            // 
            // CheckSumTable
            // 
            this.CheckSumTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckSumTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CheckSumTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4});
            this.CheckSumTable.Location = new System.Drawing.Point(23, 30);
            this.CheckSumTable.Name = "CheckSumTable";
            this.CheckSumTable.Size = new System.Drawing.Size(715, 304);
            this.CheckSumTable.TabIndex = 45;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Path";
            this.Column3.Name = "Column3";
            this.Column3.Width = 54;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Hash Code";
            this.Column4.Name = "Column4";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(339, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 46);
            this.button1.TabIndex = 43;
            this.button1.Text = "Browse";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Browse_Click);
            // 
            // CheckSumWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CloningTool.Properties.Resources.p8WSUkY;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(778, 568);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.version);
            this.Controls.Add(this.Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckSumWin";
            this.Text = "Setting";
            this.SwPackagesTab.ResumeLayout(false);
            this.SwPackagesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SoftwarePackageTable)).EndInit();
            this.ValidHashesTab.ResumeLayout(false);
            this.ValidHashesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValidHashTable)).EndInit();
            this.Tabs.ResumeLayout(false);
            this.CheckSumTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckSumTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label version;
        private TabPage SwPackagesTab;
        private Button SwSaveBtn;
        private TabPage ValidHashesTab;
        private Button BrowseHashBtn;
        private Button SaveHashBtn;
        private TabControl Tabs;
        private DataGridView SoftwarePackageTable;
        private TabPage CheckSumTab;
        private Button button1;
        private DataGridView ValidHashTable;
        private DataGridView CheckSumTable;
        private Button SWFindBtn;
        private TextBox SearchBoxSw;
        private TextBox SearchBoxHash;
        private Button HashFindBtn;
        private DataGridViewTextBoxColumn col1;
        private DataGridViewTextBoxColumn col2;
        private DataGridViewTextBoxColumn col3;
        private DataGridViewTextBoxColumn col4;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}