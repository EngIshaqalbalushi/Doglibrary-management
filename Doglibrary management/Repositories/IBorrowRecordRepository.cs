using Doglibrary_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doglibrary_management.Repositories
{
    public interface IBorrowRecordRepository
    {
        void Add(BorrowRecord record);
        BorrowRecord? GetActiveBorrow(string bookId);
        void Update(BorrowRecord record);
        List<BorrowRecord> GetAll();
        void Save();
    }
}
