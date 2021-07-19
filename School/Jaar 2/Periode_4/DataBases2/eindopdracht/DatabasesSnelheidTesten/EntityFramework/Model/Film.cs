using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesSnelheidTesten.EntityFramework.Model
{
    class Film
    {
        public int filmID { get; set; }

        public Genre genre { get; set; }

        [MaxLength(100)]
        public string naam { get; set; }

        [MaxLength(255)]
        public string filmLocatie { get; set; }

        [MaxLength(255)]
        public string omschrijving { get; set; }

        public TimeSpan tijdsduur { get; set; }

        [MaxLength(20)]
        public string resolutie { get; set; }
    }
}
