using AutoGest.Domain.Entities;
using AutoGest.Domain.Exceptions;
using AutoGest.Domain.Interfaces;

namespace AutoGest.Application.UseCases.Users;

public class DeleteUserUseCase(IUserRepository userRepository)
{
    public async Task ExecuteAsync(Guid id, Guid tenantId, CancellationToken ct = default)
    {
        var user = await userRepository.GetByIdAsync(id, tenantId, ct)
            ?? throw new NotFoundException(nameof(User), id);

        await userRepository.DeleteAsync(user, ct);
    }
}
