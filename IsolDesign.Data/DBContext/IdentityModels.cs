using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using IsolDesign.Data.Models;

namespace IsolDesign.Data.DBContext
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Assignment> Assignments { get; set; } // Assignment is an abstract class with two children (OrderedAssignment and PartnerAssignment)
        public DbSet<Competency> Competencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DevMethod> DevMethods { get; set; }
        public DbSet<Economy> Economies { get; set; }
        //public DbSet<OrderedAssignment> OrderedAssignments { get; set; } **************************
        public DbSet<Partner> Partners { get; set; }
        //public DbSet<PartnerAssignment> PartnerAssignments { get; set; } **************************
        public DbSet<Patent> Patents { get; set; }
        public DbSet<PortfolioSubject> PortfolioSubjects { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Subcontractor> Subcontractors { get; set; }
        public DbSet<Team> Teams { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}