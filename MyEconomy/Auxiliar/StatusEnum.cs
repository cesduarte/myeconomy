using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class StatusEnum
    {
        public enum Status
        {
            [Description("Conta a pagar")] //Descrição será exibido como item do dropdown
            ContasAPagar = 1,// item do enumerator atribuido o seu valor constante.
            [Description("Conta paga")]
            ContasPagas = 2
        }
    }
}