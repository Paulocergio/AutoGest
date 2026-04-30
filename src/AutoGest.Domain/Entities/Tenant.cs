namespace AutoGest.Domain.Entities;

public class Tenant
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string CNPJ { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    public ICollection<User> Users { get; private set; } = new List<User>();

    private Tenant() { }

    public static Tenant Create(string name, string cnpj)
    {
        return new Tenant
        {
            Id = Guid.NewGuid(),
            Name = name,
            CNPJ = cnpj,
            CreatedAt = DateTime.UtcNow
        };
    }
}
