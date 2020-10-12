namespace SecurityAccessQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtChallenge = new System.Windows.Forms.TextBox();
            this.dgvResponse = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDLLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDLLFilteredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.diagnosticsDumpDLLReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponse)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtChallenge
            // 
            this.txtChallenge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChallenge.BackColor = System.Drawing.SystemColors.Window;
            this.txtChallenge.Location = new System.Drawing.Point(12, 29);
            this.txtChallenge.Name = "txtChallenge";
            this.txtChallenge.Size = new System.Drawing.Size(667, 20);
            this.txtChallenge.TabIndex = 0;
            this.txtChallenge.TextChanged += new System.EventHandler(this.txtChallenge_TextChanged);
            this.txtChallenge.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChallenge_KeyDown);
            // 
            // dgvResponse
            // 
            this.dgvResponse.AllowUserToAddRows = false;
            this.dgvResponse.AllowUserToDeleteRows = false;
            this.dgvResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResponse.Location = new System.Drawing.Point(12, 53);
            this.dgvResponse.Name = "dgvResponse";
            this.dgvResponse.ReadOnly = true;
            this.dgvResponse.Size = new System.Drawing.Size(748, 378);
            this.dgvResponse.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(772, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectDLLToolStripMenuItem,
            this.selectDLLFilteredToolStripMenuItem,
            this.toolStripSeparator2,
            this.diagnosticsDumpDLLReportToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectDLLToolStripMenuItem
            // 
            this.selectDLLToolStripMenuItem.Name = "selectDLLToolStripMenuItem";
            this.selectDLLToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.selectDLLToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.selectDLLToolStripMenuItem.Text = "Select DLL";
            this.selectDLLToolStripMenuItem.Click += new System.EventHandler(this.selectDLLToolStripMenuItem_Click);
            // 
            // selectDLLFilteredToolStripMenuItem
            // 
            this.selectDLLFilteredToolStripMenuItem.Name = "selectDLLFilteredToolStripMenuItem";
            this.selectDLLFilteredToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.selectDLLFilteredToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.selectDLLFilteredToolStripMenuItem.Text = "Select DLL (Filtered)";
            this.selectDLLFilteredToolStripMenuItem.Click += new System.EventHandler(this.selectDLLFilteredToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(250, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(685, 27);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // diagnosticsDumpDLLReportToolStripMenuItem
            // 
            this.diagnosticsDumpDLLReportToolStripMenuItem.Name = "diagnosticsDumpDLLReportToolStripMenuItem";
            this.diagnosticsDumpDLLReportToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.diagnosticsDumpDLLReportToolStripMenuItem.Text = "Diagnostics: Dump DLL Report";
            this.diagnosticsDumpDLLReportToolStripMenuItem.Click += new System.EventHandler(this.diagnosticsDumpDLLReportToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(250, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 443);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.dgvResponse);
            this.Controls.Add(this.txtChallenge);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Access Query";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponse)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChallenge;
        private System.Windows.Forms.DataGridView dgvResponse;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectDLLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectDLLFilteredToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem diagnosticsDumpDLLReportToolStripMenuItem;
    }
}

