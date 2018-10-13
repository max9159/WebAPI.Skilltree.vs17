using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.Skilltree.vs17.Filters;
using WebAPI.Skilltree.vs17.Forrmatters;

namespace WebAPI.Skilltree.vs17
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
            // Web API configuration and services
            config.Filters.Add(new ModelValidationFilterAttribute());

            config.Formatters.Add(new ProductCsvFormatter());
			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
