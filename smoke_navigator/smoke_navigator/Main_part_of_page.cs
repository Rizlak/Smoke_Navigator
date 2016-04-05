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
    class Main_part_of_page
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
        public void TC21_isMapPresent()
        {
            Assert.True(driver.FindElement(By.ClassName("leaflet-map-pane")).Displayed);
            Assert.True(driver.FindElement(By.ClassName("leaflet-map-pane")).Enabled);
        }

        [Test]
        public void TC22_isMenuBarPresent()
        {
            Assert.True(driver.FindElement(By.ClassName("left-menu-pane")).Displayed);
            Assert.True(driver.FindElement(By.ClassName("left-menu-pane")).Enabled);
        }


        [Test]
        public void TC23_plusMinusButtonsArePresent()
        {
            Assert.True(driver.FindElement(By.ClassName("leaflet-control-zoom-in")).Displayed);
            Assert.True(driver.FindElement(By.ClassName("leaflet-control-zoom-in")).Enabled);
            Assert.True(driver.FindElement(By.ClassName("leaflet-control-zoom-out")).Displayed);
            Assert.True(driver.FindElement(By.ClassName("leaflet-control-zoom-out")).Enabled);

        }

        [Test]
        public void TC24_zoomInzoomOut()
        {
            driver.FindElement(By.ClassName("leaflet-control-zoom-in")).Click();
            waitTime(1);
            driver.FindElement(By.ClassName("leaflet-control-zoom-in")).Click();
            waitTime(1);
            driver.FindElement(By.ClassName("leaflet-control-zoom-out")).Click();
            waitTime(1);
            driver.FindElement(By.ClassName("leaflet-control-zoom-out")).Click();

            Console.WriteLine("zoom in");
        }

        [Test]
        public void TC25_isLayerToSatelite_MapPresent()
        {
            Assert.True(driver.FindElement(By.ClassName("satellite-layer-icon")).Displayed);
            Assert.True(driver.FindElement(By.ClassName("satellite-layer-icon")).Enabled);
        }

        [Test]
        public void TC26_isChangedToSateliteMapView()
        {
            //IWebElement iconBefore = driver.FindElement(By.ClassName("leaflet-layer"));
            //String styleZ = iconBefore.GetAttribute("style");
            //Console.WriteLine("zoom in " + styleZ);

            driver.FindElement(By.ClassName("satellite-layer-icon")).Click();
            waitTime(1);

            IWebElement iconAfter = driver.FindElement(By.ClassName("leaflet-layer"));
            String styleZ1 = iconAfter.GetAttribute("style");
            Console.WriteLine("After click " + styleZ1);


            if (styleZ1=="z-index: 2;")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
            driver.FindElement(By.ClassName("street-layer-icon")).Click();
            waitTime(2);

        }

        [Test]
        public void TC27_isChangedToMapSateliteView()
        {

            driver.FindElement(By.ClassName("satellite-layer-icon")).Click();
            waitTime(2);
            driver.FindElement(By.ClassName("street-layer-icon")).Click();
            waitTime(1);

            IWebElement iconAfter = driver.FindElement(By.ClassName("leaflet-layer"));
            String styleZ1 = iconAfter.GetAttribute("style");
            //Console.WriteLine("After click " + styleZ1);


            if (styleZ1 == "z-index: 1;")
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }

        }

        [Test]
        public void TC28_isGooglePlayButtonPresent() //find by href
        {
            Boolean checkTest = false;
            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                String hrefL=link.GetAttribute("href");
                   
                if (hrefL=="https://play.google.com/store/apps/details?id=com.atlantbh.navigator")
                {
                    checkTest = true;
                    break;
                }
            }

            Assert.AreEqual(true, checkTest);

        }

        [Test]
        public void TC29_isSeparateTabGooglePlayOpened()
        {
            string currentWindow = driver.CurrentWindowHandle;

            IList<IWebElement> links = driver.FindElements(By.TagName("img"));

            foreach (IWebElement link in links)
            {
                String imgL = link.GetAttribute("src");

                if (imgL == "https://www.navigator.ba/assets/android_app.png")
                {
                    link.Click();
                    break;
                }
            }

            foreach (String window in driver.WindowHandles)
            {
                driver.SwitchTo().Window(window);
            }
            waitTime(2);
            Assert.IsTrue(driver.Url.Contains("https://play.google.com/store/apps/details?id=com.atlantbh.navigator"));
            driver.Close();
            driver.SwitchTo().Window(currentWindow);

        }


        [Test]
        public void TC30_isAppStoreButtonPresent() // find by img
        {
            Boolean checkTest = false;

            IList<IWebElement> links = driver.FindElements(By.TagName("img"));

            foreach (IWebElement link in links)
            {
                
                String imgL = link.GetAttribute("src");

                if (imgL == "https://www.navigator.ba/assets/ios_app.png")
                {
                    checkTest = true;
                    break;
                }
            }

            Assert.AreEqual(true, checkTest);

        }

        [Test]
        public void TC31_isSeparateTabAppStoreOpened()
        {
            string currentWindow = driver.CurrentWindowHandle;

            IList<IWebElement> links = driver.FindElements(By.TagName("img"));

            foreach (IWebElement link in links)
            {
                String imgL = link.GetAttribute("src");

                if (imgL == "https://www.navigator.ba/assets/ios_app.png")
                {
                    link.Click();
                    break;
                }
            }

            foreach (String window in driver.WindowHandles)
            {
                driver.SwitchTo().Window(window);
            }
            waitTime(2);
            Assert.IsTrue(driver.Url.Contains("https://itunes.apple.com/app/id638809479"));
            driver.Close();
            driver.SwitchTo().Window(currentWindow);

        }

        [Test]
        public void TC32_isAboutLinkPresent()
        {
            Boolean checkTest = false;

            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                if ((link.Text.Equals("About")) || (link.Text.Equals("O Navigatoru")))
                {

                    checkTest = true;
                    break;
                }
            }
            Assert.AreEqual(true, checkTest);

        }

        [Test]
        public void TC33_isAboutLinkLeadsTOUrl()
        {

            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                if ((link.Text.Equals("About")) || (link.Text.Equals("O Navigatoru")))
                {
                    link.Click();
                    waitTime(2);
                    
                    break;
                }
            }

            Assert.IsTrue(driver.Url.Contains("https://www.navigator.ba/#/about"));
            driver.Navigate().Back();

        }

        [Test]
        public void TC34_isLeafletLinkPresent() //find by href
        {
            Boolean checkTest = false;
            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                String hrefL = link.GetAttribute("href");

                if (hrefL == "http://leafletjs.com/")
                {
                    checkTest = true;
                    break;
                }
            }

            Assert.AreEqual(true, checkTest);

        }



        [Test]
        public void TC35_isAtlantBHLinkPresent() //find by href
        {
            Boolean checkTest = false;
            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                String hrefL = link.GetAttribute("href");

                if (hrefL == "http://www.atlantbh.com/")
                {
                    checkTest = true;
                    break;
                }
            }

            Assert.AreEqual(true, checkTest);

        }

        [Test]
        public void TC36_isSeparateTabAtlantBHOpened()
        {
            string currentWindow = driver.CurrentWindowHandle;

            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                String imgL = link.GetAttribute("href");

                if (imgL == "http://www.atlantbh.com/")
                {
                    link.Click();
                    break;
                }
            }

            foreach (String window in driver.WindowHandles)
            {
                driver.SwitchTo().Window(window);
            }
            waitTime(2);
            Assert.IsTrue(driver.Url.Contains("http://www.atlantbh.com/"));
            driver.Close();
            driver.SwitchTo().Window(currentWindow);

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
