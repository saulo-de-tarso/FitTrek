namespace FitTrek.Application.Users
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}