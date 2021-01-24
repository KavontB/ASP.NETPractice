using System;
using Microsoft.AspNetCore.Mvc;


namespace NathansCRUDWebsite.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
