using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekSystem;
using Xunit;

namespace BibliotekSystem.Tests
{
    public class BookTests
    {
        [Fact]
        public void Loan_WhenBookIsAvailable_ShouldMarkAsLoaned()
        {
            // Arrange
            var book = new Book("Clean Code", "Robert Martin", "ISBN001");

            // Act
            book.Loan();

            // Assert
            Assert.True(book.IsLoaned);
        }

        [Fact]
        public void Loan_WhenBookIsAlreadyLoaned_ShouldThrowException()
        {
            // Arrange
            var book = new Book("Clean Code", "Robert Martin", "ISBN001");
            book.Loan();

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => book.Loan());
            Assert.Equal("Boken är redan utlånad.", exception.Message);
        }

        [Fact]
        public void Return_WhenBookIsLoaned_ShouldMarkAsAvailable()
        {
            // Arrange
            var book = new Book("Clean Code", "Robert Martin", "ISBN001");
            book.Loan();

            // Act
            book.Return();

            // Assert
            Assert.False(book.IsLoaned);
        }
        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            string title = "The Pragmatic Programmer";
            string author = "Andrew Hunt and David Thomas";
            string isbn = "ISBN123456";
            // Act
            var book = new Book(title, author, isbn);
            // Assert
            Assert.Equal(title, book.Title);
            Assert.Equal(author, book.Author);
            Assert.Equal(isbn, book.ISBN);
            Assert.False(book.IsLoaned);
        }
        [Fact]
        public void Constructor_ShouldSetIsLoanedToFalseByDefault()
        {
            // Arrange
            string title = "Design Patterns";
            string author = "Erich Gamma et al.";
            string isbn = "ISBN7891011";
            // Act
            var book = new Book(title, author, isbn);
            // Assert
            Assert.False(book.IsLoaned);
        }
    }
}
