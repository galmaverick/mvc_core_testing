﻿using GTLII.Controllers;
using GTLII.Entities;
using GTLII.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class BookControllerTest
    {
        Mock<IBooksRepository> repoMock;
        BookController bc;
        [Fact]
        public void GetAllBooks()
        {
            List<Book> booksMock = new List<Book>()
            {
                new Book()
                {
                    Id=1,
                    ISBN="asd",
                    Name="name"
                },
                new Book()
                {
                    Id=2,
                    ISBN="asdd",
                    Name="nana"
                }

            };
            repoMock = new Mock<IBooksRepository>();
            repoMock.Setup(b => b.GetBooks(It.IsAny<string>())).Returns(booksMock);

            bc = new BookController(repoMock.Object);
            var actionResult = bc.GetBooks();
            Assert.IsType<OkObjectResult>(actionResult);
           // tests for repo :) 
         //   Assert.Equal(books.Count, 2);
         //   Assert.Equal(books.Find(b => b.Id == 1).Name, "name");
        }
        [Fact]
        public void GetBookRightId()
        {
            Book result = new Book()
            {
                Id = 1,
                ISBN = "asd",
                Name = "name"
            };
               
            repoMock = new Mock<IBooksRepository>();
            repoMock.Setup(b => b.GetBook(1)).Returns(result);

            bc = new BookController(repoMock.Object);
            var actionResult = bc.GetBook(1);
            Assert.IsType<OkObjectResult>(actionResult);
        }
        [Fact]
        public void GetBookWrongId()
        {
            repoMock = new Mock<IBooksRepository>();

            bc = new BookController(repoMock.Object);
            var actionResult = bc.GetBook(1);
            Assert.IsType<NotFoundResult>(actionResult);
        }
    }
}
