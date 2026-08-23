using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Domain
{
    public class Product
    {
        public int ProductId { get; set; }

        public  string? Name { get; set; }

        public  string? Description { get; set; }

        public decimal Price { get; set; }

        public  string? Category { get; set; }

        public string? ImgUrl { get; set; }

        public string? Color { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
