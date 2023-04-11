using HomeLibrary.Content.Controller;
using HomeLibrary.Content.Models;
using HomeLibrary.Content.ViewModels;
using HomeLibrary.Content.Viues;
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

            LoadBookAddView();

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

        //Load BookAddView
        private void LoadBookAddView()
        {
            BookAddView bookAddWindow = new BookAddView();
            RightPanel.Children.Clear();
            RightPanel.Children.Add(bookAddWindow);
        }

        //Load BookAddView with choosen option
        private void LoadBookAddView(Guid id, UIType Operation, bool isDataEnabled)
        {
            BookAddView bookAddWindow = new BookAddView();
            bookAddWindow.LoadDataFromGrid(id);
            bookAddWindow.ChangeUIType(Operation);
            bookAddWindow.SetDataIsEnabled(isDataEnabled);
            RightPanel.Children.Clear();
            RightPanel.Children.Add(bookAddWindow);
        }

        private void editBook_Click(object sender, RoutedEventArgs e) 
        {
            Button b = (Button)sender;

            if (b.CommandParameter != null)
            {
                Guid id = Guid.Parse(b.CommandParameter.ToString());

                LoadBookAddView(id,UIType.UIEdit, true);

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
