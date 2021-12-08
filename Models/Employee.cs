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
        [StringLength(60, MinimumLength = 2)]
        [Display(Name = "Tên nhân viên")]
        public string EmployeeName { get; set; }
        [Display(Name = "Số điện thoại"), DataType(DataType.PhoneNumber)]
        public int EmployeePhoneNumber { get; set; }
        [Display(Name = "Địa chỉ")]
        public string EmployeeAddress { get; set; }

    }
}