using Anacrusa.Data;
using Anacrusa.Data.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Repository
{
    class SetListRepository : ISetlistRepository
    {
        private readonly SQLiteAsyncConnection _db;

        public SetListRepository(AppDatabase database)
        {
            _db = database.Connection;
        }

        public async Task<int> CreateAsync(string name)
        {
            var entity = new SetListEntity
            {
                Name = name
            };

            await _db.InsertAsync(entity);
            return entity.Id;
        }

        public async Task<List<SetListEntity>> GetAllAsync()
        {
            return await _db.Table<SetListEntity>().ToListAsync();
        }

        public async Task DeleteAsync(int setListId)
        {
            await _db.DeleteAsync<SetListEntity>(setListId);
        }
    }
}
