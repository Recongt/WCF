using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Library
{
    public class Service1 : IService1
    {

        public static int UserId = 1;

        private static List<Book> books = new List<Book>
        {
            new Book
            {
                ID = 0,
                BookInfo = new BookInfo
                {
                    Title = "Anioły i demony",
                    Author = "Dan Brown",
                    Year = "2000"
                },
                Status = new Status
                {
                    BookID = 0,
                    Stan = false,
                    UserId = 0
                }

            },
            new Book
            {
                ID = 1,
                BookInfo = new BookInfo
                {
                    Title = "Metro 2033",
                    Author = "Dmitrij Głuchowski",
                    Year = "2005"
                },
                Status = new Status
                {
                    BookID = 1,
                    Stan = false,
                    UserId = 0
                }
            },
            new Book
            {
                ID = 2,
                BookInfo = new BookInfo
                {
                    Title = "Krótka historia czasu",
                    Author = "Stephen Hawking",
                    Year = "1990"
                },
                Status = new Status
                {
                    BookID = 2,
                    Stan = false,
                    UserId = 0
                }
            },
                        new Book
            {
                ID = 3,
                BookInfo = new BookInfo
                {
                    Title = "Ślepy zegarmistrz",
                    Author = "Richard Dawkins",
                    Year = "1986"
                },
                Status = new Status
                {
                    BookID = 3,
                    Stan = false,
                    UserId = 0
                }
            }

        };


        public int connectToLibrary()
        {
            return UserId++;
        }

        public List<Book> listOfBooks()
        {
            return books;
        }

        public List<Book> listOfBorrowedItems()
        {
            try
            {
                List<Book> ksiazki;
                ksiazki = books.Where(x => x.Status.Stan).ToList();
                return ksiazki;
            }
            catch (Exception)
            {
                BookExceptions ex = new BookExceptions();
                ex.Message = "Brak wypożyczonych książek";

                throw new FaultException<BookExceptions>(ex);
            }
        }

        public List<Book> getUserBorrowedBooks(int userID)
        {
            try
            {
                List<Book> ksiazki;
                ksiazki = books.Where(x => x.Status.Stan && x.Status.UserId == userID).ToList();
                return ksiazki;
            }
            catch (Exception)
            {
                BookExceptions ex = new BookExceptions();
                ex.Message = "Nie masz wypożyczonej żadnej książki";

                throw new FaultException<BookExceptions>(ex);
            }

        }

        public Book getBookInfo(int bookID)
        {
            try
            {
                Book book;
                book = books.First(x => x.ID == bookID);
                return book;
            }
            catch (Exception)
            {
                BookExceptions ex = new BookExceptions();
                ex.Message = "Nie ma takiej książki";

                throw new FaultException<BookExceptions>(ex);
            }

        }

        public void borrowBook(int bookID, int userID)
        {
            try
            {
                Book book = books.First(x => x.ID == bookID && x.Status.UserId == 0);
                if (!book.Status.Stan)
                {
                    book.Status.Stan = true;
                    book.Status.UserId = userID;

                }
            }
            catch (Exception)
            {

                BookExceptions ex = new BookExceptions();
                ex.Message = "Nie można wypożyczyć. \n\tNieprawidłowy nr książki lub książka aktualnie wypożyczona";
                throw new FaultException<BookExceptions>(ex);
            }
        }

        public void giveBook(int bookID, int userID)
        {
            try
            {
                Book book = books.First(x => x.ID == bookID && x.Status.UserId == userID);
                if (book.Status.Stan)
                {
                    book.Status.Stan = false;
                    book.Status.UserId = 0;

                }
            }
            catch (Exception)
            {
                BookExceptions ex = new BookExceptions();
                ex.Message = "Nie ma takiej książki na Twoim koncie";
                throw new FaultException<BookExceptions>(ex);
            }

        }
    }
}
