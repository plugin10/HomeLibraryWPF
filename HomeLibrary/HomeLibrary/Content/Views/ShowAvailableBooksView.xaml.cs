﻿using HomeLibrary.Content.Controller;
using HomeLibrary.Content.Models;
using HomeLibrary.Content.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeLibrary.Content.Views
{
    /// <summary>
    /// Interaction logic for ShowAvailableBooksView.xaml
    /// </summary>
    public partial class ShowAvailableBooksView : UserControl
    {
        public ShowAvailableBooksView()
        {
            InitializeComponent();

            JsonFileController crud = new JsonFileController();

            ShowAvailableBooksViewModel test = new ShowAvailableBooksViewModel();

            foreach (Book book in test.books)
            {
                if (book.IsAvailable == true)
                {
                    BooksDataGrid.Items.Add(book);
                }
            }
        }

        private void editBook_Click(object sender, RoutedEventArgs e) 
        {
            Button b = (Button)sender;

            if (b.CommandParameter != null)
            {
                Guid id = Guid.Parse(b.CommandParameter.ToString());
                
                MessageBox.Show(id.ToString());
            }
        }

        private void deleteBook_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (b.CommandParameter != null)
            {
                Guid id = Guid.Parse(b.CommandParameter.ToString());

                MessageBox.Show(id.ToString());
            }
        }
    }
}
