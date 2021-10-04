/*
 * Project:Ycobinator Application-Selenium WebDriver
 * Author:Sona G
 * Date :22/09/2021
 */
using NUnit.Framework;
using SeleniumYCombinator.Pages;

namespace SeleniumYCombinator
{
    public class Tests:Base.BaseClass
    {

        [Test]
        public void TestForNews()
        {
            NewsClass news = new NewsClass();
            news.NewsHeadlines();
            news.RetrievePoints();
            news.RetrieveHeadlines();
        }

        [Test]
        public void TestForNews1()
        {
            Headlines c = new Headlines();
            c.NewsHeadlines();
        }
    }
}