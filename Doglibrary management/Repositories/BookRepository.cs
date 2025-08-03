using Doglibrary_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doglibrary_management.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly FileContext _context;
        private List<Book> books;
        private readonly string path = "books.json";

        public BookRepository(FileContext context)
        {
            _context = context;
            books = _context.LoadFromFile<Book>(path);
        }

        public void Add(Book book) { books.Add(book); Save(); }
        public Book? GetById(string id) => books.FirstOrDefault(b => b.Id == id);
        public List<Book> GetAll() => books;
        public void Save() => _context.SaveToFile(path, books);
    }
}
