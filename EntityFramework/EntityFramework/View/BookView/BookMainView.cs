using EntityFramework.Exceptions;
using EntityFramework.View.Helper;

namespace EntityFramework.View.BookView
{
    public class BookMainView
    {
        private void ShowCommands()
        {
            Console.WriteLine();
            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(BookCommands.stop + ": прекращение работы с таблицей");
            Console.WriteLine(BookCommands.findById + ": найти книгу по ID");
            Console.WriteLine(BookCommands.add + ": добавление книги");
            Console.WriteLine(BookCommands.delete + ": удаление книги");
            Console.WriteLine(BookCommands.updateName + ": обновление названия книги по Id");
            Console.WriteLine(BookCommands.showAll + ": просмотр всех книг");

            Console.WriteLine();
            Console.WriteLine("Введите команду: ");
        }
        public void Show()
        {
            string command;
            do
            {
                ShowCommands();
                command = Console.ReadLine();
                switch (command)
                {
                    case nameof(BookCommands.stop):
                        return;
                    case nameof(BookCommands.findById):
                        Program.findBookView.Show();
                        break;
                    case nameof(BookCommands.add):
                        Program.addBookView.Show();
                        break;
                    case nameof(BookCommands.delete):
                        Program.deleteBookView.Show();
                        break;
                    case nameof(BookCommands.updateName):
                        Program.updateNameBookView.Show();
                        break;
                    case nameof(BookCommands.showAll):
                        Program.showAllBookView.Show();
                        break;
                    default:
                        throw new EnteredCommandException();
                }
            } while (command != nameof(BookCommands.stop));



        }
    }
}
