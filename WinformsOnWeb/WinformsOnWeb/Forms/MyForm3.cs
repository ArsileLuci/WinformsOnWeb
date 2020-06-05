using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsOnWeb
{
    public partial class MyForm3 : Form
    {
        public MyForm3()
        {
            InitializeComponent();
        }

        private void visibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.texboxValueLabel.Visible = this.visibleCheckBox.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.texboxValueLabel.Text = this.textBox1.Text;
        }
    }
}
