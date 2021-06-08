using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace IC_June2020.BDD.Steps
{
    [Binding]
    public class CustomerAPISteps
    {
        string CustomerJsonBody;
        public CustomerAPI custApi;
        public readonly static string email = "user17@sector36.com";
        public readonly static string password = "user@12023";
        Customer orgCustomer;
        [Given(@"Create Customer Data")]
        public void GivenCreateCustomerData()
        {
            //Temp 
            custApi = new CustomerAPI();
            User user = new User(email, password);
            string auth = JsonConvert.SerializeObject(user);
            string token = BaseAPI.GetAuthToken(auth);
            BaseAPI.token = token;
            //Temp


            orgCustomer = new Customer
            {
                company_name = "testing",
                country = "NZ",
                currency = "NZ",
                phone = "1231231232",
                website = "www.yahoo.com",
                vat_number = "12312",
                default_language = "en"
            };

            CustomerJsonBody = JsonConvert.SerializeObject(orgCustomer);
        }

        CustomerResponse postResponse;

        [When(@"Post Customer Data")]
        public void WhenPostCustomerData()
        {
            IRestResponse responseData = custApi.PostCustomer(CustomerJsonBody);
            postResponse = JsonConvert.DeserializeObject<CustomerResponse>(responseData.Content);

        }

        [Then(@"It should be successfully created")]
        public void ThenItShouldBeSuccessfullyCreated()
        {
            Assert.Multiple(() =>
         {
             Assert.AreEqual(postResponse.data.company_name, orgCustomer.company_name, "comparing company name");
             Assert.AreEqual(postResponse.data.company_name, orgCustomer.country, "comparing country");
             Assert.AreEqual(postResponse.data.company_name, orgCustomer.currency, "comparing currency");
         });

        }
    }
}
