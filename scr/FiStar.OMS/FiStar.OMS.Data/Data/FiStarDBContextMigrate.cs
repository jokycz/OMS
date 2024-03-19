using Microsoft.EntityFrameworkCore;

namespace FiStar.OMS.Data.Data;

public class FiStarOmrDBContextMigrate : FiStarOmrDBContext
{
    public FiStarOmrDBContextMigrate(DbContextOptions<FiStarOmrDBContextMigrate> options) : base(options)
    {
    }
}