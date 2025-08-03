using Doglibrary_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doglibrary_management.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);
        Book? GetById(string id);
        List<Book> GetAll();
        void Save();
    }
}
