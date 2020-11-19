namespace INF_Seminararbeit
{
    partial class Dialog2
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
            this.dgvHighscore = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighscore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHighscore
            // 
            this.dgvHighscore.AllowUserToAddRows = false;
            this.dgvHighscore.AllowUserToDeleteRows = false;
            this.dgvHighscore.AllowUserToOrderColumns = true;
            this.dgvHighscore.AllowUserToResizeColumns = false;
            this.dgvHighscore.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHighscore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHighscore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHighscore.Location = new System.Drawing.Point(0, 0);
            this.dgvHighscore.Margin = new System.Windows.Forms.Padding(8);
            this.dgvHighscore.Name = "dgvHighscore";
            this.dgvHighscore.ReadOnly = true;
            this.dgvHighscore.RowHeadersWidth = 51;
            this.dgvHighscore.Size = new System.Drawing.Size(1240, 817);
            this.dgvHighscore.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 807);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 10);
            this.panel1.TabIndex = 1;
            // 
            // Dialog2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 817);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvHighscore);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Dialog2";
            this.Text = "Dialog2";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighscore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHighscore;
        private System.Windows.Forms.Panel panel1;
    }
}