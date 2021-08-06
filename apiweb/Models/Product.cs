using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiweb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public DateTime DtmCadastro { get => dtmCadastro; set => dtmCadastro = value; }
        private DateTime dtmCadastro = DateTime.Now;

        private bool bAtivo = true;

        public bool BAtivo { get => bAtivo; set => bAtivo = value; }


        [Required(ErrorMessage = "O nome do produto deve ser preenchido")]
        public string SNome { get; set; }

        [Required(ErrorMessage = "Informe uma descrição para o produto")]
        public string SDescricao { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage ="O preço deve ser maior do que zero")]
        public decimal DValor { get; set; }

        public string SPathFoto { get; set; }
    }
}
