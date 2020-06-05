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
    public partial class MyForm4 : Form
    {
        public MyForm4()
        {
            InitializeComponent();
        }

        private int counter = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            counter++;
            this.Counter.Text = $"Clicked {this.counter} times";
        }
    }
}
