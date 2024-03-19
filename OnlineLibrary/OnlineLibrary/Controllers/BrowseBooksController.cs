using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Models.ViewModels;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Google.Apis.Requests;
using System.Runtime.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using static OnlineLibrary.Models.ViewModels.BookInfo;
using static Google.Apis.Requests.BatchRequest;

namespace OnlineLibrary.Controllers
{
    public class BrowseBooksController : Controller
    {
        [HttpGet]
        public IActionResult Browse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Browse(string inputField)
        {
            // Create search query from user input
            if (inputField == null || inputField == "")
            {
                return View();
            }
            else
            {
                // Curate the inputField data
                string searchQuery = inputField.Replace(" ", "+");
                string pagination = "&maxResults=40";

                using (var client = new HttpClient())
                {
                    // Send request to the API and fetch the response
                    var uri = new Uri("https://www.googleapis.com/books/v1/volumes?q=" + searchQuery + pagination);
                    var response = await client.GetAsync(uri);

                    // List of VolumeInfos returned by the response
                    List<BookViewModel> books = new List<BookViewModel>();
                    if (response.IsSuccessStatusCode)
                    {
                        books = generateBook(response);
                        return View(books);
                    }
                    // Return the list of models to the view
                    else
                    {
                        // Handle Errors
                        System.Diagnostics.Debug.WriteLine("Oh noes someone stepped on my toes. >.<");
                    }
                    return View();
                }
            }
        }

        private List<BookViewModel> generateBook(HttpResponseMessage response)
        {
            // Generate string from response
            var textResult = response.Content.ReadAsStringAsync().Result;

            // List of VolumeInfos returned by the response
            List<BookViewModel> books = new List<BookViewModel>();

            // Deserialize the entire JSON response into BookInfo model
            BookInfo.Rootobject rootObject = JsonConvert.DeserializeObject<BookInfo.Rootobject>(textResult);

            if (rootObject.totalItems > 1)
            {
                foreach (var item in rootObject.items)
                {
                    // Access individual book information from each item
                    string title = item.volumeInfo.title;
                    string[] authors = item.volumeInfo.authors;
                    string publisher = item.volumeInfo.publisher;
                    string publishedDate = item.volumeInfo.publishedDate;
                    string description = item.volumeInfo.description;
                    int pageCount = item.volumeInfo.pageCount;
                    string printType = item.volumeInfo.printType;
                    string[] categories = item.volumeInfo.categories;

                    // Access imageLinks property
                    string smallThumbnail = item.volumeInfo.imageLinks?.smallThumbnail;
                    string thumbnail = item.volumeInfo.imageLinks?.thumbnail;

                    string language = item.volumeInfo.language;
                    float averageRating = item.volumeInfo.averageRating;
                    string apiBookID = item.id;

                    string shortDescription = item.volumeInfo.description;
                    if (!string.IsNullOrEmpty(shortDescription) && shortDescription.Length > 150)
                    {
                        shortDescription = shortDescription.Substring(0, 150);
                        shortDescription += "...";
                    }

                    // Populate the volumeInfo model
                    BookViewModel volumeinfo = new BookViewModel
                    {
                        title = title,
                        authors = authors,
                        publisher = publisher,
                        publishedDate = publishedDate,
                        description = description,
                        pageCount = pageCount,
                        printType = printType,
                        categories = categories,
                        smallThumbnail = smallThumbnail,
                        thumbnail = thumbnail,
                        language = language,
                        shortDescription = shortDescription,
                        averageRating = averageRating,
                        apiBookID = apiBookID
                    };
                    // Add the volumeInfo model to a list of models
                    books.Add(volumeinfo);
                }
            }
            else
            {
                EditBookInfo.Rootobject editRootobject = JsonConvert.DeserializeObject<EditBookInfo.Rootobject>(textResult);
                var item = editRootobject;

                // Access individual book information from each item
                string title = item.volumeInfo.title;
                string[] authors = item.volumeInfo.authors;
                string publisher = item.volumeInfo.publisher;
                string publishedDate = item.volumeInfo.publishedDate;
                string description = item.volumeInfo.description;
                int pageCount = item.volumeInfo.pageCount;
                string printType = item.volumeInfo.printType;
                string[] categories = item.volumeInfo.categories;

                // Access imageLinks property
                string smallThumbnail = item.volumeInfo.imageLinks?.smallThumbnail;
                string thumbnail = item.volumeInfo.imageLinks?.thumbnail;

                string language = item.volumeInfo.language;
                float averageRating = 0.0f;
                string apiBookID = item.id;

                string shortDescription = item.volumeInfo.description;
                if (!string.IsNullOrEmpty(shortDescription) && shortDescription.Length > 150)
                {
                    shortDescription = shortDescription.Substring(0, 150);
                    shortDescription += "...";
                }

                // Populate the volumeInfo model
                BookViewModel volumeinfo = new BookViewModel
                {
                    title = title,
                    authors = authors,
                    publisher = publisher,
                    publishedDate = publishedDate,
                    description = description,
                    pageCount = pageCount,
                    printType = printType,
                    categories = categories,
                    smallThumbnail = smallThumbnail,
                    thumbnail = thumbnail,
                    language = language,
                    shortDescription = shortDescription,
                    averageRating = averageRating,
                    apiBookID = apiBookID
                };
                // Add the volumeInfo model to a list of models
                books.Add(volumeinfo);
            }
            // Access the items array containing the book information
            return books;
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            using (var client = new HttpClient())
            {
                // Send request to the API and fetch the response
                var uri = new Uri("https://www.googleapis.com/books/v1/volumes/" + id);
                var response = await client.GetAsync(uri);
                System.Diagnostics.Debug.WriteLine(id);

                // List of VolumeInfos returned by the response
                List<BookViewModel> books = new List<BookViewModel>();
                if (response.IsSuccessStatusCode)
                {
                    books = generateBook(response);
                    System.Diagnostics.Debug.WriteLine(books);
                    return View(books);
                }
                // Return the list of models to the view
                else
                {
                    // Handle Errors
                    System.Diagnostics.Debug.WriteLine("Oh noes someone stepped on my toes. >.<");
                }
                return View();
            }
        }
    }
}
