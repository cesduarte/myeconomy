using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class DespesasVariadasInformation: ContasBancariasInformation
    {
        public int IdDespesaVariada { get; set; }

        public int IdClassificacao { get; set; }
        
        public string DescricaoDespesaVariada { get; set; }
        public decimal ValorDespesaVariada { get; set; }
        public DateTime DataDespesaVariada { get; set; }
       
    }
}