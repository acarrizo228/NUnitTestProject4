using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace NUnitTestProject4.PageObject
{
    class LoginPage
    {

        By UserName = By.Name("username");
        By Password = By.Name("password");
        By LoginButton = By.XPath("//button[contains(text(),'Login')]");

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Login(String username, String password)
        {
            driver.FindElement(UserName).SendKeys(username);
            driver.FindElement(Password).SendKeys(password);

            driver.FindElement(LoginButton).Click();
        }
        
    }
}