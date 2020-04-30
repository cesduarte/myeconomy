using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class Validador
    {

        //Valida quando o saldo não for preenchido
        public Boolean ValidarSaldo(string Saldo)
        {
            bool ret = false;
            if (Saldo == "")
            {
                ret = true;

            }
            return ret;
        }

    }
}