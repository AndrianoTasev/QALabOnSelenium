using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace QALabOnSelenium
{
    [TestClass]
    public class QaLabOnSelenium
    {
        IWebDriver driver = new FirefoxDriver();

        [TestMethod]
        public void SuccessfulLogin_Test()
        {
            
            Login();

            driver.Quit();
        }

        private void Login()
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://www.abv.bg/");

            var username = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/form/div[1]/input[1]"));
            username.SendKeys("jorojoro.jorojoro");

            var userPassword = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/form/div[1]/input[2]"));
            userPassword.SendKeys("jorojoro.jorojoro");

            var loginButton = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/form/div[1]/input[3]"));
            loginButton.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            var correctUser =
                driver.FindElement(
                    By.XPath("/html/body/div[1]/div/div[4]/div/div[4]/div/div[4]/div/div[2]/div/div[2]/div[1]/div[1]"));

            Assert.AreEqual("jorojoro jorojoro", correctUser.Text);
            
        }
        /**
         * Remember the Bug tracking systems we have talked about?
         * JIRA or GitHub Issues? Make one of your tests to fail.
         * Use some conditions to see if they have failed, and if so, before stopping the test,
         * make Selenium to open you bug tracking system, login with your user and create new issue as a bug.
        **/

        [TestMethod]
        public void SelfReportingFail_Test()
        {
            Login();

            var correctUser =
                driver.FindElement(
                    By.XPath("/html/body/div[1]/div/div[4]/div/div[4]/div/div[4]/div/div[2]/div/div[2]/div[1]/div[1]"));

            if ("Ivan ivan" != correctUser.Text)
            {
                driver.Navigate().GoToUrl("https://github.com/");

                var signInButton = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a[2]"));
                signInButton.Click();

                var username = driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div/form/div[3]/input[1]"));
                username.SendKeys("jorojoro.jorojoro@abv.bg");

                var userPassword = driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div/form/div[3]/input[2]"));
                userPassword.SendKeys("jorojoro.jorojoro");

                var submitButton = driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div/form/div[3]/input[3]"));
                submitButton.Click();

                var dropDown = driver.FindElement(By.XPath("/html/body/div[1]/div/ul[2]/li[2]/a/span[2]"));
                dropDown.Click();

                var createNewRepository = driver.FindElement(By.XPath("/html/body/div[1]/div/ul[2]/li[2]/div/ul/a[1]"));
                createNewRepository.Click();

                var repositoryName =
                    driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div/form/div[2]/dl[2]/dd/input"));
                repositoryName.SendKeys("SelfReportingTest");

                var descriptiongField =
                    driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div/form/div[3]/dl/dd/input"));
                descriptiongField.SendKeys("Self reporting test.Create an issue.");

                var createRepository = driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div/form/div[3]/button"));
                createRepository.Click();

                var clickOnIssue =
                    driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/div[1]/div[1]/nav/ul[1]/li[2]/a/span[2]"));
                clickOnIssue.Click();

                var issueBuutton =
                    driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/div[1]/div[2]/div/div[2]/a"));
                issueBuutton.Click();

                var titleField =
                    driver.FindElement(
                        By.XPath(
                            "/html/body/div[4]/div/div[2]/div[1]/div[2]/div/form/div[2]/div[1]/div/div/div[1]/input"));
                titleField.SendKeys("Wrong username.");

                var textArea =
                    driver.FindElement(
                        By.XPath(
                            "/html/body/div[4]/div/div[2]/div[1]/div[2]/div/form/div[2]/div[1]/div/div/div[2]/div/div[3]/textarea"));
                textArea.SendKeys("Intentionally failed test");

                var octionButton =
                    driver.FindElement(
                        By.XPath(
                            "/html/body/div[4]/div/div[2]/div[1]/div[2]/div/form/div[2]/div[2]/div[1]/div/div[1]/button/span"));
                octionButton.Click();

                var selectBug =
                    driver.FindElement(
                        By.XPath(
                            "/html/body/div[4]/div/div[2]/div[1]/div[2]/div/form/div[2]/div[2]/div[1]/div/div[1]/div/div/div[3]/div[1]"));
                selectBug.Click();

                var submitNewIssue =
                    driver.FindElement(
                        By.XPath(
                            "/html/body/div[4]/div/div[2]/div[1]/div[2]/div/form/div[2]/div[1]/div/div/div[3]/button"));
                submitNewIssue.Click();

                driver.Quit();
            }
        }
    }
}
