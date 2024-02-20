namespace EntityFramework.Models
{
    public class Book
    {
        /// <summary>
        /// Id книги (первичный ключ)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название книги
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Год выпуска книги
        /// </summary>
        public uint PublishYear { get; set; }

        /// <summary>
        /// Пользователь, на руках у которого находится книга
        /// </summary>
        public User User { get; set; }
    }
}