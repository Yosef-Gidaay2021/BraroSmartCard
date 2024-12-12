using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class AccessPricing
{
    public void AccessPricingPage()
    {
        // Initialize ChromeDriver
        IWebDriver driver = new ChromeDriver();

        try
        {
            // Navigate to the website
            driver.Navigate().GoToUrl("https://brarosmartcard.vercel.app/");
            Console.WriteLine("Navigated to the website.");

            // Wait for the page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.FindElement(By.TagName("body")));
            Console.WriteLine("Page loaded.");

            // Find and click the Pricing link
            try
            {
                var pricingLink = driver.FindElement(By.XPath("//a[contains(@href, '/pricing')]"));
                pricingLink.Click();
                Console.WriteLine("Found Pricing link and clicked.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Pricing link not found.");
                return;
            }
            IWebElement body = driver.FindElement(By.TagName("body"));
            string bodyText = body.Text;
            Console.WriteLine(bodyText);


           
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Console.WriteLine("Stack Trace: " + ex.StackTrace);
        }
        finally
        {
            System.Threading.Thread.Sleep(5000);
            // Close the browser
            driver.Quit();
            Console.WriteLine("Browser closed.");
        }
    }
}