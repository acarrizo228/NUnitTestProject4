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
        By InputFirstName = By.XPath("//label[contains(text(),'First Name')]");
        By ConfirmButtonBooking = By.XPath("//button[contains(text(),'CONFIRM THIS BOOKING')]");
        By InputLastName = By.XPath("//label[contains(text(),'Last Name')]");
        By FormControl = By.XPath("./following-sibling::input");
        By Terms = By.CssSelector("#terms");
        By Footer = By.CssSelector("#footer");
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
            ScrollPage(Terms);
            Driver.FindElement(ButtonBookNow).Click();
        }

        public String GetFirsName()
        {
            String result = Driver.FindElement(InputFirstName).FindElement(FormControl).GetAttribute("value").ToString();
            return result;
        }

        public String GetLastName()
        {
            String result = Driver.FindElement(InputLastName).FindElement(FormControl).GetAttribute("value").ToString();
            return result;
        }

        public void ConfirmBooking()
        {
            ScrollPage(Footer);
            Driver.FindElement(ConfirmButtonBooking).Click();
        }

        public void ScrollPage(By selector)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(Driver.FindElement(selector));
            actions.Perform();
        }
    }
}
