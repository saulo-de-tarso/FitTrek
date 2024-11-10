using AutoMapper;
using FitTrek.Domain.Entities;

namespace FitTrek.Application.Clients.Dtos;

public class ClientsProfile : Profile
{
    public ClientsProfile()
    {
        CreateMap<Client, ClientDto>();
    }

}
