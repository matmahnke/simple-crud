using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace FunctionalTests
{
    //[TestClass]
    //public class SeleniumTest
    //{
    //    private static string baseURL;
    //    private static IWebDriver driver;
    //    private bool acceptNextAlert = true;
    //    private StringBuilder verificationErrors;

    //    [ClassCleanup]
    //    public static void CleanupClass()
    //    {
    //        try
    //        {
    //            //driver.Quit();// quit does not close the window
    //            driver.Close();
    //            driver.Dispose();
    //        }
    //        catch (Exception)
    //        {
    //            // Ignore errors if unable to close the browser
    //        }
    //    }

    //    [ClassInitialize]
    //    public static void InitializeClass(TestContext testContext)
    //    {
    //        driver = new ChromeDriver(@"C:\Users\matheus.mahnke\Desktop\Application\packages\Selenium.Chrome.WebDriver.2.45\driver");
    //    }

    //    [TestCleanup]
    //    public void CleanupTest()
    //    {
    //        Assert.AreEqual("", verificationErrors.ToString());
    //    }

    //    [TestInitialize]
    //    public void InitializeTest()
    //    {
    //        verificationErrors = new StringBuilder();
    //    }

    //    [TestMethod]
    //    public void TheUntitledTestCaseTest()
    //    {
    //        driver.Navigate().GoToUrl("https://www.google.com/");
    //        driver.FindElement(By.Name("q")).Clear();
    //        driver.FindElement(By.Name("q")).SendKeys("exmaple");
    //        driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
    //        driver.FindElement(By.Id("tw-source-text-ta")).Click();
    //        // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=tw-source-text-ta | ]]
    //        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Resultados da Web'])[1]/following::div[4]")).Click();
    //        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Resultados da Web'])[1]/following::div[4]")).Click();
    //        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Ao pé da letra'])[1]/following::nobr[1]")).Click();
    //        // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | xpath=(.//*[normalize-space(text()) and normalize-space(.)='Ao pé da letra'])[1]/following::nobr[1] | ]]
    //        driver.FindElement(By.Name("q")).Clear();
    //        driver.FindElement(By.Name("q")).SendKeys("selenium");
    //        driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
    //        driver.FindElement(By.Name("q")).Clear();
    //        driver.FindElement(By.Name("q")).SendKeys("dollar hoje");
    //        driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
    //        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Real brasileiro'])[1]/following::span[1]")).Click();
    //        driver.FindElement(By.Id("knowledge-currency__tgt-currency")).Click();
    //        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Dólar americano'])[1]/following::div[1]")).Click();
    //        try
    //        {
    //            Assert.AreEqual("Real brasileiro", driver.FindElement(By.Id("knowledge-currency__tgt-currency")).Text);
    //        }
    //        catch (Exception e)
    //        {
    //            verificationErrors.Append(e.Message);
    //        }
    //        try
    //        {
    //            Assert.AreEqual("Aproximadamente 9.980.000 resultados (0,82 segundos)", driver.FindElement(By.Id("topabar")).Text);
    //        }
    //        catch (Exception e)
    //        {
    //            verificationErrors.Append(e.Message);
    //        }
    //        driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Máx'])[1]/following::div[4]")).Click();
    //        Assert.AreEqual("dollar hoje - Pesquisa Google", driver.Title);
    //    }

    //    private string CloseAlertAndGetItsText()
    //    {
    //        try
    //        {
    //            IAlert alert = driver.SwitchTo().Alert();
    //            string alertText = alert.Text;
    //            if (acceptNextAlert)
    //            {
    //                alert.Accept();
    //            }
    //            else
    //            {
    //                alert.Dismiss();
    //            }
    //            return alertText;
    //        }
    //        finally
    //        {
    //            acceptNextAlert = true;
    //        }
    //    }

    //    private bool IsAlertPresent()
    //    {
    //        try
    //        {
    //            driver.SwitchTo().Alert();
    //            return true;
    //        }
    //        catch (NoAlertPresentException)
    //        {
    //            return false;
    //        }
    //    }

    //    private bool IsElementPresent(By by)
    //    {
    //        try
    //        {
    //            driver.FindElement(by);
    //            return true;
    //        }
    //        catch (NoSuchElementException)
    //        {
    //            return false;
    //        }
    //    }
    //}
}