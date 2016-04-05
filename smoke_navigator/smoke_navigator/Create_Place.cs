using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;

namespace smoke_navigator
{
    [TestFixture]
    class Create_Place
    {
        //IWebDriver driver = new ChromeDriver(); //enable comm for Chrome tests
        IWebDriver driver = new FirefoxDriver();

        [SetUp]
        public void firstRun()
        {
            driver.Navigate().GoToUrl("https://www.navigator.ba/#/categories");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void cleanUp()
        {
            //driver.Quit();
        }

        [Test]
        public void TC57_isCreatePlaceModalOpened()
        {

            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                if ((link.Text.Equals("Create Place")) || (link.Text.Equals("Kreiraj objekat")))
                {
                    link.Click();
                    if ((driver.FindElement(By.TagName("h4")).Text.Equals("Create Place")) || (driver.FindElement(By.TagName("h4")).Text.Equals("Kreiraj objekat")))
                    {
                        Assert.True(driver.FindElement(By.ClassName("mCSB_container")).Displayed);
                        Console.WriteLine("Create Place");
                    }
                    else Assert.True(false);

                    break;
                }
            }
        }

       

        


        //Element wait
        public IWebElement waitForElement(By locator, int maxSec)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(maxSec)).Until(ExpectedConditions.ElementExists(locator));
        }

        //System wait
        public void waitTime(int secTime)
        {
            System.Threading.Thread.Sleep(secTime * 1000);
        }

        //Screenshot
        public void takeScreenShot(String filename)
        {
            ITakesScreenshot screenshotHandler = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotHandler.GetScreenshot();
            screenshot.SaveAsFile(filename + "_" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt") + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
