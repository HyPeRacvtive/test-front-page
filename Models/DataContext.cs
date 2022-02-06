using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace test_front_page.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
    
        public DbSet<Messages> Contact { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Sliders> Sliders { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Videos> Videos { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Admin> Admin { get; set; }

    }
}