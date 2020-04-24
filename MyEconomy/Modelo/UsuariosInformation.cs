using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class UsuariosInformation
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public bool TrocarSenha { get; set; }
        public bool Isdelete { get; set; }

        
    }
}