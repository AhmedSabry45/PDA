
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.DirectoryServices.AccountManagement;
using System.Data;
using System.Data.OracleClient;
using Dapper;
using Microsoft.AspNetCore.Http;

using System.DirectoryServices;

namespace PDA.Managers;

public class UserManager : IUserManager
{
    //private readonly UserContext _context;

    private readonly string _connectionString;
    private readonly string _username;
    public UserManager(IHttpContextAccessor httpContextAccessor)
    {
       
   
       // _connectionString = Environment.GetEnvironmentVariable("ZodiacDBTFusionConnection", EnvironmentVariableTarget.Machine);

        _username = httpContextAccessor.HttpContext?.Session.GetString("userName") ?? string.Empty;
    }

    private (bool IsDisabled, string Message) IsUserDisabled(string username)
    {
        (bool IsDisabled, string Message) result = (false, null!);


        using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
        {
            UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username.Trim().ToLower());

            if (user != null)
            {
                bool isDisabled = (!user?.Enabled) ?? true;  // Check if the user account is disabled

                result = isDisabled ? (true, $"User: '{username}' is disabled on Active Directory, Please Contact DPWS IT Team") : (false, "");

                return result;
            }
            else
            {
                result = (true, $"User: '{username}' not found");
                return result;

            }
        }
    }
    private (bool IsLocked, string Message) IsUserLockedOut(string username)
    {
        (bool IsLocked, string Message) result = (false, null!);
        using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
        {
            UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username.Trim().ToLower());

            if (user != null)
            {
                bool isLockedOut = user.IsAccountLockedOut();  // Check if the user account is locked

                result = isLockedOut ? (true, $"User: '{username}' is locked on Active Directory, Please Contact DPWS IT Team") : (false, "");

                return result;
            }
            else
            {
                result = (true, $"User: '{username}' not found in active directory");
                return result;
            }
        }
    }


   

    public (bool IsAuthenticated, string Message) IsUserAuthenticated(string domain, string username, string password)
    {
        (bool IsAuthenticated, string Message) result = (false, null!);

        using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain))
        {
            UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username.Trim().ToLower());

            var checkLockResult = IsUserLockedOut(username.Trim().ToLower());
            if (checkLockResult.IsLocked)
            {
                result = (false, checkLockResult.Message);

                return result;
            }

            var checkDisabledResult = IsUserDisabled(username.Trim().ToLower());
            if (checkDisabledResult.IsDisabled)
            {
                result = (false, checkDisabledResult.Message);

                return result;
            }

            bool isInValid = context.ValidateCredentials(username.Trim().ToLower(), password);

            if (!isInValid)
            {
                result = (false, "Password is incorrect");
                return result;
            }


            result = (true, "Valid User");
            return result;
        }
    }

    //public (bool IsAuthenticated, bool IsAuthorized, string? Message) IsUserAuthenticated(string username, string password)
    //{
    //    //var financeGroup = new ConfigurationBuilder()
    //    //                   .SetBasePath(Directory.GetCurrentDirectory())
    //    //                   .AddJsonFile("appsettings.json")
    //    //                   .Build()["FinanceGroup"];

    //    var financeGroups = new ConfigurationBuilder()
    //               .SetBasePath(Directory.GetCurrentDirectory())
    //               .AddJsonFile("appsettings.json")
    //               .Build()
    //               .GetSection("FinanceGroup")
    //               .Get<List<string>>() ?? new List<string>();

    //    (bool IsAuthenticated, bool IsAuthorized, string Message) result = (false, false, null);

    //    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "spdc.com"))
    //    {
    //        UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);

    //        var checkLockResult = IsUserLockedOut(username);
    //        if (checkLockResult.IsLocked)
    //        {
    //            result = (false, false, checkLockResult.Message);

    //            return result;
    //        }

    //        var checkDisabledResult = IsUserDisabled(username);
    //        if (checkDisabledResult.IsDisabled)
    //        {
    //            result = (false, false, checkDisabledResult.Message);

    //            return result;
    //        }

    //        bool isInValid = !context.ValidateCredentials(username.ToLower(), password);
    //        if (isInValid)
    //        {
    //            result = (false, false, "incorrect password");

    //            return result;
    //        }
    //        DirectoryEntry directoryEntry = (DirectoryEntry)user.GetUnderlyingObject();
    //        var groups = directoryEntry.Properties["memberOf"]?.Value as object[];


    //        if (groups is object[])
    //        {
    //            bool isAuthorized = groups.Any(group =>
    //                financeGroups.Any(financeGroup =>
    //                    group?.ToString()?.Contains(financeGroup, StringComparison.OrdinalIgnoreCase) ?? false));

    //            if (isAuthorized)
    //            {
    //                result = (true, true, "User is authorized");
    //            }
    //            else
    //            {
    //                result = (true, false, "This User Doesn't have Access to login to this Application");
    //            }
    //        }

    //        else
    //        {
    //            result = (true, false, "No groups found for the user");
    //        }

    //        return result;
    //    }
    //}
}





