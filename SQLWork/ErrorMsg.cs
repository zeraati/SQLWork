using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlWork
{
    public partial class ErrorMsg : Form
    {
        public ErrorMsg(string Error)
        {
            InitializeComponent();
            txtMsg.Text = Error;
        }

        private void ErrorMsg_Load(object sender, EventArgs e)
        {
            
        }
    }
}
