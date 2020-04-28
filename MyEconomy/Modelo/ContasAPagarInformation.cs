﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy.Modelo
{
    public class ContasAPagarInformation: ContasInformation
    {

        public int IdContasAPagar { get; set; }
        public DateTime DataVencimentoContasAPagar { get; set; }

        public int NParcelaContasAPagar { get; set; }

    }
}