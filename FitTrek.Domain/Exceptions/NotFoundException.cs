namespace FitTrek.Domain.Exceptions;

public class NotFoundException(string resourceType, string resourceIdentifier) 
    : Exception($"{resourceType} {resourceIdentifier} does not exist.")
{
}
