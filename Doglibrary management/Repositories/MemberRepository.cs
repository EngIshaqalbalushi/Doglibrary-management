using Doglibrary_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doglibrary_management.Repositories
{
    public class MemberRepository: IMemberRepository
    {
        private readonly FileContext _context;
        private List<Member> members;
        private readonly string path = "members.json";

        public MemberRepository(FileContext context)
        {
            _context = context;
            members = _context.LoadFromFile<Member>(path);
        }

        public void Add(Member member) { members.Add(member); Save(); }
        public Member? GetById(string id) => members.FirstOrDefault(m => m.Id == id);
        public List<Member> GetAll() => members;
        public void Save() => _context.SaveToFile(path, members);
    }
}
