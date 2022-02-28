using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TFLCodingChallenge.Pages;

namespace TFLCodingChallenge.StepDefinition
{
    [Binding, Scope(Tag = "TFL")]
    public sealed class JourneyPlannerSteps
    {
        TFLHomePage tflHomePage = null;
        //TFLHooks tflHooks = null;
        public static IWebDriver driver;
        readonly String AppURL = "https://tfl.gov.uk/";

        [Given(@"I launch the chrome browser and maximize it")]
        public void GivenILaunchTheChromeBrowserAndMaximizeIt()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            tflHomePage = new TFLHomePage(driver);
            //tflHooks = new TFLHooks(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Given(@"I launch the TFL site")]
        public void GivenILaunchTheTFLSite()
        {
            driver.Navigate().GoToUrl(AppURL);
            tflHomePage.AcceptCookies(); //Method to accept all cookies

            Actions actionObj = new Actions(driver);
            //To press the Done button after accepting cookies
            actionObj.SendKeys(Keys.Tab).SendKeys(Keys.Enter).Build().Perform();
        }

        [Given(@"I enter the source and destination locations in TFL site")]
        public void GivenIEnterTheSourceAndDestinationLocationsInTFLSite(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            tflHomePage.FromandToLocations((string)data.Source, (string)data.Destination);
        }

        [When(@"I click Plan my Journey button without proving From and To locations")]
        [When(@"I click Plan my Journey button")]
        [Given(@"I click Plan my Journey button")]
        public void WhenIClickPlanMyJourneyButton()
        {
            tflHomePage.ClickPlanMyJourneyButton();
        }

        [Then(@"The displayed journey details are validated")]
        public void ThenTheDisplayedJourneyDetailsAreValidated()
        {
            ThenTheJourneyDetailsAreDisplayed();
            driver.Close();
        }

        [Given(@"The journey details are displayed")]
        public void ThenTheJourneyDetailsAreDisplayed()
        {
            String Title = "Journey results - Transport for London";
            Assert.AreEqual(driver.Title, Title);
            Assert.IsTrue(driver.FindElement(By.Id("disambiguation-options-from")).Displayed);

            Assert.AreEqual("Barking", tflHomePage.JourneyResultsFrom.Text);
            Assert.AreEqual("North Greenwich", tflHomePage.JourneyResultsTo.Text);
        }

        [Then(@"An error message is displayed")]
        public void ThenAnErrorMessageIsDisplayed(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            String Error = "Journey planner could not find any results to your search. Please try again";
            Assert.AreEqual(Error, (string)data.ErrorMessage);
            driver.Close();
        }

        [Then(@"Appropriate error messages are displayed in journey planner widget")]
        public void ThenAppropriateErrorMessagesAreDisplayedInJourneyPlannerWidget()
        {
            Assert.AreEqual("The From field is required.", tflHomePage.FromError.Text);
            Assert.AreEqual("The To field is required.", tflHomePage.ToError.Text);
            driver.Close();
        }

        [When(@"I select Edit Journey option in journey results page")]
        public void WhenISelectEditJourneyOptionInJourneyResultsPage()
        {
            tflHomePage.EditJourney.Click();
        }

        [When(@"I update the From location as ""(.*)""")]
        public void WhenIUpdateTheFromLocationAs(string sourcelocation)
        {
            tflHomePage.Source.Clear();
            tflHomePage.Source.Click();

            Actions actionObj = new Actions(driver);
            actionObj.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete).Build().Perform();

            tflHomePage.Source.SendKeys(sourcelocation);
        }

        [When(@"I press Update Journey button")]
        public void WhenIPressUpdateJourneyButton()
        {
            tflHomePage.UpdateJourney.Click();
        }

        [Then(@"The updated journey details are displayed")]
        public void ThenTheUpdatedJourneyDetailsAreDisplayed()
        {
            Assert.AreEqual("Canary Wharf", tflHomePage.JourneyResultsFrom.Text);
            Assert.AreEqual("North Greenwich", tflHomePage.JourneyResultsTo.Text);
            driver.Close();
        }

        [Given(@"I press Plan a Journey button")]
        public void GivenIPressPlanAJourneyButton()
        {
            tflHomePage.PlanJourney.Click();
        }

        [Given(@"I press Recents tab")]
        [When(@"I press Recents tab")]
        public void WhenIPressRecentsTab()
        {
            tflHomePage.Recents.Click();
        }

        [Then(@"The recent search history should be displayed")]
        public void ThenTheRecentSearchHistoryShouldBeDisplayed()
        {
            Assert.AreEqual("Barking to North Greenwich", tflHomePage.RecentsHistory.Text);
            driver.Close();
        }
    }
}
