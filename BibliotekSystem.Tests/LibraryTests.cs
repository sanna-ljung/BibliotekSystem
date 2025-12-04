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
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            //Arrange
            var library = new Library();
            var book1 = new Book("Book One", "Author A", "ISBN001");
            var book2 = new Book("Book Two", "Author B", "ISBN002");
            library.AddBook(book1);
            library.AddBook(book2);
            // Act
            var allBooks = library.GetAllBooks();
            // Assert
            Assert.Equal(2, allBooks.Count);
            Assert.Contains(book1, allBooks);
            Assert.Contains(book2, allBooks);
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
        [Fact]
        public void LoanBook_WhenBookIsAlreadyLoaned_ShouldThrowException()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Test Book", "Test Author", "ISBN001");
            library.AddBook(book);
            library.LoanBook("ISBN001");
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => library.LoanBook("ISBN001"));
        }
        [Fact]
        public void ReturnBook_ShouldMarkBookAsAvailable()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Test Book", "Test Author", "ISBN001");
            library.AddBook(book);
            library.LoanBook("ISBN001");
            // Act
            library.ReturnBook("ISBN001");
            // Assert
            Assert.False(book.IsLoaned);
        }
        [Fact]
        public void ReturnBook_WhenBookIsNotLoaned_ShouldThrowException()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Test Book", "Test Author", "ISBN001");
            library.AddBook(book);
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => library.ReturnBook("ISBN001"));
        }
        [Fact]
        public void Constructor_ShouldInitializeBooksList()
        {
            // Arrange & Act
            var library = new Library();
            // Assert
            Assert.NotNull(library.Books);
            Assert.Empty(library.Books);
        }
    }
    }
