using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.IO;
using EPAMTraining.Utility;
using OpenQA.Selenium;
using System.Configuration;
using Newtonsoft.Json;
using static EPAMTraining.Utility.ConfigClass;

namespace EPAMTraining
{
    [Binding]
    public sealed class Hooks
    {
        static AventStack.ExtentReports.ExtentReports extent;
        [ThreadStatic]
        static AventStack.ExtentReports.ExtentTest feature;
        static AventStack.ExtentReports.ExtentTest scenario;
        private static ExtentTest step;

        public  static string repoPath;
        public static string url;
        public static string browserType;
        public static dynamic jsonFile;

        public static DriverManager drivermanager;
        public static IWebDriver driver;
        

        [AfterScenario]
        public void AfterScenario()
        {
           drivermanager.quitdriver();
        }

        [AfterFeature]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            Hooks.LoadJson();
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(repoPath);
            htmlReport.Config.DocumentTitle = "Report001.html";
            extent = new AventStack.ExtentReports.ExtentReports();
            
            extent.AttachReporter(htmlReport);
            drivermanager = DriverManagerFactory.getManager(browserType);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            feature = extent.CreateTest(featurecontext.FeatureInfo.Title);
            feature.Log(Status.Info, "Feature is starting");
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            driver = drivermanager.getdriver();
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
                var MediaEntity = CaptureScreenshotReturnModel(context.StepContext.StepInfo.Text);
                step.Log(Status.Fail, context.StepContext.StepInfo.Text, MediaEntity);
            }
        }

        public void ReportLogs( string Description)
        {
            step.Log(Status.Pass, Description);
        }

        public static void ReadJsonFile(string jsonFileIn)
        {
            jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(jsonFileIn));

            Console.WriteLine($"Today's Video is: {jsonFile["ReportPath"]}");
        }

        public static void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Ranjith_Paramasivam\source\repos\EPAM_Automation\EPAM_UIAutomation\EPAM_UIAutomation\Utility\Config.json"))
            {
                string json = r.ReadToEnd();
                Item items = JsonConvert.DeserializeObject<Item>(json);
                repoPath = items.ReportPath;
                browserType = items.Browser;
                url = items.URL;
            }
        }

        public MediaEntityModelProvider CaptureScreenshotReturnModel(string Name)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,Name).Build();

        }
    }
}