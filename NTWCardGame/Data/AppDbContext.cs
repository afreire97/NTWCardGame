using Microsoft.EntityFrameworkCore;

namespace NTWCardGame.Data
{

        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
        }
    }

