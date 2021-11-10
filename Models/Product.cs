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
        public double UnitPrice { get; set; }
        [Display(Name = "số lượng")]
        public int Quantity { get; set; }


    }
}