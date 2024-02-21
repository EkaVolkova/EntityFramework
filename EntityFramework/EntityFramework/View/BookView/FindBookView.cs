using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.BookView
{
    public class FindBookView
    {
        private IBookRepository bookRepository;

        public FindBookView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите Id пользователя");
            var id = int.Parse(Console.ReadLine());
            Book book = bookRepository.FindById(id);
            Console.WriteLine("Id: " + book.Id + ", Name: " + book.Name + ", Publish Year: " + book.PublishYear);



        }
    }

}
