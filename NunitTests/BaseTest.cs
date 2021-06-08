using Newtonsoft.Json;
using NUnit.Framework;

namespace IC_June2020
{
    public class BaseTest
    {

        public CustomerAPI custApi;
        public readonly static string email = "user17@sector36.com";
        public readonly static string password = "user@12023";

        [OneTimeSetUp]
        public void Setup()
        {
            custApi = new CustomerAPI();
            User user = new User(email, password);
            string auth = JsonConvert.SerializeObject(user);
            string token = BaseAPI.GetAuthToken(auth);
            BaseAPI.token = token;
        }

    }
}