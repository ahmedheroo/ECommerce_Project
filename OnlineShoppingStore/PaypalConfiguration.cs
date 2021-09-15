using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;


        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AVJpGRZCpVJEEMcTNlnVLGi4ddjuC83oo1UwAMJeBkoLRXCu-hcm7jY71P3FrBug7L4V4mvn08Tnrv57";
            clientSecret = "EOEdfm-OxIGXkGqEA5a1hN1bgMMXrdjAb3RxCUuMCktJJxRnUm6IRXBECPlovkdT3ZBF6-SHQh3hwGJ6";
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}