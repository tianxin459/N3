using N3DB.Entity;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataCollector
{
    public class WebUtil
    {
        public List<Article> Articles { get; set; } = new List<Article>();

        public Regex r1 = new Regex(@"(?<=编辑推荐<\/h3><\/div>).*?<\/div>.*?(?=<div class=""one-third"">)", RegexOptions.Singleline);
        public string GetPageContent(string url)
        {
            string result = string.Empty;

            using (var client = new HttpClient())
            {
                result = client.GetStringAsync(url).Result;
            }

            return result;
        }

        public List<string> Filter1(string input)
        {
            List<string> result = new List<string>();
            var r1s = r1.Matches(input);
            foreach (var m in r1s)
            {
                result.Add(m.ToString());
            }
            return result;
        }

        public void OpenSite(string url)
        {

            IWebDriver driver;
            driver = new ChromeDriver();

            List<IWebElement> titleElement = new List<IWebElement>();
            List<Article> articles = new List<Article>();
            List<string> rs = new List<string>();

            driver.Navigate().GoToUrl(url);
            var article = driver.FindElements(By.ClassName("clash-card"));
            article.ToList().ForEach(
                x =>
                {
                    articles.Add(new Article()
                    {
                        Title = x.FindElement(By.ClassName("clash-card__unit-name")).GetAttribute("innerText").Trim(),
                        Content = x.FindElement(By.ClassName("clash-card__unit-description")).GetAttribute("innerText").Trim(),
                        LinkUrl = x.FindElement(By.ClassName("clash-card__unit-name")).FindElement(By.TagName("a")).GetAttribute("href"),
                        MimeUrl = x.FindElement(By.ClassName("clash-card_box")).FindElement(By.TagName("img")).GetAttribute("src"),
                        Mimetype = "Pic"
                    });
                }
                );
            this.Articles = articles;
        }

    }
}
