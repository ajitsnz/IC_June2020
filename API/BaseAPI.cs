using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace IC_June2020
{
    public class BaseAPI
    {
        public static string baseUrl = "http://api.qaauto.co.nz/api";
        public static string version = "v1";
        public static string token;

        public static string GetAuthToken(string auth)
        {
            var client = new RestClient($"{baseUrl}/{version}/auth/login");
            TestContext.WriteLine($"{baseUrl}/{version}/auth/login");
            var request = new RestRequest(Method.POST);

            //Headers
            request.AddHeader("Content-Type", "application/json");

            //How to set body 
            request.AddParameter("application/json", auth, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            string jsonData = response.Content;
            Token data = JsonConvert.DeserializeObject<Token>(jsonData);

            return data.access_token;

        }
    }
}