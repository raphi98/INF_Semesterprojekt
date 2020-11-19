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
            this.panel1.Location = new System.Drawing.Point(0, 437);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 125);
            this.panel1.TabIndex = 1;
            // 
            // lblConeNumber
            // 
            this.lblConeNumber.AutoSize = true;
            this.lblConeNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConeNumber.Location = new System.Drawing.Point(230, 42);
            this.lblConeNumber.Name = "lblConeNumber";
            this.lblConeNumber.Size = new System.Drawing.Size(52, 16);
            this.lblConeNumber.TabIndex = 4;
            this.lblConeNumber.Text = "Cones";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(302, 39);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(176, 22);
            this.tbName.TabIndex = 3;
            this.tbName.Text = "Name";
            // 
            // lblCar
            // 
            this.lblCar.AutoSize = true;
            this.lblCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCar.Location = new System.Drawing.Point(137, 42);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(32, 16);
            this.lblCar.TabIndex = 2;
            this.lblCar.Text = "Car";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(25, 42);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(43, 16);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "Time";
            // 
            // btnEnterScore
            // 
            this.btnEnterScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnterScore.Location = new System.Drawing.Point(494, 38);
            this.btnEnterScore.Name = "btnEnterScore";
            this.btnEnterScore.Size = new System.Drawing.Size(116, 23);
            this.btnEnterScore.TabIndex = 0;
            this.btnEnterScore.Text = "enter score";
            this.btnEnterScore.UseVisualStyleBackColor = true;
            this.btnEnterScore.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvHighscore
            // 
            this.dgvHighscore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHighscore.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvHighscore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHighscore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHighscore.Location = new System.Drawing.Point(0, 0);
            this.dgvHighscore.Name = "dgvHighscore";
            this.dgvHighscore.RowHeadersVisible = false;
            this.dgvHighscore.RowHeadersWidth = 82;
            this.dgvHighscore.Size = new System.Drawing.Size(784, 437);
            this.dgvHighscore.TabIndex = 2;
            // 
            // Dialog1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.dgvHighscore);
            this.Controls.Add(this.panel1);
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