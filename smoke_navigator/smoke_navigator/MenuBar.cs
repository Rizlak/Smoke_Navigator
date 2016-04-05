using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace smoke_navigator
{
    [TestFixture]
    class MenuBar
    {
        //IWebDriver driver = new ChromeDriver();
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
        public void TC39_isMenubarScrollPresent()
        {
            Assert.True(driver.FindElement(By.ClassName("mCSB_dragger")).Displayed);
            Console.WriteLine("TC39_isMenubarScrollPresent true");
        }


        [Test]
        public void TC40_isSarajevoTheatresWithPicturePresent()
        {

            Boolean checkTest = false;
            IList<IWebElement> links = driver.FindElements(By.TagName("li"));

            foreach (IWebElement link in links)
            {
                String hrefL = link.GetAttribute("style");

                if (hrefL.Contains("8ad3b8101a302b940cc059d91b217428")) //name of pic
                {
                    checkTest = true;
                    break;
                }
            }

            Assert.AreEqual(true, checkTest);

        }

        [Test]
        public void TC41_isAccomodationPresent() // finding by div value
        {
            Boolean checkTest = false;

            IList<IWebElement> links = driver.FindElements(By.TagName("div"));

            foreach (IWebElement link in links)
            {
                if ((link.Text.Equals("ACCOMMODATION")) || (link.Text.Equals("SMJEŠTAJ")))
                {

                    checkTest = true;
                    break;
                }
            }

            Assert.AreEqual(true, checkTest);
        }

        [Test]
        public void TC42_isFoodPresent() // finding by class
        {
            Assert.True(driver.FindElement(By.ClassName("food")).Displayed && driver.FindElement(By.ClassName("food")).Enabled);
        }

        [Test]
        public void TC43_isCoffeePresent() // finding by class
        {
            Assert.True(driver.FindElement(By.ClassName("coffee")).Displayed && driver.FindElement(By.ClassName("coffee")).Enabled);
        }

        [Test]
        public void TC44_isNightlifePresent() // finding by class
        {
            Assert.True(driver.FindElement(By.ClassName("nightlife")).Displayed && driver.FindElement(By.ClassName("nightlife")).Enabled);
        }

        [Test]
        public void TC45_isShoppingPresent() // finding by class
        {
            Assert.True(driver.FindElement(By.ClassName("shopping")).Displayed && driver.FindElement(By.ClassName("shopping")).Enabled);
        }

        [Test]
        public void TC46_isAttractionsPresent() // finding by class
        {
            Assert.True(driver.FindElement(By.ClassName("attractions")).Displayed && driver.FindElement(By.ClassName("attractions")).Enabled);
        }

        [Test]
        public void TC47_isArtPresent() // finding by class
        {
            Assert.True(driver.FindElement(By.ClassName("art")).Displayed && driver.FindElement(By.ClassName("art")).Enabled);
        }

        [Test]
        public void TC48_isSportPresent() // finding by class
        {
            Assert.True(driver.FindElement(By.ClassName("sport")).Displayed && driver.FindElement(By.ClassName("sport")).Enabled);
        }

        [Test]
        public void TC49_isTransportPresent() // finding by class
        {
            Assert.True(driver.FindElement(By.ClassName("transport")).Displayed && driver.FindElement(By.ClassName("transport")).Enabled);
        }

        [Test]
        public void TC50_isServicesPresent() // finding by class
        {
            Assert.True(driver.FindElement(By.ClassName("services")).Displayed && driver.FindElement(By.ClassName("services")).Enabled);
        }

        [Test]
        public void TC51_isBusinessPresent() // finding by class
        {
            Assert.True(driver.FindElement(By.ClassName("business")).Displayed && driver.FindElement(By.ClassName("business")).Enabled);
        }

        [Test]
        public void TC52_isStreetPresent() // finding by class
        {
            Assert.True(driver.FindElement(By.ClassName("street")).Displayed && driver.FindElement(By.ClassName("street")).Enabled);
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
