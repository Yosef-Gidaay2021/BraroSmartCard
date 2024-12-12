using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;

public class SubmitForm
{
    public void SubmitFormPage()
    {
        // Set Edge options
        EdgeOptions options = new EdgeOptions();
        options.AddArguments("--disable-infobars");
        options.AddArguments("--no-sandbox");
        options.AddArguments("--disable-dev-shm-usage");

        // Initialize EdgeDriver
        IWebDriver driver = new EdgeDriver(options);

        try
        {
            // Navigate to the website
            driver.Navigate().GoToUrl("https://brarosmartcard.vercel.app/");
            Console.WriteLine("Navigated to the website.");

            // Wait for the page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.FindElement(By.TagName("body")));
            Console.WriteLine("Page loaded.");

            // Find and click the 'Contact' button
            try
            {
                // XPath for the "Contact" button in the navigation bar
                IWebElement contactButton = driver.FindElement(By.XPath("//a[contains(@href, '/contact')]"));
                contactButton.Click();
                Console.WriteLine("Clicked on the Contact button.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Contact button not found.");
                return;
            }

            // Wait for the contact form to be visible (scrolling to the form if necessary)
            wait.Until(d => d.FindElement(By.Name("name")));
            Console.WriteLine("Contact form is visible.");

            // Fill out the form
            try
            {
                // Name input
                IWebElement nameInput = driver.FindElement(By.Name("name"));
                nameInput.SendKeys("John Doe");

                // Email input
                IWebElement emailInput = driver.FindElement(By.Name("email"));
                emailInput.SendKeys("johndoe@example.com");

                // Phone input
                IWebElement phoneInput = driver.FindElement(By.Name("phone"));
                phoneInput.SendKeys("123-456-7890");

                // Message input
                IWebElement messageInput = driver.FindElement(By.Name("message"));
                messageInput.SendKeys("Hello, I am interested in your services.");

                // Submit the form
                IWebElement submitButton = driver.FindElement(By.XPath("//button[@type='submit']"));
                submitButton.Click();
                Console.WriteLine("Form submitted.");
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Form elements not found: " + ex.Message);
                return;
            }

            // Wait for the form submission to complete (adjust time as necessary)
            System.Threading.Thread.Sleep(5000);  // Adjust this time based on how long it takes for the form to submit

            // Optionally, check for a success message (if present)
            try
            {
                // Example: Wait for a success message or confirmation
                wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Thank you for contacting us')]")));
                Console.WriteLine("Form submitted successfully.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Success message not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Console.WriteLine("Stack Trace: " + ex.StackTrace);
        }
        finally
        {
            // Close the browser
            driver.Quit();
            Console.WriteLine("Browser closed.");
        }
    }
}