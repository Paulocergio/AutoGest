using AutoGest.Domain.Entities;
using AutoGest.Domain.Interfaces;
using AutoGest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoGest.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid id, Guid tenantId, CancellationToken ct = default) =>
        await context.Users.FirstOrDefaultAsync(u => u.Id == id && u.TenantId == tenantId, ct);

    public async Task<User?> GetByEmailAsync(string email, Guid tenantId, CancellationToken ct = default) =>
        await context.Users.FirstOrDefaultAsync(u => u.Email == email.ToLowerInvariant() && u.TenantId == tenantId, ct);

    public async Task<IEnumerable<User>> GetAllAsync(Guid tenantId, CancellationToken ct = default) =>
        await context.Users.Where(u => u.TenantId == tenantId).ToListAsync(ct);

    public async Task AddAsync(User user, CancellationToken ct = default)
    {
        await context.Users.AddAsync(user, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(User user, CancellationToken ct = default)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(User user, CancellationToken ct = default)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync(ct);
    }

    public async Task<bool> EmailExistsAsync(string email, Guid tenantId, Guid? excludeUserId = null, CancellationToken ct = default)
    {
        var query = context.Users.Where(u => u.Email == email.ToLowerInvariant() && u.TenantId == tenantId);
        if (excludeUserId.HasValue)
            query = query.Where(u => u.Id != excludeUserId.Value);
        return await query.AnyAsync(ct);
    }
}
