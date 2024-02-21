using EntityFramework.Models;

namespace EntityFramework.Repositories
{
    public interface IBookRepository
    {
        Book FindById(int id);

        public List<Book> FindAll();

        public void Add(Book book);

        void Delete(Book book);

        void UpdateById(int id, string value);
        public uint GetCountBooksByAuthorInLibrary(Author author);

    }
}