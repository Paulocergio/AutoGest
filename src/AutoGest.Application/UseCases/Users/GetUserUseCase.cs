using AutoGest.Application.DTOs;
using AutoGest.Application.Mappers;
using AutoGest.Domain.Entities;
using AutoGest.Domain.Exceptions;
using AutoGest.Domain.Interfaces;

namespace AutoGest.Application.UseCases.Users;

public class GetUserUseCase(IUserRepository userRepository)
{
    public async Task<UserResponse> ExecuteAsync(Guid id, Guid tenantId, CancellationToken ct = default)
    {
        var user = await userRepository.GetByIdAsync(id, tenantId, ct)
            ?? throw new NotFoundException(nameof(User), id);

        return UserMapper.ToResponse(user);
    }
}
