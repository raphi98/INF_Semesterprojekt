using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF_Seminararbeit
{
    public class Highscore
    {
        public int Rank { get; set; }
        public TimeSpan Time { get; set; }
        public string Car { get; set; }
        public int ConeNumber { get; set; }
        public string Name { get; set; }
       
    }
}
