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

    /*public async Task<Client?> GetByIdAsync(int id)
    {
        var client = await dbContext.Clients.
            FirstOrDefaultAsync(n => n.Id == id);

        return client;
    }*/

    public Task SaveChanges()
    => dbContext.SaveChangesAsync();

}
