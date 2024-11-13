using MediatR;
using System.Text.Json.Serialization;

namespace FitTrek.Application.Clients.Commands.DeleteClient;

public class DeleteClientCommand(int clientId) : IRequest
{
    [JsonIgnore]
    public int NutritionistId { get; set; }
    public int ClientId { get; } = clientId;

}
