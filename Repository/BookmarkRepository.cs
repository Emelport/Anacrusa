using Anacrusa.Data.Entities;
using Anacrusa.Models;
using SQLite;
using Anacrusa.Data;

namespace Anacrusa.Repository
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public BookmarkRepository(AppDatabase database)
        {
            _db = database.Connection;
        }

        public async Task<int> InsertAsync(Bookmark bookmark)
        {
            var entity = new BookmarkEntity
            {
                Name = bookmark.Name,
                ScoreId = bookmark.Score.Id, // 👈 aquí está la clave
                StartPage = bookmark.StartPage,
                EndPage = bookmark.EndPage
            };

            await _db.InsertAsync(entity);
            return entity.Id;
        }

        public async Task<List<Bookmark>> GetByScoreAsync(Score score)
        {
            var entities = await _db.Table<BookmarkEntity>()
                .Where(b => b.ScoreId == score.Id)
                .ToListAsync();

            return entities.Select(e =>
                new Bookmark(
                    e.Name,
                    score,
                    e.StartPage,
                    e.EndPage
                )
                {
                    Id = e.Id
                }
            ).ToList();
        }

        public async Task DeleteAsync(int bookmarkId)
        {
            await _db.DeleteAsync<BookmarkEntity>(bookmarkId);
        }
    }
}
