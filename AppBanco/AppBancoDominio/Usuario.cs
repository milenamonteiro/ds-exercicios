using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AppBancoDominio
{
    public class Usuario
    {
        [DisplayName("Código")]
        public int IdUsu { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Digite o nome!")]
        public string NomeUsu { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "Digite o cargo!")]
        public string Cargo { get; set; }
        
        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "Digite a data de cadastro!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
    }
}
