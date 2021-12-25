using System;
using System.Collections.Generic;

namespace SvaSorcery.Patterns.Enterprise.InputOutput.PagingIterator.Types
{
    public abstract class AbstractPagedIterator<T>
    {
        public abstract int GetPageSize();
        public abstract int GetTotalSize();
        public abstract T[] GetPage(int pageNumber);

        public bool UseCache => true;
        public IDictionary<int, T[]> CachedPages { get; set; }
        public T[] CurrentPage { get; set; }
        public int CurrentPageNumber { get; set; }
        public int Index { get; set; } = 0;

        public T Current => GetOffset(Index);
        public int Count => GetTotalSize();
        public bool IsValid => OffsetExists(Index);
        public bool OffsetExists(int offset) => offset >= 0 && offset < Count;
        public void Next() => ++Index;
        public void Rewind() => Index = 0;

        public T GetOffset(int offset)
        {
            if (!OffsetExists(offset))
                throw new ArgumentOutOfRangeException(nameof(offset));

            var page = offset / GetPageSize();

            if (UseCache)
            {
                if (!CachedPages.ContainsKey(page))
                {
                    CachedPages[page] = GetPage(page);
                }
                return CachedPages[page][offset % GetPageSize()];
            }

            if (page != CurrentPageNumber)
            {
                CurrentPageNumber = page;
                CurrentPage = GetPage(page);
            }
            return CurrentPage[offset % GetPageSize()];
        }
    }
}
