
using PDA.Models;

namespace PDA.Managers;

public interface IUserManager
{
   // (bool IsAuthenticated, bool IsAuthorized, string? Message) IsUserAuthenticated(string username, string password);

    (bool IsAuthenticated, string Message) IsUserAuthenticated(string domain, string username, string password);



}


