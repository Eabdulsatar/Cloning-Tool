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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(278, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 20);
            this.textBox1.TabIndex = 41;
            // 
            // Browse
            // 
            this.Browse.BackgroundImage = global::CloningTool.Properties.Resources.p8WSUkY;
            this.Browse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Browse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Browse.Location = new System.Drawing.Point(60, 88);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 40;
            this.Browse.Text = "Browse";
            this.Browse.UseMnemonic = false;
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Lucida Calligraphy", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Title.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Title.Location = new System.Drawing.Point(187, 7);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(169, 28);
            this.Title.TabIndex = 39;
            this.Title.Text = "Cloning Tool";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.Location = new System.Drawing.Point(12, 200);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(35, 13);
            this.version.TabIndex = 42;
            this.version.Text = "label1";
            // 
            // CheckSumWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CloningTool.Properties.Resources.p8WSUkY;
            this.ClientSize = new System.Drawing.Size(600, 222);
            this.Controls.Add(this.version);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckSumWin";
            this.Text = "Check Sum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label version;
    }
}