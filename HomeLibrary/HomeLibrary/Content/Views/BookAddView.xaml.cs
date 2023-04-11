using HomeLibrary.Content.Models;
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

namespace HomeLibrary.Content.Viues
{
    /// <summary>
    /// Interaction logic for BookAddView.xaml
    /// </summary>
    public partial class BookAddView : UserControl
    {
        public BookAddView()
        {
            InitializeComponent();
        }

        //private void AcceptButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ownerInput.GetValue(TextBox.TextProperty) != null && titleInput.GetValue(TextBox.TextProperty) != null && authorInput.GetValue(TextBox.TextProperty) != null)
        //    {
        //        var filePath = @"../../../Data/db.json";
        //        // Read existing json data
        //        var jsonData = System.IO.File.ReadAllText(filePath);
        //        // De-serialize to object or create new list
        //        var bookList = JsonConvert.DeserializeObject<List<Book>>(jsonData) ?? new List<Book>();

        //        Book newBook = new Book
        //        {
        //            Id = Guid.NewGuid(),
        //            Owner = ownerInput.Text,
        //            Title = titleInput.Text,
        //            Author = authorInput.Text,
        //            IsAvailable = true
        //        };

        //        bookList.Add(newBook);

        //        jsonData = JsonConvert.SerializeObject(bookList);
        //        System.IO.File.WriteAllText(@"../../../Data/db.json", jsonData);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please fill all fields");
        //    }
        //}
    }
}
