using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        public int Id { get; set; }
        public int KhachHangId { get; set; }
        public int PersonId { get; set; }

        public KhachHang khachHangs { get; set; }

        public Person people { get; set; }
    }
}