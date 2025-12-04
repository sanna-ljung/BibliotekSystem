using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekSystem;

namespace BibliotekSystem.Tests
{
    public class LibraryTests
    {
        [Fact]
        public void AddBook_ShouldAddBookToLibrary()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Test Book", "Test Author", "ISBN001");

            // Act
            library.AddBook(book);

            // Assert
            Assert.Single(library.Books);
            Assert.Contains(book, library.Books);
        }

        [Fact]
        public void FindBookByTitle_ShouldBeCaseInsensitive()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Clean Code", "Robert Martin", "ISBN001");
            library.AddBook(book);

            // Act
            var found = library.FindBookByTitle("clean code");

            // Assert
            Assert.NotNull(found);
            Assert.Equal("Clean Code", found.Title);
        }

        [Fact]
        public void LoanBook_ShouldMarkBookAsLoaned()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Test Book", "Test Author", "ISBN001");
            library.AddBook(book);

            // Act
            library.LoanBook("ISBN001");

            // Assert
            Assert.True(book.IsLoaned);
        }
    }
}
