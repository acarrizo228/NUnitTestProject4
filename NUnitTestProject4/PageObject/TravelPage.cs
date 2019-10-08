using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace NUnitTestProject4.PageObject
{
    class TravelPage
    {
        By ButtonMyAccount = By.XPath("//nav[contains(@class,'navbar')]//*[contains(text(),'My Account')]");
        By ButtonLogin = By.XPath("//nav[contains(@class,'navbar')]//a[contains(text(),'Login')]");
        By Forma = By.Id("thflights");
        By InputOrigin = By.XPath("//input[@id='origin']/..");
        By InputDestination = By.XPath("//input[@id='destination']/..");
        By InputPassanger = By.XPath(".//*[@name='totalManualPassenger']");
        By SearchButton = By.XPath(".//div[contains(@class,'search-button')]//button");
        By SelectDropDown = By.XPath("//li[@class='select2-results-dept-0 select2-result select2-result-selectable select2-highlighted']");

        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }

        public TravelPage(IWebDriver driver, WebDriverWait wait)
        {
            this.Driver = driver;
            this.Wait = wait;

        }


        public void OpenLoginPage()
        {
            Driver.FindElement(ButtonMyAccount).Click();
            Driver.FindElement(ButtonLogin).Click();
        }

        public void SelectOrigin(String text)
        {
            Driver.FindElement(InputOrigin).FindElement(By.XPath(".//input")).SendKeys(text);
            SelectDropDownElement();
        }

        public void SelectDestination(String text)
        {
            Driver.FindElement(InputDestination).FindElement(By.XPath(".//input")).SendKeys(text);
            SelectDropDownElement();
        }

        public void ChoosePassanger(String number)
        {
            Driver.FindElement(InputPassanger).SendKeys(number);
        }
        public void ClickSearchButton()
        {
            Driver.FindElement(Forma).FindElement(SearchButton).Click();
        }

        public void SelectDropDownElement()
        {
            Wait.Until(d => d.FindElement(SelectDropDown));
            Driver.FindElement(SelectDropDown).Click();
        }
    }
}