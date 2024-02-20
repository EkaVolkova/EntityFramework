using EntityFramework.Exceptions;
using EntityFramework.Models;
using EntityFramework.Repositories;
using EntityFramework.View;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class Program
{
    static IBookRepository bookRepository = new BookRepository();
    static IUserRepository userRepository = new UserRepository(bookRepository);


    public static UserMainView userMainView;
    public static AddUserView addUserView;
    public static DeleteUserView deleteUserView;
    public static FindUserView findUserView;
    public static ShowAllUserView showAllUserView;
    public static UpdateEmailUserView updateEmailUserView;
    public static UpdateNameUserView updateNameUserView;
    public static ShowAllUserBooksView showAllUserBooksView;
    public static GetBookByUserView getBookByUserView;
    public static ReturnBookByUserView returnBookByUserView;
    public static FindBookView findBookView;
    public static AddBookView addBookView;
    public static DeleteBookView deleteBookView;
    public static UpdateNameBookView updateNameBookView;
    public static ShowAllBookView showAllBookView;
    public static BookMainView bookMainView;

    private static void Main(string[] args)
    {
        MainView mainView = new MainView();
        userMainView = new UserMainView();
        addUserView = new AddUserView(userRepository);
        deleteUserView = new DeleteUserView(userRepository);
        findUserView = new FindUserView(userRepository);
        showAllUserView = new ShowAllUserView(userRepository);
        updateEmailUserView = new UpdateEmailUserView(userRepository);
        updateNameUserView  = new UpdateNameUserView(userRepository);
        showAllUserBooksView = new ShowAllUserBooksView(userRepository);
        getBookByUserView = new GetBookByUserView(userRepository);
        returnBookByUserView = new ReturnBookByUserView(userRepository);
        findBookView = new FindBookView(bookRepository);
        addBookView = new AddBookView(bookRepository);
        deleteBookView = new DeleteBookView(bookRepository);
        updateNameBookView = new UpdateNameBookView(bookRepository);
        showAllBookView = new ShowAllBookView(bookRepository);
        bookMainView = new BookMainView();

        try
        {
            mainView.Show();
        }
        catch(EnteredTableException) 
        {
            Console.WriteLine("Неверно введено название таблицы\r\n");
        }
        catch(EnteredCommandException)
        {
            Console.WriteLine("Неверно введена команда\r\n");
        }




    }
}