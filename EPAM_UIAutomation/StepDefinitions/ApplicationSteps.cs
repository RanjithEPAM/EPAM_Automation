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

namespace Exercise_Epam
{
    [Binding]
    public class ApplicationSteps
    {
        public BrowserMethods mds;
        public IWebDriver driver;
        HomePage homepage;
        SelectMenu selectMenu;
        Elements elem;
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
            driver = mds.NavigateToGivenURL("https://demoqa.com/");
            homepage = new HomePage(driver);
            elem = new Elements(driver);
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
            elem = new Elements(driver);
            elem.VerifyElementHeader();
        }

        [When(@"Navigating to Select Menu screen")]
        public void WhenNavigatingToSelectMenuScreen()
        {
            BrowserMethods.Scroll();
            selectMenu = new SelectMenu(driver);
            elem.CloseAds();
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
            elem = new Elements(driver);
            BrowserMethods.Scroll();
            homepage.ElementsOpt();
            elem.NavigateToRegisterScreen();
        }

        [When(@"the user details are submitted as")]
        public void WhenTheUserDetailsAreSubmittedAs(Table table)
        {
            var inputdata = table.CreateInstance<RegistrationTable>();
            elem.EnterRegistrationDetails(inputdata.Name, inputdata.Email, inputdata.CurrentAddress, inputdata.PermanentAddress);
            _scenarioContext["Name1"] = inputdata.Name;
            _scenarioContext["Email"] = inputdata.Email;
            _scenarioContext["CurrentAddress"] = inputdata.CurrentAddress;
            _scenarioContext["PermanentAddress"] = inputdata.PermanentAddress;
        }

        [Then(@"the submitted details should be displayed in the same screen")]
        public void ThenTheSubmittedDetailsShouldBeDisplayedInTheSameScreen()
        {
            BrowserMethods.Scroll();
            elem.VerifyRegisteredSection();
            string Name = _scenarioContext["Name1"].ToString();
            string Email = _scenarioContext["Email"].ToString();
            string CurrentAddress = _scenarioContext["CurrentAddress"].ToString();
            string PermanentAddress = _scenarioContext["PermanentAddress"].ToString();

            elem.VerifySubmittedData(Name, Email, CurrentAddress, PermanentAddress);
        }

        [Then(@"able to collect all links in webpage")]
        public void ThenAbleToCollectAllLinksInWebpage()
        {
            elem.CaptureAllLinks();
        }

    }
}