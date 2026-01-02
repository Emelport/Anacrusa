using Anacrusa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Repository
{
    public interface ISetlistItemRepository
    {
        Task AddScoreAsync(int setlistId, int scoreId,int order);
        Task AddBookmarkAsync(int setlistId, int bookmarkId, int order);

        Task<List<SetListItemsEntity>> GetItemsAsync (int setlistId);

        Task MoveItemAsync(int setListId,int oldOrder, int newOrder);
        Task DeleteItemAsync(int itemId);
    }
}
