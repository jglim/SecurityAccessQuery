namespace SecurityAccessQuery
{
    partial class LibrarySelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibrarySelector));
            this.dgvResponse = new System.Windows.Forms.DataGridView();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cbHasValidModes = new System.Windows.Forms.CheckBox();
            this.cbHasGenerationFn = new System.Windows.Forms.CheckBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponse)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResponse
            // 
            this.dgvResponse.AllowUserToAddRows = false;
            this.dgvResponse.AllowUserToDeleteRows = false;
            this.dgvResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResponse.Location = new System.Drawing.Point(12, 12);
            this.dgvResponse.Name = "dgvResponse";
            this.dgvResponse.ReadOnly = true;
            this.dgvResponse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResponse.Size = new System.Drawing.Size(776, 393);
            this.dgvResponse.TabIndex = 2;
            this.dgvResponse.DoubleClick += new System.EventHandler(this.dgvResponse_DoubleClick);
            this.dgvResponse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvResponse_KeyDown);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(12, 418);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(296, 20);
            this.txtFilter.TabIndex = 3;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // cbHasValidModes
            // 
            this.cbHasValidModes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHasValidModes.AutoSize = true;
            this.cbHasValidModes.Checked = true;
            this.cbHasValidModes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHasValidModes.Location = new System.Drawing.Point(325, 420);
            this.cbHasValidModes.Name = "cbHasValidModes";
            this.cbHasValidModes.Size = new System.Drawing.Size(112, 17);
            this.cbHasValidModes.TabIndex = 4;
            this.cbHasValidModes.Text = "Filter: Valid Modes";
            this.cbHasValidModes.UseVisualStyleBackColor = true;
            this.cbHasValidModes.CheckedChanged += new System.EventHandler(this.cbHasValidModes_CheckedChanged);
            // 
            // cbHasGenerationFn
            // 
            this.cbHasGenerationFn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHasGenerationFn.AutoSize = true;
            this.cbHasGenerationFn.Checked = true;
            this.cbHasGenerationFn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHasGenerationFn.Location = new System.Drawing.Point(443, 420);
            this.cbHasGenerationFn.Name = "cbHasGenerationFn";
            this.cbHasGenerationFn.Size = new System.Drawing.Size(183, 17);
            this.cbHasGenerationFn.TabIndex = 5;
            this.cbHasGenerationFn.Text = "Filter: Exports generation function";
            this.cbHasGenerationFn.UseVisualStyleBackColor = true;
            this.cbHasGenerationFn.CheckedChanged += new System.EventHandler(this.cbHasGenerationFn_CheckedChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(632, 416);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(713, 416);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LibrarySelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.cbHasGenerationFn);
            this.Controls.Add(this.cbHasValidModes);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.dgvResponse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LibrarySelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Selector";
            this.Load += new System.EventHandler(this.LibrarySelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResponse;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.CheckBox cbHasValidModes;
        private System.Windows.Forms.CheckBox cbHasGenerationFn;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCancel;
    }
}