using AutoMapper;
using FitTrek.Application.Clients.Enums;
using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Enums;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Extensions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Clients.Commands.UpdateClient;

public class UpdateClientCommandHandler(ILogger<UpdateClientCommandHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository,
    IClientsRepository clientsRepository,
    IUserContext userContext) : IRequestHandler<UpdateClientCommand>
{
    public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdAsync(user!.Id);

        request.NutritionistId = nutritionist.Id;

        logger.LogInformation("Updating client {ClientId} for nutritionist with id {NutritionistId} with the values: {@UpdatedClient}",
            request.Id, request.NutritionistId, request);

        var client = nutritionist.Clients.FirstOrDefault(c => c.Id == request.Id)
            ?? throw new NotFoundException(nameof(Client), request.Id.ToString());

        var currentPlanRevenue = client.SubscriptionPlan.GetRevenue();

        var updatedPlan = request.SubscriptionPlan ?? client.SubscriptionPlan;

        var updatedPlanRevenue = updatedPlan.GetRevenue();

        //logic so that you can update only one property
        if (request.FirstName is null)
            request.FirstName = client.FirstName;
        if (request.LastName is null)
            request.LastName = client.LastName;
        if (request.Email is null)
            request.Email = client.Email;
        if (request.PhoneNumber is null)
            request.PhoneNumber = client.PhoneNumber;
        if (request.Gender is null)
            request.Gender = client.Gender;
        if (request.DateOfBirth is null)
            request.DateOfBirth = client.DateOfBirth;
        if (request.HeightInCm is null)
            request.HeightInCm = client.HeightInCm;
        if (request.HeightInCm is null)
            request.WeightInKg = client.WeightInKg;
        if (request.SubscriptionPlan is null)
            request.SubscriptionPlan = client.SubscriptionPlan;


        mapper.Map(request, client);

        await clientsRepository.SaveChanges();

        nutritionist.CurrentMonthlyRevenue += (updatedPlanRevenue - currentPlanRevenue);

        await nutritionistsRepository.SaveChanges();


    }
}
