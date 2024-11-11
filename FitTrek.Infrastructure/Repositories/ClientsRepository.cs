using FitTrek.Domain.Entities;
using FitTrek.Domain.Repositories;
using FitTrek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitTrek.Infrastructure.Repositories;

internal class ClientsRepository(FitTrekDbContext dbContext) : IClientsRepository
{
    public async Task<int> Create(Client entity)
    {
        dbContext.Clients.Add(entity);

        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAll(IEnumerable<Client> entities)
    {
        dbContext.RemoveRange(entities);
        await dbContext.SaveChangesAsync();
    }
        

    public Task SaveChanges()
    => dbContext.SaveChangesAsync();

}
