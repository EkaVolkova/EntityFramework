using EntityFramework.Repositories;

namespace EntityFramework.View
{
    public class ShowAllBookView
    {
        private IBookRepository bookRepository;

        public ShowAllBookView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            var books = bookRepository.FindAll();
            foreach (var item in books)
            {
                Console.WriteLine("Id: " + item.Id + ", Name: " + item.Name + ", Year Publisher: " + item.PublishYear);
            }



        }
    }

}
