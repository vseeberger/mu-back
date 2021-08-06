using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiweb.Models
{
    public class OrderItems
    {
        [Required(ErrorMessage = "Informe a sequencia do item")]
        public int Item { get; set; }

        //[Required(ErrorMessage = "O produto deve ser vinculado ao pedido")]
        //public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal ProductValorUn { get; set; }

        public decimal ProductQuantity { get; set; }
    }
}
