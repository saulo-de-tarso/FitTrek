﻿using FitTrek.Application.Clients.Dtos;
using MediatR;

namespace FitTrek.Application.Clients.Queries.GetClientById;

public class GetClientByIdQuery(int clientId) : IRequest<ClientDto>
{

    public int Id { get; } = clientId;
}
