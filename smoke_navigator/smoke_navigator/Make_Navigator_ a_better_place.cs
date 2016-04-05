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
    class Make_Navigator__a_better_place
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
        public void TC60_isSuggestFeaturesReportProblemOpen()
        {
            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                if ((link.Text.Equals("Suggest features - Report a problem")) || (link.Text.Equals("Predloži ideju - Pošalji komentar")))
                {
                    link.Click();

                    if ((driver.FindElement(By.TagName("h4")).Text.Equals("Make Navigator a better place")) || (driver.FindElement(By.TagName("h4")).Text.Equals("Navigator po tvojoj mjeri")))
                    {
                        Assert.True(driver.FindElement(By.ClassName("mCSB_container")).Displayed);
                        Console.WriteLine("Make Navigator a better place");
                    }
                    else Assert.True(false);


                    break;
                }
            }

        }

        [Test]
        public void TC61_isSuggestFeaturesReportProblemOpenPossibleWithoutComment()
        {
            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                if ((link.Text.Equals("Suggest features - Report a problem")) || (link.Text.Equals("Predloži ideju - Pošalji komentar")))
                {
                    link.Click();

                    IList<IWebElement> links1 = driver.FindElements(By.TagName("input"));
                    foreach (IWebElement link1 in links1)
                    {
                        if (link1.GetAttribute("name") == "name_surname")
                        {
                            link1.Click();
                            link1.SendKeys("Test");
                            break;
                        }

                    }

                    driver.FindElement(By.ClassName("emailcheck")).Click();
                    driver.FindElement(By.ClassName("emailcheck")).SendKeys("this@test.com");
                    //driver.FindElement(By.TagName("textarea")).Click();
                    //driver.FindElement(By.TagName("textarea")).SendKeys("this@test.com1111111");
                    driver.FindElement(By.ClassName("green-button")).Click();

                    break;
                }
                
             }
            waitTime(2);
          
            Boolean present=false;

            try
            {
                driver.FindElement(By.ClassName("alert-success")); //info Hvala na poruci
                Console.WriteLine("alert true");
                present = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("alert ffff");
                present = false;
            }
            
            Assert.AreEqual(false, present);

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
