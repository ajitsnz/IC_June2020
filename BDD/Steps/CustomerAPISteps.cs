using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow;

namespace IC_June2020.BDD.Steps
{
    [Binding]
    public class CustomerAPISteps
    {
        string CustomerJsonBody;
        public CustomerAPI customerApi;
        Customer orgCustomer;


        public readonly ScenarioContext scenarioContext;

        public CustomerAPISteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"Create Customer Data")]
        public void GivenCreateCustomerData()
        {
            customerApi = (CustomerAPI)scenarioContext["API"];
            //Example 
            string authKey = (string)scenarioContext["AuthKey"];
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
            IRestResponse responseData = customerApi.PostCustomer(CustomerJsonBody);
            postResponse = JsonConvert.DeserializeObject<CustomerResponse>(responseData.Content);

        }

        [Then(@"It should be successfully created")]
        public void ThenItShouldBeSuccessfullyCreated()
        {
            //Object1 - postResponse.data 
            //Object2 - orgCustomer

            //   Assert.Multiple(() =>
            //{
            //    Assert.AreEqual(postResponse.data.company_name, orgCustomer.company_name, "comparing company name");
            //    Assert.AreEqual(postResponse.data.country, orgCustomer.country, "comparing country");
            //    Assert.AreEqual(postResponse.data.currency, orgCustomer.currency, "comparing currency");
            //});

            //Fluent Assertion 
            //Hack 
            //postResponse.data.id = 0;

            Customer actual = postResponse.data;

            actual.Should().BeEquivalentTo(orgCustomer, options => options.Excluding(o => o.id));

            //string comparision 
            //  postResponse.data.Should().Be(orgCustomer);

        }

        [When(@"Delete Customer")]
        public void WhenDeleteCustomer()
        {
            //add your code
        }

        [Then(@"It should be successfully Delete")]
        public void ThenItShouldBeSuccessfullyDelete()
        {
            //add your code
        }

        [When(@"Update Customer")]
        public void WhenUpdateCustomer()
        {
            //add your code
        }

        [Then(@"It should be successfully updated")]
        public void ThenItShouldBeSuccessfullyUpdated()
        {
            //add your code
        }


    }
}
