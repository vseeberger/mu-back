using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiweb.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public DateTime DtmCadastro { get => dtmCadastro; set => dtmCadastro = value; }
        private DateTime dtmCadastro = DateTime.Now;

        private bool bAtivo = true;
        [Required(ErrorMessage ="O nome deve ser preenchido")]
        [MinLength(5, ErrorMessage = "Este campo deve ter no mínimo 5 caracteres")]
        public string SNome { get; set; }

        [Required(ErrorMessage = "O E-mail deve ser preenchido")]
        public string SEmail { get; set; }

        [Required(ErrorMessage = "Você deve informar a aldeia")]
        public string SAldeia { get; set; }
        public bool BAtivo { get => bAtivo; set => bAtivo = value; }
    }
}
