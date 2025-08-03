using Doglibrary_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doglibrary_management.Repositories
{
    public class BorrowRecordRepository : IBorrowRecordRepository
    {

        private readonly FileContext _context;
        private List<BorrowRecord> records;
        private readonly string path = "records.json";

        public BorrowRecordRepository(FileContext context)
        {
            _context = context;
            records = _context.LoadFromFile<BorrowRecord>(path);
        }

        public void Add(BorrowRecord record) { records.Add(record); Save(); }
        public BorrowRecord? GetActiveBorrow(string bookId) => records.FirstOrDefault(r => r.BookId == bookId && r.ReturnDate == null);
        public void Update(BorrowRecord record) { Save(); }
        public List<BorrowRecord> GetAll() => records;
        public void Save() => _context.SaveToFile(path, records);
    }
}

