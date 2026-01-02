using Anacrusa.Data.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Data
{
    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public AppDatabase(string path)
        {
            _db = new SQLiteAsyncConnection(path);
        }

        public async Task InitializeAsync()
        {
            await _db.CreateTableAsync<ScoreEntity>();
            await _db.CreateTableAsync<BookmarkEntity>();
            await _db.CreateTableAsync<SetListEntity>();
            await _db.CreateTableAsync<SetListItemsEntity>();
        }

        public SQLiteAsyncConnection Connection => _db;
    }
}
