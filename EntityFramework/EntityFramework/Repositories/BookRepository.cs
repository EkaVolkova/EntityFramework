using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace EntityFramework.Repositories
{
    public class BookRepository : IBookRepository
    {
        /// <summary>
        /// Добавление книги в бд
        /// </summary>
        /// <param name="book">модель книги</param>
        public void Add(Book book)
        {
            using (var db = new AppContext())
            {
                //вытаскиваем жанры отдельно
                var genres = book.Genres.ToList();
                book.Genres = new List<Genre>();

                // Добавление книги
                db.Books.Add(book);
                db.SaveChanges();

                //добавление жанров
                var findGenres = db.Books.Include(b => b.Genres).Where(b => b.Name == book.Name && b.PublishYear == book.PublishYear && b.AuthorId == book.AuthorId).ToList().FirstOrDefault().Genres;
                findGenres.AddRange(genres);

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление книги из бд
        /// </summary>
        /// <param name="book">модель книги</param>
        public void Delete(Book book)
        {
            using (var db = new AppContext())
            {

                var findBook = db.Books.Where(b => b.Name == book.Name && b.PublishYear == book.PublishYear && b.AuthorId == book.AuthorId).ToList().FirstOrDefault();
                db.Books.Remove(findBook);

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Поиск всех книг в бд
        /// </summary>
        /// <returns>список книг</returns>
        public List<Book> FindAll()
        {
            List<Book> allBooks;
            using (var db = new AppContext())
            {

                allBooks = db.Books.ToList();

            }
            return allBooks;
        }

        /// <summary>
        /// Найти книгу по Id
        /// </summary>
        /// <param name="id">Id книги</param>
        /// <returns></returns>
        public Book FindById(int id)
        {
            Book book;
            using (var db = new AppContext())
            {

                book = db.Books.Where(b => b.Id == id).ToList().FirstOrDefault();

            }
            return book;
        }

        /// <summary>
        /// Обновить название книги по Id
        /// </summary>
        /// <param name="id">Id книги</param>
        /// <param name="value">Новое название книги</param>
        public void UpdateById(int id, string value)
        {
            using (var db = new AppContext())
            {

                var book = db.Books.Where(u => u.Id == id).ToList().FirstOrDefault();
                book.Name = value;

                db.SaveChanges();

            }
        }

        /// <summary>
        /// Получает список книг определенного жанра и вышедших между определенными годами
        /// </summary>
        /// <param name="genre">жанр книги</param>
        /// <param name="minYear">минимальный год выпуска</param>
        /// <param name="maxYear">максимальный год выпуска</param>
        /// <returns></returns>
        public List<Book> GetBooksByGenreAndDate(Genre genre, uint minYear, uint maxYear)
        {
            using (var db = new AppContext())
            {

                return db.Books.Include(b => b.Genres)
                    .Where(b => b.Genres.Contains(genre) && b.PublishYear >= minYear && b.PublishYear <= maxYear)
                    .ToList();

            }
        }

        

    }
}
