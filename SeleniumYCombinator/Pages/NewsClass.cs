/*
 * Project:Ycobinator Application-Selenium WebDriver
 * Author:Sona G
 * Date :22/09/2021
 */
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SeleniumYCombinator.Pages
{
    public class NewsClass : Base.BaseClass
    {
        List<int> sorting;
        List<string> headline;
        public NewsClass()
        {
            sorting = new List<int>();
            headline = new List<string>();
        }

        public void NewsHeadlines()
        {
            Console.WriteLine("****************News Headline*****************");
            try
            {
                foreach (var n in driver.FindElements(By.XPath("//*[@class='storylink']")))
                {
                    //Check whether the sting is null or not
                    if (!string.IsNullOrEmpty(n.Text))
                    {
                        // Add the text into a list
                        headline.Add(n.Text);

                        Console.WriteLine("Healine:{0}", n.Text);
                    }
                    else
                    {
                        //If the string is null then remove it
                        headline.Remove(n.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RetrievePoints()
        {
            Console.WriteLine("****************Points*****************");
            try
            {
                foreach (var p in driver.FindElements(By.XPath("//*[@class='score']")))
                {
                    string records = p.Text;
                    //Split the integers and string from the text
                    string[] numbers = Regex.Split(records, @"\D+");
                    foreach (string value in numbers)
                    {
                        //Check whether the sting is null or not
                        if (!string.IsNullOrEmpty(value))
                        {
                            int i = int.Parse(value);
                            //Adding integer value into the list
                            sorting.Add(i);
                            Console.WriteLine("Headline Points : {0}", i);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            RetrieveHighestData();
        }
        public void RetrieveHighestData()
        {
            Console.WriteLine("****************Highest Points*****************");

            var res = sorting.OrderByDescending(g => g).Take(1);
            foreach (var g in res)
            {
                Console.WriteLine("Highest value:{0}", g);
            }
        }

        public void RetrieveHeadlines()
        {
            foreach (var n in driver.FindElements(By.XPath("//*[@class='storylink']")))
            {
                //Check whether the string is null or not
                if (!string.IsNullOrEmpty(n.Text))
                {
                    // Add the text into a list
                    string result = n.Text;

                    headline.Add(result);
                    //Split the list
                    headline = result.Split(" ").ToList();

                }
            }
            FrequentOccuredWord();
        }

        public void FrequentOccuredWord()
        {
            Console.WriteLine("****************Frequent Occured Word*****************");
            var most = headline.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).Where(x => x != null).Last();

            int count = headline.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).Where(x => x != null).Last().Count();
            
            Console.WriteLine("Highest value:{0} {1}", most, count);

        }
    }
}


