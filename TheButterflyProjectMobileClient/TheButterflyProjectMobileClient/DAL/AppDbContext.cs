using AndroidX.Startup;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheButterflyProjectMobileClient.Contracts;
using TheButterflyProjectMobileClient.Models;

namespace TheButterflyProjectMobileClient.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Artiste> Artistes => Set<Artiste>();
        public DbSet<Album> Albums => Set<Album>();
        public DbSet<Morceau> Morceaux => Set<Morceau>();
        public DbSet<Playlist> Playlists => Set<Playlist>();
        public DbSet<ArtisteMorceau> ArtisteMorceaux => Set<ArtisteMorceau>();
        public DbSet<PlaylistMorceau> PlaylistMorceaux => Set<PlaylistMorceau>();
        public DbSet<Collection> Collection => Set<Collection>();
        public DbSet<Serie> Serie => Set<Serie>();
        public DbSet<Tome> Tome => Set<Tome>();
        public DbSet<Setting> Setting => Set<Setting>();
        public DbSet<TodoList> TodoLists => Set<TodoList>();
        public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artiste>().Ignore(x=>x.CoverLocalPath);
            modelBuilder.Entity<Artiste>().Ignore(x => x.IsCoverLocal);
            modelBuilder.Entity<Artiste>().Ignore(x => x.FanartLocalPath);
            modelBuilder.Entity<Artiste>().Ignore(x => x.IsFanartLocal);
            modelBuilder.Entity<Album>().Ignore(x => x.CoverLocalPath);
            modelBuilder.Entity<Album>().Ignore(x => x.IsCoverLocal);
            modelBuilder.Entity<Playlist>().Ignore(x => x.CoverLocalPath);
            modelBuilder.Entity<Playlist>().Ignore(x => x.IsCoverLocal);
            modelBuilder.Entity<Morceau>().Ignore(x => x.LocalPath);
            modelBuilder.Entity<Morceau>().Ignore(x => x.IsLocal);
            modelBuilder.Entity<Collection>().Ignore(x => x.CoverLocalPath);
            modelBuilder.Entity<Collection>().Ignore(x => x.IsCoverLocal);
            modelBuilder.Entity<Collection>().Ignore(x => x.FanartLocalPath);
            modelBuilder.Entity<Collection>().Ignore(x => x.IsFanartLocal);
            modelBuilder.Entity<Serie>().Ignore(x => x.CoverLocalPath);
            modelBuilder.Entity<Serie>().Ignore(x => x.IsCoverLocal);
            modelBuilder.Entity<Tome>().Ignore(x => x.LocalPath);
            modelBuilder.Entity<Tome>().Ignore(x => x.IsLocal);
            modelBuilder.Entity<Tome>().Ignore(x => x.CoverLocalPath);
            modelBuilder.Entity<Tome>().Ignore(x => x.IsCoverLocal);
            base.OnModelCreating(modelBuilder);
        }
    }
    public class DbContextInitializer(AppDbContext context) : IDbInitializer
    {
        /// <inheritdoc />
        public void Initialize()
        {
            _ = context.Database.EnsureCreated();
        }

        /// <inheritdoc />
        public Task InitializeAsync(CancellationToken cancellationToken = default)
            => context.Database.EnsureCreatedAsync(cancellationToken);
    }
}
