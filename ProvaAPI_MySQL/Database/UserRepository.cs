using System;
using ProvaAPI_MySQL.Entity;

namespace ProvaAPI_MySQL.Database
{
	public class UserRepository
	{
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserEntity> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public UserEntity GetUserById(int idUser)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.IdUser == idUser);

            return user;
        }

        public List<UserEntity> GetUsersByName(string name)
        {
            var users = _dbContext.Users.Where(u => u.Name == name).ToList();

            return users;
        }

        public List<UserEntity> GetUsersBySurname(string surname)
        {
            var users = _dbContext.Users.Where(u => u.Surname == surname).ToList();

            return users;
        }

        public void AddUser(UserEntity user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public bool DeleteUser(int idUser)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.IdUser == idUser);
            var flag = false;

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                flag = true;
            }

            return flag;
        }

        public bool UpdateUser(UserEntity user, int idUser)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.IdUser == idUser);
            bool flag = false;

            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;

                flag = true;

                _dbContext.SaveChanges();
            }

            return flag;
        }
    }
}

