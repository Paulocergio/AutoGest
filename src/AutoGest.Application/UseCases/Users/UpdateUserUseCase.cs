using AutoGest.Application.DTOs;
using AutoGest.Application.Mappers;
using AutoGest.Domain.Entities;
using AutoGest.Domain.Exceptions;
using AutoGest.Domain.Interfaces;
using FluentValidation;

namespace AutoGest.Application.UseCases.Users;

public class UpdateUserUseCase(
    IUserRepository userRepository,
    IValidator<UpdateUserRequest> validator)
{
    public async Task<UserResponse> ExecuteAsync(Guid id, Guid tenantId, UpdateUserRequest request, CancellationToken ct = default)
    {
        var validation = await validator.ValidateAsync(request, ct);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var user = await userRepository.GetByIdAsync(id, tenantId, ct)
            ?? throw new NotFoundException(nameof(User), id);

        if (await userRepository.EmailExistsAsync(request.Email, tenantId, excludeUserId: id, ct: ct))
            throw new DomainException($"E-mail '{request.Email}' já está em uso neste tenant.");

        user.Update(request.FullName, request.Email);
        await userRepository.UpdateAsync(user, ct);

        return UserMapper.ToResponse(user);
    }
}
