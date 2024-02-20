﻿using EntityFramework.Repositories;

namespace EntityFramework.View
{
    public class UpdateNameBookView
    {
        private IBookRepository bookRepository;

        public UpdateNameBookView(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Show()
        {
            Console.WriteLine("Введите Id книги");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите новое название");
            var name = Console.ReadLine();
            bookRepository.UpdateById(id, name);



        }
    }

}