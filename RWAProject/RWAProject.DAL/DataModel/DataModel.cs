using System.Data.Entity;

namespace RWAProject.DAL {
    public partial class DataModel : DbContext
    {
        public DataModel() : base("name=DataModelCon") { }

        #region Properties

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonEmail> PersonEmails { get; set; }
        public virtual DbSet<Role> Roles { get; set; } 

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.People)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonEmails)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.People)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
