using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace ExperienceWithSeleniumWeb
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

        public void Login(String username, String passwd)
        {
            driver.FindElement(UserName).SendKeys(username);
            driver.FindElement(Password).SendKeys(passwd);

            driver.FindElement(LoginButton).Click();
        }
        
    }
}