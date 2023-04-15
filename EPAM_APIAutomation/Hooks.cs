using APIAutomationTests.Config;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace APIAutomationTests
{
    [Binding]
    public sealed class Hooks
    {
        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        static AventStack.ExtentReports.ExtentTest scenario;
        private static ExtentTest step;


        public static string reportpath;
       

        [AfterScenario]
        public void AfterScenario()
        {
            //BrowserMethods.cleanup();
        }


        [AfterFeature]
        public static void TearDownReport()
        {
            extent.Flush();
            //comment
        }


        [BeforeTestRun]
        public static void InitializeReport()
        {
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        }


        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            feature = extent.CreateTest(featurecontext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            scenario = feature.CreateNode(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {

            if (context.TestError == null)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)

            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
            step.Log(Status.Info, "Step initiated");
        }

        public static void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Ranjith_Paramasivam\source\repos\EPAM_Automation\EPAM_UIAutomation\EPAM_UIAutomation\Utility\Config.json"))
            {
                string json = r.ReadToEnd();
                APIData items = JsonConvert.DeserializeObject<APIData>(json);
                reportpath = items.ReportPath;
            }
        }
    }
}