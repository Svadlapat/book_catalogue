using BookCatalog.Models;
using Microsoft.Data.Sqlite;

namespace BookCatalog.Forms;

public partial class AddEditBookForm : Form
{
    private const string ConnectionString = "Data Source=data/books.db";
    private readonly Book? _bookToEdit;

    public AddEditBookForm(Book? book = null)
    {
        InitializeComponent();
        _bookToEdit = book;

        if (book != null)
        {
            Text = "Edit Book";
            txtTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtGenre.Text = book.Genre;
            numYear.Value = book.PublicationYear;
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
            string.IsNullOrWhiteSpace(txtAuthor.Text) ||
            string.IsNullOrWhiteSpace(txtGenre.Text))
        {
            MessageBox.Show("Please fill in all fields.", "Validation Error");
            return;
        }

        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        if (_bookToEdit == null)
        {
            command.CommandText = @"INSERT INTO books (Title, Author, Genre, PublicationYear) 
                                  VALUES (@title, @author, @genre, @year)";
        }
        else
        {
            command.CommandText = @"UPDATE books 
                                  SET Title = @title, Author = @author, 
                                      Genre = @genre, PublicationYear = @year
                                  WHERE Id = @id";
            command.Parameters.AddWithValue("@id", _bookToEdit.Id);
        }

        command.Parameters.AddWithValue("@title", txtTitle.Text);
        command.Parameters.AddWithValue("@author", txtAuthor.Text);
        command.Parameters.AddWithValue("@genre", txtGenre.Text);
        command.Parameters.AddWithValue("@year", (int)numYear.Value);

        command.ExecuteNonQuery();
        DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }
}