using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GalaSoft.MvvmLight;
using UIKit;
using Foundation;

namespace ejemplo
{
    public class Book

    {
        public Book()
        {

        }
        [JsonProperty("error")]

        public long Error { get; set; }

        [JsonProperty("total")]

        public long Total { get; set; }

        [JsonProperty("books")]
        public List<BookElement> Books { get; set; }
    }

    public class BookElement
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("isbn13")]
        public string Isbn13 { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        static UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);

        }
        [JsonProperty("image")]
        public Uri
         Image { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }


        public UIImage ImageFull { get; set; }

        
        public BookElement(string title, string subtitle, string isbn13, string price, Uri image, Uri url)
        {
             
            Title = title;
            Subtitle = subtitle;
            Isbn13 = isbn13;
            Price = price;

            ImageFull = FromUrl(Image.ToString()); 
            
            Url = url;

        }

        public BookElement()
        {
        }
    }
    public class BookDetail { 

    [JsonProperty("error")]
    public long Error { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("subtitle")]
    public string Subtitle { get; set; }

    [JsonProperty("authors")]
    public string Authors { get; set; }

    [JsonProperty("publisher")]
    public string Publisher { get; set; }

    [JsonProperty("isbn10")]
    public string Isbn10 { get; set; }

    [JsonProperty("isbn13")]
    public string Isbn13 { get; set; }

    [JsonProperty("pages")]

    public string Pages { get; set; }

    [JsonProperty("year")]

    public string Year { get; set; }

    [JsonProperty("rating")]

    public string Rating { get; set; }

    [JsonProperty("desc")]
    public string Desc { get; set; }

    [JsonProperty("price")]
    public string Price { get; set; }

    [JsonProperty("image")]
    public Uri Image { get; set; }

    [JsonProperty("url")]
    public Uri Url { get; set; }

    [JsonProperty("pdf")]
        public List<string> Pdf  { get; set; }
    }
}
