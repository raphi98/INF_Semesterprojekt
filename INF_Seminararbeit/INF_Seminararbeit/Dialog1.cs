using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF_Seminararbeit
{
    public partial class Dialog1 : Form
    {
        Highscore newScore;
        List<Highscore> highscoreLocal = new List<Highscore>();
        TimeSpan timeLokal;
        string fmtMS = "000";
        string fmtS = "00";
        string fmtM = "00";


        public Dialog1(ref List<Highscore> highscore, int cones, String car, TimeSpan time)
        {
            InitializeComponent();
            timeLokal = time;
            highscoreLocal = highscore;
            dgvHighscore.DataSource = highscoreLocal;
            lblCar.Text = car;
            lblConeNumber.Text = cones.ToString();
            lblTime.Text = time.Minutes.ToString(fmtM) + " : " + time.Seconds.ToString(fmtS) + " : " + time.Milliseconds.ToString(fmtMS);


        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            newScore = new Highscore()
            {
                Rank = 1,
                Time = timeLokal,
                Car = lblCar.Text,
                ConeNumber = Convert.ToInt32(lblConeNumber.Text),
                Name = tbName.Text,
            };
            highscoreLocal.Add(newScore);
            sortTable(ref highscoreLocal);
            dgvHighscore.DataSource = null;
            dgvHighscore.Update();
            dgvHighscore.Refresh();
            dgvHighscore.DataSource = highscoreLocal;
            btnEnterScore.Enabled = false;

        }
        private void sortTable(ref List<Highscore> highscore)
        {
            highscore.OrderBy(o => o.Time);
            for(int i=0; i<highscore.Count;i++)
            {
                highscore[i].Rank = i + 1;
            }
        }
    }
}
