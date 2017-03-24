using System.Linq;
using aBlog.Core.Repositories;
using aBlog.DataModel.Models;

namespace aBlog.Persistence.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Category CheckCategory(string categoryName)
        {
            return _context.Categories.SingleOrDefault(t => t.Name == categoryName)
                ?? new Category() { Name = categoryName };
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }
    }
}
