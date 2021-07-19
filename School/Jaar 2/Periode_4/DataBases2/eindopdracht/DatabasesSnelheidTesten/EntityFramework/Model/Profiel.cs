using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesSnelheidTesten.EntityFramework.Model
{
    class Profiel
    {
        public int profielID { get; set; }

        [MaxLength(50)]
        public string naam { get; set; }

        [MaxLength(255)]
        public string fotolocatie { get; set; }

        public DateTime geboorteDatum { get; set; }

        [MaxLength(50)]
        public string taal { get; set; }
    }
}
