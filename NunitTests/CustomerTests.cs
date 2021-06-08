using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
//read http
namespace IC_June2020
{
    public class CustomerTests : BaseTest
    {
        [Test]
        public void Create_Customer_Test()
        {

            //Create customer 
            Customer cust = new Customer
            {
                company_name = "testing",
                country = "NZ",
                currency = "NZ",
                phone = "1231231232",
                website = "www.yahoo.com",
                vat_number = "12312",
                default_language = "en"
            };


            //Serializing body 
            string jsonBody = JsonConvert.SerializeObject(cust);


            //post customer 
            IRestResponse responseData = custApi.PostCustomer(jsonBody);

            TestContext.WriteLine(responseData.Content);

            //deserialize object 
            CustomerResponse postResponse = JsonConvert.DeserializeObject<CustomerResponse>(responseData.Content);

            int id = postResponse.data.id;


            IRestResponse getRes = custApi.GetCustomer(id);

            CustomerResponse getResponse = JsonConvert.DeserializeObject<CustomerResponse>(getRes.Content);

            //Validating reponse .....

        }

        [Test]
        public void Delete_Customer_Test()
        {

            Customer cust = new Customer
            {
                company_name = "testing",
                country = "NZ",
                currency = "NZ",
                phone = "1231231232",
                website = "www.yahoo.com",
                vat_number = "12312",
                default_language = "en"
            };


            string jsonBody = JsonConvert.SerializeObject(cust);

            IRestResponse responseData = custApi.PostCustomer(jsonBody);

            TestContext.WriteLine(responseData.Content);

            CustomerResponse res = JsonConvert.DeserializeObject<CustomerResponse>(responseData.Content);

            int id = res.data.id;

            custApi.DeleteCustomer(id);
        }

        [Test]
        public void Get_Customer_Test()
        {
            //post
            //read 
            //validate 
        }

        [Test]
        public void Put_Customer_Test()
        {
            //post
            //put 
            //read 
            //validate
            //test

        }

        [Test]
        public void Get_All_Customers_Test()
        {
            //read all record 
            //iterate 
            //validate success message...
            //print id of each record...

        }
    }
}