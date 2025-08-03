using Doglibrary_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doglibrary_management.Services
{
    public interface ILibraryService
    {
        void BorrowBook(string bookId, string memberId);
        void ReturnBook(string bookId, string memberId);
        void RegisterMember(Member member);
        void AddBook(Book book);



        void ViewAllBooks();
        void ViewAllMembers();
        void ViewAllBorrowRecords();
        void SearchBooksByTitle(string keyword);
        void SearchMembersByName(string keyword);
        void ViewMemberHistory(string memberId);

    }
}
