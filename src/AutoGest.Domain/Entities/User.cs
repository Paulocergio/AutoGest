namespace AutoGest.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public Guid TenantId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Tenant? Tenant { get; private set; }

    private User() { }

    public static User Create(string fullName, string email, string passwordHash, Guid tenantId)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            FullName = fullName,
            Email = email.ToLowerInvariant(),
            PasswordHash = passwordHash,
            TenantId = tenantId,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void Update(string fullName, string email)
    {
        FullName = fullName;
        Email = email.ToLowerInvariant();
    }

    public void UpdatePassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
    }
}
