using HomeLibrary.Content.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeLibrary.Content.ViewModels
{
    class ShowAvailableBooksViewModel
    {
        public ShowAvailableBooksViewModel() 
        {
            LoadJson();
        }

        public List<Book> books = new List<Book>();
        //public List<Book> LoadFile()
        //{
        //    //string json = File.ReadAllText(@"../../../Data/db.json");
        //    //List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
        //    //List<Book> availableBooks = new List<Book>();

        //    //return books;
        //    ////foreach (Book book in books)
        //    ////{
        //    ////    availableBooks.Add(book);
        //    ////    BooksDataGrid.Items.Add(book);
        //    ////}
        //}

        private void LoadJson()
        {
            string json = @"../../../Data/db.json";
            if (File.Exists(json) == true)
            {
                var listOfBooks = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(json));

                if (listOfBooks != null)
                {
                    books = listOfBooks;
                }
                else
                {
                    books = new List<Book>();
                }
            }
            else
            {
                books = new List<Book>();
            }
        }
        
        
    }
}
