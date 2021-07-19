using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasesSnelheidTesten.EntityFramework.Model
{
    class FilmGeschiedenis
    {
        public int filmGeschiedenisID { get; set; }

        public DateTime tijd { get; set; }

        public DateTime kijkDatum { get; set; }
    }
}
