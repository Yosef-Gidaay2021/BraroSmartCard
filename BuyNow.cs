using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class BuyNow
{
  public void BuyNowPage()
  {
    // Initialize ChromeDriver
    IWebDriver driver = new ChromeDriver();

    try
    {
      // Navigate to the website
      driver.Navigate().GoToUrl("https://brarosmartcard.vercel.app/");
      Console.WriteLine("Navigated to the website.");
       System.Threading.Thread.Sleep(5000);

      try
      {
        var buyNowLink = driver.FindElement(By.CssSelector("button.z-0.group.relative.inline-flex.items-center.justify-center"));
        buyNowLink.Click();
        Console.WriteLine("Found Get Your Card link and clicked.");
      }
      catch (NoSuchElementException)
      {
        Console.WriteLine("Buy Now link not found.");
        return;
      }

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