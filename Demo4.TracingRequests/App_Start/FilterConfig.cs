﻿using System.Web;
using System.Web.Mvc;

namespace Demo4.TracingRequests
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
