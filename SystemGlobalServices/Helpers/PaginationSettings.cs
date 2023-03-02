using System;
namespace SystemGlobalServices.Helpers
{
    public abstract class PaginationSettings
    {
        const int _maxPageSizeValue = 15;

        private int _pageSize = 10;

        public int PageSize { get { return _pageSize; } set { _pageSize =  value > _maxPageSizeValue ? _maxPageSizeValue : value; } }

        public int PageNumber { get; set; } = 1;
    }
}

