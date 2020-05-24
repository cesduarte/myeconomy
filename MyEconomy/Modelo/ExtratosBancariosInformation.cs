using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class ExtratosBancariosInformation:ClasseGenericaInformation
    {
        public int IdExtratoBancarios { get; set; }
        public int IdOcorrencia { get; set; }
        public string DescricaoExtratoBancario { get; set; }
        public decimal ValorOcorrencia { get; set; }
        public DateTime DataOcorrencia { get; set; }


    }
}