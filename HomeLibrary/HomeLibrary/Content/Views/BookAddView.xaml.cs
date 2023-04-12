using HomeLibrary.Content.Controller;
using HomeLibrary.Content.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (ownerInput.Text.Length == 0)
            {
                MessageBox.Show("Owner is required", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (titleInput.Text.Length == 0)
            {
                MessageBox.Show("Title is required", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (AcceptButton.Content == null) return;
            var book = GetUserData();

            string commandType = AcceptButton.Content.ToString();

            switch (commandType.ToLower().Trim())
            {
                case "update record":
                    {
                        EditBook(book);
                    }
                    break;
                case "insert record":
                    {
                        CreateBook(book);
                    }
                    break;
                case "delete record":
                    {
                        RemoveBook(book);
                    }
                    break;
            }

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
        }

        //Load ID from the grid
        public void LoadDataFromGrid(Guid? id)
        {
            Book book = new Book();

            //check if id is null
            if (id.HasValue)
            {
                book.Id = id.Value;
            }
            else
            {
                ClearBookAddView();
                return;
            }

            JsonFileController crud = new JsonFileController();
            List<Book> books = crud.FindBook(book);
            
            //get object from list
            Book record = books.FirstOrDefault(b => b.Id == id);
            if (record != null)
            {
                this.idInput.Text = id.ToString();
                this.ownerInput.Text = record.Owner.ToString();
                this.titleInput.Text = record.Title.ToString();
                this.authorInput.Text = record.Author.ToString();
                this.isAvailableInput.IsChecked = record.IsAvailable;
                
                if (record.Borrower != null)
                {
                    this.borrowerInput.Text = record.Borrower.ToString();
                }
            }
        }

        //Change UI type
        public void ChangeUIType(UIType uiType)
        {
            switch (uiType)
            {
                case UIType.UIEdit:
                    {
                        AcceptButton.Content = "Update Record";
                    }
                    break;
                case UIType.UICreate:
                    {
                        AcceptButton.Content = "Insert Record";
                    }
                    break;
                case UIType.UIDelete:
                    {
                        AcceptButton.Content = "Delete Record";
                    }
                    break;
            }
        }

        //Get data from the form
        private Book GetUserData()
        {
            var book = new Book();
            book.Id = Guid.Parse(this.idInput.Text.ToString());
            book.Owner = ownerInput.Text.Trim();
            book.Title = titleInput.Text.Trim();
            book.Author = authorInput.Text.Trim();
            book.IsAvailable = isAvailableInput.IsChecked.Value;

            if (borrowerInput.Text.Trim().Length > 0)
                book.Borrower = borrowerInput.Text.Trim();
            else
                book.Borrower = null;

            return (book);
        }

        private void ResetDataEntry()
        {
            ClearBookAddView();
        }

        //Clear the form
        public void ClearBookAddView()
        {
            this.idInput.Text = String.Empty;
            this.ownerInput.Text = String.Empty;
            this.titleInput.Text = String.Empty;
            this.authorInput.Text = String.Empty;
            this.isAvailableInput.IsChecked = false;
            this.borrowerInput.Text = String.Empty;
        }

        public void NewRecordGuid()
        {
            this.idInput.Text = Guid.NewGuid().ToString();
            this.idInput.IsEnabled = false;
        }

        public void SetDataIsEnabled(bool state)
        {
            this.ownerInput.IsEnabled = state;
            this.titleInput.IsEnabled = state;
            this.authorInput.IsEnabled = state;
        }

        //Create a new record
        private void CreateBook(Book newBook)
        {
            JsonFileController crud = new JsonFileController();

            var tupValue = crud.InsertData(newBook);

        }

        //Update a record
        private void EditBook(Book book)
        {
            JsonFileController crud = new JsonFileController();

            var tupValue = crud.UpdateData(book);

        }

        //Delete a record
        private void RemoveBook(Book book)
        {
            JsonFileController crud = new JsonFileController();
            var tupValue = crud.DeleteData(book);
        }
    }
}

