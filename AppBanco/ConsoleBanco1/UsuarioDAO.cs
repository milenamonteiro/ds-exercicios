using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBanco1
{
    class UsuarioDAO
    {
        private Banco db;

        public void Insert(string vNome, string vCargo, string vData)
        {
            var StrQuery = "INSERT INTO TBUsuario (NomeUsu, Cargo, Data)";
            StrQuery += string.Format(" VALUES ('{0}','{1}',CONVERT(DATETIME,'{2}',103));", vNome, vCargo, vData);

            using (db = new Banco())
            {
                db.ExecutaComando(StrQuery);
            }
        }
    }
}
