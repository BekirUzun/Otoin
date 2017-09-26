using System;
using System.Windows.Forms;

namespace Otoin {
    public partial class HelpForm : Form {

        public HelpForm() {
            InitializeComponent();
            
        }

        private void closeBtn_Click(object sender, EventArgs e) {
            this.Hide();
        }

        public void SelectTab(int index) {
            tabControl.SelectTab(index);
        }
    }
}
