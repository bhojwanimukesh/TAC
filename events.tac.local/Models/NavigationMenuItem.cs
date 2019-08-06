using System.Collections.Generic;

namespace events.tac.local.Models
{
    public class NavigationMenuItem : NavigationItem
    {
        public NavigationMenuItem(string title, string url, IEnumerable<NavigationMenuItem> children) : base (title, url, false)
        {
            Children = children != null ? children : new List<NavigationMenuItem>();
        }

        public IEnumerable<NavigationMenuItem> Children { get; private set; }
    }
}