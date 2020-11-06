    namespace INF_Seminararbeit
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelGame = new System.Windows.Forms.Panel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.lblPenalty = new System.Windows.Forms.Label();
            this.btnChangeCar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimeHeading = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tmrGameTime = new System.Windows.Forms.Timer(this.components);
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.tmrHitObstacle = new System.Windows.Forms.Timer(this.components);
            this.pbArrow = new System.Windows.Forms.PictureBox();
            this.pbCar = new System.Windows.Forms.PictureBox();
            this.pbStart = new System.Windows.Forms.PictureBox();
            this.tmrBoost = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panelGame.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStart)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.Controls.Add(this.pbCar);
            this.panelGame.Controls.Add(this.pbStart);
            this.panelGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGame.Location = new System.Drawing.Point(0, 0);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(1871, 1135);
            this.panelGame.TabIndex = 0;
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelControls.Controls.Add(this.button1);
            this.panelControls.Controls.Add(this.pbArrow);
            this.panelControls.Controls.Add(this.lblPenalty);
            this.panelControls.Controls.Add(this.btnChangeCar);
            this.panelControls.Controls.Add(this.tableLayoutPanel1);
            this.panelControls.Controls.Add(this.btnStart);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControls.Location = new System.Drawing.Point(1329, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(542, 1135);
            this.panelControls.TabIndex = 1;
            // 
            // lblPenalty
            // 
            this.lblPenalty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPenalty.AutoSize = true;
            this.lblPenalty.Font = new System.Drawing.Font("Calibri Light", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPenalty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPenalty.Location = new System.Drawing.Point(130, 471);
            this.lblPenalty.Name = "lblPenalty";
            this.lblPenalty.Size = new System.Drawing.Size(287, 72);
            this.lblPenalty.TabIndex = 2;
            this.lblPenalty.Text = "Penalty: 0s";
            // 
            // btnChangeCar
            // 
            this.btnChangeCar.Font = new System.Drawing.Font("Calibri Light", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeCar.Location = new System.Drawing.Point(90, 323);
            this.btnChangeCar.Name = "btnChangeCar";
            this.btnChangeCar.Size = new System.Drawing.Size(377, 81);
            this.btnChangeCar.TabIndex = 2;
            this.btnChangeCar.Text = "Car Model: 1";
            this.btnChangeCar.UseVisualStyleBackColor = true;
            this.btnChangeCar.Click += new System.EventHandler(this.btnChangeCar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.5F));
            this.tableLayoutPanel1.Controls.Add(this.lblTime, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeHeading, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(90, 65);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.4898F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.5102F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(377, 196);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Calibri Light", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(67, 110);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(242, 72);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "00:00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimeHeading
            // 
            this.lblTimeHeading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTimeHeading.AutoSize = true;
            this.lblTimeHeading.Font = new System.Drawing.Font("Calibri Light", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeHeading.Location = new System.Drawing.Point(114, 12);
            this.lblTimeHeading.Name = "lblTimeHeading";
            this.lblTimeHeading.Size = new System.Drawing.Size(148, 72);
            this.lblTimeHeading.TabIndex = 1;
            this.lblTimeHeading.Text = "Time";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Calibri Light", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(90, 977);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(377, 106);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tmrGameTime
            // 
            this.tmrGameTime.Interval = 20;
            this.tmrGameTime.Tick += new System.EventHandler(this.tmrGameTime_Tick);
            // 
            // tmrClock
            // 
            this.tmrClock.Interval = 50;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // tmrHitObstacle
            // 
            this.tmrHitObstacle.Interval = 5000;
            this.tmrHitObstacle.Tick += new System.EventHandler(this.tmrHitObstacle_Tick);
            // 
            // pbArrow
            // 
            this.pbArrow.Image = global::INF_Seminararbeit.Properties.Resources.arrow_left;
            this.pbArrow.Location = new System.Drawing.Point(157, 658);
            this.pbArrow.Name = "pbArrow";
            this.pbArrow.Size = new System.Drawing.Size(237, 137);
            this.pbArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArrow.TabIndex = 3;
            this.pbArrow.TabStop = false;
            // 
            // pbCar
            // 
            this.pbCar.BackColor = System.Drawing.Color.Transparent;
            this.pbCar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCar.Image = global::INF_Seminararbeit.Properties.Resources.car1;
            this.pbCar.Location = new System.Drawing.Point(130, 912);
            this.pbCar.Name = "pbCar";
            this.pbCar.Size = new System.Drawing.Size(100, 100);
            this.pbCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCar.TabIndex = 1;
            this.pbCar.TabStop = false;
            // 
            // pbStart
            // 
            this.pbStart.Image = global::INF_Seminararbeit.Properties.Resources.finishLine;
            this.pbStart.Location = new System.Drawing.Point(0, 833);
            this.pbStart.Name = "pbStart";
            this.pbStart.Size = new System.Drawing.Size(1353, 50);
            this.pbStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStart.TabIndex = 2;
            this.pbStart.TabStop = false;
            // 
            // tmrBoost
            // 
            this.tmrBoost.Interval = 1000;
            this.tmrBoost.Tick += new System.EventHandler(this.tmrBoost_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 867);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 78);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1871, 1135);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelGame.ResumeLayout(false);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimeHeading;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer tmrGameTime;
        private System.Windows.Forms.PictureBox pbCar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnChangeCar;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.Timer tmrHitObstacle;
        private System.Windows.Forms.PictureBox pbStart;
        private System.Windows.Forms.Label lblPenalty;
        private System.Windows.Forms.PictureBox pbArrow;
        private System.Windows.Forms.Timer tmrBoost;
        private System.Windows.Forms.Button button1;
    }
}

