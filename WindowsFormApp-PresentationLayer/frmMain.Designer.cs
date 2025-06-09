namespace WindowsFormApp_PresentationLayer
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.dgv_AllContact = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_AddNewContact = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AllContact)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_AllContact
            // 
            this.dgv_AllContact.AllowUserToAddRows = false;
            this.dgv_AllContact.AllowUserToDeleteRows = false;
            this.dgv_AllContact.AllowUserToOrderColumns = true;
            this.dgv_AllContact.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_AllContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_AllContact.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_AllContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AllContact.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_AllContact.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_AllContact.Location = new System.Drawing.Point(12, 12);
            this.dgv_AllContact.Name = "dgv_AllContact";
            this.dgv_AllContact.ReadOnly = true;
            this.dgv_AllContact.RowHeadersWidth = 51;
            this.dgv_AllContact.RowTemplate.Height = 26;
            this.dgv_AllContact.Size = new System.Drawing.Size(1267, 409);
            this.dgv_AllContact.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 52);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btn_AddNewContact
            // 
            this.btn_AddNewContact.Location = new System.Drawing.Point(1062, 451);
            this.btn_AddNewContact.Name = "btn_AddNewContact";
            this.btn_AddNewContact.Size = new System.Drawing.Size(216, 51);
            this.btn_AddNewContact.TabIndex = 1;
            this.btn_AddNewContact.Text = "Add New Contact";
            this.btn_AddNewContact.UseVisualStyleBackColor = true;
            this.btn_AddNewContact.Click += new System.EventHandler(this.btn_AddNewContact_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 543);
            this.Controls.Add(this.btn_AddNewContact);
            this.Controls.Add(this.dgv_AllContact);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Main Window";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AllContact)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_AllContact;
        private System.Windows.Forms.Button btn_AddNewContact;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

