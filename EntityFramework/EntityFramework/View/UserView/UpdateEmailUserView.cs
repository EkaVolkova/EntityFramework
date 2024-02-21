using EntityFramework.Repositories;

namespace EntityFramework.View.UserView
{
    public class UpdateEmailUserView
    {
        private IUserRepository userRepository;

        public UpdateEmailUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите Id пользователя");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите новый email");
            var email = Console.ReadLine();
            userRepository.UpdateEmailById(id, email);



        }
    }

}
