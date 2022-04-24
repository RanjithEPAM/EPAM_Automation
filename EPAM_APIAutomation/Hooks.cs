using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
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


        static string reportpath = @System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
         + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".html";
        //+ Path.DirectorySeparatorChar + "Result_1.html";

        [AfterScenario]
        public void AfterScenario()
        {
            //BrowserMethods.cleanup();
        }


        [AfterFeature]
        public static void TearDownReport()
        {
            extent.Flush();
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

    }
}