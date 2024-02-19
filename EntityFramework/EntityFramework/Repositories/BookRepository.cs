using EntityFramework.Models;

namespace EntityFramework.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void Add(Book book)
        {
            using (var db = new AppContext())
            {

                // Добавление книги
                db.Books.Add(book);

                db.SaveChanges();
            }
        }

        public void Delete(Book book)
        {
            using (var db = new AppContext())
            {

                // Удаление книги
                db.Books.Remove(book);

                db.SaveChanges();
            }
        }

        public List<Book> FindAll()
        {
            List<Book> allBooks;
            using (var db = new AppContext())
            {

                allBooks = db.Books.ToList();

            }
            return allBooks;
        }

        public Book FindById(int id)
        {
            Book book;
            using (var db = new AppContext())
            {

                book = db.Books.Where(user => user.Id == id).ToList().FirstOrDefault();

            }
            return book;
        }

        public void UpdateById(int id, string value)
        {
            using (var db = new AppContext())
            {

                var book = db.Books.Where(u => u.Id == id).ToList().FirstOrDefault();
                book.Name = value;

                db.SaveChanges();

            }
        }
    }
}
