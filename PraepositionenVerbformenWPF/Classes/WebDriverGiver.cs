using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.DevTools.V122.Browser;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraepositionenVerbformenWPF.Classes
{
    internal static class WebDriverGiver
    {
        const string s_driverPath = @"C:\Users\persh\source\repos\PraepositionenVerbformenWPF\PraepositionenVerbformenWPF\bin\Debug\net6.0-windows\chromedriver.exe";
        private static IWebDriver _driver = null!;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver is null)
                {
                    _driver = new ChromeDriver(s_driverPath);

                    _driver.Navigate().GoToUrl("https://www.verbformen.de");

                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("sp_message_iframe_890776")));

                    _driver.SwitchTo().Frame(_driver.FindElement(By.Id("sp_message_iframe_890776")));

                    IWebElement button = _driver.FindElement(By.XPath("//button[@title='Zustimmen']"));

                    button.Click();

                    System.Threading.Thread.Sleep(2000);

                    _driver.SwitchTo().DefaultContent();
                }
                return _driver;
            }
        }

        public static void CloseBrowser() 
        {
            if (_driver is not null) 
            {
                _driver.Quit();
            }
        }
    }
}
