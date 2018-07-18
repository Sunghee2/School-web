using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]   
        public string Name { get; set; }
        [Range(15, 70)]
        public string Age { get; set; }
        [Required]
        [MinLength(5)]
        public string Country { get; set; }
    }
}
