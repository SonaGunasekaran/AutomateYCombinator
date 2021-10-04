/*
 * Project:Ycobinator Application-Selenium WebDriver
 * Author:Sona G
 * Date :22/09/2021
 */
using OpenQA.Selenium;
using System;
using System.IO;
using System.Text;

namespace SeleniumYCombinator.Pages
{
    public class Headlines:Base.BaseClass
    {
        public void NewsHeadlines()
        {
            Console.WriteLine("****************News Headline*****************");
            try
            {
                var csv = new StringBuilder();
                foreach (var n in driver.FindElements(By.XPath("//*[@class='storylink']")))
                {
                    String records =n.Text;
                    //Check whether the sting is null or not
                    if (!string.IsNullOrEmpty(n.Text))
                    {
                        var first = records.ToString();
                        var newLine = string.Format("{0}", first);
                        csv.AppendLine(newLine);

                    }
                }
                File.WriteAllText(@"C:\Users\sona.g\source\repos\SeleniumYCombinator\SeleniumYCombinator\Pages\News.csv", csv.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
