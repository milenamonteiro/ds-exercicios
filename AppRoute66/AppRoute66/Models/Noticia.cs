using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AppRoute66.Models
{
    public class Noticia
    {
        public int NoticiaId { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }

        public IEnumerable<Noticia> TodasAsNoticias()
        {
            var retorno = new Collection<Noticia>
            {
                new Noticia
                {
                    NoticiaId =1,
                    Categoria="Esportes",
                    Titulo="O time da escola ganha dos catados!",
                    Conteudo="O time da escola vence de 10 a 0 de time montado de alunos sem time",
                    Data=new DateTime(22/03/2019)
                },
                new Noticia
                {
                    NoticiaId =2,
                    Categoria="Esportes",
                    Titulo="Catados pede desforra do time da escola",
                    Conteudo="O time da escola venceu de 10 a 0, ferindo o orgulho dos catados que querem desforra!",
                    Data=new DateTime(28/03/2019)
                },
                new Noticia
                {
                    NoticiaId =3,
                    Categoria="Escola",
                    Titulo="É votada no congresso, lei que permite o uso de aparelhos pirotécnicos na sala de aula!",
                    Conteudo="O congresso anuncia que aparelhos pirotécnicos como lança chamas e desodorantes com esqueiros, poderão ser usados em salas de aula",
                    Data=new DateTime(15/04/2019)
                },
                new Noticia
                {
                    NoticiaId =4,
                    Categoria="Escola",
                    Titulo="Aniversário da Milena",
                    Conteudo="Parabéns Milena, te amo",
                    Data=new DateTime(09/05/2019)
                }
            };
            return retorno;
        }
    }
}
/*
||||||  ||  ||  ||||||  ||||||
||      ||  ||  ||      ||  ||
||||||  ||  ||  ||      ||  ||
    ||  ||  ||  ||      ||  ||
||||||  ||||||  ||||||  ||||||
*/