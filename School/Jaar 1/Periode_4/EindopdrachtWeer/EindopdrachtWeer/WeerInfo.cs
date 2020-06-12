using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtWeer
{
    class WeerInfo
    {
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }
        public class weather
        {
            public string icon { get; set; }
            public string description { get; set; }
        }
        public class main
        {
            public double temp { get; set; }
            public string humidity { get; set; }

        }
        public class wind
        {
            public double speed { get; set; }
            public double deg { get; set; }

        }
        public class sys
        {
            public string country { get; set; }
        }
        public class Root
        {
            public string name { get; set; }
            public sys sys { get; set; }
            public wind wind { get; set; }
            public main main { get; set; }
            public List<weather> weather { get; set; }

        }
    }
}
