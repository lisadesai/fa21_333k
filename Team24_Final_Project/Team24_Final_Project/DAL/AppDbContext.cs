﻿using System;
using Microsoft.EntityFrameworkCore;

// Update this using statement to include your project name
using Team24_Final_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//: Make this namespace match your project name
namespace Team24_Final_Project.DAL
{
    //NOTE: This class definition references the user class for this project.  
    //If your User class is called something other than AppUser, you will need
    //to change it in the line below
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //this code makes sure the database is re-created on the $5/month Azure tier
            builder.HasPerformanceLevel("Basic");
            builder.HasServiceTier("Basic");
            base.OnModelCreating(builder);
        }

        //TODO: Add Dbsets here.  Products is included as an example.  
        public DbSet<Property> Properties { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
