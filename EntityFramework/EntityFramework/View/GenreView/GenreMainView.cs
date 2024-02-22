using EntityFramework.View.Helper;

namespace EntityFramework.View.GenreView
{
    public class GenreMainView
    {
        private void ShowCommands()
        {
            Console.WriteLine();
            Console.WriteLine("Список команд для работы консоли:");
            Console.WriteLine(GenreCommands.stop + ": прекращение работы с таблицей");
            Console.WriteLine(GenreCommands.findById + ": найти автора по ID");
            Console.WriteLine(GenreCommands.add + ": добавление автора");
            Console.WriteLine(GenreCommands.delete + ": удаление автора");
            Console.WriteLine(GenreCommands.showAllBooks + ": просмотр всех книг автора");
            Console.WriteLine(GenreCommands.showAll + ": просмотр всех авторов");

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
                    case nameof(GenreCommands.stop):
                        return;
                    case nameof(GenreCommands.findById):
                        Program.findGenreView.Show();
                        break;
                    case nameof(GenreCommands.add):
                        Program.addGenreView.Show();
                        break;
                    case nameof(GenreCommands.delete):
                        Program.deleteGenreView.Show();
                        break;
                    case nameof(GenreCommands.showAllBooks):
                        Program.showAllGenreBooksView.Show();
                        break;
                    case nameof(GenreCommands.showAll):
                        Program.ShowAllGenreView.Show();
                        break;
                    default:
                        Console.WriteLine("Введена неверная команда");
                        break;
                }
            } while (command != nameof(GenreCommands.stop));
        }
    }

}
