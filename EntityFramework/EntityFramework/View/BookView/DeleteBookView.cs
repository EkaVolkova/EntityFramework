using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.BookView
{
    public class DeleteBookView
    {
        private IBookRepository bookRepository;

        public DeleteBookView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите название");
            var name = Console.ReadLine();
            Console.WriteLine("Введите год издания");
            var year = uint.Parse(Console.ReadLine());

            bookRepository.Delete(new Book { Name = name, PublishYear = year });



        }
    }

}
