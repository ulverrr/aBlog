using aBlog.DataModel.Models;

namespace aBlog.Core.Repositories
{
    public interface ICategoryRepository
    {
        Category CheckCategory(string categoryName);
        void Add(Category category);
    }
}