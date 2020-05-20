using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class ReceitasVariadasInformation: ClasseGenericaInformation
    {
        public int IdReceitaVariada { get; set; }

       
        public string DescricaoReceitaVariada { get; set; }

        public decimal ValorReceita { get; set; }
        public DateTime DataReceitaVariada { get; set; }
    }
}