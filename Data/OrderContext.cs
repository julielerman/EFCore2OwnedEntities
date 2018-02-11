using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace OwnedEntityDemo {
  public class OrderContext : DbContext {
    public DbSet<SalesOrder> SalesOrders { get; set; }
    protected override void OnModelCreating (ModelBuilder modelBuilder) {
      modelBuilder.Entity<SalesOrder> ().OwnsOne (s => s.BillingAddress);
      modelBuilder.Entity<SalesOrder> ().OwnsOne (s => s.ShippingAddress);
     }
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite ("Data Source=SalesOrder.db");
    }

    public override int SaveChanges () {
      foreach (var entry in ChangeTracker.Entries ().Where (e => e.Entity is SalesOrder &&
          (e.State == EntityState.Added || e.State == EntityState.Modified))) {
        if (entry.Entity is SalesOrder order) {
          if (entry.Reference ("ShippingAddress").CurrentValue == null) {
            entry.Reference ("ShippingAddress").CurrentValue = PostalAddress.Empty ();
          }
          if (entry.Reference ("BillingAddress").CurrentValue == null) {
            entry.Reference ("BillingAddress").CurrentValue = PostalAddress.Empty ();
          }
          entry.Reference ("ShippingAddress").TargetEntry.State = entry.State;
          entry.Reference ("BillingAddress").TargetEntry.State = entry.State;
        }
      }
      return base.SaveChanges ();
    }

  }

}