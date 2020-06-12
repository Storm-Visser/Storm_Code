using System.Collections.Generic;

namespace EindopdrachtWeer
{
    
    class Forecast
    {
        public List<list> list { get; set; }
    }
    public class list
    {
        public main main { get; set; }
    }
    public class main
    {
        public double temp { get; set; }
    }
}
