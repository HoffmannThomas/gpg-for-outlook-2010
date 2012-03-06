using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OutlookGpg2010
{
    public partial class PasswordPromt : Form
    {
        public String password { get; private set;}

        public PasswordPromt()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            this.password = this.passwordBox.Text;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
