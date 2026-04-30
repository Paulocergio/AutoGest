using AutoGest.Application.DTOs;
using AutoGest.Application.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace AutoGest.API.Controllers;

[ApiController]
[Route("api/tenants/{tenantId:guid}/users")]
public class UsersController(
    CreateUserUseCase createUser,
    GetUserUseCase getUser,
    ListUsersUseCase listUsers,
    UpdateUserUseCase updateUser,
    DeleteUserUseCase deleteUser) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(Guid tenantId, CancellationToken ct)
    {
        var users = await listUsers.ExecuteAsync(tenantId, ct);
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid tenantId, Guid id, CancellationToken ct)
    {
        var user = await getUser.ExecuteAsync(id, tenantId, ct);
        return Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Create(Guid tenantId, [FromBody] CreateUserRequest request, CancellationToken ct)
    {
        var requestWithTenant = request with { TenantId = tenantId };
        var user = await createUser.ExecuteAsync(requestWithTenant, ct);
        return CreatedAtAction(nameof(GetById), new { tenantId, id = user.Id }, user);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Update(Guid tenantId, Guid id, [FromBody] UpdateUserRequest request, CancellationToken ct)
    {
        var user = await updateUser.ExecuteAsync(id, tenantId, request, ct);
        return Ok(user);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid tenantId, Guid id, CancellationToken ct)
    {
        await deleteUser.ExecuteAsync(id, tenantId, ct);
        return NoContent();
    }
}
