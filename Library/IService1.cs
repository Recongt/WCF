using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Library
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Book> listOfBooks();

        [OperationContract]
        int connectToLibrary();

        [OperationContract]
        [FaultContract(typeof(BookExceptions))]
        List<Book> listOfBorrowedItems();
        
        [OperationContract]
        [FaultContract(typeof(BookExceptions))]
        List<Book> getUserBorrowedBooks(int userID);
        
        [OperationContract]
        [FaultContract(typeof(BookExceptions))]
        Book getBookInfo(int bookID);
       
        [OperationContract]
        [FaultContract(typeof(BookExceptions))]
        void borrowBook(int bookID, int userID);

        [OperationContract]
        [FaultContract(typeof(BookExceptions))]
        void giveBook(int bookID, int userID);
    }
}
