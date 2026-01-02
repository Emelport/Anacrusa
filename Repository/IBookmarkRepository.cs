using Anacrusa.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Repository
{
    public interface IBookmarkRepository
    {
        Task<int> InsertAsync(Bookmark bookmark);
        Task<List<Bookmark>> GetByScoreAsync(Score score);
        Task DeleteAsync(int bookmarkId);
    }
}
