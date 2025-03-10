﻿
using FitTrek.Domain.Entities;

namespace FitTrek.Domain.Repositories;

public interface IClientsRepository
{
    Task<int> Create(Client entity);
    Task DeleteById(Client entity);

    Task<Client?> GetByIdAsync(int id);

    Task SaveChanges();


}
