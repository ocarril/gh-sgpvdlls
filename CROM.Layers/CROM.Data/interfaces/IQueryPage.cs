namespace CROM.Data.interfaces
{
    using System.Collections.Generic;


    public interface IQueryPage<out T>
    {
        IReadOnlyCollection<T> Rows { get; }
        int Total { get; set; }

    }
}
