namespace Laughy.IdentityService
{
    public static class LoginConstants
    {
        //Properties
        public static readonly string TenantName = "morieckardtgmail";   
        
        public static readonly string TenantId = "morieckardtgmail.onmicrosoft.com";

        public static readonly string ClientId = "45d72ec4-58fc-4c10-bae5-a51ef82dfcd5";

        public static readonly string SignUpSignInPolicyId = "B2X_1_signup_signin";

        public static readonly string IosKeychainSecurityGroups = "com.microsoft.aadb2cauthentication";

        public static readonly string[] Scopes = new string[] {"openid", "offline_access"};

        public static readonly string AuthorityBase = $"https://{TenantName}.b2clogin.com/tfp/{TenantId}/";

        public static readonly string AuthoritySignIn = $"{AuthorityBase}{SignUpSignInPolicyId}";
    }
}
