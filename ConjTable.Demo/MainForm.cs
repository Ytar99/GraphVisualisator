﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConjTable.Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        int[,] _matrix = new int[,]
            {
                {0, 1, 1},
                {1, 0, 1},
                {1, 1, 0},
            };

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            conjTable1.Build(_matrix);
            conjPanel1.Build(_matrix);
            conjList1.Build(_matrix);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            conjPanel1.Build(conjTable1.Matrix);
        }

        private void conjTable1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            conjPanel1.Build(conjTable1.Matrix);
        }

        private void deleteNode_button_Click(object sender, EventArgs e)
        {
            
        }

        private void conjList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conjList1.SelectedItem != null)
            {
                deleteNode_button.Enabled = true;
            } else { 
                deleteNode_button.Enabled = false;
            }
        }
    }
}
