using EntityFramework.Exceptions;
using EntityFramework.Models;
using EntityFramework.Repositories;
using EntityFramework.View;
using EntityFramework.View.AuthorView;
using EntityFramework.View.BookView;
using EntityFramework.View.GenreView;
using EntityFramework.View.UserView;

public class Program
{
    static AppContext appContext = new AppContext();
    static IGenreRepository genreRepository = new GenreRepository();
    static IAuthorRepository authorRepository = new AuthorRepository();
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
    public static AuthorMainView authorMainView;
    public static AddAuthorView addAuthorView;
    public static DeleteAuthorView deleteAuthorView;
    public static FindAuthorView findAuthorView;
    public static ShowAllAuthorBooksView ShowAllAuthorBooksView;
    public static ShowAllAuthorsView ShowAllAuthorsView;
    public static AddGenreView addGenreView;
    public static DeleteGenreView deleteGenreView;
    public static FindGenreView findGenreView;
    public static ShowAllGenreBooksView showAllGenreBooksView;
    public static ShowAllGenreView ShowAllGenreView;
    public static GenreMainView genreMainView;

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
        addBookView = new AddBookView(bookRepository, authorRepository, genreRepository);
        deleteBookView = new DeleteBookView(bookRepository);
        updateNameBookView = new UpdateNameBookView(bookRepository);
        showAllBookView = new ShowAllBookView(bookRepository);
        bookMainView = new BookMainView();
        authorMainView = new AuthorMainView();
        addAuthorView = new AddAuthorView(authorRepository);
        deleteAuthorView = new DeleteAuthorView(authorRepository);
        findAuthorView = new FindAuthorView(authorRepository);
        ShowAllAuthorBooksView = new ShowAllAuthorBooksView(authorRepository);
        ShowAllAuthorsView = new ShowAllAuthorsView(authorRepository);
        addGenreView = new AddGenreView(genreRepository);
        deleteGenreView = new DeleteGenreView(genreRepository);
        findGenreView = new FindGenreView(genreRepository);
        showAllGenreBooksView = new ShowAllGenreBooksView(genreRepository);
        ShowAllGenreView = new ShowAllGenreView(genreRepository);
        genreMainView = new GenreMainView();

        while (true)
        {

            try
            {
                mainView.Show();
            }
            catch (EnteredTableException)
            {
                Console.WriteLine("Неверно введено название таблицы\r\n");
            }
            catch (EnteredCommandException)
            {
                Console.WriteLine("Неверно введена команда\r\n");
            }
        }



    }
}