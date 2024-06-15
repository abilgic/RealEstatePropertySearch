using Microsoft.EntityFrameworkCore;
using RealEstatePropertySearch.Server.Entities;

namespace RealEstatePropertySearch.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
        DbSet<Property> Property { get; set; }
    }
}

