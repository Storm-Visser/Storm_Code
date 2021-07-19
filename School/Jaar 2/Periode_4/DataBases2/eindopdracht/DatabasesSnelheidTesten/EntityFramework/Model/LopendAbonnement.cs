using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesSnelheidTesten.EntityFramework.Model
{
    class LopendAbonnement
    {
        public int lopendAbonnementID { get; set; }

        public DateTime aankoopdatum { get; set; }
    }
}
