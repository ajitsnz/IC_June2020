using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace IC_June2020.BDD.framework
{
    [Binding]
    public sealed class Hooks1
    {
        public CustomerAPI custApi;
        public readonly static string email = "user17@sector36.com";
        public readonly static string password = "user@12023";

        public readonly ScenarioContext scenarioContext;

        public Hooks1(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            custApi = new CustomerAPI();
            User user = new User(email, password);
            string auth = JsonConvert.SerializeObject(user);
            string token = BaseAPI.GetAuthToken(auth);
            BaseAPI.token = token;

            //abstration
            scenarioContext["API"] = custApi;
            scenarioContext["AuthKey"] = auth;
        }

        [AfterScenario]
        public void AfterScenario()
        {
        }
    }
}
