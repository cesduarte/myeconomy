using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy.Modelo
{
    public class ContasBancariasInformation
    {
        public int IdContasBancarias { get; set; }
        public string DescricaoContasBancarias { get; set; }
        public decimal SaldoContasBancarias { get; set; }
        public bool Isdelete { get; set; }

    }
}