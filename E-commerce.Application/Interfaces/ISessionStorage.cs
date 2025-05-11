using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Interfaces
{
    public interface ISessionStorage
    {
        void SaveLastUserId(int userId);
        int GetLastUserId();
        void ClearLastUserId();
    }
}
