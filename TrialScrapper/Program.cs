using HtmlAgilityPack;
using System;
using System.Diagnostics;
using System.Net;

namespace TrialScrapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double price = 0;
            string url = "https://www.google.com/finance/quote/TCS:NSE";
            string htmlContent;

            using (WebClient client = new WebClient())
            {
                htmlContent = client.DownloadString(url);
            }
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlContent);
          

            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//div[@class='YMlKec fxKbKc']");
            HtmlNodeCollection nodes1 = document.DocumentNode.SelectNodes("div.my-class");

            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    string data = node.InnerHtml; // Extract the desired data from the element
                    //Console.WriteLine(data.Substring(1)); // Output the extracted data
                    price = double.Parse(data.Substring(1));
                }
            }

            Console.WriteLine("SBIN : " + price);
        }
    }
}