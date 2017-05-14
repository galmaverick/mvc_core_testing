﻿
using GTLII.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTLII.Services
{
    public class BooksRepository : IBooksRepository
    {
        public static List<Book> books= new List<Book>();

        public BooksRepository()
        {
            if (books.Count() == 0) { 
                Book book1 = new Book()
                {
                    Id = 1,
                    ISBN = "asdasdasdasd",
                    Name = "Name",
                    Copies = new List<BookCopy>
                {
                    new BookCopy
                    {
                        Id =1,
                        IsAvailable = true
                    },
                      new BookCopy
                    {
                          Id =2,
                        IsAvailable = true
                    }
                }


                };
                Book book2 = new Book()
                {
                    Id = 2,
                    ISBN = "dsaddasdd",
                    Name = "Name2",
                    Copies = new List<BookCopy> { }

                };
                Book book3 = new Book()
                {
                    Id = 3,
                    ISBN = "oipiojlkoh",
                    Name = "Name3",
                    Copies = new List<BookCopy> { }

                };
                Book book4 = new Book()
                {
                    Id = 4,
                    ISBN = "oipiojlkoh",
                    Name = "star wars",
                    Copies = new List<BookCopy> { }

                };

                books.Add(book1);
                books.Add(book2);
                books.Add(book3);
                books.Add(book4);
            }
        }
        public IEnumerable<Book> GetBooks(string name = "")
        {
            if (books == null)
                return null;
            if (name != "")
                return books.Where(b => b.Name.ToLower().Contains(name.ToLower())).ToList();
            else
                return books.ToList();
        }

        public Book GetBook(int id)
        {
            if (books == null)
                return null;
            return books.Find(b => b.Id == id);
            // books.
        }
        public BookCopy GetCopy(int bookId, int id)
        {
          BookCopy copy=   books.Find(b => b.Id == bookId).Copies.FirstOrDefault(c => c.Id == id);
            return copy;
        }
        public bool LoanCopy(int bookId, int id)
        {
            try{
                books.Find(b => b.Id == bookId).Copies.FirstOrDefault(c => c.Id == id).IsAvailable = false;
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
            
        }
        //IEnumerable<BookCopy> GetCopiesForBook(int bookId)
        //{
        //    return books
        //}
        //BookCopy GetCopyForBook(int bookId, int id)
        //{

        //}

    }
}
