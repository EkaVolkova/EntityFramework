using EntityFramework.Models;
using EntityFramework.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EntityFramework.View.BookView
{
    public class ShowCountBooksByAuthorInLibrary
    {
        private IBookRepository bookRepository;

        public ShowCountBooksByAuthorInLibrary(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите имя автора");
            var firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию автора");
            var lastName = Console.ReadLine();

            var booksCount = bookRepository.GetCountBooksByAuthorInLibrary(new Author { FirstName = firstName, LastName = lastName});
            if (booksCount == 0)
            {
                Console.WriteLine("В базе нет ни одной книги");
            }
            else
                Console.WriteLine($"В базе {booksCount} книг {firstName} {lastName}");


        }
    }
}
