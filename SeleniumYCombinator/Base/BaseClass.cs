/*
 * Project:Ycobinator Application-Selenium WebDriver
 * Author:Sona G
 * Date :22/09/2021
 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumYCombinator.Base
{
    public class BaseClass
    {
        public static IWebDriver driver;
        [SetUp]
        public void Setup()
        {

            driver = new ChromeDriver();

            driver.Url = "https://news.ycombinator.com/news";

        }

        [TearDown]
        public void Close_Browser()
        {
            driver.Quit();
        }
    }
}
