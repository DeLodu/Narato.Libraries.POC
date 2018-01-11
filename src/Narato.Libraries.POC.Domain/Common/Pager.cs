namespace Narato.Libraries.POC.Domain.Common
{
    public class Pager
    {
        public Pager(int page, int pagesize, int records)
        {
            // standard pagesize
            if (pagesize == 0)
                pagesize = 20;

            // set pagenumber
            if (pagesize * page > records)
                page = 0;

            Page = page;
            Pagesize = pagesize;
            Records = records;
        }


        public int Page { get; }

        public int Pagesize { get; }

        public int Records { get;  }
    }
}