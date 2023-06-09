﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using MyLeasing.Web.Data.Entity;

namespace MyLeasing.Web.Data
{ 
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Lessee> Lessee { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
