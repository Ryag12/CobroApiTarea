using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CobroApiP2.Models
{
    public class Cobros
    {
        [Key]
        public int IdCobro { get; set; }

        public DateTime Fecha { get; set; }

        public string Referencia { get; set; }

        public int IdRemoto { get; set; }

        public int IdRuta { get; set; }

        public decimal Mora { get; set; }

        public decimal Monto { get; set; }

        public decimal Latitud { get; set; }

        public decimal Longitud { get; set; }

        public bool EsNulo { get; set; }
    }
}
