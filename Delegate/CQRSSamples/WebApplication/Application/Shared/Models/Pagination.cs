using System.Collections.Generic;

namespace WebApplication.Application.Shared.Models
{
    public class Pagination
    {
        public int Total { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public IList<object> Page { get; set; }
    }

    public class Pagination<T>
    {
        public int Total { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public IList<T> Page { get; set; }
    }
}