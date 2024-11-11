using AutoMapper;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Clients.Commands.UpdateClient;

public class UpdateClientCommandHandler(ILogger<UpdateClientCommandHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository,
    IClientsRepository clientsRepository) : IRequestHandler<UpdateClientCommand>
{
    public async Task Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating client {request.Id} for nutritionist with id {request.NutritionistId}");

        var nutritionist = await nutritionistsRepository.GetByIdAsync(request.NutritionistId)
            ?? throw new NotFoundException(nameof(Nutritionist), request.NutritionistId.ToString());

        var client = nutritionist.Clients.FirstOrDefault(c => c.Id == request.Id)
            ?? throw new NotFoundException(nameof(Client), request.Id.ToString());             

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
        if (request.IsActive is null)
            request.IsActive = client.IsActive;
        if (request.SubscriptionPlan is null)
            request.SubscriptionPlan = client.SubscriptionPlan;


        mapper.Map(request, client);

        await clientsRepository.SaveChanges();

    }
}
