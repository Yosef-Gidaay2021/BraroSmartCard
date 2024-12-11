using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class SubscribeYouTube
{
    public void SubscribeYouTubeChannel()
    {
        // Initialize ChromeDriver
        IWebDriver driver = new ChromeDriver();

        // Navigate to the website
        driver.Navigate().GoToUrl("https://brarosmartcard.vercel.app/");

        // Wait for the page to load
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        wait.Until(d => d.FindElement(By.TagName("body")));

        // Scroll and look for YouTube link
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        // Set a maximum number of scroll attempts
        int maxScrollAttempts = 10;
        int scrollAttempts = 0;

        // Scroll and search for the YouTube link in the page
        while (scrollAttempts < maxScrollAttempts)
        {
            // Scroll down by a specific amount
            js.ExecuteScript("window.scrollBy(0, window.innerHeight);");
            Console.WriteLine("Scrolling down...");

            // Wait for new content to load
            System.Threading.Thread.Sleep(2000);

            // Try to find the YouTube link after scrolling
            try
            {
                var youtubeLink = driver.FindElement(By.XPath("//a[contains(@href, 'youtube.com')]"));
                youtubeLink.Click();
                Console.WriteLine("Found YouTube link and clicked.");
                break; // Exit the loop after clicking the YouTube link
            }
            catch (NoSuchElementException)
            {
                // If YouTube link not found, keep scrolling
                Console.WriteLine("YouTube link not found, scrolling again.");
            }

            scrollAttempts++;
        }

        if (scrollAttempts == maxScrollAttempts)
        {
            Console.WriteLine("YouTube link not found after scrolling.");
            driver.Quit();
            return;
        }

        // Wait for the YouTube page to load (increased timeout for page load)
        WebDriverWait youtubeWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        youtubeWait.Until(d => d.Url.Contains("youtube.com"));

        // Check if sign-in is required
        try
        {
            // Wait for the sign-in button to be visible and click it
            var signInButton = new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                .Until(d => d.FindElement(By.XPath("//yt-formatted-string[text()='Sign in']")));
            signInButton.Click();
            Console.WriteLine("Click on the 'Sign In' button and log in manually.");
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Sign In button not found. Maybe already signed in?");
        }

        // Pause the script to allow time for manual login
        // You can adjust the sleep time based on how long it typically takes for you to sign in
        System.Threading.Thread.Sleep(30000); // 30 seconds to sign in manually (adjust if needed)

        // After manual login, wait for YouTube to load completely
        youtubeWait.Until(d => d.Url.Contains("youtube.com"));

        // Wait for the Subscribe button to be clickable and click it
        try
        {
            // Use XPath to find the subscribe button element
            var subscribeButton = youtubeWait.Until(d => d.FindElement(By.XPath("//ytd-subscribe-button-renderer//*[@id='subscribe-button']")));
            subscribeButton.Click();
            Console.WriteLine("Subscribed to the channel.");
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Subscribe button not found.");
        }

        // Optional: Sleep for a few seconds to simulate human interaction
        System.Threading.Thread.Sleep(5000);

        // Close the browser
        driver.Quit();
    }
}
