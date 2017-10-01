using System;
using System.Drawing;
using System.Windows.Forms;

namespace Otoin {
    public partial class UpdateForm : Form {

        PictureBox blur;
        public UpdateForm(PictureBox blur) {
            this.blur = blur;
            InitializeComponent();
        }

        private void neverButton_Click(object sender, EventArgs e) {
            Properties.Settings.Default.updateCheck = false;
            Properties.Settings.Default.Save();
            CloseForm();
        }

        private void noButton_Click(object sender, EventArgs e) {
            CloseForm();
        }

        private void openButton_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/BekirUzun/Otoin/#%C4%B0ndirme-linkleri");
            CloseForm();
            Application.Exit();
        }

        private void CloseForm() {
            blur.Visible = false;
            blur.SendToBack();          
            this.Close();
            this.Dispose();
        }
    }
}
