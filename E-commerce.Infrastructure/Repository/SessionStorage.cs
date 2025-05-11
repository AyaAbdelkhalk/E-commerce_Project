//using E_commerce.Application.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace E_commerce.Infrastructure.Repository
//{
//    public class SessionStorage : ISessionStorage
//    {
//        public void SaveLastUserId(int userId)
//        {
//            Settings.Default.LastUserId = userId;
//            Settings.Default.Save();
//        }

//        public int GetLastUserId()
//        {
//            return Settings.Default.LastUserId;
//        }

//        public void ClearLastUserId()
//        {
//            Settings.Default.LastUserId = 0;
//            Settings.Default.Save();
//        }

//    }
//}
