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
using PraepositionenVerbformenWPF.Classes;

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
            IWebDriver driver = WebDriverGiver.GetDriver();

            try
            {
                IWebElement searchBox = driver.FindElement(By.Name("w"));

                searchBox.SendKeys(tbInput.Text);

                searchBox.Submit();

                // Wait for the search results page to load (you might need to adjust the time based on your internet speed)
                System.Threading.Thread.Sleep(2000);
            }
            finally
            {
                // Close the browser window
                //driver.Quit();
            }
        }

        private void btnPopulate_Click(object sender, RoutedEventArgs e)
        {
            IWebDriver driver = WebDriverGiver.GetDriver();

            string en = driver.FindElements(By.CssSelector("dd[lang='en']")).Single().Text;

            string uk = driver.FindElements(By.CssSelector("dd[lang='uk']")).Single().Text;
            string ru = driver.FindElements(By.CssSelector("dd[lang='ru']")).Single().Text;

            rtb2.Document.Blocks.Clear();
            rtb2.Document.Blocks.Add(new Paragraph(new Run($"{en}\n{uk}\n{ru}")));
        }
    }
}
