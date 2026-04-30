namespace AutoGest.Domain.Exceptions;

public class NotFoundException : DomainException
{
    public NotFoundException(string entity, object id)
        : base($"{entity} com id '{id}' não foi encontrado.") { }
}
