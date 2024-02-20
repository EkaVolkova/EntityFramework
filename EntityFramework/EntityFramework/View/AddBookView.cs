using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View
{
    public class AddBookView
    {
        private IBookRepository bookRepository;

        public AddBookView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите название");
            var name = Console.ReadLine();
            Console.WriteLine("Введите год издания");
            var year = uint.Parse(Console.ReadLine());

            bookRepository.Add(new Book { Name = name, PublishYear = year });



        }
    }

}
