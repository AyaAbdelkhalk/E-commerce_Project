using E_commerce.Core.Models;
using System.Diagnostics;
using E_commerce.Application.Services.UserServices;
using E_commerce.Shared;

namespace E_commerce.Application.Helper
{
    public static class SessionManager
    {
        private static ISessionStorage? _sessionStorage;

        public static void Initialize(ISessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public static User? CurrentUser { get; private set; }
        public static bool IsLoggedIn => CurrentUser != null;
        private static DateTime LastActivityTime;
        private static readonly TimeSpan SessionTimeout = TimeSpan.FromDays(5); 


        public static bool IsSessionActive()
        {
            if (CurrentUser == null)
                return false;

            if (LastActivityTime == DateTime.MinValue)
                return false;

            if (DateTime.UtcNow - LastActivityTime > SessionTimeout)
            {
                Logout();
                return false;
            }




            LastActivityTime = DateTime.UtcNow;
            return true;
        }

        public static void Login(User user)
        {
            if (user == null) return;

            CurrentUser = user;
            user.LastLoginDate = DateTime.UtcNow;
            LastActivityTime = DateTime.UtcNow;

            _sessionStorage?.SaveLastUserId(user.UserID);
        }

        public static void Logout()
        {
            if (CurrentUser != null)
            {
                CurrentUser = null;
                LastActivityTime = DateTime.MinValue;
                _sessionStorage?.ClearLastUserId();
            }
        }

        public static bool IsAdmin() =>
            IsLoggedIn && CurrentUser.Role == Core.Enum.Role.Admin;

        
        public static async Task LoadLastUser(IUserServices userServices)
        {
            if (_sessionStorage == null) return;

            int lastUserId = _sessionStorage.GetLastUserId();
            if (lastUserId != 0)
            {
                var user = await userServices.GetUserById(lastUserId);
                if (user != null)
                {
                    Login(user);
                }
            }
        }

    }
}
