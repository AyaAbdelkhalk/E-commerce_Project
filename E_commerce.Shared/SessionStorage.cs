using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace E_commerce.Shared
{
    public class SessionStorage : ISessionStorage
    {
        private readonly string FilePath;

        public SessionStorage()
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "E_commerce");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            FilePath = Path.Combine(dir, "session.json");
        }
        public void SaveLastUserId(int userId)
        {
            try
            {
                var data = new SessionData { LastUserId = userId };
                var json = JsonSerializer.Serialize(data);

                var directory = Path.GetDirectoryName(FilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving session data: {ex.Message}");
            }
        }

        public int GetLastUserId()
        {
            try
            {
                if (!File.Exists(FilePath))
                    return 0;

                var json = File.ReadAllText(FilePath);
                var data = JsonSerializer.Deserialize<SessionData>(json);
                return data?.LastUserId ?? 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reading session data: {ex.Message}");
                return 0;
            }
        }

        public void ClearLastUserId()
        {
            try
            {
                if (File.Exists(FilePath))
                    File.Delete(FilePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting session file: {ex.Message}");
            }
        }

        private class SessionData
        {
            public int LastUserId { get; set; }
        }
    }
}
