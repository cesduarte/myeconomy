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

        public enum TipoClassificacao
        {
            [Description("--")] //Descrição será exibido como item do dropdown
            inicial = 0,// item do enumerator atribuido o seu valor constante.
            [Description("Investimento")] //Descrição será exibido como item do dropdown
            Investimento = 1,// item do enumerator atribuido o seu valor constante.
            [Description("Padrão")]
            Padrão = 2
        }

        public enum TipoEntradaSaida
        {
            [Description("--")] //Descrição será exibido como item do dropdown
            inicial = 0,// item do enumerator atribuido o seu valor constante.
            [Description("Entrada")] //Descrição será exibido como item do dropdown
            Entrada = 1,// item do enumerator atribuido o seu valor constante.
            [Description("Saída")]
            Saida = 2
        }

    }
}