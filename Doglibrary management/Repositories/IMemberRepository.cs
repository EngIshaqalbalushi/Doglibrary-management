using Doglibrary_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doglibrary_management.Repositories
{
    public interface IMemberRepository
    {
        void Add(Member member);
        Member? GetById(string id);
        List<Member> GetAll();
        void Save();
    }
}
