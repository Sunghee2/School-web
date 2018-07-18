using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher(){ Name = "세종대왕", Class = "한글" },
                new Teacher(){ Name = "이순신", Class = "해상전략" },
                new Teacher(){ Name = "제갈량", Class = "지략" },
                new Teacher(){ Name = "을지문덕", Class = "지상전략" }
            };

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            return View(viewModel);
        }

        // GET: /<controller>/
        public IActionResult Student()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher(){ Name = "세종대왕", Class = "한글" },
                new Teacher(){ Name = "이순신", Class = "해상전략" },
                new Teacher(){ Name = "제갈량", Class = "지략" },
                new Teacher(){ Name = "을지문덕", Class = "지상전략" }
            };

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Student(StudentTeacherViewModel model)
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
