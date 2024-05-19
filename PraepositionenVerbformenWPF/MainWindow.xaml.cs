using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenQA.Selenium.Support.UI;

namespace PraepositionenVerbformenWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            // Specify the path to the WebDriver executable
            var driverPath = @"C:\Users\persh\source\repos\PraepositionenVerbformenWPF\PraepositionenVerbformenWPF\bin\Debug\net6.0-windows\chromedriver.exe";

            // Create a new instance of the ChromeDriver (or other WebDriver)
            IWebDriver driver = new ChromeDriver(driverPath);

            try
            {
                // Navigate to Google
                driver.Navigate().GoToUrl("https://www.verbformen.de");

                string xpath = "//*[@id=\"sp_message_container_890759\"]";

                // Create an instance of WebDriverWait with a timeout of 10 seconds
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Wait until the element is found and is visible
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("sp_message_iframe_890776")));

                driver.SwitchTo().Frame(driver.FindElement(By.Id("sp_message_iframe_890776")));

                

                // Find the button element by its ID, class, or other attributes
                //IWebElement button = driver.FindElement(By.XPath(("//button[@class='message-component message-button no-children focusable sp_choice_type_11']")));
                IWebElement button = driver.FindElement(By.XPath("//button[@title='Zustimmen']"));

                /*
                 * #sp_message_container_890759
                 */

                //driver.FindElements();

                // Click the button
                button.Click();

                System.Threading.Thread.Sleep(2000);

                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.Id("sp_message_iframe_890776")));


                // Wait for some time to observe the result or perform additional actions
                //System.Threading.Thread.Sleep(2000);

                driver.SwitchTo().DefaultContent();

                // Find the search input element by its name attribute value
                IWebElement searchBox = driver.FindElement(By.Name("w"));

                // Type the search query
                searchBox.SendKeys(tbInput.Text);

                // Submit the form (press Enter)
                searchBox.Submit();

                // Wait for the search results page to load (you might need to adjust the time based on your internet speed)
                System.Threading.Thread.Sleep(2000);

                // Print the title of the search results page
                Console.WriteLine("Page title: " + driver.Title);

                string en = driver.FindElement(By.XPath("//*[@id=\"xa19dc\"]/dl[3]/dd[1]/span[2]")).Text;
                string uk = driver.FindElement(By.XPath("//*[@id=\"xa19dc\"]/dl[3]/dd[9]/span[2]")).Text;
                string ru = driver.FindElement(By.XPath("//*[@id=\"xa19dc\"]/dl[3]/dd[1]/span[2]")).Text;

                rtb2.Document.Blocks.Clear();
                rtb2.Document.Blocks.Add(new Paragraph(new Run($"{en}\n{uk}\n{ru}")));

                /*
                // Navigate to the currently opened page
                driver.Navigate().GoToUrl("https://www.verbformen.de/?w=urlaub");  // This will navigate to the current page



                // Wait for the page to load (you might need to adjust the time based on your application)
                System.Threading.Thread.Sleep(2000);

                // Get the HTML code of the page
                string htmlCode = driver.PageSource;

                // Print or use the HTML code as needed
                Console.WriteLine(htmlCode);*/
            }
            finally
            {
                // Close the browser window
                driver.Quit();
            }
        }

        private void F() 
        {
            // Specify the path to the WebDriver executable
            var driverPath = @"C:\Users\persh\source\repos\TestForAnkiAndVerbformen\TestForAnkiAndVerbformen\bin\Debug\net6.0\chromedriver.exe";

            // Create a new instance of the ChromeDriver (or other WebDriver)
            IWebDriver driver = new ChromeDriver(driverPath);

            try
            {
                // Navigate to Google
                driver.Navigate().GoToUrl("https://www.verbformen.de");

                driver.SwitchTo().Frame(driver.FindElement(By.Id("sp_message_iframe_890776")));

                // Find the button element by its ID, class, or other attributes
                //IWebElement button = driver.FindElement(By.XPath(("//button[@class='message-component message-button no-children focusable sp_choice_type_11']")));
                IWebElement button = driver.FindElement(By.XPath("//button[@title='Zustimmen']"));



                //driver.FindElements();

                // Click the button
                button.Click();

                // Wait for some time to observe the result or perform additional actions
                System.Threading.Thread.Sleep(2000);

                driver.SwitchTo().DefaultContent();

                // Find the search input element by its name attribute value
                IWebElement searchBox = driver.FindElement(By.Name("w"));

                // Type the search query
                searchBox.SendKeys("Urlaub");

                // Submit the form (press Enter)
                searchBox.Submit();

                // Wait for the search results page to load (you might need to adjust the time based on your internet speed)
                System.Threading.Thread.Sleep(2000);

                // Print the title of the search results page
                Console.WriteLine("Page title: " + driver.Title);


                /*
                // Navigate to the currently opened page
                driver.Navigate().GoToUrl("https://www.verbformen.de/?w=urlaub");  // This will navigate to the current page



                // Wait for the page to load (you might need to adjust the time based on your application)
                System.Threading.Thread.Sleep(2000);

                // Get the HTML code of the page
                string htmlCode = driver.PageSource;

                // Print or use the HTML code as needed
                Console.WriteLine(htmlCode);*/
            }
            finally
            {
                // Close the browser window
                driver.Quit();
            }
        }
    }
}
