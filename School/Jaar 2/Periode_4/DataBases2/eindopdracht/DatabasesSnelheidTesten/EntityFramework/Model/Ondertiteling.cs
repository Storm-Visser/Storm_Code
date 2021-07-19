using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesSnelheidTesten.EntityFramework.Model
{
    class Ondertiteling
    {
        public int ondertitelingID { get; set; }

        [MaxLength(50)]
        public string taal { get; set; }

        [MaxLength(255)]
        public string ondertitelingLocatie { get; set; }
    }
}
