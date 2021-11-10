using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Display(Name = "ID nhân viên")]
        public String EmployeeId { get; set; }
        [Display(Name = "Tên nhân viên")]
        public string EmployeeName { get; set; }
        [Display(Name = "Số điện thoại")]
        public int EmployeePhoneNumber { get; set; }

    }
}