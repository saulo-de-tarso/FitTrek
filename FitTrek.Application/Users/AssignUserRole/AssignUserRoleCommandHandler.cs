using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;


namespace FitTrek.Application.Users.AssignUserRole;

public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    INutritionistsRepository nutritionistsRepository,
    IClientsRepository clientsRepository)
    : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning user role: {@Request}", request);
        var user = await userManager.FindByEmailAsync(request.UserEmail)
            ?? throw new NotFoundException(nameof(User), request.UserEmail);

        var role = await roleManager.FindByNameAsync(request.RoleName)
            ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

        if (request.RoleName == "Nutritionist")
        {
            var nutritionist = await nutritionistsRepository.GetByIdAsync(request.NutritionistId)
                ?? throw new NotFoundException(nameof(Nutritionist), request.NutritionistId.ToString());

            nutritionist.UserId = user.Id;
            await nutritionistsRepository.SaveChanges();
        }

        if (request.RoleName == "Client")
        {
            var client = await clientsRepository.GetByIdAsync(request.ClientId)
                ?? throw new NotFoundException(nameof(Client), request.ClientId.ToString());

            client.UserId = user.Id;
            await nutritionistsRepository.SaveChanges();
        }

        await userManager.AddToRoleAsync(user, role.Name!);


    }
}
