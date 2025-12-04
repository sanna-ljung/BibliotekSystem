using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekSystem.Tests
{
    public class LibraryIntegrationTests
    {
        [Fact]
        public void CompleteFlow_AddBook_LoanBook_ReturnBook_ShouldSucceed() 
        {
            // Arrange
            var library = new Library();
            var book = new Book("Integration Test Book", "Test Author", "ISBN001");

            // Act step 1: Add book to library
            library.AddBook(book);
            // Assert step 1
            var foundBook = library.FindBookByTitle("Integration Test Book");
            Assert.NotNull(foundBook);
            Assert.False(foundBook.IsLoaned);
            
            // Act step 2: Loan the book
            library.LoanBook("ISBN001");
            // Assert step 2
            Assert.True(foundBook.IsLoaned);
            
            // Act step 3: Return the book
            library.ReturnBook("ISBN001");
            // Assert step 3
            Assert.False(foundBook.IsLoaned);
        }
        [Fact]
        public void CompleteFlow_MultipleBooks_ShouldHandleIndependently()
        {
            // Arrange
            var library = new Library();
            var book1 = new Book("Book One", "Author A", "ISBN001");
            var book2 = new Book("Book Two", "Author B", "ISBN002");
            
            // Act: Add books to library
            library.AddBook(book1);
            library.AddBook(book2);
            
            // Act: Loan first book
            library.LoanBook("ISBN001");
            
            // Assert: First book is loaned, second is not
            Assert.True(library.FindBookByTitle("Book One").IsLoaned);
            Assert.False(library.FindBookByTitle("Book Two").IsLoaned);
            
            // Act: Return first book and loan second book
            library.ReturnBook("ISBN001");
            library.LoanBook("ISBN002");
            
            // Assert: First book is returned, second is loaned
            Assert.False(library.FindBookByTitle("Book One").IsLoaned);
            Assert.True(library.FindBookByTitle("Book Two").IsLoaned);
        }
    }
}
