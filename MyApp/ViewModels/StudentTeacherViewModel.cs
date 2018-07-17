using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// 한 페이지(view)에 보이고 싶어하는 model을 묶음.
namespace MyApp.ViewModels
{
    public class StudentTeacherViewModel
    {
        public Student Student { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
