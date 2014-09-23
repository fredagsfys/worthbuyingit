using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WBI.Models.Scraper
{
    public class Prisjakt
    {
        // URL to scrape
        private readonly string _urlAddress;
        public Prisjakt(string urlAddress)
        {
            this._urlAddress = urlAddress;
        }

        public void Scrape()
        {
            // Create a request with url
            var webRequest = WebRequest.Create(this._urlAddress);
            // Get the response from the request
            var response = (HttpWebResponse)webRequest.GetResponse();

            // Check if response is 200 OK
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Init new HtmlDocument
                var doc = new HtmlDocument();
                try
                {
                    // Get the stream from requests response
                    Stream stream = webRequest.GetResponse().GetResponseStream();
                    if (stream != null)
                    {
                        // Load the document using stream
                        doc.Load(stream);
                        // Close the stream
                        stream.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                // Begin scraping


                var productName =
                    doc.DocumentNode.Descendants().Single(o => o.Id == "page_header").Element("h1").InnerText.Trim();

                var productBrand =
                    doc.DocumentNode.Descendants()
                        .Single(x => x.Name == "meta" && x.Attributes.Contains("property")
                                     && x.Attributes["property"].Value.Split().Contains("og:brand")).Attributes[
                                         "content"].Value;


                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//div[@id='desc_trunc']"))
                {
                    string att = link.InnerText;
                    //att.Value = FixLink(att);
                }
            }

            //doc.Save("file.htm"););
        }
    }
}
