using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet.Models
{
    [Table("NhanVien")]
    public class NhanVien : Person
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MyProperty { get; set; }
    }
}