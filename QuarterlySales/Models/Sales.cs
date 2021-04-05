using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public class Sales
    {
        public int SalesId { get; set; }

        [Required(ErrorMessage = "Please enter the quarter number")]
        [Range(1,4, ErrorMessage = "Quarter number must be between 1 and 4")]
        public int? Quarter { get; set; }

        [Required(ErrorMessage = "Please enter the year")]
        //[GreaterThan(2000, ErrorMessage = "Year may not be before 2000")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter the amount")]
        //[GreaterThan(0.0, ErrorMessage = "Amount must be greater than 0")]
        public double? Amount { get; set; }

        //[GreaterThan(0, ErrorMessage = "Please select an employee")]
        [Remote("CheckSales", "Validation", AdditionalFields = "Quarter, Year")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

    }
}
