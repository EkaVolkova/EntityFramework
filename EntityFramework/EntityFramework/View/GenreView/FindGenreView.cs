using EntityFramework.Repositories;

namespace EntityFramework.View.GenreView
{
    public class FindGenreView
    {
        IGenreRepository genreRepository;
        public FindGenreView(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите Id жанра");
            var id = int.Parse(Console.ReadLine());
            genreRepository.FindById(id);

        }
    }
}
