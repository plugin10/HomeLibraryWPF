using HomeLibrary.Content.Models;
using Newtonsoft.Json;
using System;
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

            Loaded += UserControl_Loaded;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText(@"../../../Data/db.json");
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
            List<Book> availableBooks = new List<Book>();
            foreach (Book book in books)
            {
                availableBooks.Add(book);
                BooksDataGrid.Items.Add(book);
            }
        }
    }
}
