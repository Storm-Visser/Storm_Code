using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesSnelheidTesten.EntityFramework.Model
{
    class Gebruiker
    {
        public int gebruikerID { get; set; }

        [MaxLength(100)]
        public string email { get; set; }

        [MaxLength(255)]
        public string wachtwoord { get; set; }

        public bool isGeactiveerd { get; set; }

        public int aantalInlogPogingen { get; set; }

        public DateTime aanmaakdatum { get; set; }

        public bool krijgtKorting { get; set; }

        public bool isUitgenodigd { get; set; }
    }
}