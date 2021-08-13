namespace Snippet.Data.Filters.FilterModels.Base
{
    public class PaginationModel
    {
        public int Count { get; set; } = int.MaxValue;
        public int Skip { get; set; } = default;
    }
}
