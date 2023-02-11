using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migrator.UI
{
    public partial class FormInputName : Form
    {
        public string NewName { get; set; }
        public FormInputName()
        {
            InitializeComponent();
        }
        public FormInputName(string defaultValue)
        {
            InitializeComponent();
            txtInput.Text = defaultValue;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NewName = txtInput.Text;
            Close();
        }
    }
}
