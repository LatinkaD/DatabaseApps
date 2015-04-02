namespace MountainsCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MountainContext : DbContext
    {
        public MountainContext()
            : base("name=MountainContext")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Mountain> Mountains { get; set; }

        public virtual DbSet<Peak> Peaks { get; set; }

    }
}