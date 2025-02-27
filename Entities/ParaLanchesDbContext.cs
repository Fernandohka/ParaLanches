using Microsoft.EntityFrameworkCore;
using Server.Entities.Pedido;

namespace Server.Entities;

public class ParaLanchesDbContext(DbContextOptions<ParaLanchesDbContext> options) : DbContext(options)
{
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Bebida> Bebidas { get; set; }
    public DbSet<Ingrediente> Ingredientes { get; set; }
    public DbSet<Lanche> Lanches { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Review> Reviews { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>()
            .HasMany(e => e.InvitedUsers)
            .WithOne(e => e.InvitedBy)
            .HasForeignKey(e => e.InvitedById)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Entity<ApplicationUser>()
            .HasOne(e => e.InvitedBy)
            .WithMany(e => e.InvitedUsers)
            .HasForeignKey(e => e.InvitedById)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<Order>()
            .HasOne(e => e.Lanches);
        
        builder.Entity<Order>()
            .HasOne(e => e.Bebidas);

        builder.Entity<Review>()
            .HasOne(e => e.Client);
        
        builder.Entity<Review>()
            .HasOne(e => e.Lanche);
        
        builder.Entity<Review>()
            .HasOne(e => e.Bebida);

        builder.Entity<FinalOrder>()
            .HasMany(e => e.Orders)
            .WithOne();
        
        builder.Entity<Order>()
            .HasMany(e => e.Adicionais);
        
        builder.Entity<Order>()
            .HasMany(e => e.Removidos);
    }
}