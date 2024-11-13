using AutoMapper;
using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Nutritionists.Commands.CreateNutritionist;

public class CreateNutritionistCommandHandler(ILogger<CreateNutritionistCommandHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository,
    IUserContext userContext) : IRequestHandler<CreateNutritionistCommand, int>
{
    public async Task<int> Handle(CreateNutritionistCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        
        logger.LogInformation("{UserEmail} [{UserId}] is creating a new nutritionist: {@Nutritionist}", 
            currentUser.Email,
            currentUser.Id,
            request);

        var nutritionist = mapper.Map<Nutritionist>(request);


        int id = await nutritionistsRepository.Create(nutritionist);

        return id;
    }
}
