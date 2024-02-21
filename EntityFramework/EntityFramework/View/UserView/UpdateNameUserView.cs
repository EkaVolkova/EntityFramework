using EntityFramework.Repositories;

namespace EntityFramework.View.UserView
{
    public class UpdateNameUserView
    {
        private IUserRepository userRepository;

        public UpdateNameUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите Id пользователя");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите новое имя");
            var name = Console.ReadLine();
            userRepository.UpdateNameById(id, name);



        }
    }

}
