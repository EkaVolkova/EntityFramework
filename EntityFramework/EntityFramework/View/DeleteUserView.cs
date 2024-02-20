using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View
{
    public class DeleteUserView
    {
        private IUserRepository userRepository;

        public DeleteUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
            Console.WriteLine("Введите Email пользователя");
            var email = Console.ReadLine();

            userRepository.Delete(new User { Email = email, Name = name });


        }
    }

}
