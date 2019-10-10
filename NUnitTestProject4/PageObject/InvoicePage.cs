using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System;

namespace NUnitTestProject4.PageObject
{
    class InvoicePage
    {

        By UserName = By.Name("username");
        By Password = By.Name("password");
        By LoginButton = By.XPath("//button[contains(text(),'Login')]");

        By FormInvoice = By.XPath("//table[@id='invoiceTable']//div[contains(text(),'Customer Details')]/..");
        By PersonalInformation = By.XPath(".//div[contains(text(),'User')]");

        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }

        public InvoicePage(IWebDriver driver, WebDriverWait wait)
        {
            this.Driver = driver;
            this.Wait = wait;
        }

        public void AssertPersonalInformation(String username, String lastname)
        {
            Wait.Until(d => d.FindElement(FormInvoice));

            var result = Driver.FindElement(FormInvoice).FindElement(PersonalInformation).Text.ToString();
            Assert.AreEqual(result.ToLower(), username.ToLower() + " " + lastname.ToLower());
            
        }

    }
}
