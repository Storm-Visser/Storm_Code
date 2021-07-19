using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabasesSnelheidTesten.EntityFramework.Model
{
    public class Aflevering
    {
        public int afleveringID { get; set; }
        public int nummer { get; set; }

        [MaxLength(100)]
        public string naam { get; set; }

        [MaxLength(255)]
        public string afleveringLocatie { get; set; }

        [MaxLength(255)]
        public string omschrijving { get; set; }

        public DateTime tijdsduur { get; set; }

        [MaxLength(20)]
        public string resolutie { get; set; }
    }
}
