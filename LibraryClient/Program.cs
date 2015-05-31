using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LibraryClient.ServiceReference;

namespace LibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IService1 server = new Service1Client();
            int userId = server.connectToLibrary();
            int bookID = 0;

            Console.WriteLine("Witaj! Użytkownik nr: " + userId);
            do
            {
                Console.WriteLine("Wybierz polecenie");
                Console.WriteLine(" 1. Lista książek");
                Console.WriteLine(" 2. Wypozycz książkę");
                Console.WriteLine(" 3. Oddaj książkę");
                Console.WriteLine(" 4. Twoje książki");
                Console.WriteLine(" 5. Lista wypożyczonych książek");
                Console.WriteLine(" 6. Informacje o książce");
                Console.WriteLine(" \n 0. Koniec");
                int wybor = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();

                switch (wybor)
                {
                    case 1:
                        Book[] books = server.listOfBooks();
                        Console.WriteLine("Lista dostępnych książek:");
                        foreach (Book item in books)
                        {
                            Console.WriteLine(item.ID + ". " + item.BookInfo.Author + " " + item.BookInfo.Title);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Podaj numer książki");
                        try
                        {
                            bookID = Convert.ToInt16(Console.ReadLine());

                            server.borrowBook(bookID, userId);
                            Console.WriteLine("Wypożyczyłeś książkę");
                        }
                        catch (FaultException<BookExceptions> ex)
                        {
                            Console.WriteLine(ex.Detail.Message);
                        }

                        break;
                    case 3:
                        Console.WriteLine("Podaj numer książki");
                        try
                        {
                            bookID = Convert.ToInt16(Console.ReadLine());

                            server.giveBook(bookID, userId);
                            Console.WriteLine("Książka oddana pomyślnie");
                        }
                        catch (FaultException<BookExceptions> ex)
                        {
                            Console.WriteLine(ex.Detail.Message);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Twoje książki");
                        try
                        {
                            Book[] userBorrowedBooks = server.getUserBorrowedBooks(userId);
                            foreach (Book item in userBorrowedBooks)
                            {
                                Console.WriteLine(item.ID + ". " + item.BookInfo.Author + " " + item.BookInfo.Title);
                            }
                        }
                        catch (FaultException<BookExceptions> ex)
                        {
                            Console.WriteLine(ex.Detail.Message);
                        }
                        break;
                    case 5:
                        try
                        {
                            Book[] borrowedBooks = server.listOfBorrowedItems();
                            Console.WriteLine("Lista wypożyczonych książek");

                            Console.WriteLine();
                            foreach (Book item in borrowedBooks)
                            {
                                Console.WriteLine(item.ID + ". " + item.BookInfo.Author + " " + item.BookInfo.Title);
                            }
                        }
                        catch (FaultException<BookExceptions> ex)
                        {
                            Console.WriteLine(ex.Detail.Message);
                        }
                        break;
                    case 6:
                        Console.WriteLine("Podaj numer książki");
                        bookID = Convert.ToInt16(Console.ReadLine());
                        try
                        {
                            Book book = server.getBookInfo(bookID);

                            Console.WriteLine(book.ID + ".\t" + book.BookInfo.Author + "\t" + book.BookInfo.Title + "\t" +
                                              book.BookInfo.Year);
                        }
                        catch (FaultException<BookExceptions> ex)
                        {
                            Console.WriteLine(ex.Detail.Message);
                        }
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Brak polecenia");
                        break;
                }
                Console.WriteLine();
            } while (true);
        }
    }
}
