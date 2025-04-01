using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    internal class BookInfo
    {
        private string CategoryID {  get; set; }
        public string CategoryName { get; set; }
        public string BookID { get; set; }
        public string BookTitle { get; set; }
        private string AuthorID { get; set; }
        public string AuthorName { get; set; }
        private string PublisherID { get; set; }
        public string PublisherName { get; set; }
        public string Year { get; set; }
        public string Quantity { get; set; }
        public string BookStatus { get; set; }
        public string BookValue { get; set; }

        public BookInfo(string categoryID, string categoryName, string bookID, string bookTitle, string authorID, string authorName, string publisherID, string publisherName, string year, string quantity, string bookStatus, string bookValue)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            BookID = bookID;
            BookTitle = bookTitle;
            AuthorID = authorID;
            AuthorName = authorName;
            PublisherID = publisherID;
            PublisherName = publisherName;
            Year = year;
            Quantity = quantity;
            BookStatus = bookStatus;
            BookValue = bookValue; 
        }
    }
}
