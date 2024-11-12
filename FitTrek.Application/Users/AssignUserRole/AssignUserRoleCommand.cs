using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FitTrek.Application.Users.AssignUserRole;

public class AssignUserRoleCommand : IRequest
{
    [Required]
    [EmailAddress]
    public string UserEmail { get; set; } = default!;
    [Required]
    public string RoleName { get; set; } = default!;
}
