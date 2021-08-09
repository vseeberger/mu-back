using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoEFMysql.Models
{
    public class ShortURL
    {
        [Key]
        public long id { get; set; }
        public string url { get; set; }
        public string shortUrl { get; set; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        private DateTime created_at = DateTime.Now;

    }
}
