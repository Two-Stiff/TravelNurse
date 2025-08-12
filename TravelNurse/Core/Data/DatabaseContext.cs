using System.Linq.Expressions;
using Core.Attributes;
using Core.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;

namespace Core.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext(DbContextOptions options
        ): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        var cascadeFks = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFks)
        {
            fk.DeleteBehavior = DeleteBehavior.NoAction;
        }

        //LambdaExpression filterExpr = 
          //  (Expression<Func<Entity, bool>>)(
           // e => e.DeletedOn.CompareTo(Constants.DefaultDateTime) == 0
            //);

        // foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes()
        //              .Where(x => x.ClrType.IsAssignableTo(typeof(Entity))))
        // {
        //     var parameter = Expression.Parameter(mutableEntityType.ClrType);
        //     var body = ReplacingExpressionVisitor.Replace(
        //         filterExpr.Parameters.First(),
        //         parameter,
        //         filterExpr.Body
        //     );
        //
        //     var lambdaExpression = Expression.Lambda(body, parameter);
        //     
        //     mutableEntityType.SetQueryFilter(lambdaExpression);
        // }
    }

    public override int SaveChanges()
    {
        UpdateEntityStatuses();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default
        )
    {
        UpdateEntityStatuses();

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken); 
    }

    /// <summary>
    /// This method will update the CreatedOn, ModifiedOn, and DeletedOn properties of an entity automatically
    /// </summary>
    private void UpdateEntityStatuses()
    {
        ChangeTracker.DetectChanges();
        
        var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is Entity 
                        && x.State != EntityState.Unchanged 
                        && x.State != EntityState.Detached).ToList();

        // foreach (var entry in entities)
        // {
        //     var now = DateTime.UtcNow;
        //
        //     var hardDeleteEnabled = Attribute.IsDefined(entry.Entity.GetType(), typeof(EnableHardDeleteAttribute));
        //
        //     switch (entry.State)
        //     {  
        //         case EntityState.Deleted:
        //             if (hardDeleteEnabled == false)
        //             {
        //                 ((Entity)entry.Entity).DeletedOn = now;
        //             }
        //
        //             break;
        //         case EntityState.Modified:
        //             ((Entity)entry.Entity).ModifiedOn = now;
        //             break;
        //         case EntityState.Added:
        //             ((Entity)entry.Entity).CreatedOn = now;
        //             ((Entity)entry.Entity).ModifiedOn = now;
        //             ((Entity)entry.Entity).DeletedOn = now;
        //             break;
        //     }
        // }
    }
}