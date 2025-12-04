namespace BibliotekSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();
            bool running = true;

            while (running)
            {
                DisplayMenu();
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (choice)
                    {
                        case 1:
                            ShowAddBookMenu(library);
                            break;
                        case 2:
                            ShowRemoveBookMenu(library);
                            break;
                        case 3:
                            ShowFindBookMenu(library);
                            break;
                        case 4:
                            ShowGetAllBooksMenu(library);
                            break;
                        case 5:
                            ShowLoanMenu(library);
                            break;
                        case 6:
                            ShowReturnMenu(library);
                            break;
                        case 7:
                            running = false;
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Find Book by Title");
            Console.WriteLine("4. Get All Books");
            Console.WriteLine("5. Loan Book");
            Console.WriteLine("6. Return Book");
            Console.WriteLine("7. Exit");
            Console.WriteLine("******************************************");
            Console.WriteLine("Ange val:");
        }

        static void ShowAddBookMenu(Library library)
        {
            Console.WriteLine("Add Book Menu");
            Console.WriteLine("*************");
            // Implementation for adding a book
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            var book = new Book(title, author, isbn, true);

            library.AddBook(book);

            Console.WriteLine($"Book '{title}' added successfully.");
        }
        static void ShowRemoveBookMenu(Library library)
        {
            Console.WriteLine("Remove Book Menu");
            Console.WriteLine("****************");
            // Implementation for removing a book
        }
        static void ShowFindBookMenu(Library library)
        {
            Console.WriteLine("Find Book Menu");
            Console.WriteLine("**************");
            // Implementation for finding a book by title
            Console.Write("Enter book title to find: ");
            string title = Console.ReadLine();
            var book = library.FindBookByTitle(title);
            if (book != null)
            {
                Console.WriteLine($"Book found: {book.Title} by {book.Author}, ISBN: {book.ISBN}, Available: {book.IsLoaned}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        static void ShowGetAllBooksMenu(Library library)
        {
            Console.WriteLine("Get All Books Menu");
            Console.WriteLine("******************");
            // Implementation for getting all books
            var books = library.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author}, ISBN: {book.ISBN}, Available: {book.IsLoaned}");
            }
        }
        static void ShowLoanMenu(Library library)
        {
            Console.WriteLine("Loan Book Menu");
            Console.WriteLine("**************");
            Console.Write("Enter ISBN of the book to loan: ");
            string isbn = Console.ReadLine();
            try
            {
                var book = library.LoanBook(isbn);
                Console.WriteLine($"Book '{book.Title}' loaned successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ShowReturnMenu(Library library)
        {
            Console.WriteLine("Return Book Menu");
            Console.WriteLine("****************");
            Console.Write("Enter ISBN of the book to return: ");
            string isbn = Console.ReadLine();
            try
            {
                var book = library.ReturnBook(isbn);
                Console.WriteLine($"Book '{book.Title}' returned successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
