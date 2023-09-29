using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.ModelConfiguration.ReadConfiguration;
using WireChat.Infrastructure.EntityFramework.Models;

namespace WireChat.Infrastructure.EntityFramework.Contexts
{
    public sealed class ReadDbContext : IdentityDbContext<UserReadModel>
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public ReadDbContext(DbContextOptions<ReadDbContext> options, IEncryptionProvider encryptionProvider) : base(options)
        {
            _encryptionProvider = encryptionProvider;
        }

        public DbSet<GroupReadModel> Groups { get; set; }
        public DbSet<ChatReadModel> ChatReadModels { get; set; }
        public DbSet<ChatMessageReadModel> ChatMessageReadModels { get; set; }
        public DbSet<UserReadModel> UserReadModels { get; set; }
        public DbSet<ChatUserReadModel> ChatUserReadModels { get; set; }
        public DbSet<UserContactRequestReadModel> UserContactRequestReadModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("wirechat");

            base.OnModelCreating(modelBuilder);

            //Applying configurations for the entity models
            modelBuilder.ApplyConfiguration(new ChatConfiguration(_encryptionProvider));
            modelBuilder.ApplyConfiguration(new ChatMessageConfiguration(_encryptionProvider));
            modelBuilder.ApplyConfiguration(new ChatUserConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration(_encryptionProvider));
            modelBuilder.ApplyConfiguration(new UserContactRequestConfiguration(_encryptionProvider));
            modelBuilder.ApplyConfiguration(new GroupConfiguration(_encryptionProvider));
        }
    }
}
