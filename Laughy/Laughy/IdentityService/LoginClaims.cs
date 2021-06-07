using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Laughy.IdentityService
{
    public class LoginClaims : ILoginClaims //ServiceCollection Registration in app.xaml.cs
    {
        //Properties
        public string IssuerId { get; set; }
        public string Subject { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public AuthenticationResult AuthenticationResult { get; set; }


        //Methods
        public void GetClaimsFromLogin(AuthenticationResult authResult)
        {
            if (authResult != null)
            {
                var handler = new JwtSecurityTokenHandler();

                var data = handler.ReadJwtToken(authResult.IdToken);

                if (data != null)
                {
                    IssuerId = data.Claims.FirstOrDefault(x => x.Type.Equals("iss")).Value;
                    Subject = data.Claims.FirstOrDefault(x => x.Type.Equals("sub")).Value;
                    FullName = data.Claims.FirstOrDefault(x => x.Type.Equals("name")).Value;
                    Email = data.Claims.FirstOrDefault(x => x.Type.Equals("email")).Value;
                    AuthenticationResult = authResult;
                }
            }
        }

        public void SetClaimsToNull()
        {
            IssuerId = null;
            Subject = null;
            FullName = null;
            Email = null;
            AuthenticationResult = null;
        }
    }
}
