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
        int carSpeedMax = -5;
        int carSpeed = 0;
        int carSpeedMaxMerker = 0;
        int carAcceleration = 1;
        int carAngle = 90;
        int carPictureAngle = 90;
        int obstacleSpeed = -1;
        bool accelerateCones = false;
        bool isRunning = false;
        int carStyle = 1;
        bool reset = false;
        bool crashSituation = false;
        bool slalomDirection = false;  //False:left true:right
        PictureBox finish;

        //Cones
        int coneNumber = 7;
        int coneDistance = 400;
        int indexNextCone=0;
        List<PictureBox> listOfCones = new List<PictureBox>();

        //Splines
        Point[] left = { };
        Point[] right = { };

        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            carStandardImage = pbCar.Image;
        }
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
                if(!crashSituation)
                {
                    carSpeedMaxMerker = carSpeedMax;
                    carSpeedMax = -10;
                    carSpeed = -10;
                    tmrBoost.Enabled = true;
                }                
                return true;
            }

            return false;
        }
        private void placeObstacles()
        {
            Random rnd = new Random();
            for (int i = 0; i < coneNumber; i++)                
            {
                int x= rnd.Next(50, 530);
                var picture = new PictureBox
                {
                    Name = "pbCone" + i.ToString(),
                    Size = new Size(35, 35),
                    Location = new Point(x, 100 - i * coneDistance),
                    Image = INF_Seminararbeit.Properties.Resources.cone,
                    SizeMode = PictureBoxSizeMode.StretchImage,   
                };
                //left[i] = new Point(x, 00 - i * coneDistance);
                //right[i] = new Point(x+200, 00 - i * coneDistance);
                panelGame.Controls.Add(picture);
                listOfCones.Add(picture);

                finish = new PictureBox
                {
                    Name = "pbFinish",
                    Size = new Size(1353, 50),
                    Location = new Point(0,-2700),
                    Image = INF_Seminararbeit.Properties.Resources.finishLine,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                panelGame.Controls.Add(finish);
            }   
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
            pbStart.Top -= coneSpeed;
            finish.Top -= coneSpeed;
        }
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

        private void tmrGameTime_Tick(object sender, EventArgs e)
        {
            //Move
            MoveCar();
            moveObstacles();
            RotateCarPicture();
            //Crashdetection
            if(checkCrash()&&!crashSituation)
            {
                crashSituation = true;
                carSpeedMaxMerker = carSpeedMax;
                carSpeedMax = -1;
                carSpeed = -1;
                tmrHitObstacle.Enabled = true;
            }
            //Slalom
            slalomCheck();
            //Finish
            if (pbCar.Bounds.IntersectsWith(finish.Bounds))
            {
                Finish();
            }  
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
            if ((carMovementY + pbCar.Height + pbCar.Top) < panelGame.Height && (pbCar.Top + carMovementY) >200 )
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
        private void btnChangeCar_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                if (carStyle == 3)
                {
                    pbCar.Image = INF_Seminararbeit.Properties.Resources.car1;
                    pbCar.Refresh();
                    carSpeedMax = -8;
                    carAcceleration = 3;
                    obstacleSpeed = -1;
                    carStyle = 1;
                    reset = true;
                    btnChangeCar.Text = "Car Model: " + carStyle.ToString();
                }

                if (carStyle == 2)
                {
                    pbCar.Image = INF_Seminararbeit.Properties.Resources.car3;
                    pbCar.Refresh();
                    carSpeedMax = -5;
                    carAcceleration = 2;
                    obstacleSpeed = -3;
                    carStyle += 1;
                    btnChangeCar.Text = "Car Model: " + carStyle.ToString();
                }

                if (carStyle == 1 && reset == false)
                {
                    pbCar.Image = INF_Seminararbeit.Properties.Resources.car2; ;
                    pbCar.Refresh();
                    carSpeedMax = -3;
                    obstacleSpeed = -2;
                    carAcceleration = 1;
                    carStyle += 1;
                    btnChangeCar.Text = "Car Model: " + carStyle.ToString();
                }
                reset = false;
                carStandardImage = pbCar.Image;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(btnStart.Text == "Restart")
            {
                Application.Restart();
                Environment.Exit(0);
            }
            if (!isRunning)
            {
                tmrGameTime.Start();
                placeObstacles();
                startTime = DateTime.Now;
                tmrClock.Start();
                isRunning = true;
                btnStart.Text = "Stop";
            }
            else {
                tmrGameTime.Stop();
                tmrClock.Stop();
                btnStart.Text = "Start";
                isRunning = false;
            }
        }
        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblTime.Text = (DateTime.Now - startTime).ToString();
        }

        private void Finish()
        {
            tmrClock.Stop();
            lblTimeHeading.Text = "Finished in:";
            lblTimeHeading.ForeColor = Color.Green;
            lblTime.ForeColor = Color.Green;
            btnStart.Text = "Restart";

            carSpeed = 0;
            carSpeedMax = 0;
            obstacleSpeed = 0;
        }
        private void tmrHitObstacle_Tick(object sender, EventArgs e)
        {
            crashSituation = false;
            carSpeedMax = carSpeedMaxMerker;
            carSpeedMaxMerker = 0;
            tmrHitObstacle.Enabled = false;
        }
        private void slalomCheck()
        {
            
            if(getNearestCone()==indexNextCone && distanceNearestCone(getNearestCone())<10)
            {
                int coneleft = listOfCones[getNearestCone()].Left;
                int coneright = listOfCones[getNearestCone()].Left+ listOfCones[getNearestCone()].Width;
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
            int index=0;
            int mindistance = Math.Abs(listOfCones[0].Top - pbCar.Top);
            for (int i = 0; i < coneNumber; i++)
            {
                if(mindistance > Math.Abs(listOfCones[i].Top - pbCar.Top))
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

        private void tmrBoost_Tick(object sender, EventArgs e)
        {
            carSpeedMax = carSpeedMaxMerker;
            carSpeedMaxMerker = 0;
            carSpeed = carSpeedMax;
            tmrBoost.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
  /*          // Create the message dialog and set its content
            var messageDialog = new MessageDialog("No internet connection has been found.");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand(
                "Try again",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand(
                "Close",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();*/
        }
    } 
}
