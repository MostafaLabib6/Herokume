using Herokume.Application.Contracts.Persistance;
using Herokume.Infrastrcture;
using Herokume.Infrastrcture.Authentication;
namespace Herokume.Persisitance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly HerokumeIdentityDbContext _dbContext;

    public UserRepository(HerokumeIdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
