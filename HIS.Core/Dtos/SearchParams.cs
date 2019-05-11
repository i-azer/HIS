using HIS.Core.Entities;
using HIS.Core.Enums;

namespace HIS.Core.Dtos
{
    public class SearchParams
    {
        private const int MaxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize;}
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value;}
        }

        public string Sex { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Telephone { get; set; }
        public string OrderBy { get; set; }
    }
}