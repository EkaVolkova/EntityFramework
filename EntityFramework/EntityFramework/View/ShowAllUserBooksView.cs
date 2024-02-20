using EntityFramework.Repositories;

namespace EntityFramework.View
{
    public class ShowAllUserBooksView
    {
        private IUserRepository userRepository;

        public ShowAllUserBooksView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите Id пользователя");
            var userId = int.Parse(Console.ReadLine());
            var books = userRepository.FindAllBooks(userId);
            foreach (var item in books)
            {
                Console.WriteLine("Id: " + item.Id + ", Name: " + item.Name + ", Email: " + item.PublishYear);
            }




        }
    }

}
