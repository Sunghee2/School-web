﻿using Microsoft.EntityFrameworkCore;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions options) : base(options) {}

        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
    }
}
