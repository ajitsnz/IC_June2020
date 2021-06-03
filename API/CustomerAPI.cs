using NUnit.Framework;
using RestSharp;

namespace IC_June2020
{
    public class CustomerAPI : BaseAPI
    {
        public IRestResponse GetAllCustomers()
        {
            string url = $"{baseUrl}/{version}/customers";
            var client = new RestClient(url);
            TestContext.WriteLine(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"bearer {token}");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse GetCustomer(int id)
        {
            string url = $"{baseUrl}/{version}/customers/{id}";
            var client = new RestClient(url);
            TestContext.WriteLine(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"bearer {token}");
            IRestResponse response = client.Execute(request);
            TestContext.WriteLine(response.Content);
            return response;
        }


        public IRestResponse PostCustomer(string body)
        {
            string url = $"{baseUrl}/{version}/customers";
            var client = new RestClient(url);
            // TestContext.WriteLine(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", $"bearer {token}");

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            return response;
        }


        public IRestResponse DeleteCustomer(int id)
        {
            string url = $"{baseUrl}/{version}/customers/{id}";
            var client = new RestClient(url);
            // TestContext.WriteLine(url);
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", $"bearer {token}");
            IRestResponse response = client.Execute(request);
            return response;
        }

        public IRestResponse UpdateCustomer(string body)
        {
            string url = $"{baseUrl}/{version}/customers/12";
            var client = new RestClient(url);
            // TestContext.WriteLine(url);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", $"bearer {token}");

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            //TestContext.WriteLine(response.Content);
            return response;
        }
    }
}
