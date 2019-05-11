using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HIS.Core.Dtos;
using HIS.Core.Entities;
using HIS.Core.Helpers;

namespace HIS.Core.Interfaces
{
    public interface IRepository
    {
        Task<T> GetById<T>(Guid id) where T : Patient;
        Task<PagedList<T>> List<T>(SearchParams searchParam) where T : Patient;
        Task<T> Add<T>(T entity) where T : Patient;
        void Update<T>(T entity) where T : Patient;
        void Delete<T>(T entity) where T : Patient;
    }
}