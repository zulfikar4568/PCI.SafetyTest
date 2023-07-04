using System;
using System.Drawing;
using System.Windows.Forms;

namespace PCI.SafetyTest.Components
{

    public partial class FormAlert : Form
    {
        public FormAlert()
        {
            InitializeComponent();
            Location = Screen.FromPoint(Cursor.Position).Bounds.Location;
        }

        public Color BackColorAlertBox
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public Color ColorAlertBox
        {
            get { return LineAlertBox.BackColor; }
            set { LineAlertBox.BackColor = labelTitleAlertBox.ForeColor = labelTextAlertBox.ForeColor = btnExit.ForeColor = value; }
        }

        public Image IconAlertBox
        {
            get { return PicAlertBox.Image; }
            set { PicAlertBox.Image = value; }
        }

        public string TitleAlertBox
        {
            get { return labelTitleAlertBox.Text; }
            set { labelTitleAlertBox.Text = value; }
        }

        public string TextAlertBox
        {
            get { return labelTextAlertBox.Text; }
            set { labelTextAlertBox.Text = value; }
        }

        private void PositionAlertBox()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width - 20, workingArea.Bottom - Size.Height - 350);
        }

        private void FormAlert_Load(object sender, EventArgs e)
        {
            if (labelTextAlertBox.Size.Height > 60) this.Height += (int)(labelTextAlertBox.Size.Height / 1.4);
            PositionAlertBox();
            for (int i = 0; i < 500; i++)
                timerAnimation.Start();
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            LineAlertBox.Width = LineAlertBox.Width + 2;
            if (LineAlertBox.Width >= 500)
                this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAlert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.Close();
        }
    }
}
