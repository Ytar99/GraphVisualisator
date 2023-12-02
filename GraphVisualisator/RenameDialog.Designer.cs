namespace GraphVisualisator
{
    partial class RenameDialog
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
            this.newLabel_textbox = new System.Windows.Forms.TextBox();
            this.rename_label = new System.Windows.Forms.Label();
            this.rename_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newLabel_textbox
            // 
            this.newLabel_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newLabel_textbox.Location = new System.Drawing.Point(15, 44);
            this.newLabel_textbox.Margin = new System.Windows.Forms.Padding(8);
            this.newLabel_textbox.MaxLength = 6;
            this.newLabel_textbox.Name = "newLabel_textbox";
            this.newLabel_textbox.Size = new System.Drawing.Size(331, 20);
            this.newLabel_textbox.TabIndex = 0;
            this.newLabel_textbox.TextChanged += new System.EventHandler(this.newLabel_textbox_TextChanged);
            this.newLabel_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.newLabel_textbox_KeyDown);
            // 
            // rename_label
            // 
            this.rename_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rename_label.Location = new System.Drawing.Point(15, 24);
            this.rename_label.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.rename_label.Name = "rename_label";
            this.rename_label.Size = new System.Drawing.Size(331, 21);
            this.rename_label.TabIndex = 1;
            this.rename_label.Text = "Введите новую метку для узла (не больше 6 символов)";
            // 
            // rename_button
            // 
            this.rename_button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rename_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rename_button.Enabled = false;
            this.rename_button.Location = new System.Drawing.Point(218, 90);
            this.rename_button.Name = "rename_button";
            this.rename_button.Size = new System.Drawing.Size(128, 23);
            this.rename_button.TabIndex = 2;
            this.rename_button.Text = "Переименовать";
            this.rename_button.UseVisualStyleBackColor = true;
            this.rename_button.Click += new System.EventHandler(this.rename_button_Click);
            // 
            // RenameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 125);
            this.Controls.Add(this.rename_button);
            this.Controls.Add(this.newLabel_textbox);
            this.Controls.Add(this.rename_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "RenameDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Переименовать узел";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox newLabel_textbox;
        private System.Windows.Forms.Label rename_label;
        private System.Windows.Forms.Button rename_button;
    }
}