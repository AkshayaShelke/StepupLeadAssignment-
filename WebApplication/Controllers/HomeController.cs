using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.IO;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            this.configuration = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(HomeModel homeModel)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[User](FirstName, LastName, Email, ComapnyName, CompanySize,JobRole,JobDepartment,Phone,Country)" + " VALUES (@FirstName, @LastName, @Email, @CompanyName, @CompanySize,@JobRole,@JobDepartment,@Phone,@Country)", connection);
                command.Parameters.AddWithValue("@FirstName", homeModel.FirstName);
                command.Parameters.AddWithValue("@LastName", homeModel.LastName);
                command.Parameters.AddWithValue("@Email", homeModel.Email);
                command.Parameters.AddWithValue("@CompanyName", homeModel.CompanyName);
                command.Parameters.AddWithValue("@CompanySize", homeModel.CompanySize);
                command.Parameters.AddWithValue("@JobRole", homeModel.JobRole);
                command.Parameters.AddWithValue("@JobDepartment", homeModel.JobDepartment);
                command.Parameters.AddWithValue("@Phone", Convert.ToDecimal(homeModel.Phone));
                command.Parameters.AddWithValue("@Country", homeModel.Country);
                command.ExecuteNonQuery();
                TempData["UserDetails"] = homeModel;

                connection.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index","Thanks");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
