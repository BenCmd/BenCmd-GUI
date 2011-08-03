namespace BCGUIConfig
{
    partial class UserPermissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPermissions));
            this.panel1 = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.LabelHPerm = new System.Windows.Forms.Label();
            this.LabelHAllow = new System.Windows.Forms.Label();
            this.LabelHDeny = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelP1 = new System.Windows.Forms.Label();
            this.CheckAP1 = new System.Windows.Forms.CheckBox();
            this.CheckDP1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 296);
            this.panel1.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(231, 351);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(150, 351);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // LabelHPerm
            // 
            this.LabelHPerm.AutoSize = true;
            this.LabelHPerm.Location = new System.Drawing.Point(15, 18);
            this.LabelHPerm.Name = "LabelHPerm";
            this.LabelHPerm.Size = new System.Drawing.Size(60, 13);
            this.LabelHPerm.TabIndex = 3;
            this.LabelHPerm.Text = "Permission:";
            // 
            // LabelHAllow
            // 
            this.LabelHAllow.AutoSize = true;
            this.LabelHAllow.Location = new System.Drawing.Point(229, 18);
            this.LabelHAllow.Name = "LabelHAllow";
            this.LabelHAllow.Size = new System.Drawing.Size(32, 13);
            this.LabelHAllow.TabIndex = 4;
            this.LabelHAllow.Text = "Allow";
            // 
            // LabelHDeny
            // 
            this.LabelHDeny.AutoSize = true;
            this.LabelHDeny.Location = new System.Drawing.Point(264, 18);
            this.LabelHDeny.Name = "LabelHDeny";
            this.LabelHDeny.Size = new System.Drawing.Size(32, 13);
            this.LabelHDeny.TabIndex = 5;
            this.LabelHDeny.Text = "Deny";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 209F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Controls.Add(this.CheckDP1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelP1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CheckAP1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 54);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LabelP1
            // 
            this.LabelP1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelP1.AutoSize = true;
            this.LabelP1.Location = new System.Drawing.Point(3, 6);
            this.LabelP1.Name = "LabelP1";
            this.LabelP1.Size = new System.Drawing.Size(85, 13);
            this.LabelP1.TabIndex = 0;
            this.LabelP1.Text = "Can use /spawn";
            // 
            // CheckAP1
            // 
            this.CheckAP1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckAP1.AutoSize = true;
            this.CheckAP1.Location = new System.Drawing.Point(219, 5);
            this.CheckAP1.Name = "CheckAP1";
            this.CheckAP1.Size = new System.Drawing.Size(15, 14);
            this.CheckAP1.TabIndex = 1;
            this.CheckAP1.UseVisualStyleBackColor = true;
            // 
            // CheckDP1
            // 
            this.CheckDP1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckDP1.AutoSize = true;
            this.CheckDP1.Location = new System.Drawing.Point(255, 5);
            this.CheckDP1.Name = "CheckDP1";
            this.CheckDP1.Size = new System.Drawing.Size(15, 14);
            this.CheckDP1.TabIndex = 2;
            this.CheckDP1.UseVisualStyleBackColor = true;
            // 
            // UserPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 386);
            this.Controls.Add(this.LabelHDeny);
            this.Controls.Add(this.LabelHAllow);
            this.Controls.Add(this.LabelHPerm);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserPermissions";
            this.Text = "Edit user permissions";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LabelHPerm;
        private System.Windows.Forms.Label LabelHAllow;
        private System.Windows.Forms.Label LabelHDeny;
        private System.Windows.Forms.Label LabelP1;
        private System.Windows.Forms.CheckBox CheckAP1;
        private System.Windows.Forms.CheckBox CheckDP1;
    }
}