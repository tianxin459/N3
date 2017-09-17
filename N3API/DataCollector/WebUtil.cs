using N3DB.Entity;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
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
        IWebDriver _driver;

        public List<Article> Articles { get; set; } = new List<Article>();
        public List<Item> Items { get; set; } = new List<Item>();

        public Regex r1 = new Regex(@"(?<=编辑推荐<\/h3><\/div>).*?<\/div>.*?(?=<div class=""one-third"">)", RegexOptions.Singleline);

        public WebUtil()
        {
            PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
            //service.IgnoreSslErrors = true;
            service.LoadImages = false;
            //service.ProxyType = "none";
            _driver = new PhantomJSDriver(service);
        }


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

        public void CollectDataForItems()
        {
            string url = "https://cachecachebmnw.tmall.com/search.htm";
            List<IWebElement> titleElement = new List<IWebElement>();
            List<Article> articles = new List<Article>();
            List<string> rs = new List<string>();

            _driver.Navigate().GoToUrl(url);

            var items = _driver.FindElements(By.XPath(@"//*[@class='item ']"));
            if (items.Count == 0) Console.WriteLine("XPath for item is wrong");
            items.ToList().ForEach(i => this.Items.Add(new Item()
            {
                Title = i.FindElement(By.XPath(@".//*[@class='detail']/a")).GetAttribute("innerText").Trim(),
                Desc = "Desc: " + i.FindElement(By.XPath(@".//*[@class='detail']/a")).GetAttribute("innerText").Trim(),
                ImgUrl = "http:" + i.FindElement(By.XPath(@".//*[@class='photo']/*/img")).GetAttribute("data-ks-lazyload").Replace("_240x240.jpg",String.Empty).Trim(),
                Price = Decimal.Parse(i.FindElement(By.XPath(@".//*[@class='attribute']/*/span[@class='c-price']")).GetAttribute("innerText").Trim()),
            }));

            //var itemlines =_driver.FindElements(By.ClassName("clash-card"));
            //itemlines.ToList().ForEach(
            //    line =>
            //    {
            //        var items = line.FindElements(By.ClassName("item"));
            //    items.ToList().ForEach(
            //        i => this.Items.Add(new Item() {
            //            ImgUrl = x.FindElement(By.ClassName("photo")).GetAttribute("innerText").Trim()
            //        });
            //            );

            //        articles.Add(new Article()
            //        {
            //            Title = x.FindElement(By.ClassName("clash-card__unit-name")).GetAttribute("innerText").Trim(),
            //            Content = x.FindElement(By.ClassName("clash-card__unit-description")).GetAttribute("innerText").Trim(),
            //            LinkUrl = x.FindElement(By.ClassName("clash-card__unit-name")).FindElement(By.TagName("a")).GetAttribute("href"),
            //            MimeUrl = x.FindElement(By.ClassName("clash-card_box")).FindElement(By.TagName("img")).GetAttribute("src"),
            //            Mimetype = "Pic"
            //        });
            //    }
            //    );
            //this.Articles = articles;
        }



        public void OpenSite(string url)
        {
            //IWebDriver_driver;
            //driver = new PhantomJSDriver();

            List<IWebElement> titleElement = new List<IWebElement>();
            List<Article> articles = new List<Article>();
            List<string> rs = new List<string>();

            _driver.Navigate().GoToUrl(url);
            var article = _driver.FindElements(By.ClassName("clash-card"));
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
