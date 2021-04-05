using Microsoft.EntityFrameworkCore;
using System;

namespace QuarterlySales.Models
{
    public class SalesContext : DbContext
    {

        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options) { }

        public DbSet<Sales> Sales { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    Firstname = "Bruce",
                    Lastname = "Wayne",
                    DOB = new DateTime(1985, 12, 10),
                    DateOfHire = new DateTime(1995, 1, 1),
                    ManagerId = 0 // has no manager
                },
                new Employee
                {
                    EmployeeId = 2,
                    Firstname = "Peter",
                    Lastname = "Parker",
                    DOB = new DateTime(1990, 12, 10),
                    DateOfHire = new DateTime(1995, 1, 1),
                    ManagerId = 1 // Bruce Wayne Manager
                },
                new Employee
                {
                    EmployeeId = 3,
                    Firstname = "Diana",
                    Lastname = "Prince",
                    DOB = new DateTime(1950, 12, 10),
                    DateOfHire = new DateTime(1995, 1, 1),
                    ManagerId = 1 // Bruce Wayne Manager
                }
             );

            modelBuilder.Entity<Sales>().HasData(
                new Sales
                {
                    SalesId = 1,
                    Quarter = 4,
                    Year = 2020,
                    Amount = 50000,
                    EmployeeId = 2
                },
                new Sales
                {
                    SalesId = 2,
                    Quarter = 1,
                    Year = 2020,
                    Amount = 50000,
                    EmployeeId = 3
                },
                new Sales
                {
                    SalesId = 3,
                    Quarter = 2,
                    Year = 2020,
                    Amount = 50000,
                    EmployeeId = 3
                },
                new Sales
                {
                    SalesId = 4,
                    Quarter = 3,
                    Year = 2019,
                    Amount = 50000,
                    EmployeeId = 2
                }
             );
        }
    }
}
