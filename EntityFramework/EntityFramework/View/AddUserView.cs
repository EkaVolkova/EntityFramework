using EntityFramework.Models;
using EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.View
{
    public class AddUserView
    {
        private IUserRepository userRepository;

        public AddUserView(IUserRepository userRepository) 
        {
            this.userRepository = userRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
            Console.WriteLine("Введите Email пользователя");
            var email = Console.ReadLine();

            userRepository.Add(new User { Email = email, Name = name });
            

        }
    }


}
