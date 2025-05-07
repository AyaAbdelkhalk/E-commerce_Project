using E_commerce.Core.Models;
using System.Diagnostics;

namespace E_commerce.Application.Helper
{
    public static class SessionManager
    {
        public static User? CurrentUser { get; private set; }
        public static bool IsLoggedIn => CurrentUser != null;

        private const int SessionTimeoutMinutes = 300;
        private static DateTime LastActivityTime;

        public static bool IsSessionActive()
        {
            if (CurrentUser == null)
            {
                return false;
            }
            var timeSinceLastActivity = DateTime.UtcNow - LastActivityTime;
            if (timeSinceLastActivity.TotalMinutes > SessionTimeoutMinutes)
            {
                Debug.WriteLine($"Session expired for user {CurrentUser.UserName}. Logging out.");
                LastActivityTime = DateTime.UtcNow;
                Logout();
                return false;
            }
            LastActivityTime = DateTime.UtcNow;
            Debug.WriteLine($"Session is active for user {CurrentUser.UserName}. Last activity time updated to {LastActivityTime}.");
            return true;
        }


        public static void Login(User user)
        {
            if (user == null)
            {
                return;
            }
            CurrentUser = user;
            user.LastLoginDate = DateTime.UtcNow;
            LastActivityTime = DateTime.UtcNow;
            Debug.WriteLine($"User {user.UserName} logged in.");
        }

        public static void Logout()
        {
            if (CurrentUser != null)
            {
                Debug.WriteLine($"User {CurrentUser.UserName} logged out.");
                CurrentUser = null;
                LastActivityTime = DateTime.MinValue;
            }
            else
            {
                Debug.WriteLine("No user is logged in.");
            }

        }

        public static bool IsAdmin()
        {
            return IsLoggedIn && CurrentUser.Role == Core.Enum.Role.Admin;

        }

       
    }
}
