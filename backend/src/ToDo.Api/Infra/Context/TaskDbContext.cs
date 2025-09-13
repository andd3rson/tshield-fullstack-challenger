namespace ToDo.Api.Infra.Context;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options) { }

    public virtual DbSet<Tasks> Tasks { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var item in ChangeTracker.Entries<Audit>())
        {
            if (item.State == EntityState.Added)
            {
                item.Entity.CreatedAt = DateTime.UtcNow;
                item.Entity.LastUpdatedAt = DateTime.UtcNow;
            }

            if (item.State == EntityState.Modified)
            {
                item.Entity.LastUpdatedAt = DateTime.UtcNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
