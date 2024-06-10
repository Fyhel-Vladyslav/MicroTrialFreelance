using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MicroTrialFreelance.Entities;
using MicroTrialFreelance.Models;
using System;
using System.Reflection.Emit;

namespace MicroTrialFreelance.Data
{
    public class ApplicationDbContext : IdentityDbContext<DbUser, DbRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
               : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}

