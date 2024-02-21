using EntityFramework.Repositories;

namespace EntityFramework.View.UserView
{
    public class ReturnBookByUserView
    {
        private IUserRepository userRepository;

        public ReturnBookByUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите Id пользователя");
            var userId = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите Id книги");
            var bookId = int.Parse(Console.ReadLine());

            userRepository.ReturnBookToLibrary(userId, bookId);

        }
    }

}
