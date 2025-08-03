using Doglibrary_management.Models;
using Doglibrary_management.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doglibrary_management.Services
{
    public class LibraryService : ILibraryService
    {

        private readonly IBookRepository _bookRepo;
        private readonly IMemberRepository _memberRepo;
        private readonly IBorrowRecordRepository _borrowRepo;

        public LibraryService(IBookRepository bookRepo, IMemberRepository memberRepo, IBorrowRecordRepository borrowRepo)
        {
            _bookRepo = bookRepo;
            _memberRepo = memberRepo;
            _borrowRepo = borrowRepo;
        }

        public void AddBook(Book book)
        {
            _bookRepo.Add(book);
            Console.WriteLine("✅ Book added successfully.");
        }

        public void RegisterMember(Member member)
        {
            _memberRepo.Add(member);
            Console.WriteLine("✅ Member registered successfully.");
        }

        public void BorrowBook(string bookId, string memberId)
        {
            var book = _bookRepo.GetById(bookId);
            var member = _memberRepo.GetById(memberId);

            if (book == null || !book.IsAvailable)
            {
                Console.WriteLine("❌ Book is not available or does not exist.");
                return;
            }

            if (member == null)
            {
                Console.WriteLine("❌ Member not found.");
                return;
            }

            book.IsAvailable = false;
            _bookRepo.Save();

            _borrowRepo.Add(new BorrowRecord
            {
                BookId = bookId,
                MemberId = memberId
            });

            Console.WriteLine("📚 Book borrowed successfully.");
        }

        public void ReturnBook(string bookId, string memberId)
        {
            var record = _borrowRepo.GetActiveBorrow(bookId);
            var book = _bookRepo.GetById(bookId);

            if (record == null || book == null)
            {
                Console.WriteLine("❌ Borrow record or book not found.");
                return;
            }

            record.ReturnDate = DateTime.Now;
            book.IsAvailable = true;

            _borrowRepo.Save();
            _bookRepo.Save();

            Console.WriteLine("📖 Book returned successfully.");
        }

        public void ViewAllBooks()
        {
            var books = _bookRepo.GetAll();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📘 All Books:");
            foreach (var book in books)
            {
                Console.WriteLine($"- ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Available: {(book.IsAvailable ? "✅" : "❌")}");
            }
            Console.ResetColor();
        }

        public void ViewAllMembers()
        {
            var members = _memberRepo.GetAll();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n👥 Registered Members:");
            foreach (var member in members)
            {
                Console.WriteLine($"- ID: {member.Id}, Name: {member.Name}");
            }
            Console.ResetColor();
        }

        public void ViewAllBorrowRecords()
        {
            var records = _borrowRepo.GetAll();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n📝 Borrow Records:");
            foreach (var record in records)
            {
                Console.WriteLine($"- Record ID: {record.Id}, Book ID: {record.BookId}, Member ID: {record.MemberId}, Borrowed: {record.BorrowDate}, Returned: {(record.ReturnDate?.ToString() ?? "Not Yet")}");
            }
            Console.ResetColor();
        }

        public void SearchBooksByTitle(string keyword)
        {
            var books = _bookRepo.GetAll().Where(b => b.Title.ToLower().Contains(keyword.ToLower())).ToList();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n🔍 Books Matching Title:");
            foreach (var book in books)
            {
                Console.WriteLine($"- ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Available: {(book.IsAvailable ? "✅" : "❌")}");
            }
            if (books.Count == 0) Console.WriteLine("❌ No books found.");
            Console.ResetColor();
        }

        public void SearchMembersByName(string keyword)
        {
            var members = _memberRepo.GetAll().Where(m => m.Name.ToLower().Contains(keyword.ToLower())).ToList();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n🔍 Members Matching Name:");
            foreach (var member in members)
            {
                Console.WriteLine($"- ID: {member.Id}, Name: {member.Name}");
            }
            if (members.Count == 0) Console.WriteLine("❌ No members found.");
            Console.ResetColor();
        }

        public void ViewMemberHistory(string memberId)
        {
            var records = _borrowRepo.GetAll().Where(r => r.MemberId == memberId).ToList();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n📂 Borrow History for Member ID: {memberId}");
            foreach (var r in records)
            {
                Console.WriteLine($"- Book ID: {r.BookId}, Borrowed: {r.BorrowDate}, Returned: {(r.ReturnDate?.ToString() ?? "Not Yet")}");
            }
            if (records.Count == 0) Console.WriteLine("❌ No history found.");
            Console.ResetColor();
        }



    }
}
