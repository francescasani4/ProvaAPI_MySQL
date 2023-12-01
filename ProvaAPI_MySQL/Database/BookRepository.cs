using System;
namespace ProvaAPI_MySQL.Database
{
	public class BookRepository
	{
        private readonly MyDbContext _dbContext;

        public BookRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookEntity> GetAllBooks()
        {
            return _dbContext.Books.ToList();
        }

        public BookEntity GetBookById(int idBook)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.IdBook == idBook);

            return book;
        }

        public List<BookEntity> GetBooksByTitle(string title)
        {
            var books = _dbContext.Books.Where(b => b.Title == title).ToList();

            return books;
        }

        public List<BookEntity> GetBooksByAuthor(string author)
        {
            var books = _dbContext.Books.Where(b => b.Author == author).ToList();

            return books;
        }

        public List<BookEntity> GetBooksByTitleAndAuthor(string title, string author)
        {
            var books = _dbContext.Books.Where(b => b.Title == title && b.Author == author).ToList();

            return books;
        }

        public List<BookEntity> GetBooksByPublicationDate(DateTime publicationDate)
        {
            var books = _dbContext.Books.Where(b => b.PublicationDate == publicationDate).ToList();

            return books;
        }

        public void AddBook(BookEntity book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public bool DeleteBook(int idBook)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.IdBook == idBook);
            bool flag = false;

            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
                flag = true;
            }

            return flag;
        }

        public bool UpdateBook(BookEntity book)
        {
            var existingBook = _dbContext.Books.FirstOrDefault(b => b.IdBook == book.IdBook);
            bool flag = false;

            if (existingBook != null) //&& existingUser != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.PublicationDate = book.PublicationDate;

                if (book.IdUser != null)
                {
                    var existingUser = _dbContext.Users.FirstOrDefault(u => u.IdUser == book.IdUser); //controllo se l'id dell'utente esiste

                    if (existingUser != null)
                        flag = true;
                }

                existingBook.IdUser = book.IdUser;
                flag = true;

                _dbContext.SaveChanges();
            }

            return flag;
        }
    }
}

