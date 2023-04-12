using HomeLibrary.Content.Controller;
using HomeLibrary.Content.Models;
using HomeLibrary.Content.ViewModels;
using System;
using System.Collections.Generic;
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
using static System.Net.Mime.MediaTypeNames;

namespace HomeLibrary.Content.Views
{
    /// <summary>
    /// Interaction logic for ShowUnavailableBooksView.xaml
    /// </summary>
    public partial class ShowUnavailableBooksView : UserControl
    {
        public ShowUnavailableBooksView()
        {
            InitializeComponent();

            JsonFileController crud = new JsonFileController();

            foreach (Book book in crud.books)
            {
                if (book.IsAvailable == false)
                {
                    BooksDataGrid.Items.Add(book);
                }
            }
        }
    }
}
