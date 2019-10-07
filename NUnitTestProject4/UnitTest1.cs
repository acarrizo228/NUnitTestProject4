using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace ExperienceWithSeleniumWeb
{
    [TestFixture]
    public class Tests
    {
        public IWebDriver driver { get; set; }
        public WebDriverWait wait;

        /*TravelPage travelPage;
        LoginPage loginPage;
        UserPage userPage;*/

        [SetUp]
        public void CreateDriver()
        {
            driver = new ChromeDriver("C:\\Users\\Vladyslav_Lyshchuk\\source\\repos\\NUnitTestProject4\\NUnitTestProject4\\bin\\Debug\\netcoreapp2.2");
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.phptravels.net/");
        }
        [Test]
        public void Test()
        {

            TravelPage travelPage = new TravelPage(driver, wait);
            LoginPage loginPage = new LoginPage(driver);
            UserPage userPage = new UserPage(driver);

            String login = "user@phptravels.com";
            String password = "demouser";

            travelPage.OpenLoginPage();
            loginPage.Login(login, password);
            wait.Until(d => d.FindElement(By.XPath("//*[@class='profile-icon']")));
            userPage.OpenFlightsCategory();
            travelPage.SelectOrigin("London");
            travelPage.SelectDestination("Monroe");
            travelPage.ChoosePassanger("1");
            travelPage.ClickSearchButton();

            //_wait.Until(d => d.FindElement(By.XPath("//*[@id='all_flights']")));
            driver.FindElement(By.XPath("//*[@id='all_flights']/div[1]")).Click();
            Thread.Sleep(10000);
        }

        /*private void ClickSearchButton()
        {
            var tabPanel = driver.FindElement(By.CssSelector(".tab-pane.fade.active.in"));
            tabPanel.FindElement(By.XPath(".//button[contains(text(),'Search')]")).Click();
        }*/
        /*private void ChoosePassanger(String number)
        {
            driver.FindElement(By.XPath("//*[@name='totalManualPassenger']")).SendKeys(number);
        }*/
        /*private void ChooseDestination(String text)
        {
            var forma = driver.FindElement(By.Id("thflights"));
            forma.FindElement(By.XPath("//input[@id='destination']/..//input")).SendKeys(text);
            _wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'New York')]")));
            driver.FindElement(By.XPath("//*[contains(text(),'New York')]")).Click();
        }*/
        /*private void ChooseOrigin(String text)
        {
            var forma = driver.FindElement(By.Id("thflights"));
            forma.FindElement(By.XPath(".//input[@id='origin']/..//input")).SendKeys(text);
            _wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'East')]")));
            driver.FindElement(By.XPath("//*[contains(text(),'East')]")).Click();
        }*/
        /*private void OpenFlightsCategory()
        {
            driver.FindElement(By.XPath("//span[contains(text(),'Flights')]/..")).Click();
        }*/

        /*private void LoginInSite(String username, String passwd)
        {
            driver.FindElement(By.Name("username")).SendKeys(username);
            driver.FindElement(By.Name("password")).SendKeys(passwd);
            driver.FindElement(By.XPath("//button[contains(text(),'Login')]")).Click();

            _wait.Until(d => d.FindElement(By.XPath("//*[@class='profile-icon']")));
        }*/

        /*private void OpenLoginPage()
        {
            var navigationBar = driver.FindElement(By.XPath("//nav[contains(@class,'navbar')]"));
            navigationBar.FindElement(By.XPath(".//*[contains(@class,'dropdown-toggle')]")).Click();
            navigationBar.FindElement(By.XPath(".//a[contains(text(),'Login')]")).Click();
        }*/

        /*private void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://www.phptravels.net/");
        }*/

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}