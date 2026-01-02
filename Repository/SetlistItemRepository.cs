using Anacrusa.Data.Entities;
using SQLite;
using Anacrusa.Data;

namespace Anacrusa.Repository;

public class SetListItemsRepository : ISetlistItemRepository
{
    private readonly SQLiteAsyncConnection _db;

    public SetListItemsRepository(AppDatabase database)
    {
        _db = database.Connection;
    }

    public async Task AddScoreAsync(int setListId, int scoreId, int order)
    {
        var entity = new SetListItemsEntity
        {
            SetListId = setListId,
            ScoreId = scoreId,
            BookmarkId = null,
            Order = order
        };

        await _db.InsertAsync(entity);
    }

    public async Task AddBookmarkAsync(int setListId, int bookmarkId, int order)
    {
        var entity = new SetListItemsEntity
        {
            SetListId = setListId,
            ScoreId = null,
            BookmarkId = bookmarkId,
            Order = order
        };

        await _db.InsertAsync(entity);
    }

    public async Task<List<SetListItemsEntity>> GetItemsAsync(int setListId)
    {
        return await _db.Table<SetListItemsEntity>()
            .Where(i => i.SetListId == setListId)
            .OrderBy(i => i.Order)
            .ToListAsync();
    }

    public async Task MoveItemAsync(int setListId, int oldOrder, int newOrder)
    {
        var items = await GetItemsAsync(setListId);

        var item = items.First(i => i.Order == oldOrder);
        items.Remove(item);
        items.Insert(newOrder, item);

        for (int i = 0; i < items.Count; i++)
        {
            items[i].Order = i;
            await _db.UpdateAsync(items[i]);
        }
    }

    public async Task DeleteItemAsync(int itemId)
    {
        await _db.DeleteAsync<SetListItemsEntity>(itemId);
    }
}
