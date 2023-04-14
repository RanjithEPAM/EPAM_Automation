using EPAMTraining;
using EPAMTraining.POM;
using EPAMTraining.Utility;
using Exercise_Epam.POM;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static EPAMTraining.Hooks;

namespace Exercise_Epam
{
    [Binding]
    public class ApplicationSteps
    {
        [ThreadStatic]
        public IWebDriver driver;
        public BrowserMethods mds;
        HomePage homepage;
        SelectMenu selectMenu;
        Elements elementsObj;
        private readonly ScenarioContext _scenarioContext;
        public ApplicationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this.driver = Hooks.driver;
        }
        
        [Given(@"I launch the ToolsQA url")]
        public void GivenILaunchTheToolsQAUrl()
        {
            mds = new BrowserMethods(driver);
            driver = mds.NavigateToGivenURL(url);
            homepage = new HomePage(driver);
            elementsObj = new Elements(driver);
        }

        [When(@"I select Elements option")]
        public void WhenISelectElementsOption()
        {
            BrowserMethods.Scroll();
            homepage.ElementsOpt();
        }

        [Then(@"Elements page is displayed")]
        public void ThenElementsPageIsDisplayed()
        {
            elementsObj = new Elements(driver);
            elementsObj.VerifyElementHeader();
        }

        [When(@"Navigating to Select Menu screen")]
        public void WhenNavigatingToSelectMenuScreen()
        {
            BrowserMethods.Scroll();
            selectMenu = new SelectMenu(driver);
            elementsObj.CloseAds();
            BrowserMethods.Scroll();
            selectMenu.NavigateToSelectMenu();
        }

        [Then(@"user should be able to select value from drop downs")]
        public void ThenUserShouldBeAbleToSelectValueFromDropDowns()
        {
            selectMenu = new SelectMenu(driver);
            selectMenu.SelectValueFromSelectMenu();
        }

        [When(@"I navigate to Registration screen")]
        public void WhenINavigateToRegistrationScreen()
        {
            elementsObj = new Elements(driver);
            BrowserMethods.Scroll();
            homepage.ElementsOpt();
            elementsObj.NavigateToRegisterScreen();
        }

        [When(@"the user details are submitted as")]
        public void WhenTheUserDetailsAreSubmittedAs(Table table)
        {
            var inputdata = table.CreateInstance<RegistrationTable>();
            elementsObj.EnterRegistrationDetails(inputdata.Name, inputdata.Email, inputdata.CurrentAddress, inputdata.PermanentAddress);
            _scenarioContext["Name1"] = inputdata.Name;
            _scenarioContext["Email"] = inputdata.Email;
            _scenarioContext["CurrentAddress"] = inputdata.CurrentAddress;
            _scenarioContext["PermanentAddress"] = inputdata.PermanentAddress;
        }

       




        [Then(@"the submitted details should be displayed in the same screen")]
        public void ThenTheSubmittedDetailsShouldBeDisplayedInTheSameScreen()
        {
            BrowserMethods.Scroll();
            elementsObj.VerifyRegisteredSection();
            string Name = _scenarioContext["Name1"].ToString();
            string Email = _scenarioContext["Email"].ToString();
            string CurrentAddress = _scenarioContext["CurrentAddress"].ToString();
            string PermanentAddress = _scenarioContext["PermanentAddress"].ToString();

            elementsObj.VerifySubmittedData(Name, Email, CurrentAddress, PermanentAddress);
        }

        [Then(@"able to collect all links in webpage")]
        public void ThenAbleToCollectAllLinksInWebpage()
        {
            elementsObj.CaptureAllLinks();
        }
    }
}