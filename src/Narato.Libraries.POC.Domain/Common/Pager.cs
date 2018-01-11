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
        }


        public int page { get; }

        public int pagesize { get; }

        public int records { get;  }
    }
}