using Anacrusa.Data.Entities;
using Anacrusa.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Repository
{
    public interface ISetlistRepository
    {
        Task<int> CreateAsync(string name);
        Task<List<SetListEntity>> GetAllAsync();
        Task DeleteAsync(int setListId);

    }
}
