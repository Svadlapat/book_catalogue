using Microsoft.Data.Sqlite;

namespace BookCatalog.Forms;

public partial class ReportForm : Form
{
    private const string ConnectionString = "Data Source=data/books.db";

    public ReportForm()
    {
        InitializeComponent();
        LoadReports();
    }

    private void LoadReports()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        // Books by Genre
        var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT Genre, COUNT(*) as Count 
            FROM books 
            GROUP BY Genre 
            ORDER BY Count DESC, Genre";

        txtReport.AppendText("Books by Genre:\r\n");
        txtReport.AppendText("----------------\r\n");
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                txtReport.AppendText($"{reader.GetString(0)}: {reader.GetInt32(1)}\r\n");
            }
        }

        // Books by Author
        command = connection.CreateCommand();
        command.CommandText = @"
            SELECT Author, COUNT(*) as Count 
            FROM books 
            GROUP BY Author 
            ORDER BY Count DESC, Author
            LIMIT 10";

        txtReport.AppendText("\r\nTop 10 Authors by Number of Books:\r\n");
        txtReport.AppendText("--------------------------------\r\n");
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                txtReport.AppendText($"{reader.GetString(0)}: {reader.GetInt32(1)}\r\n");
            }
        }

        // Publication Years
        command = connection.CreateCommand();
        command.CommandText = @"
            SELECT 
                CASE 
                    WHEN PublicationYear >= 2020 THEN '2020s'
                    WHEN PublicationYear >= 2010 THEN '2010s'
                    WHEN PublicationYear >= 2000 THEN '2000s'
                    WHEN PublicationYear >= 1990 THEN '1990s'
                    ELSE 'Before 1990'
                END as Decade,
                COUNT(*) as Count
            FROM books 
            GROUP BY Decade 
            ORDER BY MIN(PublicationYear) DESC";

        txtReport.AppendText("\r\nBooks by Decade:\r\n");
        txtReport.AppendText("----------------\r\n");
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                txtReport.AppendText($"{reader.GetString(0)}: {reader.GetInt32(1)}\r\n");
            }
        }
    }
}