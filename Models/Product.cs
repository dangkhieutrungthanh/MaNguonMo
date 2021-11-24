using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Display(Name = "ID sản phẩm")]
        public string ProductId { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Giá sản phẩm")]
        [Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }

    }
}