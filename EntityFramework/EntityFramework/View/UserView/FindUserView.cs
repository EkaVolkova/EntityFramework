using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework.View.UserView
{
    public class FindUserView
    {
        private IUserRepository userRepository;

        public FindUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите Id пользователя");
            var id = int.Parse(Console.ReadLine());
            User user = userRepository.FindById(id);
            Console.WriteLine("Id: " + user.Id + ", Name: " + user.Name + ", Email: " + user.Email);



        }
    }

}
