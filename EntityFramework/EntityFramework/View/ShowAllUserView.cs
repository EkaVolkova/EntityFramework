using EntityFramework.Repositories;

namespace EntityFramework.View
{
    public class ShowAllUserView
    {
        private IUserRepository userRepository;

        public ShowAllUserView(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            var users = userRepository.FindAll();
            foreach (var item in users)
            {
                Console.WriteLine("Id: " + item.Id + ", Name: " + item.Name + ", Email: " + item.Email);
            }




        }
    }

}
