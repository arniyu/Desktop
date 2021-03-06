﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SozialWeb.Models
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


	public class FriendConnection
	{
		public int ID { get; set; }
		public string Friend1 { get; set; }

		public string Friend2 { get; set; }
	}

	public interface IAppDataContext
	{
		IDbSet<FriendConnection> FriendConnections { get; set; }
		int SaveChanges();
	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IAppDataContext
	{
		public IDbSet<FriendConnection> FriendConnections { get; set; }
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