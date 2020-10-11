﻿using Microsoft.EntityFrameworkCore;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
                
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
