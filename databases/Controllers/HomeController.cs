using databases.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;

namespace databases.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DetailsContext _taskContext;
        public HomeController(ILogger<HomeController> logger, DetailsContext taskContext)
        {
            _logger = logger;
            this._taskContext = taskContext;
        }
     
   
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Mod(StudentDetails user)
        {
            StudentDetails studentDetails = new StudentDetails();
           
            studentDetails.Address = user.Address;
            studentDetails.FirstName = user.FirstName;
            studentDetails.LastName = user.LastName;
            studentDetails.EmailId = user.EmailId;
            studentDetails.StudentId = user.StudentId;
            _taskContext.Add(studentDetails);
            _taskContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}