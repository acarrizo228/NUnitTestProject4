using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace NUnitTestProject4.PageObject
{
    class TourPage
    {
        By Forma = By.Id("tours");
        By InputSearchTour = By.XPath("//*[@id='txtsearch']/..//a[contains(@class,'select2-choice')]");
        By SelectDropDown = By.XPath("//li[@class='select2-results-dept-1 select2-result select2-result-selectable']");
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
            SelectElement element = new SelectElement(Driver.FindElement(By.XPath("//select[@name='adults']")));
            //element.SelectByText("1 Guest");
            element.SelectByIndex(1);
        }
        public void ChooseTourType()
        {
            SelectElement element = new SelectElement(Driver.FindElement(By.XPath("//select[@id='tourtype']")));
            element.SelectByIndex(2); 
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