using System;
using Microsoft.EntityFrameworkCore;
using ProvaAPI_MySQL.Model;

namespace ProvaAPI_MySQL.Database
{
	public class MyDbContext : DbContext
	{
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }

        public DbSet<UserModel> UsersModel { get; set; }
        public DbSet<BookModel> BooksModel { get; set; }
    }
}

