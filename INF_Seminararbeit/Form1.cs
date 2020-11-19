using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.CompilerServices;

namespace INF_Seminararbeit
{
    public partial class Form1 : Form, IMessageFilter
    {
        //Constants
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        Image carStandardImage;
       
        //Variables general
        DateTime startTime;
        int penalty=0;
        int carSpeedMax = -3;
        int carSpeed = 0;
        int carSpeed_tmp = 0;
        int carSpeedMaxMerker = 0;
        int carSpeedBoostMerker = 0;
        int carSpeedBoostMaxMerker = 0;
        int carAcceleration = 1;
        int carAngle = 90;
        int carStyle = 1;
        int carPictureAngle = 90;
        int obstacleSpeed = -1;
        int obstacleSpeed_tmp = 0;
        bool accelerateCones = false;
        bool isRunning = false;
        bool reset = false;
        bool restart = false;
        bool crashSituation = false;
        bool slalomDirection = false;  //False:left true:right
        PictureBox finish;
        TimeSpan runtime;

        //Cones
        int coneNumber = 7;
        int coneNumber2 = 0;
        int coneDistance = 400;
        int indexNextCone=0;
        bool obstaclesPlaced = false;
        List<PictureBox> listOfCones = new List<PictureBox>();

        //Splines
        private List<Point> left = new List<Point>();
        private List<Point> right = new List<Point>();

        public List<Highscore> highscoreTable = new List<Highscore>();
        //Formatters
        string fmtMS = "000";
        string fmtS = "00";
        string fmtM = "00";
        //background
        Image image;
        TextureBrush tBrush;
        Image image2;
        

        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            carStandardImage = pbCar.Image;
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            image = new Bitmap(INF_Seminararbeit.Properties.Resources.grass);
            image2 = new Bitmap(INF_Seminararbeit.Properties.Resources.asphalt);
            tBrush = new TextureBrush(image);
            tBrush.Transform = new Matrix(
                   75.0f / 640.0f,
                   0.0f,
                   0.0f,
                   75.0f / 480.0f,
                   0.0f,
                   0.0f);
            pbStartLights.Enabled = false;
            pbStartLights.Visible = false;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pbCar.BackColor = Color.Transparent;
            pbStartLights.BackColor = Color.Transparent;
            pbCar.Parent = pbGame;
            pbStartLights.Parent = pbGame;
            pbStart.Parent = pbGame;
            pbCar.BringToFront();
            pbStartLights.Parent = pbGame;
        }


        ///////////////////
        ///// Timers /////
        //////////////////
        private void tmrGameTime_Tick(object sender, EventArgs e)
        {
            MoveCar();
            moveObstacles();
            RotateCarPicture();
            slalomCheck();

            //Crashdetection
            if (checkCrash() && !crashSituation)
            {
                crashSituation = true;
                carSpeedMaxMerker = carSpeedMax;
                carSpeedMax = -1;
                carSpeed = -1;
                tmrHitObstacle.Enabled = true;
                pgbBoost.Value = 0;
            }

            //Finish
            if (pbCar.Bounds.IntersectsWith(finish.Bounds))
            {
                Finish();
                tmrGameTime.Enabled = false;
                Application.RemoveMessageFilter(this);
                Dialog1 dialog1 = new Dialog1(ref highscoreTable, coneNumber2,CarName(carStyle), runtime);
                dialog1.ShowDialog();
                Application.AddMessageFilter(this);
            }
        }
        private void tmrClock_Tick(object sender, EventArgs e)
        {
            TimeSpan time= DateTime.Now - startTime;
            lblTime.Text = time.Minutes.ToString(fmtM) + " : " + time.Seconds.ToString(fmtS) + " : " + time.Milliseconds.ToString(fmtMS);
        }
        private void tmrBoost_Tick(object sender, EventArgs e)
        {
            if (!crashSituation)
            {
                carSpeed = carSpeedBoostMerker;
                carSpeedMax = carSpeedBoostMaxMerker;
                tmrBoostLock.Start();
                tmrBoost.Enabled = false;
            }
        }

        private void tmrBoostLock_Tick(object sender, EventArgs e)
        {
            carSpeedBoostMerker = 0;
            carSpeedBoostMaxMerker = 0;
            pgbBoost.Value = 100;
            lblBoost.Text = "Boost";
            tmrBoostLock.Stop();

        }
        private void tmrHitObstacle_Tick(object sender, EventArgs e)
        {
            crashSituation = false;
            carSpeedMax = carSpeedMaxMerker;
            carSpeedMaxMerker = 0;
            tmrHitObstacle.Enabled = false;
            pgbBoost.Value = 100;
        }
        private void tmrStartLights_Tick(object sender, EventArgs e)
        {
            tmrStartLights.Enabled = false;
            
            if (isRunning)
            {
                if (restart)
                {
                    tmrClock.Start();
                    obstacleSpeed = obstacleSpeed_tmp;
                    carSpeed = carSpeed_tmp;
                    btnStart.Text = "Pause";
                    restart = false;
                }
                else
                {
                    obstacleSpeed_tmp = obstacleSpeed;
                    carSpeed_tmp = carSpeed;
                    obstacleSpeed = 0;
                    carSpeed = 0;
                    tmrClock.Stop();
                    btnStart.Text = "Resume";
                    restart = true;
                }
            }
            else
            {
                coneNumber2 = coneNumber;
                startTime = DateTime.Now;
                tmrGameTime.Start();
                placeObstacles();
                tmrClock.Start();
                isRunning = true;
                btnStart.Text = "Pause";
            }
        }
        private void tmrStartlightsDelete_Tick(object sender, EventArgs e)
        {
            pbStartLights.Enabled = false;
            pbStartLights.Visible = false;
            tmrStartlightsDelete.Enabled = false;
        }



        ////////////////////////
        ///// Key Strokes /////
        ///////////////////////
        public bool PreFilterMessage(ref Message m)
        {
            Keys keyCode = (Keys)(int)m.WParam & Keys.KeyCode;
            if (m.Msg == WM_KEYDOWN && keyCode == Keys.W)
            {
                if(carSpeed>carSpeedMax)
                {
                    carSpeed -= carAcceleration;
                }                
                return true;
            }
            if (m.Msg == WM_KEYDOWN && keyCode == Keys.S)
            {
                if (carSpeed < 0)
                {
                    carSpeed += carAcceleration;
                }
                return true;
            }
            if (m.Msg == WM_KEYDOWN && keyCode == Keys.A)
            {
                carAngle -= 15;
                return true;
            }
            if (m.Msg == WM_KEYDOWN && keyCode == Keys.D)
            {
                carAngle += 15;
                return true;
            }

            if (m.Msg == WM_KEYDOWN && keyCode == Keys.N)
            {
                if(!crashSituation && pgbBoost.Value == 100)
                {
                    carSpeedBoostMaxMerker = carSpeedMax;
                    carSpeedBoostMerker = carSpeed;
                    carSpeedMax = -12;
                    carSpeed = -12;
                    tmrBoost.Enabled = true;
                    pgbBoost.Value = 0;
                }
                return true;
            }
            return false;
        }


        /////////////////////
        ///// Obstacles /////
        /////////////////////
        private void placeObstacles()
        {
            left.Clear();
            right.Clear();
            left.Add(new Point(pbCar.Left - 20, pbCar.Top-20));
            right.Add( new Point(pbCar.Left + pbCar.Width+ 20, pbCar.Top - 20));
            Random rnd = new Random();
            for (int i = 0; i < coneNumber; i++)                
            {
                int x= rnd.Next(150, 450);
                var picture = new PictureBox
                {
                    Name = "pbCone" + i.ToString(),
                    Size = new Size(35, 35),
                    Location = new Point(x, 100 - i * coneDistance),
                    Image = INF_Seminararbeit.Properties.Resources.cone,
                    BackColor = Color.Transparent,
                    Parent = pbGame,
                    SizeMode = PictureBoxSizeMode.StretchImage,   
                };
                if(i%2==0)
                {
                    left.Add(new Point(x-150, 100 - i * coneDistance+17));
                    right.Add(new Point(x, 100 - i * coneDistance+17));
                }
                if(i%2==1)
                {                    
                    left.Add(new Point(x+35, 100 - i * coneDistance + 17));
                    right.Add(new Point(x + 185, 100 - i * coneDistance + 17));
                }                
                pbGame.Controls.Add(picture);
                listOfCones.Add(picture);

                finish = new PictureBox
                {
                    Name = "pbFinish",
                    Size = new Size(1353, 50),
                    Location = new Point(0,pbCar.Top-397*(coneNumber+1)),
                    Image = INF_Seminararbeit.Properties.Resources.finishLine,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                pbGame.Controls.Add(finish);
            }
            left.Add(new Point(250, pbCar.Top - 397 * (coneNumber + 1)+50));
            right.Add(new Point(400, pbCar.Top - 397 * (coneNumber + 1) + 50));
            obstaclesPlaced = true;
            pbGame.Refresh();
        }
        private void moveObstacles()
        {
            int coneSpeed = obstacleSpeed;
            int carMovementY = Convert.ToInt32(carSpeed * Math.Sin(DegrToRadians(carAngle)));
            if (accelerateCones)
            {
                coneSpeed = obstacleSpeed + carMovementY;
            }
            for(int i=0;i<listOfCones.Count ; i++)
            {
                listOfCones[i].Top -= coneSpeed;           
            }
            for(int i=0;i<left.Count;i++)
            {
                left[i] = new Point(left[i].X, left[i].Y - coneSpeed);
            }
            for (int i = 0; i < right.Count; i++)
            {
                right[i] = new Point(right[i].X, right[i].Y - coneSpeed);
            }
            pbStart.Top -= coneSpeed;
            finish.Top -= coneSpeed;
            pbGame.Refresh();
        }
        private void numCones_ValueChanged(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                coneNumber = Convert.ToInt32(numCones.Value);
                coneNumber2 = coneNumber;
                pbGame.Refresh();
            }
        }


        ///////////////////
        /////// Car ///////
        ///////////////////
        private Bitmap RotateImageByAngle(Image oldBitmap, float angle)
        {
            var newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height);
            newBitmap.SetResolution(oldBitmap.HorizontalResolution, oldBitmap.VerticalResolution);
            var graphics = Graphics.FromImage(newBitmap);
            graphics.TranslateTransform((float)oldBitmap.Width / 2, (float)oldBitmap.Height / 2);
            graphics.RotateTransform(angle);
            graphics.TranslateTransform(-(float)oldBitmap.Width / 2, -(float)oldBitmap.Height / 2);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(oldBitmap, new Point(0, 0));
            return newBitmap;
        }
        private double DegrToRadians(int degr)
        {
            return (Math.PI/180) * degr;
        }
        private void MoveCar()
        {
            int carMovementX = 0;
            int carMovementY = 0;
            carMovementX = Convert.ToInt32(carSpeed * Math.Cos(DegrToRadians(carAngle)));
            carMovementY = Convert.ToInt32(carSpeed * Math.Sin(DegrToRadians(carAngle)));
            if ((carMovementX + pbCar.Width + pbCar.Left) < 620 && (pbCar.Left + carMovementX) > 0)
            {
                pbCar.Left += carMovementX;
            }
            if ((carMovementY + pbCar.Height + pbCar.Top) < pbGame.Height && (pbCar.Top + carMovementY) >200 )
            {
                pbCar.Top += carMovementY;
                accelerateCones = false;
            }
            if((pbCar.Top + carMovementY) <= 200)
            {
                accelerateCones = true;
            }
        }
        private void RotateCarPicture()
        {
            if (carPictureAngle != carAngle)
            {
                if (carAngle % 360 == 90)
                {
                    pbCar.Image = carStandardImage;
                }
                else
                {
                    float dif = carAngle - carPictureAngle;
                    pbCar.Image = RotateImageByAngle(pbCar.Image, dif);
                    carPictureAngle = carAngle;
                }
            }
        }
        private String CarName(int cartype)
        {
            switch (cartype)
            {
                case 1: return "Mini";
                case 2: return "Spider";
                case 3: return "F1 Car";
                default: return "No Car";
            }
        }


        ///////////////////////////////
        // Crash & Slalom Detection //
        //////////////////////////////
        private bool checkCrash()
        {
            for (int i = 0; i < listOfCones.Count; i++)
            {
                if (pbCar.Bounds.IntersectsWith(listOfCones[i].Bounds))
                {
                    return true;
                }
            }
            return false;
        }
        private void slalomCheck()
        {
            if (getNearestCone() == indexNextCone && distanceNearestCone(getNearestCone()) < 10)
            {
                int coneleft = listOfCones[getNearestCone()].Left;
                int coneright = listOfCones[getNearestCone()].Left + listOfCones[getNearestCone()].Width;
                if (!crashSituation)
                {
                    if (slalomDirection)
                    {
                        if (pbCar.Left <= coneright)
                        {
                            penalty += 5;
                            lblPenalty.Text = "Penalty: " + penalty.ToString() + "s";
                        }
                        else
                        {
                            slalomDirection = !slalomDirection;
                            pbArrow.Image = flipImage(pbArrow.Image);
                        }
                    }
                    else
                    {
                        if (pbCar.Left + pbCar.Width >= coneleft)
                        {
                            penalty += 5;
                            lblPenalty.Text = "Penalty: " + penalty.ToString() + "s";
                        }
                        else
                        {
                            slalomDirection = !slalomDirection;
                            pbArrow.Image = flipImage(pbArrow.Image);
                        }
                    }
                }
                else
                {
                    penalty += 5;
                    lblPenalty.Text = "Penalty: " + penalty.ToString() + "s";
                }
                indexNextCone++;
            }
        }
        private int getNearestCone()
        {
            int index = 0;
            int mindistance = Math.Abs(listOfCones[0].Top - pbCar.Top);
            for (int i = 0; i < coneNumber; i++)
            {
                if (mindistance > Math.Abs(listOfCones[i].Top - pbCar.Top))
                {
                    mindistance = Math.Abs(listOfCones[i].Top - pbCar.Top);
                    index = i;
                }
            }
            return index;
        }
        private int distanceNearestCone(int index)
        {
            return Math.Abs(listOfCones[index].Top - pbCar.Top);
        }
        private Image flipImage(Image image)
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return image;
        }


        ///////////////////////////////
        //// Button Click Events ////
        //////////////////////////////
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(isRunning==false || btnStart.Text == "Resume")
            {
                StartLights();
            }
            else
            {
                if (btnStart.Text == "Restart")
                {
                    //Application.Restart();
                    //Environment.Exit(0);
                    resetGame();
                    return;
                }
                if (isRunning)
                {
                    if (restart)
                    {
                        tmrClock.Start();
                        obstacleSpeed = obstacleSpeed_tmp;
                        carSpeed = carSpeed_tmp;
                        btnStart.Text = "Pause";
                        restart = false;
                    }
                    else
                    {
                        obstacleSpeed_tmp = obstacleSpeed;
                        carSpeed_tmp = carSpeed;
                        obstacleSpeed = 0;
                        carSpeed = 0;
                        tmrClock.Stop();
                        btnStart.Text = "Resume";
                        restart = true;
                    }
                }
                else
                {
                    coneNumber2 = coneNumber;
                    startTime = DateTime.Now;
                    tmrGameTime.Start();
                    placeObstacles();
                    tmrClock.Start();
                    isRunning = true;
                    btnStart.Text = "Pause";
                }
            }
            

        }
        private void btnChangeCar_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                if (carStyle == 3)
                {
                    pbCar.Image = INF_Seminararbeit.Properties.Resources.car1;
                    pbCar.Refresh();
                    carSpeedMax = -3;
                    carAcceleration = 1;
                    carStyle = 1;
                    reset = true;
                    btnChangeCar.Text = "Car Model: " + carStyle.ToString();
                }

                if (carStyle == 2)
                {
                    pbCar.Image = INF_Seminararbeit.Properties.Resources.car3;
                    pbCar.Refresh();
                    carSpeedMax = -7;
                    carAcceleration = 3;
                    carStyle += 1;
                    btnChangeCar.Text = "Car Model: " + carStyle.ToString();
                }

                if (carStyle == 1 && reset == false)
                {
                    pbCar.Image = INF_Seminararbeit.Properties.Resources.car2; ;
                    pbCar.Refresh();
                    carSpeedMax = -5;
                    carAcceleration = 2;
                    carStyle += 1;
                    btnChangeCar.Text = "Car Model: " + carStyle.ToString();
                }
                reset = false;
                carStandardImage = pbCar.Image;
            }
        }


        ///////////////////
        ///// Splines /////
        //////////////////
        protected void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (obstaclesPlaced)
            {
                GraphicsPath leftpath = new GraphicsPath();
                GraphicsPath rightpath = new GraphicsPath();
                
                leftpath.AddCurve(left.ToArray());
                leftpath.AddLine(left[coneNumber + 1], new Point(0, left[coneNumber + 1].Y));
                leftpath.AddLine(new Point(0, left[coneNumber + 1].Y), new Point(0, left[0].Y));
                leftpath.AddLine(new Point(0, left[0].Y), left[0]);
                e.Graphics.DrawPath(Pens.Gray, leftpath);

                rightpath.AddCurve(right.ToArray());
                rightpath.AddLine(right[coneNumber + 1], new Point(1350, right[coneNumber + 1].Y));
                rightpath.AddLine(new Point(1350, right[coneNumber + 1].Y), new Point(1350, right[0].Y));
                rightpath.AddLine(new Point(1350, right[0].Y), right[0]);              
                e.Graphics.DrawPath(Pens.Gray, rightpath);
                if(chbGraphics.Checked)
                {
                    e.Graphics.FillPath(tBrush, leftpath);
                    e.Graphics.FillPath(tBrush, rightpath);
                }
                else
                {
                    e.Graphics.FillPath(Brushes.Green, leftpath);
                    e.Graphics.FillPath(Brushes.Green, rightpath);
                }
            }
        }


        ///////////////////
        ///// Finish /////
        //////////////////
        private void Finish()
        {
            tmrClock.Stop();
            tmrGameTime.Stop();
            penalty = penalty * -1;
            startTime = startTime.AddSeconds(penalty);
            runtime = (DateTime.Now - startTime);
            lblTime.Text = runtime.Minutes.ToString(fmtM) + " : " + runtime.Seconds.ToString(fmtS) + " : " + runtime.Milliseconds.ToString(fmtMS);
            lblTimeHeading.Text = "Finished in:";
            lblTimeHeading.ForeColor = Color.Green;
            lblTime.ForeColor = Color.Green;
            btnStart.Text = "Restart";
        }


        ///////////////////
        /////  File  /////
        //////////////////
        private String[] toArray(List<Highscore> highscore)
        {
            List<String> liste = new List<String>();
            for (int i = 0; i < highscore.Count; i++)
            {
                liste.Add(highscore[i].Rank.ToString() + ";" +
                          highscore[i].Time.ToString() + ";" +
                          highscore[i].Car + ";" +
                          highscore[i].ConeNumber.ToString() + ";" +
                          highscore[i].Name + ";"
                    );
            }
            return liste.ToArray();
        }
        private void safeFile(String filePath)
        {
            try
            {
                File.WriteAllLines(filePath, toArray(highscoreTable));
                string message = "File succesfully saved";
                string title = "Message";
                MessageBox.Show(message, title);
            }
            catch
            {
                string message = "Error while writing to file";
                string title = "Error:";
                MessageBox.Show(message, title);
            }

        }
        private void loadFile(String filePath)
        {
            try
            {
                highscoreTable.Clear();

                List<String> lines = File.ReadAllLines(filePath).ToList();

                List<List<String>> parts = new List<List<string>>();

                for (int i = 0; i < lines.Count; i++)
                {
                    parts.Add(lines[i].Split(';').ToList());
                }

                for (int i = 0; i <= lines.Count - 1; i++)
                {
                    highscoreTable.Add(new Highscore()
                    {
                        Rank = Convert.ToInt32(parts[i][0]),
                        Time = TimeSpan.Parse(parts[i][1]),
                        Car = parts[i][2],
                        ConeNumber = Convert.ToInt32(parts[i][3]),
                        Name = parts[i][4]
                    });
                }
                string message = "File succesfully loaded";
                string title = "Message";
                MessageBox.Show(message, title);
            }
            catch
            {
                string message = "Error while loading file";
                string title = "Error:";
                MessageBox.Show(message, title);
            }
            
        }
        private void loadHighScore_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                loadFile(path);
            }
        }

        private void saveHighScore_Click(object sender, EventArgs e)
        {
            string path;
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                safeFile(path);
            }
        }

        private void showHighScore_Click(object sender, EventArgs e)
        {
            Application.RemoveMessageFilter(this);
            Dialog2 dialog2 = new Dialog2(ref highscoreTable);
            dialog2.ShowDialog();
            Application.AddMessageFilter(this);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Quit without Saving?", "Save?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                string path;
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    path = file.FileName;
                    safeFile(path);
                }
            }
        }
        private void ProgrammedBy()
        {
            string message = "This Game was Programmed by:\n Raphael Ofner & Marco Pachner\n FZT JG 2020";
            string title = "Programmed by:";
            MessageBox.Show(message, title);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            ProgrammedBy();
        }


        ///////////////////
        /////  Reset  /////
        //////////////////
        private void resetGame()
        {
            pbCar.Top = 474;
            pbCar.Left = 65;
            pbStart.Top = 433;
            pbStart.Left = 0;
            right.Clear();
            left.Clear();            
            tmrGameTime.Enabled = false;
            tmrClock.Enabled = false;
            tmrHitObstacle.Enabled = false;
            tmrBoost.Enabled = false;
            btnStart.Text = "Start";
            lblPenalty.Text = "Penalty: 0s";
            lblTime.Text = "00 : 00 : 000";
            pbGame.Controls.Remove(finish);
            for(int i=0; i<listOfCones.Count;i++)
            {
                pbGame.Controls.Remove(listOfCones[i]);
            }
            listOfCones.Clear();

            penalty = 0;
            carSpeedMax = -3;
            carSpeed = 0;
            carSpeed_tmp = 0;
            carSpeedMaxMerker = 0;
            carAcceleration = 1;
            carAngle = 90;
            carStyle = 1;
            carPictureAngle = 90;
            obstacleSpeed = -1;
            obstacleSpeed_tmp = 0;
            accelerateCones = false;
            isRunning = false;
            reset = false;
            restart = false;
            crashSituation = false;
            slalomDirection = false;

            coneNumber = Convert.ToInt32(numCones.Value);
            coneNumber2 = coneNumber;
            coneDistance = 400;
            indexNextCone = 0;
            obstaclesPlaced = false;
            pbGame.Refresh();
            pbCar.Image = carStandardImage;
        }

        private void chbGraphics_CheckedChanged(object sender, EventArgs e)
        {
            if(chbGraphics.Checked)
            {
                pbGame.Image = image2;
            }
            else
            {
                pbGame.Image = null;
            }
        }
        private void StartLights()
        {

            pbStartLights.Enabled = true;
            pbStartLights.Visible = true;      
            
            tmrStartLights.Enabled = true;
            tmrStartlightsDelete.Enabled = true;
        }


    }
}
