using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Welp.Web.Models;

namespace Welp.Web.Data
{
    public class WelpDBContext : DbContext
    {
        public WelpDBContext(DbContextOptions<WelpDBContext> options)
            : base(options)
        { }

        public DbSet<TagLine> TagLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public void SeedAll()
        {
            SeedTagLines();

            SaveChanges();
        }

        public void SeedTagLines()
        {
            if (!TagLines.Any())
            {
                TagLines.AddRange(
                    new TagLine() { Probability = 100, Text = "Specialiștii tăi"},
                    new TagLine() { Probability = 50, Text = "O dregem cumva"},
                    new TagLine() { Probability = 50, Text = "Specialistul tău" },
                    new TagLine() { Probability = 50, Text = "Alături de tine" },
                    new TagLine() { Probability = 30, Text = "Specialiști în tehnologie"},
                    new TagLine() { Probability = 20, Text = "Toți pentru unul"}
                    );
            }
        }
    }
}
