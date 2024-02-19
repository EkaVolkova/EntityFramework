using EntityFramework.Models;
using EntityFramework.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class Program
{
    static IUserRepository userRepository = new UserRepository();
    static IBookRepository bookRepository = new BookRepository();



    static void ShowHelp()
    {
        Console.WriteLine("Список команд для работы консоли:");
        Console.WriteLine(Commands.stop + ": прекращение работы");
        Console.WriteLine(Commands.add + ": добавление данных");
        Console.WriteLine(Commands.delete + ": удаление данных");
        Console.WriteLine(Commands.update + ": обновление данных");
        Console.WriteLine(Commands.show + ": просмотр данных");

        Console.WriteLine();
        Console.WriteLine("Введите команду: ");

    }


    enum Commands
    {
        stop,
        findById,
        findAll,
        add,
        delete,
        update,
        show
    }

    enum Dbs
    {
        books,
        users
    }
    static void CommandManagerUser(string command)
    {
        switch (command)
        {
            case nameof(Commands.stop):
                break;
            case nameof(Commands.findById):
                Console.WriteLine("Введите Id пользователя");
                var id = int.Parse(Console.ReadLine());
                User user = userRepository.FindById(id);
                Console.WriteLine("Id: " + user.Id + ", Name: " + user.Name + ", Email: " + user.Email);
                break;
            case nameof(Commands.update):
                Console.WriteLine("Введите Id пользователя");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите новое имя");
                var name = Console.ReadLine();
                userRepository.UpdateById(id, name);
                break;
            case nameof(Commands.show):
                var users = userRepository.FindAll();
                foreach (var item in users)
                {
                    Console.WriteLine("Id: " + item.Id + ", Name: " + item.Name + ", Email: " + item.Email);
                }
                break;
            case nameof(Commands.add):
                Console.WriteLine("Введите имя пользователя");
                name = Console.ReadLine();
                Console.WriteLine("Введите Email пользователя");
                var email = Console.ReadLine();
                Console.WriteLine("Введите роль пользователя");
                var role = Console.ReadLine();

                userRepository.Add(new User { Email = email, Name = name, Role = role });
                break;
            case nameof(Commands.delete):
                Console.WriteLine("Введите имя пользователя");
                name = Console.ReadLine();
                Console.WriteLine("Введите Email пользователя");
                email = Console.ReadLine();
                Console.WriteLine("Введите роль пользователя");
                role = Console.ReadLine();

                userRepository.Delete(new User { Email = email, Name = name, Role = role });
                break;
            default:
                Console.WriteLine("Неверно введена команда");
                break;
        }

    }
    static void CommandManagerBooks(string command)
    {
        switch (command)
        {
            case nameof(Commands.stop):
                break;
            case nameof(Commands.findById):
                Console.WriteLine("Введите Id книги");
                var id = int.Parse(Console.ReadLine());
                Book book = bookRepository.FindById(id);
                Console.WriteLine("Id: " + book.Id + ", Name: " + book.Name + ", Year Publisher: " + book.PublishYear);
                break;
            case nameof(Commands.update):
                Console.WriteLine("Введите Id книги");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите новое название");
                var name = Console.ReadLine();
                userRepository.UpdateById(id, name);
                break;
            case nameof(Commands.show):
                var books = bookRepository.FindAll();
                foreach (var item in books)
                {
                    Console.WriteLine("Id: " + item.Id + ", Name: " + item.Name + ", Year Publisher: " + item.PublishYear);
                }
                break;
            case nameof(Commands.add):
                Console.WriteLine("Введите название");
                name = Console.ReadLine();
                Console.WriteLine("Введите год издания");
                var year = Console.ReadLine();

                bookRepository.Add(new Book { Name = name, PublishYear = year});
                break;
            case nameof(Commands.delete):
                Console.WriteLine("Введите название");
                name = Console.ReadLine();
                Console.WriteLine("Введите год издания");
                year = Console.ReadLine();

                bookRepository.Delete(new Book { Name = name, PublishYear = year });
                break;
            default:
                Console.WriteLine("Неверно введена команда");
                break;
        }

    }

    private static void Main(string[] args)
    {
        string command = default;
        while (command != nameof(Commands.stop))
        {
            Console.Write("Введите название таблицы: ");
            var db = Console.ReadLine();
            ShowHelp();
            command = Console.ReadLine();
            switch(db)
            {
                case nameof(Dbs.books):
                    CommandManagerBooks(command);
                    break;
                case nameof(Dbs.users):
                    CommandManagerUser(command);
                    break;
                default:
                    Console.WriteLine("Неверный выбор таблицы");
                    break;
            }


        }




    }
}