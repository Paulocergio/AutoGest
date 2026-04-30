using AutoGest.Application.DTOs;
using AutoGest.Application.Mappers;
using AutoGest.Domain.Interfaces;

namespace AutoGest.Application.UseCases.Users;

public class ListUsersUseCase(IUserRepository userRepository)
{
    public async Task<IEnumerable<UserResponse>> ExecuteAsync(Guid tenantId, CancellationToken ct = default)
    {
        var users = await userRepository.GetAllAsync(tenantId, ct);
        return users.Select(UserMapper.ToResponse);
    }
}
