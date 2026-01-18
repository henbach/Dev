using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WinnApps.Common.Models;

namespace WinnApps.Common.Services
{
    public class UserPersistentDataService
    {
        private const string FilePath = "settings.json"; 
        public async Task SaveAsync(UserPersistentData settings) 
        { 
            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }); 
            await File.WriteAllTextAsync(FilePath, json); 
        }
        public async Task<UserPersistentData> LoadAsync() 
        { 
            if (!File.Exists(FilePath)) return new UserPersistentData(); 
            var json = await File.ReadAllTextAsync(FilePath); 
            return JsonSerializer.Deserialize<UserPersistentData>(json); 
        }
    }
}
