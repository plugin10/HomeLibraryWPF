using HomeLibrary.Content.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HomeLibrary.Content.Controller
{
    public class JsonFileController
    {
        public JsonFileController()
        {
            //Load data on startup
            LoadJson();
        }

        //List of books in memory
        public List<Book>? books = null;

        //Save data to json file
        public bool SaveJson()
        {
            string filePath = @"../../../Data/db.json";

            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(books);

            System.IO.File.WriteAllText(filePath, jsonData);

            return (true);
        }

        //Find book by id
        public List<Book> FindBook(Book obj)
        {
            LoadJson();
            if (books != null)
            {
                return (books);
            }

            return null;
        }

        //Load data from json file
        public void LoadJson()
        {

            string filePath = @"../../../Data/db.json";
            if (File.Exists(filePath) == true)
            {
                var list = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(filePath));

                if (list != null)
                    books = list;
                else
                    books = new List<Book>();
            }
            else
            {
                books = new List<Book>();
            }

        }

        //Insert data to json file
        public (bool Success, string[]? errors) InsertData(Book newBook)
        {
            LoadJson();
            if (books == null)
            {
                books = new List<Book>();
            }

            var bookExists = books.FirstOrDefault(r => r.Id == newBook.Id);
            if (bookExists == null)
            {
                // add item to list
                books.Add(newBook);

                // serializeList to disk
                bool rv = SaveJson();
                if (rv != true)
                {
                    MessageBox.Show("Error writing json to disk");
                    string[] msg1 =
                    {
                        "Error writing JSON to disk",
                        $"{newBook.Id} {newBook.Title} is in memory object"
                    };
                    return (false, msg1);
                }

                return (true, null);
            }

            string[] msg2 =
                    {
                        "Error inserting record into memory object",
                        $"{newBook.Id} {newBook.Title} already exists"
                    };
            return (false, msg2);
        }

        //Update data in json file
        public (bool Success, string[]? errors) UpdateData(Book book)
        {
            LoadJson();
            if (books == null)
                books = new List<Book>();
            
            var test = books.FirstOrDefault(r => r.Id == book.Id);
            if (test != null)
            {
                test.Title = book.Title;
                test.Photo = book.Photo;
                test.Author = book.Author;
                test.Owner = book.Owner;
                test.IsAvailable = book.IsAvailable;
                test.Borrower = book.Borrower;

                // serializeList to disk
                bool rv = SaveJson();
                if (rv != true)
                {
                    MessageBox.Show("Error writing json to disk");
                    string[] msg1 =
                    {
                        "Error writing JSON to disk",
                        $"{book.Id} {book.Title} is in memory object"
                    };
                    return (false, msg1);
                }

                return (true, null);
            }

            string[] msg2 =
                    {
                        "Error updating record into memory object",
                        $"{book.Id} {book.Title} already exists"
                    };
            return (false, msg2);

        }

        public (bool Success, string[]? errors) DeleteData(Book book)
        {
            LoadJson();
            if (books == null)
            {
                books = new List<Book>();
            }

            var test = books.FirstOrDefault(r => r.Id == book.Id);
            if (test != null)
            {
                // remove book to list
                books.RemoveAll(r => r.Id == test.Id);

                // serializeList to disk
                bool rv = SaveJson();
                if (rv != true)
                {
                    MessageBox.Show("Error writing json to disk");
                    string[] msg1 =
                    {
                        "Error writing JSON to disk",
                        $"{book.Id} {book.Title} is in memory object"
                    };
                    return (false, msg1);
                }

                return (true, null);
            }

            string[] msg2 =
                    {
                        "Error inserting record into memory object",
                        $"{book.Id} {book.Title} already exists"
                    };
            return (false, msg2);

        }
    }
}
