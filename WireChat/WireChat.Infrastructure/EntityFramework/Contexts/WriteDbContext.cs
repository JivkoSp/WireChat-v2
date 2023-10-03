using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WireChat.Domain.Entities;
using WireChat.Domain.ValueObjects;
using WireChat.Infrastructure.EntityFramework.Encryption.EncryptionProvider;
using WireChat.Infrastructure.EntityFramework.ModelConfiguration.WriteConfiguration;

namespace WireChat.Infrastructure.EntityFramework.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IEncryptionProvider _encryptionProvider;

        public WriteDbContext(DbContextOptions<WriteDbContext> options, ILoggerFactory loggerFactory,
            IEncryptionProvider encryptionProvider) : base(options)
        {
            _loggerFactory = loggerFactory;
            _encryptionProvider = encryptionProvider;
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLoggerFactory(_loggerFactory); // Enable logging
                optionsBuilder.EnableSensitiveDataLogging(); // Include parameter values in logs
            }
        }

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
            modelBuilder.ApplyConfiguration(new BlockedChatUserConfiguration());
        }
    }
}
