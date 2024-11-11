using AutoMapper;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Nutritionists.Commands.UpdateNutritionist;

public class UpdateNutritionistCommandHandler(ILogger<UpdateNutritionistCommandHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository) : IRequestHandler<UpdateNutritionistCommand>
{
    public async Task Handle(UpdateNutritionistCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating nutritionist with id {NutritionistId} with the values: {@UpdatedNutritionist}", request.Id, request);
        var nutritionist = await nutritionistsRepository.GetByIdAsync(request.Id);

        
        if (nutritionist is null)
            throw new NotFoundException(nameof(Nutritionist), request.Id.ToString());

        //logic so that you can update only one property
        if (request.FirstName is null)
            request.FirstName = nutritionist.FirstName;
        if (request.LastName is null)
            request.LastName = nutritionist.LastName;
        if (request.Email is null)
            request.Email = nutritionist.Email;
        if (request.PhoneNumber is null)
            request.PhoneNumber = nutritionist.PhoneNumber;
        if (request.DateOfBirth is null)
            request.DateOfBirth = nutritionist.DateOfBirth;


        mapper.Map(request, nutritionist);

        await nutritionistsRepository.SaveChanges();
        
    }
}
