using Microsoft.EntityFrameworkCore;
using ReviewManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewManagementApp.DataLayer
{
    public class ReviewManagementAppDbContext : DbContext
    {
        public ReviewManagementAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
    }

}