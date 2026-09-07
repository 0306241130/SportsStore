using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SportsStore.Domain
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public  string? Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public  string? Description { get; set; }

        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage = "Vui lòng nhập giá trị dương")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập danh mục")]
        public  string? Category { get; set; }

        public string? ImgUrl { get; set; }

        public string? Color { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
