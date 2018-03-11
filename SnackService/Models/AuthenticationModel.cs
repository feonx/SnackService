using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackService.Models
{
    public class AuthenticationContext : DbContext
    {

        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
            : base(options)
        { }

        public DbSet<Login> Logins { get; set; }
    }

    public class Login
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string IPaddress { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
