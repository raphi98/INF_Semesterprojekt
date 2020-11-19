namespace INF_Seminararbeit
{
    partial class Dialog1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblConeNumber = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblCar = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnEnterScore = new System.Windows.Forms.Button();
            this.dgvHighscore = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighscore)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblConeNumber);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.lblCar);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.btnEnterScore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 658);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 192);
            this.panel1.TabIndex = 1;
            // 
            // lblConeNumber
            // 
            this.lblConeNumber.AutoSize = true;
            this.lblConeNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConeNumber.Location = new System.Drawing.Point(460, 81);
            this.lblConeNumber.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblConeNumber.Name = "lblConeNumber";
            this.lblConeNumber.Size = new System.Drawing.Size(92, 30);
            this.lblConeNumber.TabIndex = 4;
            this.lblConeNumber.Text = "Cones";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(604, 75);
            this.tbName.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(348, 37);
            this.tbName.TabIndex = 3;
            this.tbName.Text = "Name";
            // 
            // lblCar
            // 
            this.lblCar.AutoSize = true;
            this.lblCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCar.Location = new System.Drawing.Point(274, 81);
            this.lblCar.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(58, 30);
            this.lblCar.TabIndex = 2;
            this.lblCar.Text = "Car";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(50, 81);
            this.lblTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(75, 30);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "Time";
            // 
            // btnEnterScore
            // 
            this.btnEnterScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnterScore.Location = new System.Drawing.Point(988, 73);
            this.btnEnterScore.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnEnterScore.Name = "btnEnterScore";
            this.btnEnterScore.Size = new System.Drawing.Size(232, 44);
            this.btnEnterScore.TabIndex = 0;
            this.btnEnterScore.Text = "enter score";
            this.btnEnterScore.UseVisualStyleBackColor = true;
            this.btnEnterScore.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvHighscore
            // 
            this.dgvHighscore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHighscore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHighscore.Location = new System.Drawing.Point(0, 0);
            this.dgvHighscore.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvHighscore.Name = "dgvHighscore";
            this.dgvHighscore.RowHeadersWidth = 82;
            this.dgvHighscore.Size = new System.Drawing.Size(1244, 658);
            this.dgvHighscore.TabIndex = 2;
            // 
            // Dialog1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 850);
            this.Controls.Add(this.dgvHighscore);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Dialog1";
            this.Text = "Dialog1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHighscore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEnterScore;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblCar;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DataGridView dgvHighscore;
        private System.Windows.Forms.Label lblConeNumber;
    }
}