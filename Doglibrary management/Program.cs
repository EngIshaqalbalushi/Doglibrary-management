// FILE: Program.cs
using Doglibrary_management.Models;
using Doglibrary_management.Repositories;
using Doglibrary_management.Services;
using Doglibrary_management;


class Program
{
    static void Main()
    {
        var context = new FileContext();
        var bookRepo = new BookRepository(context);
        var memberRepo = new MemberRepository(context);
        var borrowRepo = new BorrowRecordRepository(context);
        ILibraryService library = new LibraryService(bookRepo, memberRepo, borrowRepo);

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║         WELCOME TO SILAF LIBRARY           ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Register Member");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. View All Books");
            Console.WriteLine("6. View All Members");
            Console.WriteLine("7. View All Borrow Records");
            Console.WriteLine("8. Search Book by Title");
            Console.WriteLine("9. Search Member by Name");
            Console.WriteLine("10. View Member Borrow History");
            Console.WriteLine("0. Exit");
            Console.ResetColor();
            Console.Write("\nChoose option: ");

            var option = Console.ReadLine();
            Console.Clear();

            switch (option)
            {
                case "1":
                    Console.Write("Enter Book Title: ");
                    var title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    var author = Console.ReadLine();
                    library.AddBook(new Book { Title = title, Author = author });
                    break;

                case "2":
                    Console.Write("Enter Member Name: ");
                    var name = Console.ReadLine();
                    library.RegisterMember(new Member { Name = name });
                    break;

                case "3":
                    Console.Write("Enter Book ID: ");
                    var bookId = Console.ReadLine();
                    Console.Write("Enter Member ID: ");
                    var memberId = Console.ReadLine();
                    library.BorrowBook(bookId, memberId);
                    break;

                case "4":
                    Console.Write("Enter Book ID: ");
                    var retBookId = Console.ReadLine();
                    Console.Write("Enter Member ID: ");
                    var retMemberId = Console.ReadLine();
                    library.ReturnBook(retBookId, retMemberId);
                    break;

                case "5":
                    library.ViewAllBooks();
                    break;

                case "6":
                    library.ViewAllMembers();
                    break;

                case "7":
                    library.ViewAllBorrowRecords();
                    break;

                case "8":
                    Console.Write("Enter Book Title Keyword: ");
                    var keyword = Console.ReadLine();
                    library.SearchBooksByTitle(keyword);
                    break;

                case "9":
                    Console.Write("Enter Member Name Keyword: ");
                    var memName = Console.ReadLine();
                    library.SearchMembersByName(memName);
                    break;

                case "10":
                    Console.Write("Enter Member ID: ");
                    var memId = Console.ReadLine();
                    library.ViewMemberHistory(memId);
                    break;

                case "0":
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Invalid option.");
                    Console.ResetColor();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✔️ Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
