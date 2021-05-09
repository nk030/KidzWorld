using System;
using System.Collections.Generic;
using System.Text;
using KidzWorld.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KidzWorld.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Age> KdzAges { get; set; }

        public DbSet<Toys> KdzToys { get; set; }

        public DbSet<Sellers> Sellers { get; set; }

        public DbSet<SellerReview> KdzSellerReview { get; set; }


    }
}
