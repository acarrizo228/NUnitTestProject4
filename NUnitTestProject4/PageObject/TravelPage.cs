using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace ExperienceWithSeleniumWeb
{
    class TravelPage
    {
        By ButtonMyAccount = By.XPath("//nav[contains(@class,'navbar')]//*[contains(text(),'My Account')]");
        By ButtonLogin = By.XPath("//nav[contains(@class,'navbar')]//a[contains(text(),'Login')]");
        By Forma = By.Id("thflights");
        By InputOrigin = By.XPath(".//input[@id='origin']/..//input");
        By InputDestination = By.XPath(".//input[@id='destination']/..//input");
        By InputPassanger = By.XPath(".//*[@name='totalManualPassenger']");
        By SearchButton = By.XPath("//*[@id='thflights']//div[@class='clearfix']/../button");

        private IWebDriver Driver { get; set; }
        private WebDriverWait wait { get; set; }

        public TravelPage(IWebDriver driver, WebDriverWait wait)
        {
            this.Driver = driver;
            this.wait = wait;

        }


        public void OpenLoginPage()
        {
            Driver.FindElement(ButtonMyAccount).Click();
            Driver.FindElement(ButtonLogin).Click();
        }

        public void SelectOrigin(String text)
        {
            Driver.FindElement(Forma).FindElement(InputOrigin).SendKeys(text);
            wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'East')]")));
            Driver.FindElement(By.XPath("//*[contains(text(),'East')]")).Click();
        }

        public void SelectDestination(String text)
        {
            Driver.FindElement(Forma).FindElement(InputDestination).SendKeys(text);
            wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'New York')]")));
            Driver.FindElement(By.XPath("//*[contains(text(),'New York')]")).Click();
        }

        public void ChoosePassanger(String number)
        {
            Driver.FindElement(InputPassanger).SendKeys(number);
        }
        public void ClickSearchButton()
        {
            Driver.FindElement(SearchButton).Click();
        }
    }
}