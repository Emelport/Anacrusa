using Anacrusa.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anacrusa.Repository
{
    public interface IScoreRepository
    {
        Task<int> InsertAsync(Score score);
        Task<List<Score>> GetAllAsync();
    }
}
