using AutoMapper;
using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Extensions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Clients.Commands.CreateClient;

public class CreateClientCommandHandler(ILogger<CreateClientCommandHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository,
    IClientsRepository clientsRepository,
    IUserContext userContext) : IRequestHandler<CreateClientCommand, int>
{
    public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {

        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdAsync(user!.Id);

        request.NutritionistId = nutritionist.Id;

        logger.LogInformation("Creating a new client for nutritionist with id {NutritionistId}: {@Client}", request.NutritionistId, request);

        var client = mapper.Map<Client>(request);

        int id = await clientsRepository.Create(client);

        nutritionist.CurrentMonthlyRevenue += client.SubscriptionPlan.GetRevenue();

        await nutritionistsRepository.SaveChanges();

        return id;
    }
}
