namespace GraphVisualisator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.calcFloyd_button = new System.Windows.Forms.Button();
            this.renameNode_button = new System.Windows.Forms.Button();
            this.addNode_button = new System.Windows.Forms.Button();
            this.deleteNode_button = new System.Windows.Forms.Button();
            this.bezier_checkbox = new System.Windows.Forms.CheckBox();
            this.conjList1 = new System.Windows.Forms.AdjList();
            this.conjTable1 = new System.Windows.Forms.AdjTable();
            this.conjPanel1 = new System.Windows.Forms.AdjPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conjTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.conjList1);
            this.splitContainer1.Panel1.Controls.Add(this.conjTable1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.conjPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1087, 553);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.bezier_checkbox);
            this.panel1.Controls.Add(this.calcFloyd_button);
            this.panel1.Controls.Add(this.renameNode_button);
            this.panel1.Controls.Add(this.addNode_button);
            this.panel1.Controls.Add(this.deleteNode_button);
            this.panel1.Location = new System.Drawing.Point(0, 302);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 59);
            this.panel1.TabIndex = 6;
            // 
            // calcFloyd_button
            // 
            this.calcFloyd_button.Location = new System.Drawing.Point(3, 4);
            this.calcFloyd_button.Name = "calcFloyd_button";
            this.calcFloyd_button.Size = new System.Drawing.Size(171, 23);
            this.calcFloyd_button.TabIndex = 5;
            this.calcFloyd_button.Text = "Алгоритм Флойда-Уоршелла";
            this.calcFloyd_button.UseVisualStyleBackColor = true;
            this.calcFloyd_button.Click += new System.EventHandler(this.calcFloyd_button_Click);
            // 
            // renameNode_button
            // 
            this.renameNode_button.Enabled = false;
            this.renameNode_button.Location = new System.Drawing.Point(165, 33);
            this.renameNode_button.Name = "renameNode_button";
            this.renameNode_button.Size = new System.Drawing.Size(114, 23);
            this.renameNode_button.TabIndex = 6;
            this.renameNode_button.Text = "Переименовать";
            this.renameNode_button.UseVisualStyleBackColor = true;
            this.renameNode_button.Click += new System.EventHandler(this.renameNode_button_Click);
            // 
            // addNode_button
            // 
            this.addNode_button.Location = new System.Drawing.Point(3, 33);
            this.addNode_button.Name = "addNode_button";
            this.addNode_button.Size = new System.Drawing.Size(75, 23);
            this.addNode_button.TabIndex = 3;
            this.addNode_button.Text = "Добавить";
            this.addNode_button.UseVisualStyleBackColor = true;
            this.addNode_button.Click += new System.EventHandler(this.addNode_button_Click);
            // 
            // deleteNode_button
            // 
            this.deleteNode_button.Enabled = false;
            this.deleteNode_button.Location = new System.Drawing.Point(84, 33);
            this.deleteNode_button.Name = "deleteNode_button";
            this.deleteNode_button.Size = new System.Drawing.Size(75, 23);
            this.deleteNode_button.TabIndex = 4;
            this.deleteNode_button.Text = "Удалить";
            this.deleteNode_button.UseVisualStyleBackColor = true;
            this.deleteNode_button.Click += new System.EventHandler(this.deleteNode_button_Click);
            // 
            // bezier_checkbox
            // 
            this.bezier_checkbox.AutoSize = true;
            this.bezier_checkbox.Location = new System.Drawing.Point(280, 37);
            this.bezier_checkbox.Name = "bezier_checkbox";
            this.bezier_checkbox.Size = new System.Drawing.Size(78, 17);
            this.bezier_checkbox.TabIndex = 7;
            this.bezier_checkbox.Text = "Скруглить";
            this.bezier_checkbox.UseVisualStyleBackColor = true;
            this.bezier_checkbox.CheckedChanged += new System.EventHandler(this.bezier_checkbox_CheckedChanged);
            // 
            // conjList1
            // 
            this.conjList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conjList1.FormattingEnabled = true;
            this.conjList1.Location = new System.Drawing.Point(0, 367);
            this.conjList1.Name = "conjList1";
            this.conjList1.Size = new System.Drawing.Size(360, 186);
            this.conjList1.TabIndex = 2;
            this.conjList1.SelectedIndexChanged += new System.EventHandler(this.conjList1_SelectedIndexChanged);
            // 
            // conjTable1
            // 
            this.conjTable1.AllowUserToAddRows = false;
            this.conjTable1.AllowUserToDeleteRows = false;
            this.conjTable1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.conjTable1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.conjTable1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.conjTable1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.conjTable1.Cursor = System.Windows.Forms.Cursors.Default;
            this.conjTable1.Location = new System.Drawing.Point(0, 0);
            this.conjTable1.MultiSelect = false;
            this.conjTable1.Name = "conjTable1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.conjTable1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.conjTable1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.conjTable1.RowTemplate.Height = 23;
            this.conjTable1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.conjTable1.Size = new System.Drawing.Size(357, 296);
            this.conjTable1.TabIndex = 1;
            this.conjTable1.VirtualMode = true;
            this.conjTable1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.conjTable1_CellValueChanged);
            // 
            // conjPanel1
            // 
            this.conjPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conjPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conjPanel1.Location = new System.Drawing.Point(0, 0);
            this.conjPanel1.Name = "conjPanel1";
            this.conjPanel1.Size = new System.Drawing.Size(723, 553);
            this.conjPanel1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 553);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Визуализатор графов";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conjTable1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.AdjList conjList1;
        private System.Windows.Forms.Button calcFloyd_button;
        private System.Windows.Forms.Button deleteNode_button;
        private System.Windows.Forms.Button addNode_button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button renameNode_button;
        private System.Windows.Forms.CheckBox bezier_checkbox;
        public System.Windows.Forms.AdjPanel conjPanel1;
        public System.Windows.Forms.AdjTable conjTable1;
    }
}

