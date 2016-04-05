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
    public class NavigationBar
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
            //driver.Close();
        }

        [Test]
        public void TC1_isUrlOk()
        {
            Assert.True(driver.Url.Contains("https://www.navigator.ba/#/categories"));
            
        }

        [Test]
        public void TC2_isLogoPresent()
        {

            Assert.AreEqual(true, driver.FindElement(By.ClassName("logo")).Displayed);
                   
            Console.WriteLine("logo is displayed");
        }

        [Test]
        public void TC3_isLogoredirectingToMainPage()
        {
            waitTime(3);
            driver.FindElement(By.Id("ember625")).Click();
            waitTime(3);
            driver.FindElement(By.ClassName("logo")).Click();

            Assert.True(driver.Url.Contains("https://www.navigator.ba/#/categories"));

            Console.WriteLine("main page is displayed");
        }

        [Test]
        public void TC4_isSearchPresent()
        {

            //Assert.AreEqual(true, driver.FindElement(By.Id("header_search")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("header_search")).Displayed && driver.FindElement(By.Id("header_search")).Enabled);

            Console.WriteLine("search1 is displayed");
        }

        [Test]
        public void TC5_isSearchPlaceholderPresent()
        {
            IWebElement searchClass = driver.FindElement(By.ClassName("ember-text-field"));
            String placeholderValue = searchClass.GetAttribute("placeholder");



            if (placeholderValue == "Search street or place" || placeholderValue == "Traži ulicu ili objekat")
            {
                Assert.True(true);
                Console.WriteLine("Placeholder text: " + placeholderValue);
            }
            else
            {
                Assert.True(false);
            }
                        
        }

        [Test]
        public void TC6_isSearchDropdownOpened()
        {

            driver.FindElement(By.ClassName("ember-text-field")).Click();
            waitTime(2);

            Assert.True(driver.FindElement(By.ClassName("search-suggestion-box-wrapper")).Displayed);

            Console.WriteLine("search dropdown is displayed");
        }

        [Test]
        public void TC7_isSearchAutocomplete()
        {

            driver.FindElement(By.ClassName("ember-text-field")).Click();
            driver.FindElement(By.ClassName("ember-text-field")).SendKeys("sar");
            waitTime(1);

            Assert.True(driver.FindElement(By.ClassName("tt-dropdown-menu")).Displayed);
            waitTime(2);
            driver.FindElement(By.ClassName("ember-text-field")).SendKeys(Keys.Backspace);
            driver.FindElement(By.ClassName("ember-text-field")).SendKeys(Keys.Backspace);
            driver.FindElement(By.ClassName("ember-text-field")).SendKeys(Keys.Backspace);
            

            Console.WriteLine("search dropdown autocomplete is displayed");
        }

        [Test]
        public void TC8_isSearchKeypadArrowsPossible()
        {

            driver.FindElement(By.ClassName("ember-text-field")).Click();
            driver.FindElement(By.ClassName("ember-text-field")).SendKeys("sar");
            waitTime(1);
            driver.FindElement(By.ClassName("ember-text-field")).SendKeys(Keys.Down);
            driver.FindElement(By.ClassName("ember-text-field")).SendKeys(Keys.Down);
            driver.FindElement(By.ClassName("ember-text-field")).SendKeys(Keys.Down);
            driver.FindElement(By.ClassName("ember-text-field")).SendKeys(Keys.Up);
            driver.FindElement(By.ClassName("logo")).Click();

            Console.WriteLine("search dropdown aKeypadArrowsPossible");
        }
        

        [Test]
        public void TC9_isCreatePlaceButtonPresent()
        {

            //String placeholderText = driver.FindElement(By.XPath("//*[@id='ember564']")).GetAttribute("href");
            
            //if (placeholderText.Contains("create-place"))
            //{
            //    Assert.True(true);
            //    Console.WriteLine("Placeholder text: " + placeholderText);
            //}
            //else
            //{
            //    Assert.True(false);
            //    Console.WriteLine("Placeholder text: " + placeholderText);
            //}
            Boolean checkTest = false;

            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

           
            foreach (IWebElement link  in links)
            {
                if ((link.Text.Equals("Create Place")) || (link.Text.Equals("Kreiraj objekat")))
                {
                    checkTest = true;
                    break;
                }
            }

            Assert.AreEqual(true, checkTest);

        }

        [Test]
        public void TC10_isCreatePlaceModalOpened()
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

        [Test]
        public void TC11_isSuggestFeaturesReportProblem()
        {
            Boolean checkTest = false;

            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                if ((link.Text.Equals("Suggest features - Report a problem")) || (link.Text.Equals("Predloži ideju - Pošalji komentar")))
                {

                    checkTest = true;
                    break;
                }
            }

            Assert.AreEqual(true, checkTest);
            

        }

        [Test]
        public void TC12_isSuggestFeaturesReportProblemModalOpened()
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
        public void TC13_isSocialFacebookIconPresent()
        {

            Assert.True(driver.FindElement(By.ClassName("iconav-facebook")).Displayed);

            Console.WriteLine("facebook icon are displayed");

        }

        [Test]
        public void TC14_isSocialTwitterIconPresent()
        {

            Assert.True(driver.FindElement(By.ClassName("iconav-twitter-2")).Displayed);

            Console.WriteLine("twitter icon are displayed");

        }

        [Test]
        public void TC15_isSocialGoogleIconPresent()
        {

            Assert.True(driver.FindElement(By.ClassName("iconav-googleplus")).Displayed);

            Console.WriteLine("google icon are displayed");

        }

        [Test]
        public void TC16_isSocialopenedInSeparateTab()
        {

            string currentWindow = driver.CurrentWindowHandle;

            //facebook
            driver.FindElement(By.ClassName("iconav-facebook")).Click();
            foreach (String window in driver.WindowHandles)
            {
                driver.SwitchTo().Window(window);
            }
            waitTime(2);
            Assert.IsTrue(driver.Url.Contains("https://www.facebook.com/Navigator.ba"));
            driver.Close();
            driver.SwitchTo().Window(currentWindow);
            Assert.IsTrue(driver.Url.Contains("https://www.navigator.ba/#/categories"));

            //twitter
            driver.FindElement(By.ClassName("iconav-twitter-2")).Click();
            foreach (String window in driver.WindowHandles)
            {
                driver.SwitchTo().Window(window);
            }
            waitTime(2);
            Assert.IsTrue(driver.Url.Contains("https://twitter.com/navigatorba"));
            driver.Close();
            driver.SwitchTo().Window(currentWindow);
            Assert.IsTrue(driver.Url.Contains("https://www.navigator.ba/#/categories"));

            //googleplus
            driver.FindElement(By.ClassName("iconav-googleplus")).Click();
            foreach (String window in driver.WindowHandles)
            {
                driver.SwitchTo().Window(window);
            }
            waitTime(2);
            Assert.IsTrue(driver.Url.Contains("https://plus.google.com/108400709887587279208"));
            driver.Close();
            driver.SwitchTo().Window(currentWindow);
            Assert.IsTrue(driver.Url.Contains("https://www.navigator.ba/#/categories"));


        }

        [Test]
        public void TC17_isHoveringOverSocial()
        {
            Actions builder = new Actions(driver);
            IWebElement smiley = driver.FindElement(By.ClassName("social"));
            builder.MoveToElement(smiley).Build().Perform();
            Assert.True(driver.FindElement(By.Id("social-content-container")).Displayed);

            Console.WriteLine("dropdown is open social");

        }

        [Test]
        public void TC18_isLanguagePickerPresent()
        {
            IList<IWebElement> links = driver.FindElements(By.TagName("a"));
            int count = 0;

            foreach (IWebElement link in links)
            {
                if (link.Text.Equals("EN"))
                {
                    Console.WriteLine("Button EN present");
                    count = count + 1;
                    break;
                }
            }

            foreach (IWebElement link in links)
            {
                if (link.Text.Equals("BS"))
                {
                    Console.WriteLine("Button BS present");
                    count = count + 1;
                    break;
                }
            }
            Assert.AreEqual(count, 2);
        }


        [Test]
        public void TC19_isUserAbleChangePageLenguage() //from BS to EN then to BS
        {


            IWebElement xmlLang = driver.FindElement(By.TagName("html"));
            string lang = xmlLang.GetAttribute("lang");
            Console.WriteLine("default lang is "+lang);
            int count = 0;

            if (lang=="bs")
            {
                driver.FindElement(By.ClassName("en")).Click();
                waitTime(2);
                IWebElement xmlLangChange = driver.FindElement(By.TagName("html"));
                string lang1 = xmlLangChange.GetAttribute("lang");
                count = count + 1;
                Console.WriteLine("first changed lang is " + lang1);

            }

            IWebElement xmlLangChange1 = driver.FindElement(By.TagName("html"));
            string lang2 = xmlLangChange1.GetAttribute("lang");


            if (lang2 == "en")
            {
                driver.FindElement(By.ClassName("bs")).Click();
                waitTime(2);
                IWebElement xmlLangChange = driver.FindElement(By.TagName("html"));
                string lang1 = xmlLangChange.GetAttribute("lang");
                count = count + 1;
                Console.WriteLine("secont changed lang is " + lang1);

            }

            Assert.AreEqual(2, count);  

        }

        [Test]
        public void TC20_isChangingLanguageReflectsOnWholePage() //from BS to EN then to BS - check buttons and links
        {

            IWebElement xmlLang = driver.FindElement(By.TagName("html"));
            string lang = xmlLang.GetAttribute("lang");
            Console.WriteLine("default lang is " + lang);
            int count = 0;

            if (lang == "bs")
            {
                driver.FindElement(By.ClassName("en")).Click();
                waitTime(2);
                IWebElement xmlLangChange = driver.FindElement(By.TagName("html"));
                string lang1 = xmlLangChange.GetAttribute("lang");
                count = count + 1;
                Console.WriteLine("first changed lang is " + lang1);


                IList<IWebElement> links = driver.FindElements(By.TagName("a"));

                Boolean cplace=false;
                Boolean sfeature = false;
                Boolean coffee = false;

                foreach (IWebElement link in links)
                {
                    if (link.Text.Equals("Create Place"))
                    {
                        cplace=true;
                        Console.WriteLine("C place " + cplace);
                        break;
                    }
                }

                foreach (IWebElement link in links)
                {
                    if (link.Text.Equals("Suggest features - Report a problem"))
                    {
                        sfeature = true;
                        Console.WriteLine("sfeature " + sfeature);
                        break;
                    }
                }

                IList<IWebElement> divFind = driver.FindElements(By.TagName("div"));
                foreach (IWebElement div in divFind)
                {
                    if (div.Text.Equals("COFFEE"))
                    {
                        coffee = true;
                        Console.WriteLine("coffee " + coffee);
                        break;
                    }
                }

                if (cplace && sfeature && coffee)
                {
                    Console.WriteLine("All 3 true");
                    Assert.True(true);
                }
                else Assert.True(false);

            }


            IWebElement xmlLangChange1 = driver.FindElement(By.TagName("html"));
            string lang2 = xmlLangChange1.GetAttribute("lang");


            if (lang2 == "en")
            {
                driver.FindElement(By.ClassName("bs")).Click();
                waitTime(2);
                IWebElement xmlLangChange = driver.FindElement(By.TagName("html"));
                string lang1 = xmlLangChange.GetAttribute("lang");
                count = count + 1;
                Console.WriteLine("secont changed lang is " + lang1);

                IList<IWebElement> links = driver.FindElements(By.TagName("a"));

                Boolean cplaceBs = false;
                Boolean sfeatureBs = false;
                Boolean coffeeBs = false;

                foreach (IWebElement link in links)
                {
                    if (link.Text.Equals("Kreiraj objekat"))
                    {
                        cplaceBs = true;
                        Console.WriteLine("C place BS " + cplaceBs);
                        break;
                    }
                }

                foreach (IWebElement link in links)
                {
                    if (link.Text.Equals("Predloži ideju - Pošalji komentar"))
                    {
                        sfeatureBs = true;
                        Console.WriteLine("sfeature Bs " + sfeatureBs);
                        break;
                    }
                }

                IList<IWebElement> divFind = driver.FindElements(By.TagName("div"));
                foreach (IWebElement div in divFind)
                {
                    if (div.Text.Equals("KAFA"))
                    {
                        coffeeBs = true;
                        Console.WriteLine("coffee BS " + coffeeBs);
                        break;
                    }
                }


                if (cplaceBs && sfeatureBs && coffeeBs)
                {
                    Console.WriteLine("All 3 BS true");
                    Assert.True(true);
                }
                else Assert.True(false);


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
