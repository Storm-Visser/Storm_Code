using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesSnelheidTesten.EntityFramework.Model
{
    class KijkwijzerIndicatie
    {
        public int kijkwijzerIndicatieID { get; set; }

        [MaxLength(255)]
        public string omschrijving { get; set; }
    }
}
