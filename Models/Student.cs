using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [Display(Name = "ID")]
        public string StudentId { get; set; }
        [Display(Name = "Tên sinh viên")]
        public string StudentName { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }



    }
}