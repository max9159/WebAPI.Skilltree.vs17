﻿using System.Web;
using System.Web.Mvc;

namespace WebAPI.Skilltree.vs17
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
