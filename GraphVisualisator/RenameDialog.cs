using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphVisualisator
{
    public partial class RenameDialog : Form
    {
        public String NewName = "";

        public RenameDialog()
        {
            InitializeComponent();
        }

        private void newLabel_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (validateName())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private bool validateName()
        {
            if (newLabel_textbox.Text.Length <= 0)
            {
                return false;
            }

            if (newLabel_textbox.Text.Trim().Length <= 0)
            {
                return false;
            }

            return true;
        }

        private void rename_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newLabel_textbox_TextChanged(object sender, EventArgs e)
        {
            if (validateName())
            {
                rename_button.Enabled = true;
            }
            else
            {
                rename_button.Enabled = false;
            }

            NewName = newLabel_textbox.Text;
        }
    }
}
