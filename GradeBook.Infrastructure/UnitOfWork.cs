using GradeBook.Domain.Abstractions;
using GradeBook.Domain.Entities;
using GradeBook.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GradeBook.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    private readonly GradeBookDbContext _gradeBookDbContext;

    public UnitOfWork(GradeBookDbContext gradeBookDbContext)
    {
        _gradeBookDbContext = gradeBookDbContext;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntites();
        await _gradeBookDbContext.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditableEntites()
    {
        var entries = _gradeBookDbContext
            .ChangeTracker
            .Entries<Entity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = entry.Entity.UpdatedAt = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.Now;
            }
        }

    }
}
