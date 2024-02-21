﻿using EntityFramework.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EntityFramework.View.AuthorView
{
    public class ShowAllAuthorBooksView
    {
        IAuthorRepository authorRepository;
        public ShowAllAuthorBooksView(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public void Show()
        {
            Console.WriteLine("Введите Id автора");
            var userId = int.Parse(Console.ReadLine());
            var books = authorRepository.FindAllBooks(userId);
            if (books.IsNullOrEmpty())
            {
                Console.WriteLine("Автор не написал ни одной книги");
            }
            foreach (var item in books)
            {
                Console.WriteLine("Id: " + item.Id + ", Name: " + item.Name + ", Email: " + item.PublishYear);
            }
        }
    }
}
