﻿using System.Web;
using System.Web.Mvc;

namespace Chapter5.HandlersAndModules
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
