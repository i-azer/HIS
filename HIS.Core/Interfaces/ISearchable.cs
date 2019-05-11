using System.Collections.Generic;
using HIS.Core.Entities;
using HIS.Core.Dtos;

namespace HIS.Core.Interfaces
{
    public interface ISearchable
    {
         List<T> List<T>(SearchParams searchParams) where T : BaseEntity;
    }
}