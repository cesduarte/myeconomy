using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class TarefasInformation:ClasseGenericaInformation
    {
        public int IdTarefa { get; set; }
        public int IdUsuario { get; set; }
        public string DescricaoTarefa{ get; set; }

        public string ObsTarefa { get; set; }

        public DateTime DataTarefa { get; set; }

        public DateTime DataTarefaRealizada { get; set; }

        

        public string StatusTarefa { get; set; }
    }
}