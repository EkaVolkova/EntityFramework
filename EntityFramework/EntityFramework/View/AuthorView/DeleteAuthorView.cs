using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.AuthorView
{
    public class DeleteAuthorView
    {
        IAuthorRepository authorRepository;
        public DeleteAuthorView(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите имя автора");
            var firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию автора");
            var LastName = Console.ReadLine();
            authorRepository.Delete(new Author { FirstName = firstName, LastName = LastName, Books = new List<Book>() });

        }
    }
}
