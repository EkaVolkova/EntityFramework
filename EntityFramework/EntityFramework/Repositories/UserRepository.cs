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
        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="user">пользователь для добавления</param>
        public void Add(User user)
        {
            using (var db = new AppContext())
            {

                // Добавление одиночного пользователя
                db.Users.Add(user);

                db.SaveChanges();
            }

        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="user">пользователь для удаления</param>
        public void Delete(User user)
        {
            using (var db = new AppContext())
            {

                var findUser = db.Users.Where(u => u.Name == user.Name && u.Email == user.Email).ToList().FirstOrDefault();
                    
                db.Users.Remove(findUser);

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Поиск всех пользователей
        /// </summary>
        /// <returns></returns>
        public List<User> FindAll()
        {
            List<User> allUsers;
            using (var db = new AppContext())
            {

                allUsers = db.Users.ToList();

            }
            return allUsers;
        }

        /// <summary>
        /// Поиск пользователя по id
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <returns></returns>
        public User FindById(int id)
        {
            User user;
            using (var db = new AppContext())
            {

                user = db.Users.Where(user => user.Id == id).ToList().FirstOrDefault();

            }
            return user;

        }

        /// <summary>
        /// Обновление имени пользователя по ID
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <param name="value">Новое имя</param>
        public void UpdateNameById(int id, string value)
        {
            using (var db = new AppContext())
            {

                var user = db.Users.Where(u => u.Id == id).ToList().FirstOrDefault();
                user.Name = value;

                db.SaveChanges();

            }
        }

        /// <summary>
        /// Обновление Email пользователя по ID
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <param name="value">Новый Email</param>
        public void UpdateEmailById(int id, string value)
        {
            using (var db = new AppContext())
            {

                var user = db.Users.Where(u => u.Id == id).ToList().FirstOrDefault();
                user.Email = value;

                db.SaveChanges();

            }
        }



    }
}
