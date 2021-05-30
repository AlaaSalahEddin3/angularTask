using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityResult = Microsoft.AspNetCore.Identity.IdentityResult;

namespace DAL
{
    public class AppUser : IdentityUser
    {
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class ApplicationUserStore : UserStore<AppUser>
    {

        public ApplicationUserStore() : base(new AppDbContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }

  

    public class AppDbContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer("Data Source=.;Initial Catalog=TaskDB;Integrated Security=True"
               , options => options.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
       // public DbSet<AppUser> users;
    }
}
