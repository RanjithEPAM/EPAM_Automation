using APIAutomationTests.Helper;
using APIAutomationTests.JsonModel;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace APIAutomationTests.StepDefinitions
{
    [Binding]
    public class API_Steps
    {
        
        public string GetEndpoint = "https://reqres.in/api/users?page=2";
        private string PostEndpoint = "https://reqres.in/api/users";
        private string PutEndpoint = "https://reqres.in/api/users";
        private string DeleteEndpoint = "https://reqres.in/api/users/2";
        

        HttpClient httpClient = new HttpClient();
        HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
        private readonly ScenarioContext _scenarioContext;
        public API_Steps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have a GET request for ReqRes API")]
        public void GivenIHaveAGETRequestForReqResAPI()
        {
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json");
        }

        [When(@"I send the GET request for ReqRes API")]
        public void WhenISendTheGETRequestForReqResAPI()
        {
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(GetEndpoint);
            httpResponseMessage = httpResponse.Result;
            HttpContent content = httpResponse.Result.Content;
            string responsedata = content.ReadAsStringAsync().Result;
        }

        [Then(@"I receive the response")]
        public void ThenIReceiveTheResponse()
        {
            string responsecode = httpResponseMessage.StatusCode.ToString();
        }

        [Then(@"the status code should be (.*)")]
        public void ThenTheStatusCodeShouldBe(int statCode)
        {
            Assert.AreEqual(statCode, (int)httpResponseMessage.StatusCode);
        }

        [Given(@"I have a POST request for ReqRes API")]
        public void GivenIHaveAPOSTRequestForReqResAPI()
        {
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json");
        }

        [When(@"I send the POST request for ReqRes API as")]
        public void WhenISendThePOSTRequestForReqResAPIAs(Table table)
        {
            var inputdata = table.CreateInstance<Request>();
            string jsonString = Reusable_Methods.FrameRequest(inputdata.Name, inputdata.Job);
            _scenarioContext["Req.Name"] = inputdata.Name;
            _scenarioContext["Req.Job"] = inputdata.Job;
            var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

            Task<HttpResponseMessage> httpResponse = httpClient.PostAsync(PostEndpoint, data);
            httpResponseMessage = httpResponse.Result;
        }

        [Then(@"the new user should be created with (.*) status code")]
        public void ThenTheNewUserShouldBeCreatedWithStatusCode(int statCode)
        {
            string responsedata = httpResponseMessage.Content.ReadAsStringAsync().Result;

            Users users = JsonConvert.DeserializeObject<Users>(responsedata);
            
            Assert.AreEqual(statCode, (int)httpResponseMessage.StatusCode);
            Assert.AreEqual(_scenarioContext["Req.Name"].ToString().ToLower(), users.Name.ToString().ToLower());
            Assert.AreEqual(_scenarioContext["Req.Job"].ToString().ToLower(), users.Job.ToString().ToLower());
            httpClient.Dispose();
        }


        [Given(@"I have a PUT request for ReqRes API")]
        public void GivenIHaveAPUTRequestForReqResAPI()
        {
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json");
        }

        [When(@"I send the PUT request for ReqRes API as")]
        public void WhenISendThePUTRequestForReqResAPIAs(Table table)
        {
            var inputdata = table.CreateInstance<Request>();
            string jsonString = Reusable_Methods.FrameRequest(inputdata.Name, inputdata.Job);
            _scenarioContext["Req.Name"] = inputdata.Name;
            _scenarioContext["Req.Job"] = inputdata.Job;
            var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

            Task<HttpResponseMessage> httpResponse = httpClient.PutAsync(PutEndpoint, data);
            httpResponseMessage = httpResponse.Result;
        }

        [Then(@"the given user should be úpdated with (.*) status code")]
        public void ThenTheGivenUserShouldBeUpdatedWithStatusCode(int statCode)
        {
            string responsedata = httpResponseMessage.Content.ReadAsStringAsync().Result;

            Users users = JsonConvert.DeserializeObject<Users>(responsedata);

            Assert.AreEqual(statCode, (int)httpResponseMessage.StatusCode);
            Assert.AreEqual(_scenarioContext["Req.Name"].ToString().ToLower(), users.Name.ToString().ToLower());
            Assert.AreEqual(_scenarioContext["Req.Job"].ToString().ToLower(), users.Job.ToString().ToLower());
            httpClient.Dispose();
        }


        [Given(@"I have a DELETE request for ReqRes API")]
        public void GivenIHaveADELETERequestForReqResAPI()
        {
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json");
        }

        [When(@"I send the DELETE request for ReqRes API as")]
        public void WhenISendTheDELETERequestForReqResAPIAs(Table table)
        {
            var inputdata = table.CreateInstance<Request>();
            string jsonString = Reusable_Methods.FrameRequest(inputdata.Name, inputdata.Job);
            _scenarioContext["Req.Name"] = inputdata.Name;
            _scenarioContext["Req.Job"] = inputdata.Job;
            var data = new StringContent(jsonString, Encoding.UTF8, "application/json");

            Task<HttpResponseMessage> httpResponse = httpClient.DeleteAsync(DeleteEndpoint);
            httpResponseMessage = httpResponse.Result;
        }

        [Then(@"the given user should be deleted with (.*) status code")]
        public void ThenTheGivenUserShouldBeDeletedWithStatusCode(int statCode)
        {
            Assert.AreEqual(statCode, (int)httpResponseMessage.StatusCode);
        }

    }
}