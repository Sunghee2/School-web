﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Data.Repositories;
using MyApp.Models;
using MyApp.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        private ITeacherRepository _teacherRepository;
        private IStudentRepository _studentRepository;

        public HomeController(ITeacherRepository teacherRepository, IStudentRepository studentRepository)
        {
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var teachers = _teacherRepository.GetAllTeachers();

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            return View(viewModel);
        }

        // GET: /<controller>/
        [Authorize(Roles = "Admin")]
        public IActionResult Student()
        {
            var students = _studentRepository.GetAllStudents();

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Students = students
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Student(StudentTeacherViewModel model)
        {
            // model에 있는 유효성 검사 확인
            if(ModelState.IsValid)
            {
                // model 데이터를 Student table에 저장
                _studentRepository.AddStudent(model.Student);
                _studentRepository.Save();
                // input value 삭제
                ModelState.Clear();
            } 
            else
            {
                // error
            }
            var students = _studentRepository.GetAllStudents();

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Students = students
            };


            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            var result = _studentRepository.GetStudent(id);

            return View(result);
        }

        public IActionResult Edit(int id)
        {
            var result = _studentRepository.GetStudent(id);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            // model에 있는 유효성 검사 확인
            if (ModelState.IsValid)
            {
                // model 데이터를 Student table에 저장
                _studentRepository.Edit(student);
                _studentRepository.Save();

                return RedirectToAction("Student");
            }

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var result = _studentRepository.GetStudent(id);
            
            if (result != null)
            {
                _studentRepository.Delete(result);
                _studentRepository.Save();

            }

            return RedirectToAction("Student");
        }
    }
}
