using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPathTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ChromeOptions();
            options.AddArguments("--disable-gpu");
            options.AddArguments("disable-popup-blocking");

            var chromeDriver = new ChromeDriver("C:\\Users\\klync\\Source\\Repos\\XPathTest\\XPathTest", options);

            chromeDriver.Navigate().GoToUrl("https://login.yahoo.com/");
            chromeDriver.Manage().Window.Maximize();

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chromeDriver.FindElement(By.Id("login-username")).SendKeys("" + Keys.Enter);

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chromeDriver.FindElement(By.Id("login-passwd")).SendKeys("" + Keys.Enter);

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chromeDriver.Url = ("https://finance.yahoo.com/portfolio/p_0/view/v1");

            IWebElement list = chromeDriver.FindElementByTagName("tbody");
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> stocks = list.FindElements(By.TagName("tr"));
            int count = stocks.Count();

            Console.WriteLine("Info on stocks in Katelynn's Portfolio: " + stocks.Count);

            for (int i = 1; i <= count; i++)
            {
                chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                var symbol = chromeDriver.FindElementByXPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[1]").GetAttribute("innerText");

                Console.WriteLine(symbol);

            }
            Console.WriteLine("\n");

            chromeDriver.Close();

        }
    }
    }

