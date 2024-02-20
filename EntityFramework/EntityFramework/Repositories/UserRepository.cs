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
        IBookRepository bookRepository;
        public UserRepository(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
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

        /// <summary>
        /// Взять книгу из библиотеки
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="bookId">Id книги</param>
        public void GetBookFromLibrary(int userId, int bookId)
        {
            Book book = bookRepository.FindById(bookId);
            User user = FindById(userId);
            using (var db = new AppContext())
            {
                if(!user.Books.Contains(book))
                    user.Books.Add(book);

                db.SaveChanges();

            }
        }

        /// <summary>
        /// Вернуть книгу в библиотеку
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="bookId">Id книги</param>
        public void ReturnBookToLibrary(int userId, int bookId)
        {
            Book book = bookRepository.FindById(bookId);
            User user = FindById(userId);
            using (var db = new AppContext())
            {
                if (!user.Books.Contains(book))
                    user.Books.Remove(book);
                db.SaveChanges();

            }
        }


        /// <summary>
        /// Получить список книг, которые находятся у пользователя на руках
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Book> FindAllBooks(int userId)
        {
            User user = FindById(userId);
            return user.Books.ToList();
        }


    }
}
