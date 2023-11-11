using Herokume.Infrastrcture.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Herokume.Infrastrcture;

public class HerokumeIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public HerokumeIdentityDbContext(DbContextOptions<HerokumeIdentityDbContext> options) : base(options)
    {
    }

}
