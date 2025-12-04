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

    public List<Book> GetAllBooks()
    {
        return Books;
    }

    public Book LoanBook(string isbn)
    {
        var book = Books.FirstOrDefault(b => b.ISBN == isbn && !b.IsLoaned);
        if (book == null)
            throw new InvalidOperationException("Boken hittades inte.");
        book.Loan();
        return book;
    }

    public Book ReturnBook(string isbn)
    {
        var book = Books.FirstOrDefault(b => b.ISBN == isbn);
        if (book == null)
            throw new InvalidOperationException("Boken hittades inte.");
        book.Return();
        return book;
    }
}
