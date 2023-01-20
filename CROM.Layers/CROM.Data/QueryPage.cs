namespace CROM.Data
{
    using CROM.Data.interfaces;

    using System.Collections.Generic;
    using System.Linq;

    internal class QueryPage<T> : IQueryPage<T>
    {
        public void AddResult(IEnumerable<T> result)
        {
            Rows = result.ToList().AsReadOnly();
        }
        public IReadOnlyCollection<T> Rows { get; private set; }
        public int Total { get; set; }
    }
}
