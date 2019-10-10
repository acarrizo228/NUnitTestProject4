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
        By InvoiceTable = By.XPath("//table[@id='invoiceTable']");
        By PersonalInformation = By.XPath(".//div[contains(text(),'User')]");

        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }

        public InvoicePage(IWebDriver driver, WebDriverWait wait)
        {
            this.Driver = driver;
            this.Wait = wait;
        }

        public String GetPersonalInformation(String username, String lastname)
        {
            Wait.Until(d => d.FindElement(InvoiceTable));

            return Driver.FindElement(InvoiceTable).FindElement(PersonalInformation).Text.ToString();

        }

    }
}
