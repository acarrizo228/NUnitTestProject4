using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using NUnitTestProject4.PageObject;

namespace NUnitTestProject4
{
    [TestFixture]
    public class Tests
    {
        public IWebDriver driver { get; set; }
        public WebDriverWait wait;

        [SetUp]
        public void CreateDriver()
        {
            //driver = new FirefoxDriver("C:\\Users\\Vladyslav_Lyshchuk\\source\\repos\\NUnitTestProject4\\NUnitTestProject4\\bin\\Debug\\netcoreapp2.2");
            driver = new ChromeDriver("C:\\Users\\Vladyslav_Lyshchuk\\source\\repos\\NUnitTestProject4\\NUnitTestProject4\\bin\\Debug\\netcoreapp2.2");
            wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.phptravels.net/");
        }
        [Test]
        public void Test()
        {
            var travelPage = new TravelPage(driver, wait);
            travelPage.OpenLoginPage();

            var loginPage = new LoginPage(driver);
            var login = "user@phptravels.com";
            var password = "demouser";
            loginPage.Login(login, password);

            var userPage = new UserPage(driver);
            wait.Until(d => d.FindElement(By.XPath("//*[@class='profile-icon']")));
            userPage.OpenFlightsCategory();

            var tourPage = new TourPage(driver, wait);
            tourPage.SelectOrigin();
            tourPage.ChooseGuest("1");
            tourPage.ChooseTourType();
            tourPage.ClickSearchButton();

            var pageBookTour = new PageBookTour(driver, wait);
            pageBookTour.ClickBookNow();
            var username = pageBookTour.GetFirsName();
            var lastname = pageBookTour.GetLastName();
            var cost = pageBookTour.GetTotalCost();
            pageBookTour.ConfirmBooking();

            var invoicePage = new InvoicePage(driver, wait);
            var informationForAssert = invoicePage.GetPersonalInformation(username, lastname);
            Assert.AreEqual(informationForAssert.ToLower(), username.ToLower() + " " + lastname.ToLower());

        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}