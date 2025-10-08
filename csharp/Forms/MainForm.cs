using System.Data;
using BookCatalog.Models;
using Microsoft.Data.Sqlite;

namespace BookCatalog.Forms;

public partial class MainForm : Form
{
    private const string ConnectionString = "Data Source=data/books.db";
    private readonly DataTable _booksTable = new();

    public MainForm()
    {
        InitializeComponent();
        InitializeDataGrid();
        LoadBooks();
    }

    private void InitializeDataGrid()
    {
        _booksTable.Columns.Add("Id", typeof(int));
        _booksTable.Columns.Add("Title", typeof(string));
        _booksTable.Columns.Add("Author", typeof(string));
        _booksTable.Columns.Add("Genre", typeof(string));
        _booksTable.Columns.Add("PublicationYear", typeof(int));
        dgvBooks.DataSource = _booksTable;
    }

    private void LoadBooks(string searchTerm = "")
    {
        _booksTable.Clear();
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            command.CommandText = "SELECT * FROM books ORDER BY Title";
        }
        else
        {
            command.CommandText = @"SELECT * FROM books 
                WHERE Title LIKE @search 
                OR Author LIKE @search 
                OR Genre LIKE @search 
                ORDER BY Title";
            command.Parameters.AddWithValue("@search", $"%{searchTerm}%");
        }

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            _booksTable.Rows.Add(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetInt32(4)
            );
        }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        LoadBooks(txtSearch.Text);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var addForm = new AddEditBookForm();
        if (addForm.ShowDialog() == DialogResult.OK)
        {
            LoadBooks();
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvBooks.CurrentRow == null) return;
        
        var book = new Book
        {
            Id = (int)dgvBooks.CurrentRow.Cells["Id"].Value,
            Title = (string)dgvBooks.CurrentRow.Cells["Title"].Value,
            Author = (string)dgvBooks.CurrentRow.Cells["Author"].Value,
            Genre = (string)dgvBooks.CurrentRow.Cells["Genre"].Value,
            PublicationYear = (int)dgvBooks.CurrentRow.Cells["PublicationYear"].Value
        };

        var editForm = new AddEditBookForm(book);
        if (editForm.ShowDialog() == DialogResult.OK)
        {
            LoadBooks();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvBooks.CurrentRow == null) return;

        var id = (int)dgvBooks.CurrentRow.Cells["Id"].Value;
        var title = (string)dgvBooks.CurrentRow.Cells["Title"].Value;

        if (MessageBox.Show($"Are you sure you want to delete '{title}'?", 
            "Confirm Delete", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM books WHERE Id = @id";
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();

        LoadBooks();
    }

    private void btnReport_Click(object sender, EventArgs e)
    {
        var reportForm = new ReportForm();
        reportForm.Show();
    }
}