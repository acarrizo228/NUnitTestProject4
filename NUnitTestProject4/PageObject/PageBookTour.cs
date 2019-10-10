using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace NUnitTestProject4.PageObject
{
    class PageBookTour
    {
        By TotalCost = By.XPath("//span[@class='displaytotal']");
        By ButtonBookNow = By.XPath("//form[@role='search']//button");
        By LoggedForm = By.XPath("//form[@id='loggedform']"); 
        By InputFirstName = By.XPath(".//label[contains(text(),'First Name')]/..//input[@class='form-control']");
        By ConfirmButtonBooking = By.XPath("//button[contains(text(),'CONFIRM THIS BOOKING')]");
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
            Actions actions = new Actions(Driver);
            actions.MoveToElement(Driver.FindElement(By.CssSelector("#terms")));
            actions.Perform();
            Driver.FindElement(ButtonBookNow).Click();
        }

        public String GetFirsName()
        {
            String result = Driver.FindElement(LoggedForm).FindElement(InputFirstName).GetAttribute("value").ToString();
            return result;
        }

        public String GetLastName()
        {
            String result = Driver.FindElement(LoggedForm).FindElement(InputLastName).GetAttribute("value").ToString();
            return result;
        }

        public void ConfirmBooking()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(Driver.FindElement(By.CssSelector("#footer")));
            actions.Perform();
            Driver.FindElement(ConfirmButtonBooking).Click();
        }
    }
}
