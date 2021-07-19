using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabasesSnelheidTesten.EntityFramework.Model
{
    public class Abonnement
    {
        public int abonnementID { get; set; }
        [MaxLength(50)]
        public string naam { get; set; }
        public float bedrag { get; set; }
    }
}
