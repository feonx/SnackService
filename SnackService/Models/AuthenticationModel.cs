using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace SnackService.Models
{
    public class AuthenticationContext : DbContext
    {

        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
            :base (options) { }

        public DbSet<Login> Logins { get; set; }
    }

    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [MaxLength(30, ErrorMessage = "Password cannot be Greater than 30 Charaters")]
        [StringLength(31, MinimumLength = 7, ErrorMessage = "Password Must be Minimum 7 Charaters")]
        public string Password { get; set; }

        public string IPaddress { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
