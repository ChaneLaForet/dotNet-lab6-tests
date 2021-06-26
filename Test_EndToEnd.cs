using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TestsLab6
{
    class Test_EndToEnd
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetupDriver()
        {
            _driver = new ChromeDriver("C:\\Users\\HP\\Documents\\chrome-driver");
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }

        /*
        [Test]
        public void EmagGeniusTextExists()
        {
            _driver.Url = "https://www.emag.ro";
            bool foundGenius = false;
            foreach (var span in _driver.FindElements(By.TagName("span")))
            {
                if (span.Text == "eMAG Genius")
                {
                    foundGenius = true;
                    break;
                }
            }
            Assert.IsTrue(foundGenius);
        }
        */

        [Test]
        public void LoginIsFunctional()
        {
            _driver.Url = "http://localhost:4200/login";
            bool isLoggedIn = false;
            try
            {
                //var email = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-item[1]/ion-input"));
                //var email = _driver.FindElement(By.Name("email"));
                var email = _driver.FindElement(By.TagName("ion-input"));
                email.Click();
                email.SendKeys("mary.sue@gmail.com");
                
                var password = _driver.FindElement(By.Name("password"));
                password.Click();
                password.SendKeys("asdASD1234!@#$");
                
                var submit = _driver.FindElement(By.TagName("ion-button"));
                submit.Click();

                var ionTitle = _driver.FindElement(By.XPath("//ion-title"));
                if (ionTitle.Text == "Movies")
                {
                    isLoggedIn = true;
                }

                Assert.IsTrue(isLoggedIn);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("User is not logged in.");
            }
        }

        /*
        [Test]
        public void UserCanDeleteAMovie()
        {
            _driver.Url = "http://localhost:4200/login";
            bool isLoggedIn = false;
            try
            {
                var email = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-item[1]/ion-input"));
                email.Click();
                email.SendKeys("mary.sue@gmail.com");

                var password = _driver.FindElement(By.Name("password"));
                password.Click();
                password.SendKeys("asdASD1234!@#$");

                var submit = _driver.FindElement(By.TagName("ion-button"));
                submit.Click();

                var ionTitle = _driver.FindElement(By.XPath("//ion-title"));
                if (ionTitle.Text == "Movies")
                {
                    isLoggedIn = true;
                }

                Assert.IsTrue(isLoggedIn);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("User is not logged in.");
            }
        }
        */

        private void logIn()
        {
            var email = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-item[1]/ion-input"));
            email.Click();
            email.SendKeys("mary.sue@gmail.com");

            var password = _driver.FindElement(By.Name("password"));
            password.Click();
            password.SendKeys("asdASD1234!@#$");

            var submit = _driver.FindElement(By.TagName("ion-button"));
            submit.Click();
        }
    }
}
