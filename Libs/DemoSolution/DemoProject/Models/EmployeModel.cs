using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Northwind.Mapping;

namespace DemoProject.Models
{

    [DisplayName("Nhân Viên")]
    public partial class EmployeModel
    {
        public int EmployeeID { get; set; }

        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Title { get; set; }

        public string TitleOfCourtesy { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string HomePhone { get; set; }

        public string Extension { get; set; }

        public byte[] Photo { get; set; }

        public string Notes { get; set; }

        public int? ReportsTo { get; set; }

        public string PhotoPath { get; set; }


        public static explicit operator EmployeModel(Employees employees)
        {
            return new EmployeModel()
            {
                Address = employees.Address,
                BirthDate = employees.BirthDate,
                City = employees.City,
                Country = employees.Country,
                EmployeeID = employees.EmployeeID,
                Extension = employees.Extension,
                FirstName = employees.FirstName,
                HireDate = employees.HireDate,
                HomePhone = employees.HomePhone,
                LastName = employees.LastName,
                Notes = employees.Notes,
                Photo = employees.Photo,
                PhotoPath = employees.PhotoPath,
                PostalCode = employees.PostalCode,
                Region = employees.Region,
                ReportsTo = employees.ReportsTo,
                Title = employees.Title,
                TitleOfCourtesy = employees.TitleOfCourtesy
            };
        }

        public static explicit operator Employees(EmployeModel employees)
        {
            return new Employees()
            {
                Address = employees.Address,
                BirthDate = employees.BirthDate,
                City = employees.City,
                Country = employees.Country,
                EmployeeID = employees.EmployeeID,
                Extension = employees.Extension,
                FirstName = employees.FirstName,
                HireDate = employees.HireDate,
                HomePhone = employees.HomePhone,
                LastName = employees.LastName,
                Notes = employees.Notes,
                Photo = employees.Photo,
                PhotoPath = employees.PhotoPath,
                PostalCode = employees.PostalCode,
                Region = employees.Region,
                ReportsTo = employees.ReportsTo,
                Title = employees.Title,
                TitleOfCourtesy = employees.TitleOfCourtesy
            };
        }
    }
}
