using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using AppBancoADO;
using AppBancoDominio;
using System.Linq;

namespace AppBancoDLL
{
    public class UsuarioDAO
    {
        private Banco db;

        public void Insert(Usuario usuario)
        {
            var StrQuery = "INSERT INTO TBUsuario (NomeUsu, Cargo, Data)";
            StrQuery += string.Format(" VALUES ('{0}','{1}',CONVERT(DATETIME,'{2}',103));", usuario.NomeUsu, usuario.Cargo, usuario.Data);

            using (db = new Banco())
            {
                db.ExecutaComando(StrQuery);
            }
        }

        public void Atualizar(Usuario usuario)
        {
            var StrQuery = string.Format("UPDATE tbUsuario SET NomeUsu = '{0}', Cargo = '{1}', Data = CONVERT(DATETIME,'{2}',103) WHERE IdUsu = {3};", usuario.NomeUsu, usuario.Cargo, usuario.Data, usuario.IdUsu);

            using (db = new Banco())
            {
                db.ExecutaComando(StrQuery);
            }
        }

        public void Excluir(int? id)
        {
            var StrQuery = string.Format("DELETE FROM tbUSUARIO WHERE IdUsu = {0};", id);

            using (db = new Banco())
            {
                db.ExecutaComando(StrQuery);
            }
        }

        public void Salvar(Usuario usuario)
        {
            if (usuario.IdUsu > 0)
            {
                new UsuarioDAO().Atualizar(usuario);
            }
            else
            {
                new UsuarioDAO().Insert(usuario);
            }
        }

        public List<Usuario> Listar()
        {
            using (db = new Banco())
            {
                var retorno = db.RetornaComando("SELECT * FROM tbUsuario;");
                return ListaDeUsuario(retorno);
            }
        }

        public Usuario Listar1(int? id)
        {
            var usuario = new Usuario();
            using (db = new Banco())
            {
                var retorno = db.RetornaComando("SELECT * FROM tbUsuario WHERE IdUsu = " + id);
                return ListaDeUsuario(retorno).FirstOrDefault();
            }
        }

        private List<Usuario> ListaDeUsuario(SqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();
            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    IdUsu = int.Parse(retorno["IdUsu"].ToString()),
                    NomeUsu = retorno["NomeUsu"].ToString(),
                    Cargo = retorno["Cargo"].ToString(),
                    Data = DateTime.Parse(retorno["Data"].ToString())
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }

        public bool VerificarRegistro(Usuario usuario)
        {
            var StrQuery = string.Format("SELECT COUNT(*) FROM tbUsuario WHERE IdUsu = {0};", usuario.IdUsu);

            using (db = new Banco())
            {
                if (db.ExecScalar(StrQuery) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}