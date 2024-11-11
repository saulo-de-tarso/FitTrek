using AutoMapper;
using FitTrek.Application.Clients.Commands.CreateClient;
using FitTrek.Application.Clients.Commands.UpdateClient;
using FitTrek.Domain.Entities;

namespace FitTrek.Application.Clients.Dtos;

public class ClientsProfile : Profile
{
    public ClientsProfile()
    {
        CreateMap<CreateClientCommand, Client>()
        .AfterMap((src, dest) =>
         {
             dest.CreatedAt = DateTime.Now;
         });

        CreateMap<Client, ClientDto>();

        CreateMap<UpdateClientCommand, Client>()
        .AfterMap((src, dest) =>
        {
            dest.UpdatedAt = DateTime.Now;
        });

    }

}
