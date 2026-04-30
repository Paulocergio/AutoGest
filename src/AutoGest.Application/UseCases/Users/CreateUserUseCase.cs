using AutoGest.Application.DTOs;
using AutoGest.Application.Mappers;
using AutoGest.Domain.Entities;
using AutoGest.Domain.Exceptions;
using AutoGest.Domain.Interfaces;
using FluentValidation;

namespace AutoGest.Application.UseCases.Users;

public class CreateUserUseCase(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IValidator<CreateUserRequest> validator)
{
    public async Task<UserResponse> ExecuteAsync(CreateUserRequest request, CancellationToken ct = default)
    {
        var validation = await validator.ValidateAsync(request, ct);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        if (await userRepository.EmailExistsAsync(request.Email, request.TenantId, ct: ct))
            throw new DomainException($"E-mail '{request.Email}' já está em uso neste tenant.");

        var hash = passwordHasher.Hash(request.Password);
        var user = User.Create(request.FullName, request.Email, hash, request.TenantId);

        await userRepository.AddAsync(user, ct);

        return UserMapper.ToResponse(user);
    }
}
