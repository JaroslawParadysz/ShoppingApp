using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Authentication.Data.Models;

namespace ShoppingApp.Authentication.Data
{
    public class ShoppingAppDbContext : IdentityDbContext<User>
    {
        public ShoppingAppDbContext(DbContextOptions<ShoppingAppDbContext> options)
            : base(options)
        {
        }
    }
}
