﻿using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DataAccess
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
