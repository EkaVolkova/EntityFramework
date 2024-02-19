using EntityFramework.Models;

namespace EntityFramework.Repositories
{
    public interface IBookRepository
    {
        Book FindById(int id);

        public List<Book> FindAll();

        void Add(Book book);

        void Delete(Book book);

        void UpdateById(int id, string value);
    }
}