namespace AutoGest.Application.DTOs;

public record UserResponse(
    Guid Id,
    string FullName,
    string Email,
    Guid TenantId,
    DateTime CreatedAt
);

public record CreateUserRequest(
    string FullName,
    string Email,
    string Password,
    Guid TenantId
);

public record UpdateUserRequest(
    string FullName,
    string Email
);

public record UpdatePasswordRequest(
    string CurrentPassword,
    string NewPassword
);
