using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalKitchen.Models
{
    public class MealDBContext:DbContext
    {
        public MealDBContext(DbContextOptions<MealDBContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }

        public DbSet<Meals> Meals { get; set; }

        public DbSet<Requirements> Requirements { get; set; }
        public DbSet<SignUp> Signup { get; set; }

        public DbSet<FrequentlyAskedQuestion> FAQ { get; set; }
    }
}
