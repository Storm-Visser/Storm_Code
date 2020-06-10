using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtWeer
{
    class WindCalc
    {
        public static string GetWindDirection(double deg)
        {
            string dir;
            if (deg >= 0 && deg < 22.5)
            {
                dir = "N";
            }
            else if (deg >= 22.5 && deg < 67.5)
            {
                dir = "NE";
            }
            else if (deg >= 67.5 && deg < 112.5)
            {
                dir = "E";
            }
            else if (deg >= 112.5 && deg < 157.5)
            {
                dir = "SE";
            }
            else if (deg >= 157.5 && deg < 202.5)
            {
                dir = "S";
            }
            else if (deg >= 202.5 && deg < 247.5)
            {
                dir = "SW";
            }
            else if (deg >= 247.5 && deg < 292.5)
            {
                dir = "W";
            }
            else if (deg >= 292.5 && deg < 337.5)
            {
                dir = "NW";
            }
            else if (deg >= 337.5 && deg < 360)
            {
                dir = "N";
            }
            else
            {
                dir = "Unknown";
            }
            return dir;
        }
    }
}









