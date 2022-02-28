using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace TFLCodingChallenge.Pages
{
    [Binding]
    public class TFLHomePage
    {
        public IWebDriver Driver { get; }

        public TFLHomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        //Page Object Models for the TFL Home Page

        public IWebElement AcceptAllCookies => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        public IWebElement Source => Driver.FindElement(By.Id("InputFrom"));
        public IWebElement Destination => Driver.FindElement(By.Id("InputTo"));
        public IWebElement PlanMyJourneyButton => Driver.FindElement(By.Id("plan-journey-button"));
        public IWebElement FromError => Driver.FindElement(By.Id("InputFrom-error"));
        public IWebElement ToError => Driver.FindElement(By.Id("InputTo-error"));
        public IWebElement JourneyResultsFrom => Driver.FindElement(By.XPath("//*[@id='plan-a-journey']/div[1]/div[1]/div[1]/span[2]/strong"));
        public IWebElement JourneyResultsTo => Driver.FindElement(By.XPath("//*[@id='plan-a-journey']/div[1]/div[1]/div[2]/span[2]/strong"));
        public IWebElement NewJourney => Driver.FindElement(By.XPath("//*[@id='jp-new-tab-home']/a"));
        public IWebElement Recents => Driver.FindElement(By.LinkText("Recents"));
        public IWebElement RecentText => Driver.FindElement(By.XPath("//*[@id='jp-recent-content-home-']/p[1]"));
        public IWebElement EditJourney => Driver.FindElement(By.XPath("//*[@id='plan-a-journey']/div[1]/div[3]/a/span"));
        public IWebElement UpdateJourney => Driver.FindElement(By.Id("plan-journey-button"));
        public IWebElement PlanJourney => Driver.FindElement(By.LinkText("Plan a journey"));
        public IWebElement RecentsHistory => Driver.FindElement(By.XPath("//*[@id='jp-recent-content-jp-']/p[1]")); //Actual content Xpath => //*[@id='jp-recent-content-jp-']/a[1]
        
        public void AcceptCookies() => AcceptAllCookies.Click();

        public void FromandToLocations(string from, string to)
        {
            Source.Clear();
            Source.SendKeys(from);
            Destination.Clear();
            Destination.SendKeys(to);
            Source.Click();
        }

        public void ClickPlanMyJourneyButton() => PlanMyJourneyButton.Click();

        public void TerminateBrowser() => Driver.Quit();
    }
}
