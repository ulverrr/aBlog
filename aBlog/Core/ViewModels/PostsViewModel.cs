using System.Collections.Generic;
using System.Linq;
using aBlog.DataModel.Models;

namespace aBlog.Core.ViewModels
{
    public class PostsViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, FavouritePost> Favorites { get; set; }
    }
}