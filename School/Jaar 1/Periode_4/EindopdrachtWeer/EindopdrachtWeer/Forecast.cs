using EO.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtWeer
{
    
    class Forecast
    {
        public List<list> list { get; set; }

    }
    public class main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }
    public class list
    {
        public double dt { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public double speed { get; set; }
        public main main { get; set; }
    }
}
