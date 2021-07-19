using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabasesSnelheidTesten.EntityFramework.Model
{
    public class Seizoen
    {
        public int seizoenID { get; set; }
        public int nummer { get; set; }

        [MaxLength(100)]
        public string naam { get; set; }
        [MaxLength(255)]
        public string omschrijving { get; set; }
    }
}