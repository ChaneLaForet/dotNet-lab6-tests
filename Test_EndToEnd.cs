using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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

        [Test]
        public void LoginIsFunctional()
        {
            _driver.Url = "http://localhost:4200/login";
            bool isLoggedIn = false;

            wait(2000);

            try
            {

                //var email = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-item[1]/ion-input"));
                //var email = _driver.FindElement(By.Name("email"));
                var email = _driver.FindElement(By.Name("email")).FindElement(By.Name("email"));
                email.Click();
                email.SendKeys("mary.sue@gmail.com");
                wait(1000);

                var password = _driver.FindElement(By.Name("password")).FindElement(By.Name("password")); ;
                password.Click();
                password.SendKeys("asdASD1234!@#$");
                wait(2000);

                var submit = _driver.FindElement(By.TagName("ion-button"));
                submit.Click();
                wait(2000);

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

        /* //element is not interactable
        [Test]
        public void LoginIsFunctional()
        {
            _driver.Url = "http://localhost:4200/login";
            bool isLoggedIn = false;

            wait(2000);

            try
            {

                //var email = _driver.FindElement(By.XPath("//*[@id='content1']/app-login/ion-content/div/form/ion-item[1]/ion-input"));
                //var email = _driver.FindElement(By.Name("email"));
                 _driver.FindElement(By.TagName("ion-input")).SendKeys("aaa");
                email.Click();
                email.SendKeys("mary.sue@gmail.com");
                wait(1000);
                
                var password = _driver.FindElement(By.Name("password"));
                password.Click();
                password.SendKeys("asdASD1234!@#$");
                wait(1000);
                
                var submit = _driver.FindElement(By.TagName("ion-button"));
                submit.Click();
                wait(2000);

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

        private void wait(int timeout)
        {
            //var timeout = 5000;
            var wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(timeout));
            try
            {
                wait.Until(d => false);
            }
            catch (WebDriverTimeoutException wdtex)
            {

            }
        }
    }
}
