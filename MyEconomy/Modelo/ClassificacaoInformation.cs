using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class ClassificacaoInformation
    {
        public int IdClassificacao { get; set; }
        public string DescricaoClassificacao { get; set; }
        public string TipoClassificacao { get; set; }
        public bool Isdelete { get; set; }
    }
}