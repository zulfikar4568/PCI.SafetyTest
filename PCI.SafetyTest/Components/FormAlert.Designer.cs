namespace PCI.SafetyTest.Components
{
    partial class FormAlert
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlert));
            this.btnExit = new FontAwesome.Sharp.IconPictureBox();
            this.LineAlertBox = new System.Windows.Forms.Panel();
            this.labelTextAlertBox = new System.Windows.Forms.Label();
            this.labelTitleAlertBox = new System.Windows.Forms.Label();
            this.PicAlertBox = new System.Windows.Forms.PictureBox();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.ziEllipseControlAlert = new PCI.KittingApp.Components.ZIEllipseControl();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAlertBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnExit.IconColor = System.Drawing.Color.Black;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 20;
            this.btnExit.Location = new System.Drawing.Point(477, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(20, 20);
            this.btnExit.TabIndex = 10;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LineAlertBox
            // 
            this.LineAlertBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LineAlertBox.BackColor = System.Drawing.Color.Black;
            this.LineAlertBox.Location = new System.Drawing.Point(2, 93);
            this.LineAlertBox.Margin = new System.Windows.Forms.Padding(0);
            this.LineAlertBox.Name = "LineAlertBox";
            this.LineAlertBox.Size = new System.Drawing.Size(10, 8);
            this.LineAlertBox.TabIndex = 9;
            // 
            // labelTextAlertBox
            // 
            this.labelTextAlertBox.AutoSize = true;
            this.labelTextAlertBox.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextAlertBox.Location = new System.Drawing.Point(74, 39);
            this.labelTextAlertBox.MaximumSize = new System.Drawing.Size(400, 0);
            this.labelTextAlertBox.Name = "labelTextAlertBox";
            this.labelTextAlertBox.Size = new System.Drawing.Size(106, 23);
            this.labelTextAlertBox.TabIndex = 8;
            this.labelTextAlertBox.Text = "TextAlertBox";
            // 
            // labelTitleAlertBox
            // 
            this.labelTitleAlertBox.AutoSize = true;
            this.labelTitleAlertBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleAlertBox.Location = new System.Drawing.Point(72, 4);
            this.labelTitleAlertBox.Name = "labelTitleAlertBox";
            this.labelTitleAlertBox.Size = new System.Drawing.Size(158, 31);
            this.labelTitleAlertBox.TabIndex = 7;
            this.labelTitleAlertBox.Text = "TitleAlertBox";
            // 
            // PicAlertBox
            // 
            this.PicAlertBox.Location = new System.Drawing.Point(16, 20);
            this.PicAlertBox.Name = "PicAlertBox";
            this.PicAlertBox.Size = new System.Drawing.Size(50, 50);
            this.PicAlertBox.TabIndex = 6;
            this.PicAlertBox.TabStop = false;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 10;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // ziEllipseControlAlert
            // 
            this.ziEllipseControlAlert.CornerRedius = 30;
            this.ziEllipseControlAlert.TargetControl = this;
            // 
            // FormAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 102);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.LineAlertBox);
            this.Controls.Add(this.labelTextAlertBox);
            this.Controls.Add(this.labelTitleAlertBox);
            this.Controls.Add(this.PicAlertBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAlert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAlert";
            this.Load += new System.EventHandler(this.FormAlert_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormAlert_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicAlertBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KittingApp.Components.ZIEllipseControl ziEllipseControlAlert;
        private FontAwesome.Sharp.IconPictureBox btnExit;
        private System.Windows.Forms.Panel LineAlertBox;
        private System.Windows.Forms.Label labelTextAlertBox;
        private System.Windows.Forms.Label labelTitleAlertBox;
        private System.Windows.Forms.PictureBox PicAlertBox;
        private System.Windows.Forms.Timer timerAnimation;
    }
}