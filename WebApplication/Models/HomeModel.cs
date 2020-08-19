using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class HomeModel
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string CompanySize { get; set; }
        public string JobRole { get; set; }
        public string JobDepartment { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string IpAddress { get; set; }
        public string BrowerName { get; set; }
        public string OsName { get; set; }
        public string SaveUrl { get; set; }
    }
}
