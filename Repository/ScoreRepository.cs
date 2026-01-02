using Anacrusa.Data;
using Anacrusa.Data.Entities;
using Anacrusa.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Repository
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public ScoreRepository(AppDatabase database)
        {
            _db = database.Connection;
        }

        public async Task<int> InsertAsync(Score score)
        {
            var entity = new ScoreEntity
            {
                FilePath = score.FilePath,
                FileName = score.FileName,
                Title = score.Title,
                Composer = score.Composer,
                PageCount = score.PageCount,
                LastOpenedPage = score.LastOpenedPage,
                LastOpenedAt = score.LastOpenedAt
            };

            return await _db.InsertAsync(entity);
        }

        public async Task<List<Score>> GetAllAsync()
        {
            var entities = await _db.Table<ScoreEntity>().ToListAsync();

            return entities.Select(e =>
                new Score(
                    e.Id,
                    e.FilePath,
                    e.FileName,
                    e.Title,
                    e.PageCount,
                    e.Composer,
                    e.LastOpenedPage,
                    e.LastOpenedAt
                )
            ).ToList();

        }

    }
}
