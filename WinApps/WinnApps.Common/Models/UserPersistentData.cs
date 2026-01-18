using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinnApps.Common.Models
{
    public class UserPersistentData
    {
        public List<string> PathFavorites { get; set; } = new();
        public List<string> PathHistory { get; set; } = new();

        public void AddPathHistory(string path)
        {
            var last = PathHistory.LastOrDefault();
            if (last != null && last==path)
            {
                return;
            }
            PathHistory.Add(path);
            PathHistory = PathHistory.TakeLast(10).ToList();
        }

        public void AddToFavorites(string path)
        {
            if(PathFavorites.Contains(path) == false)
            {
                PathFavorites.Add(path);
            }
        }
    }
}
