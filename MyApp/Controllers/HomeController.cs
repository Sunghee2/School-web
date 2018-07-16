using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Student()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Student(Student model)
        {
            // model에 있는 유효성 검사 확인
            if(ModelState.IsValid)
            {
                // model 데이터를 Student table에 저장
            } 
            else
            {
                // error
            }
            return View();
        }
    }
}
