using Microsoft.EntityFrameworkCore;
using NTWCardGame.Models;
using NTWCardGame.Models.Items;

namespace NTWCardGame.Data
{

        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }


        public DbSet<CharacterEntity> Characters { get; set; }
        public DbSet<ItemEntity> Items { get; set; }

    }
}

