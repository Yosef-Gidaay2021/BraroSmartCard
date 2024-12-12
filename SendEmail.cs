using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class SendEmail
{
    public void SendEmailPage()
    {
       // Initialize ChromeDriver
        IWebDriver driver = new ChromeDriver();

        // Navigate to the website
        driver.Navigate().GoToUrl("https://brarosmartcard.vercel.app/");

        // Wait for the page to load
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        wait.Until(d => d.FindElement(By.TagName("body")));

        // Scroll and look for LinkedIn link
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        // Set a maximum number of scroll attempts
        int maxScrollAttempts = 10;
        int scrollAttempts = 0;

        // Scroll and search for the email link in the page
        while (scrollAttempts < maxScrollAttempts)
        {
            // Scroll down by a specific amount
            js.ExecuteScript("window.scrollBy(0, window.innerHeight);");
            Console.WriteLine("Scrolling down...");

            // Wait for new content to load
            System.Threading.Thread.Sleep(2000);

            // Try to find the LinkedIn link after scrolling
            try
            {
                var emailLink = driver.FindElement(By.XPath("//a[contains(@href, 'info@brarosmartcard.com')]"));
                emailLink.Click();
                Console.WriteLine("Found Email link and clicked.");
                break; // Exit the loop after clicking the LinkedIn link
            }
            catch (NoSuchElementException)
            {
                // If LinkedIn link not found, keep scrolling
                Console.WriteLine("Email link not found, scrolling again.");
            }

            scrollAttempts++;
        }

        if (scrollAttempts == maxScrollAttempts)
        {
            Console.WriteLine("LinkedIn link not found after scrolling.");
            driver.Quit();
            return;
        }
    }

}