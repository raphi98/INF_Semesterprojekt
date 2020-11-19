using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF_Seminararbeit
{
    public partial class Dialog2 : Form
    {
        public Dialog2(ref List<Highscore> highscore)
        {
            InitializeComponent();
            dgvHighscore.DataSource = highscore;
        }     
        
    }
}
