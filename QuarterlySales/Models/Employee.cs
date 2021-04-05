using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public class Employee
    {

        public int EmployeeId { get; set; }

        [Required(ErrorMessage="Please enter a first name")]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter a date of birth")]
        //[PastDate(ErrorMessage = "Birth date must be in past tense")]
        [Remote("CheckEmployee", "Validation", AdditionalFields = "Firstname, Lastname")]
        [Display(Name = "Date Of Birth")]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Please enter a date of hire")]
        //[PastDate(ErrorMessage = "Date of hire must be after 1/1/1995")]
        //[GreaterThan("1/1/1995", ErrorMessage = "Date of hire must be after 1/1/1995")]
        [Display(Name = "Date Of Hire")]
        public DateTime? DateOfHire { get; set; }

        //[GreaterThan(0), ErrorMessage = "Please select a manager"]
        [Remote("CheckManager", "Validation", AdditionalFields = "Firstname, Lastname, DOB")]
        [Display(Name = "Manager")]
        public int ManagerId { get; set; }

        public string Fullname => $"{Firstname} {Lastname}";
    }
}
