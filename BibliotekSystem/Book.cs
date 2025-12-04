namespace BibliotekSystem;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsLoaned { get; set; }

    public Book(string title, string author, string isbn, bool isLoaned = false)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        IsLoaned = false;
    }

    public void Loan()
    {
        if (IsLoaned)
            throw new InvalidOperationException("Boken är redan utlånad.");
        IsLoaned = true;
    }

    public void Return()
    {
        if (!IsLoaned)
            throw new InvalidOperationException("Boken är inte utlånad.");
        IsLoaned = false;
    }
}
