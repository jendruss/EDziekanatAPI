using System.Collections.Generic;

namespace EDziekanat.Utilities.Collections
{
    public interface IPagedList<T>
    {
        int TotalCount { get; set; }

        IList<T> Items { get; set; }
    }
}