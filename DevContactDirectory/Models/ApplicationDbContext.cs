namespace DevContactDirectory.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }


        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
    }
}