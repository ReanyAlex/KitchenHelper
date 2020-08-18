namespace KitchenHelper.API.Data.Entities.ResourceParameters
{
    public class Pagination
    {
        const int maxPageSize = 100;
        public string SearchQuery { get; set; }
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public string OrderBy { get; set; } = "Name";
        public bool SortAsc { get; set; } = true;
    }
}
