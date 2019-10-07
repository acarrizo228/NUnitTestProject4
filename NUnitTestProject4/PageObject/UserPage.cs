using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace ExperienceWithSeleniumWeb
{
    class UserPage
    {

        By FlightElement = By.XPath("//span[contains(text(),'Flights')]/..");

        private IWebDriver driver;

        public UserPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenFlightsCategory()
        {
            driver.FindElement(FlightElement).Click();
        }

    }
}