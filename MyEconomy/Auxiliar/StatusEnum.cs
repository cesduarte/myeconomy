﻿using System;
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
            [Description("Saldo inicial")]
            SaldoInicial = 6,
            [Description("Despesas Fixas")]
            DespesasFixas = 1,
            [Description("Despesas Variadas")]
            DespesasVariadas = 2,
            [Description("Receitas")]
            Receitas = 3,
            [Description("Investimento crédito")]
            InvestimentoCredito = 4,
            [Description("Investimento débito")]
            InvestimentoDebito = 5,


        }


    }
}