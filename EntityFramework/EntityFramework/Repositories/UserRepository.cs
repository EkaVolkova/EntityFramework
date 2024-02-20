using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            using (var db = new AppContext())
            {

                // Добавление одиночного пользователя
                db.Users.Add(user);

                db.SaveChanges();
            }

        }

        public void Delete(User user)
        {
            using (var db = new AppContext())
            {

                // Удаление одиночного пользователя
                var findUser = db.Users.Where(u => u.Name == user.Name && u.Email == user.Email).ToList().FirstOrDefault();
                    
                db.Users.Remove(findUser);

                db.SaveChanges();
            }
        }

        public List<User> FindAll()
        {
            List<User> allUsers;
            using (var db = new AppContext())
            {

                allUsers = db.Users.ToList();

            }
            return allUsers;
        }

        public User FindById(int id)
        {
            User user;
            using (var db = new AppContext())
            {

                user = db.Users.Where(user => user.Id == id).ToList().FirstOrDefault();

            }
            return user;

        }

        public void UpdateById(int id, string value)
        {
            using (var db = new AppContext())
            {

                var user = db.Users.Where(u => u.Id == id).ToList().FirstOrDefault();
                user.Name = value;

                db.SaveChanges();

            }
        }
    }
}
