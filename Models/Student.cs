using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet.Models
{
    [Table("Student")]
    public class Student : Person
    {
        public string Universisty { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }




    }
}