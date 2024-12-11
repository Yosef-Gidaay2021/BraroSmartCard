using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

class Program
{
    static void Main(string[] args)
    {
    
       // SubscribeYouTube subscribeYouTube = new SubscribeYouTube();
        //subscribeYouTube.SubscribeYouTubeChannel();
        FollowOnLinkedIn followOnLinkedIn = new FollowOnLinkedIn();
        followOnLinkedIn.FollowOnLinkedInPage();
    }
}
