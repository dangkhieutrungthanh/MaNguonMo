using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [Display(Name = "ID")]
        public string PersonId { get; set; }
        [Display(Name = "Họ tên")]
        public string PersonName { get; set; }


    }
}