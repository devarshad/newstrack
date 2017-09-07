using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Infrastructure;
using System.Data.Entity;

namespace NewsTrack.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string FullName { get; set; }
        //public string Gender { get; set; }
        //public string ProfilePicture { get; set; }
        //public Nullable<System.DateTime> LastStatusOn { get; set; }
        //public Nullable<System.DateTime> CreatedOn { get; set; }
        //public Nullable<bool> Active { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, long> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim(ClaimTypes.GivenName, FullName));
            //userIdentity.AddClaim(new Claim(ClaimTypes.Dns, ProfilePicture));
            //userIdentity.AddClaim(new Claim(ClaimTypes.Gender, Gender));
            //userIdentity.AddClaim(new Claim(ClaimTypes.Sid, Active.ToString()));

            return userIdentity;
        }

        public static string Token(ClaimsIdentity identity)
        {
            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(120));
            var token = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
            return token;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // You can globally assign schema here
            modelBuilder.HasDefaultSchema("nt");
            base.OnModelCreating(modelBuilder);
        }
    }

    public class CustomUserRole : IdentityUserRole<long> { }
    public class CustomUserClaim : IdentityUserClaim<long> { }
    public class CustomUserLogin : IdentityUserLogin<long> { }

    public class CustomRole : IdentityRole<long, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, long,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, long, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}