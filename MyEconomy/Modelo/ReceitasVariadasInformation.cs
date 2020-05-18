using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class ReceitasVariadasInformation: ContasBancariasInformation
    {
        public int IdReceitaVariada { get; set; }

        public int IdClassificacao { get; set; }

        public string DescricaoReceitaVariada { get; set; }
        public DateTime DataReceitaVariada { get; set; }
    }
}