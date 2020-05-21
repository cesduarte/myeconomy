using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class ClasseGenericaInformation
    {
        public DateTime DataInicialPesquisa { get; set; }
        public DateTime DataFinalPesquisa { get; set; }

        public int IdClassificacao { get; set; }

        public int IdContasBancarias { get; set; }

        public string StatusOcorrencia { get; set; }
    }
}