using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProvaAPI_MySQL.Entity;

namespace ProvaAPI_MySQL.Database
{
    public class FakeDatabase
    {
        private static int GlobalIdUser = 0;
        private static int GlobalIdBook = 0;

        public List<UserEntity> Users { get; set; }
        public List<BookEntity> Books { get; set; }

        public FakeDatabase()
        {
            Users = new List<UserEntity>();
            Books = new List<BookEntity>();

            AddUserInternal(new UserEntity
            {
                UserName = "UserName1",
                Password = "Password1",
                Name = "Name1",
                Surname = "Surname1"
            });

            AddUserInternal(new UserEntity
            {
                UserName = "UserName2",
                Password = "Password2",
                Name = "Name2",
                Surname = "Surname2"
            });

            AddUserInternal(new UserEntity
            {
                UserName = "UserName3",
                Password = "Password3",
                Name = "Name3",
                Surname = "Surname3"
            });

            AddUserInternal(new UserEntity
            {
                UserName = "UserName4",
                Password = "Password4",
                Name = "Name4",
                Surname = "Surname4"
            });

            AddBookInternal(new BookEntity
            {
                Title = "Title1",
                Author = "Author1",
                PublicationDate = new DateTime(2020, 1, 1),
                IdUser = null
            });

            AddBookInternal(new BookEntity
            {
                Title = "Title2",
                Author = "Author2",
                PublicationDate = new DateTime(2018, 4, 4),
                IdUser = null
            });

            AddBookInternal(new BookEntity
            {
                Title = "Title3",
                Author = "Author3",
                PublicationDate = new DateTime(2000, 12, 4),
                IdUser = null
            });

        }

        public void AddUser(UserEntity user)
        {
            AddUserInternal(user);
        }

        private void AddUserInternal(UserEntity user)
        {
            GlobalIdUser++;

            user.IdUser = GlobalIdUser;

            Users.Add(user);
        }

        public void AddBook(BookEntity book)
        {
            AddBookInternal(book);
        }

        private void AddBookInternal(BookEntity book)
        {
            GlobalIdBook++;

            book.IdBook = GlobalIdBook;

            Books.Add(book);
        }
    }
}

