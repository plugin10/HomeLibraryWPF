using HomeLibrary.Content.Models;
using Newtonsoft.Json;
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

namespace HomeLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (ownerInput.GetValue(TextBox.TextProperty) != null && titleInput.GetValue(TextBox.TextProperty) != null && authorInput.GetValue(TextBox.TextProperty) != null)
            {
                var filePath = @"../../../Data/db.json";
                // Read existing json data
                var jsonData = System.IO.File.ReadAllText(filePath);
                // De-serialize to object or create new list
                var employeeList = JsonConvert.DeserializeObject<List<Book>>(jsonData)
                                      ?? new List<Book>();

                Book newBook = new Book
                {
                    Id = Guid.NewGuid(),
                    Owner = ownerInput.Text,
                    Title = titleInput.Text,
                    Author = authorInput.Text,
                    IsAvailable = true    
                };

                employeeList.Add(newBook);

                jsonData = JsonConvert.SerializeObject(employeeList);
                System.IO.File.WriteAllText(@"../../../Data/db.json", jsonData);
            }
            else
            {
                MessageBox.Show("Please fill all fields");
            }
        }
    }
}
