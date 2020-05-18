using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy.Modelo
{
    public class EntradaSaidaInformation
    {
        public int IdEntradaSaida { get; set; }
        public string DescricaoEntradaSaida { get; set; }
        public int IdContasBancarias { get; set; }
        public int Idclassificacao { get; set; }
        public decimal ValorEntradaSaida { get; set; }

        public DateTime DataEntradaSaida { get; set; }
        public string StatusEntradaSaida { get; set; }

    }
}