using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace NUnitTestProject4.PageObject
{
    class PageBookTour
    {
        By TotalCost = By.XPath("//span[@class='totalCost']/strong");
        By ButtonBookNow = By.XPath("//form[@role='search']//button");
        By LoggedForm = By.XPath("//form[@id='loggedform']"); 
        By InputFirstName = By.XPath(".//label[contains(text(),'First Name')]/..//input[@class='form-control']");
        By InputLastName = By.XPath(".//label[contains(text(),'Last Name')]/..//input[@class='form-control']");
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }
        public PageBookTour(IWebDriver driver, WebDriverWait wait)
        {
            this.Driver = driver;
            this.Wait = wait;

        }

        public String GetTotalCost()
        {
            var totalCost = TotalCost.ToString();
            return totalCost;
        }

        public void ClickBookNow()
        {
            Driver.FindElement(ButtonBookNow).Click();
        }

        public void AssertFirsName(String firstname)
        {
            var expected = Driver.FindElement(LoggedForm).FindElement(InputFirstName).GetAttribute("value").ToString();
            Assert.AreEqual(firstname, expected);
        }

        public void AssertLastName(String lastname)
        {
            var expected = Driver.FindElement(LoggedForm).FindElement(InputFirstName).GetAttribute("value").ToString();
            Assert.AreEqual(lastname, expected);
        }
    }
}
