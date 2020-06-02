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
            [Description("Despesa fixa a pagar")] //Descrição será exibido como item do dropdown
            ContasAPagar = 1,// item do enumerator atribuido o seu valor constante.
            [Description("Despesa fixa paga")]
            ContasPagas = 2
        }

        public enum TipoClassificacao
        {
            [Description("--")] //Descrição será exibido como item do dropdown
            inicial = 0,// item do enumerator atribuido o seu valor constante.
            [Description("Despesas")]
            Despesas = 2,
            [Description("Investimento")] //Descrição será exibido como item do dropdown
            Investimento = 1,// item do enumerator atribuido o seu valor constante.
            
            [Description("Receitas")]
            Receitas = 3



        }
        public enum TipoOcorrencias
        {
            [Description("--")] //Descrição será exibido como item do dropdown
            inicial = 0,// item do enumerator atribuido o seu valor constante.
            
            [Description("Despesa fixa paga")]
            DespesasFixas = 1,
            [Description("Despesas variadas")]
            DespesasVariadas = 2,
            [Description("Receitas")]
            Receitas = 3,
            [Description("Investimento crédito")]
            Investimentocredito = 4,
            [Description("Investimento débito")]
            Investimentodebito = 5,



        }

        public enum OrganizarPorRelatorios
        {
           

            [Description("Contas bancárias")]
            ContasBancarias = 1,
            [Description("Classificação")]
            Classificacao = 2,
     



        }




    }
}