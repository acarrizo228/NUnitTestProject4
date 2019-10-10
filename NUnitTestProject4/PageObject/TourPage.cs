using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System;

namespace NUnitTestProject4.PageObject
{
    class TourPage
    {
        By Forma = By.Id("tours");
        By InputSearchTour = By.XPath("//input[@id='txtsearch']/parent::div//a[contains(@class,'select2-choice')]");
        By SelectDropDown = By.XPath("//div[contains(text(),'Tours')]/following-sibling::ul/li");
        By SearchButton = By.XPath(".//div[contains(@class,'search-button')]//button");
       
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }

        public TourPage(IWebDriver driver, WebDriverWait wait)
        {
            this.Driver = driver;
            this.Wait = wait;

        }

        public void SelectOrigin()
        {
            Driver.FindElement(InputSearchTour).Click();
            SelectDropDownElement();
        }

        public void ChooseGuest(String number)
        {
            var rand = new Random();
            var elements = Driver.FindElement(By.XPath("//select[@name='adults']")).FindElements(By.XPath("./options"));
            var length = elements.Count();
            var i = rand.Next(0, length);
            SelectElement select = new SelectElement(Driver.FindElement(By.CssSelector("#tourtype")));
            select.SelectByIndex(i);
        }
        public void ChooseTourType()
        {
            var rand = new Random();
            var elements = Driver.FindElement(By.CssSelector("#tourtype")).FindElements(By.XPath("./options"));
            var length = elements.Count();
            var i = rand.Next(0, length);
            SelectElement select = new SelectElement(Driver.FindElement(By.CssSelector("#tourtype")));
            select.SelectByIndex(i);

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