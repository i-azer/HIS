using System.Collections.Generic;
using HIS.Core.Dtos;
using HIS.Core.Entities;
using HIS.Core.Interfaces;

namespace HIS.Core.Services
{
    public class SearchService : ISearchable
    {
        public List<T> List<T>(SearchParams searchParams) where T : BaseEntity
        {
            throw new System.NotImplementedException();
        }
    }
}