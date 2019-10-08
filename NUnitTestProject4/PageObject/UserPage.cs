using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace NUnitTestProject4.PageObject
{
    class UserPage
    {

        By FlightElement = By.XPath("//span[contains(text(),'Tours')]");

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