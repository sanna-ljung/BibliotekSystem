namespace BibliotekSystem;

public class Library
{
    public List<Book> Books { get; set; }

    public Library()
    {
        Books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public Book? FindBookByTitle(string title)
    {
        return Books.FirstOrDefault(b =>
            b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public void LoanBook(string isbn)
    {
        var book = Books.FirstOrDefault(b => b.ISBN == isbn);
        if (book == null)
            throw new InvalidOperationException("Boken hittades inte.");
        book.Loan();
    }

    public void ReturnBook(string isbn)
    {
        var book = Books.FirstOrDefault(b => b.ISBN == isbn);
        if (book == null)
            throw new InvalidOperationException("Boken hittades inte.");
        book.Return();
    }
}
