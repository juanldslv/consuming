using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Foundation;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace ejemplo
{
    public class Request: IRequest
    {

        private static HttpClient _instance;

        HttpClient client;
        private static HttpClient HttpClientInstance => _instance ?? (_instance = new HttpClient());

        public Request()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }


        public async Task <List<BookElement>> GetBook(string title)
        {

            List<BookElement> bookel = new List<BookElement>();

            Book book = new Book();
                Uri uri;
                uri = new Uri(string.Format(Constants.URLSearch + title, string.Empty));
                var response = await client.GetAsync(uri);


                var content = await response.Content.ReadAsStringAsync();
                
                if (response.IsSuccessStatusCode)
                {

                book = JsonConvert.DeserializeObject<Book>(content);

            }
            foreach (var item in book.Books)
            {
                bookel.Add(item);
            }

            return bookel;
        }

        public async Task<List<BookElement>> GetBooks()
        {
            Uri uri;
            uri = new Uri(string.Format(Constants.URLnew, string.Empty));
            var response = await client.GetAsync(uri);
            Book bookel ;
            var content = await response.Content.ReadAsStringAsync();
            bookel = JsonConvert.DeserializeObject<Book>(content);
            List<BookElement> elements = new List<BookElement>();
            foreach (var item in bookel.Books)
            {
                elements.Add(item);
            }
            return elements;
        }

        public async Task<BookDetail> GetDetailBook(string isbn13)
        {
            Uri uri;
            BookDetail detail = new BookDetail();
            uri = new Uri(string.Format(Constants.URLBooksDetails+isbn13, string.Empty));
            var response = await client.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            detail = JsonConvert.DeserializeObject<BookDetail>(content);
            return detail;

        }
    }
}
