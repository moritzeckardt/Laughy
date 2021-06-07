using Microsoft.Identity.Client;

namespace Laughy.IdentityService
{
    public interface ILoginClaims //ServiceCollection Registration in app.xaml.cs
    {
        //Properties
        string IssuerId { get; set; }
        string Subject { get; set; }
        string FullName { get; set; }
        string Email { get; set; }
        AuthenticationResult AuthenticationResult { get; set; }


        //Methods
        void GetClaimsFromLogin(AuthenticationResult authResult);
        void SetClaimsToNull();
    }
}
