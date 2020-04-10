namespace WritingPlatform.DataLayer.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entities;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public Model1(string connection)
           : base(connection)
        {
            Database.SetInitializer(new MyInitializer());
            Model1 db = new Model1();
            db.Database.Initialize(true);
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Works> Works { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genres>()
                .HasMany(e => e.Works)
                .WithRequired(e => e.Genres)
                .HasForeignKey(e => e.GenreId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Ratings)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Works)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Works>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.Works)
                .HasForeignKey(e => e.WorkId);

            modelBuilder.Entity<Works>()
                .HasMany(e => e.Ratings)
                .WithOptional(e => e.Works)
                .HasForeignKey(e => e.WorkId);
        }
    }
}
