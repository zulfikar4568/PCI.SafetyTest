namespace PCI.SafetyTest
{
    partial class Main
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelVersion = new System.Windows.Forms.LinkLabel();
            this.iconStatusConnection = new FontAwesome.Sharp.IconButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.titleMsg = new System.Windows.Forms.Label();
            this.labelMsg = new System.Windows.Forms.Label();
            this.btnExit = new FontAwesome.Sharp.IconPictureBox();
            this.btnMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMain.Controls.Add(this.labelVersion);
            this.panelMain.Controls.Add(this.iconStatusConnection);
            this.panelMain.Controls.Add(this.progressBar);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.titleMsg);
            this.panelMain.Controls.Add(this.labelMsg);
            this.panelMain.Controls.Add(this.btnExit);
            this.panelMain.Controls.Add(this.btnMinimize);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(682, 273);
            this.panelMain.TabIndex = 0;
            this.panelMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMain_MouseDown);
            // 
            // labelVersion
            // 
            this.labelVersion.ActiveLinkColor = System.Drawing.Color.Gainsboro;
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 5F);
            this.labelVersion.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelVersion.LinkColor = System.Drawing.Color.Gainsboro;
            this.labelVersion.Location = new System.Drawing.Point(467, 252);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelVersion.Size = new System.Drawing.Size(34, 12);
            this.labelVersion.TabIndex = 12;
            this.labelVersion.TabStop = true;
            this.labelVersion.Text = "version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelVersion.VisitedLinkColor = System.Drawing.Color.Gainsboro;
            // 
            // iconStatusConnection
            // 
            this.iconStatusConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iconStatusConnection.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.iconStatusConnection.FlatAppearance.BorderSize = 0;
            this.iconStatusConnection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.iconStatusConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.iconStatusConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconStatusConnection.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold);
            this.iconStatusConnection.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconStatusConnection.IconChar = FontAwesome.Sharp.IconChar.WifiStrong;
            this.iconStatusConnection.IconColor = System.Drawing.Color.Gainsboro;
            this.iconStatusConnection.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconStatusConnection.IconSize = 32;
            this.iconStatusConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconStatusConnection.Location = new System.Drawing.Point(3, 216);
            this.iconStatusConnection.Name = "iconStatusConnection";
            this.iconStatusConnection.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.iconStatusConnection.Size = new System.Drawing.Size(214, 54);
            this.iconStatusConnection.TabIndex = 13;
            this.iconStatusConnection.Text = "Connected";
            this.iconStatusConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconStatusConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconStatusConnection.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(12, 165);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(658, 38);
            this.progressBar.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(123, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 54);
            this.label1.TabIndex = 10;
            this.label1.Text = "Safety Test Watcher";
            // 
            // titleMsg
            // 
            this.titleMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.titleMsg.AutoSize = true;
            this.titleMsg.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleMsg.ForeColor = System.Drawing.Color.White;
            this.titleMsg.Location = new System.Drawing.Point(12, 112);
            this.titleMsg.Name = "titleMsg";
            this.titleMsg.Size = new System.Drawing.Size(148, 41);
            this.titleMsg.TabIndex = 9;
            this.titleMsg.Text = "Message:";
            // 
            // labelMsg
            // 
            this.labelMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMsg.AutoSize = true;
            this.labelMsg.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMsg.ForeColor = System.Drawing.Color.White;
            this.labelMsg.Location = new System.Drawing.Point(166, 122);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(175, 28);
            this.labelMsg.TabIndex = 8;
            this.labelMsg.Text = "Doing Transaction";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnExit.IconColor = System.Drawing.Color.Gainsboro;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 20;
            this.btnExit.Location = new System.Drawing.Point(650, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(20, 20);
            this.btnExit.TabIndex = 7;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimize.IconColor = System.Drawing.Color.Gainsboro;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 20;
            this.btnMinimize.Location = new System.Drawing.Point(625, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(20, 20);
            this.btnMinimize.TabIndex = 5;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 273);
            this.Controls.Add(this.panelMain);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private FontAwesome.Sharp.IconPictureBox btnExit;
        private FontAwesome.Sharp.IconPictureBox btnMinimize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titleMsg;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.LinkLabel labelVersion;
        private FontAwesome.Sharp.IconButton iconStatusConnection;
    }
}

