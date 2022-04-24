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
        static AventStack.ExtentReports.ExtentTest feature;
        static AventStack.ExtentReports.ExtentTest scenario;
        private static ExtentTest step;

        public  static string repoPath;
        public static dynamic jsonFile;
        /*
        static string reportpath = @System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
        // + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".html";
        + Path.DirectorySeparatorChar + "Result_1.html";
        */


        public static DriverManager drivermanager;
        public static IWebDriver driver;

        [AfterScenario]
        public void AfterScenario()
        {
           // drivermanager.quitdriver();
        }

        [AfterFeature]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //ReadJsonFile(@"C:\Users\Ranjith_Paramasivam\source\repos\EPAMTraining\Config.Json");
           // string repoPath = ConfigurationManager.AppSettings["reportpath"];
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(repoPath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
            drivermanager = DriverManagerFactory.getManager(DriverType.CHROME);
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
                step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
            step.Log(Status.Info, "Step initiated");
        }


        public static void ReadJsonFile(string jsonFileIn)
        {
            jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(jsonFileIn));

            Console.WriteLine($"Today's Video is: {jsonFile["ReportPath"]}");
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Ranjith_Paramasivam\source\repos\EPAMTraining\Utility\Config.json"))
            {
                string json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                //repoPath= items.
            }
        }
    }
}