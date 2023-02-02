﻿using LX.TestPad.Business.Models;
using System.Threading.Tasks;

namespace LX.TestPad.Business.Interfaces
{
    public interface IResultService
    {
        Task<ResultModel> GetByIdAsync(int id);
        Task<IReadOnlyCollection<ResultModel>> GetAllByTestIdAsync(int testId);
        Task<int> CreateAsync(ResultModel testModel);
        Task UpdateAsync(ResultModel testModel);

        Task DeleteAsync(int id);
        Task DeleteManyAsync(IEnumerable<int> ids);
    }
}
