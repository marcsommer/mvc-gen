using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace @MvcNameSpace@
{
    public class PageConfig
    {
        private static int _pageSize = @PageSize@;

        public static int PageSize
        {
            get { return _pageSize > 0 ? _pageSize : 20; }
            set { _pageSize = value; }
        }

        static PageConfig()
        {

        }
    }
}