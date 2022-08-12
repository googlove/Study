namespace Gibdd.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Autos> Autos { get; set; }
        public virtual DbSet<Entities> Entities { get; set; }
        public virtual DbSet<IndividualOwners> IndividualOwners { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }
        public virtual DbSet<Stealings> Stealings { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TechnicalInspections> TechnicalInspections { get; set; }
        public virtual DbSet<Police_view2> Police_view2 { get; set; }
        public virtual DbSet<TechnicalOwners_View> TechnicalOwners_View { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autos>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Autos>()
                .Property(e => e.YearTax)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Owners>()
                .HasMany(e => e.Autos)
                .WithRequired(e => e.Owners)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Owners>()
                .HasOptional(e => e.Entities)
                .WithRequired(e => e.Owners)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Owners>()
                .HasOptional(e => e.IndividualOwners)
                .WithRequired(e => e.Owners)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TechnicalInspections>()
                .Property(e => e.YearNumber)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TechnicalInspections>()
                .Property(e => e.Work)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TechnicalInspections>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<TechnicalOwners_View>()
                .Property(e => e.YearNumber)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TechnicalOwners_View>()
                .Property(e => e.Work)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TechnicalOwners_View>()
                .Property(e => e.Reason)
                .IsUnicode(false);
        }
    }
}
