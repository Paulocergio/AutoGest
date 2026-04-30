using AutoGest.Application.DTOs;
using AutoGest.Domain.Entities;

namespace AutoGest.Application.Mappers;

public static class UserMapper
{
    public static UserResponse ToResponse(User user) =>
        new(user.Id, user.FullName, user.Email, user.TenantId, user.CreatedAt);
}
